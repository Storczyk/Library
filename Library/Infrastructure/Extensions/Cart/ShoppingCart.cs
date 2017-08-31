using Library.DomainModel;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infrastructure.Extensions.Cart
{
    public class ShoppingCart
    {
        private LibraryDbContext dbContext;
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public ShoppingCart()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>();
            options.UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");
            dbContext = new LibraryDbContext(options.Options);
        }
        public ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        public void AddToCart(Book book)
        {
            // Get the matching cart and album instances
            var cartItem = dbContext.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.BookId == book.BookId);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new DomainModel.Cart
                {
                    Book = book,
                    BookId = book.BookId,
                    DateCreated = DateTime.Now,
                    CartId = ShoppingCartId,
                };
                dbContext.Carts.Add(cartItem);
            }

            // Save changes
            dbContext.SaveChanges();
        }

        public void RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = dbContext.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            if (cartItem != null)
            {

                dbContext.Carts.Remove(cartItem);
                // Save changes
                dbContext.SaveChanges();
            }
        }

        public void EmptyCart()
        {
            var cartItems = dbContext.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                dbContext.Carts.Remove(cartItem);
            }
            // Save changes
            dbContext.SaveChanges();
        }

        public List<DomainModel.Cart> GetCartItems()
        {
            var l = dbContext.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
            return l;
        }

        public Guid CreateOrder(Order order)
        {

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Book = item.Book,
                    BookId = item.BookId,
                    Order = order,
                    OrderId = order.OrderId
                };


                dbContext.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count

            // Save the order
            dbContext.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }
        public string GetCartId(HttpContext context)
        {
            if (context.Session.GetString(CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session.SetString(CartSessionKey, tempCartId.ToString());
                }
            }
            return context.Session.GetString(CartSessionKey);
        }
    }
}
