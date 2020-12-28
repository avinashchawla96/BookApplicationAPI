﻿using BookApplicationAPI.Data.Interfaces;
using BookApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApplicationAPI.Data.Managers
{
    public class BookDA : IBookDA
    {
        private readonly DataContext context;

        public BookDA(DataContext context)
        {
            this.context = context;
        }
        public List<Book> GetBooks()
        {
            return this.context.Books.ToList();
        }
    }
}
