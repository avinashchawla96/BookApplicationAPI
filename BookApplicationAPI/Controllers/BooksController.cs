﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApplicationAPI.Business.Interfaces;
using BookApplicationAPI.Models;
using BookApplicationAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApplicationAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BooksController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.bookBL.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = this.bookBL.GetBookByID(id);
            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            this.bookBL.InsertBook(book);
            return Created(Request.Path + "/" + book.ID, book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            this.bookBL.UpdateBook(book, id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.bookBL.DeleteBook(id);
        }
    }
}
