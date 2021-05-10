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
    public class ThinksController : ControllerBase
    {
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;
        public ThinksController(IDbCRUD dbCrud, ILogger<BooksController> logger)
        {
            _logger = logger;
            _dbCrud = dbCrud;
        }

        [HttpGet] //  обрабатывает http-запросы GET
        public IEnumerable<ThinkModel> GetAll()
        {
            return _dbCrud.GetAllThinks();
        }
        [HttpGet("{id}")]
        public IActionResult GetReview([FromRoute] int id)
        {
            var review = _dbCrud.GetReview(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost] //  обрабатывает http-запросы POST
        public IActionResult CreateThink([FromBody] ThinkModel think)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ThinkModel thinkModel = new ThinkModel
            {
                Title = think.Title,
                Content = think.Content,
                Date_of_creation = think.Date_of_creation
            };
            try
            {
                _dbCrud.CreateThink(think);
                _logger.LogInformation("Написание мысли id: " + thinkModel.ThinkId + " успешно!");
            }
            catch (DataException e)
            {
                _logger.LogError("Ошибка при записи в бд: " + e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetThink", new { id = thinkModel.ThinkId }, thinkModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ThinkModel think)
        {
            ThinkModel thinkModel = new ThinkModel();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            think.Title = thinkModel.Title;
            think.Content = thinkModel.Content;
            think.Date_of_creation = thinkModel.Date_of_creation;

            _dbCrud.UpdateThink(think, id);
            return NoContent();
        }

        [HttpDelete("{id}")] // удаление мысли
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ThinkModel thinkModel = new ThinkModel();
            if (thinkModel == null)
            {
                return NotFound();
            }
            _dbCrud.DeleteThink(id);
            return NoContent();
        }
    }
}
