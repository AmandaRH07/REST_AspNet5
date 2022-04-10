using RestAspNet.Model;
using RestAspNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlServerContext _context;

        public BookRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Book.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Book.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return new Book();

            var result = _context.Book.SingleOrDefault(b => b.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book.Id);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Book.SingleOrDefault(b => b.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Book.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Book.Any(b => b.Id.Equals(id));
        }
    }
}
