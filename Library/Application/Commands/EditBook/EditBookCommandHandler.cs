using Library.Application.General;
using Library.DomainModel;
using Library.Infrastructure.Data;
using System;

namespace Library.Application.Commands.EditBook
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand>
    {
        private readonly Repository<Book> repository;
        public EditBookCommandHandler(Repository<Book> repository)
        {
            this.repository = repository;
        }
        public void Handle(EditBookCommand command)
        {
            //repository.Update(new Book
            //{
            //    Id = Guid.Parse(command.Id),
            //    Author=command.Author,
            //    BookTitle=command.BookTitle,
            //    Ean=command.Ean,
            //    Isbn=command.Isbn,
            //    Pages=command.Pages,
            //    Publisher=command.Publisher,
            //    Year=command.Year,
            //});
        }
    }
}
