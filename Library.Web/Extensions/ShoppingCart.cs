using Library.DomainModel;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Library.Web.Extensions;
using System.Text;
using Library.Web.Areas.Default.Models;
using Library.Application.Queries.Books;

namespace Library.Web.Extensions
{
    public class ShoppingCart
    {
        private readonly string Cart = "cart_";
        public void AddToCart(Guid bookId, ISession session)
        {
            session.SetString(Cart + bookId.ToString(), bookId.ToString());
        }
        public void RemoveFromCart(Guid id, ISession session)
        {
            session.Remove(Cart + id.ToString()); 
        }

        public void EmptyCart(ISession session)
        {
            session.Clear();
        }

        public List<string> GetCartItems(ISession session)
        {
            var keys = session.Keys;
            var books = new List<string>();
            foreach(var item in keys)
            {
                if(!item.Contains(Cart))
                {
                    continue;
                }

                books.Add(session.GetString(item));
            }
            return books;
        }

        public void CreateOrder(ISession session)
        {      
            var cartItems = GetCartItems(session);
            EmptyCart(session);
            var orderDetails = new List<OrderDetail>();

            var order = new Order
            {
                OrderDetails = new 
            }
            return order.OrderId;
        }
    }
}
