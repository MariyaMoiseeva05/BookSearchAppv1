using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;

        public QuotesController(IDbCRUD dbCrud, ILogger<QuotesController> logger)
        {
            _dbCrud = dbCrud;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<QuoteModel> GetAllQuotes()
        {
            return _dbCrud.GetAllQuotes();
        }

        [HttpGet("{id}")]
        public IActionResult GetQuote([FromRoute] int id)
        {
            var quote = _dbCrud.GetQuote(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        public IActionResult CreateQuote([FromBody] QuoteModel quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            QuoteModel quoteModel = new QuoteModel
            {
                BookID = quote.BookID,
                UserId = quote.UserId,
                Like = quote.Like,
                Content = quote.Content
            };
            try
            {
                _dbCrud.CreateQuote(quote);
                _logger.LogInformation("Создание проекта id: " + quoteModel.QuoteId + " успешно!");
            }
            catch (DataException e)
            {
                _logger.LogError("Ошибка при записи в бд: " + e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetQuote", new { id = quoteModel.QuoteId }, quoteModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuote([FromBody] QuoteModel quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.UpdateQuote(quote);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.DeleteQuote(id);
            return NoContent();
        }

    }
}
