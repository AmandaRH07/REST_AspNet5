﻿using RestAspNet.Data.Converter.Contrato;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet.Data.Converter.Implementacao
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origem)
        {
            if (origem == null) return null;
                return new Book
                {
                    Id = origem.Id,
                    Author = origem.Author,
                    LaunchDate = origem.LaunchDate,
                    Price = origem.Price,
                    Title = origem.Title
                };
        }

        public BookVO Parse(Book origem)
        {
            if (origem == null) return null;
                return new BookVO
                {
                    Id = origem.Id,

                    Author = origem.Author,
                    LaunchDate = origem.LaunchDate,
                    Price = origem.Price,
                    Title = origem.Title
                };
        }

        public List<Book> Parse(List<BookVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
