﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAspNet.Data.Converter.Value_Object;
using RestAspNet.Hypermedia.Filters;
using RestAspNet.Services.Implementations;

namespace RestAspNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookService.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookService.Create(book));
        }
        
        [HttpPut]
        [TypeFilter(typeof(HypermediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();

            return Ok(_bookService.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
