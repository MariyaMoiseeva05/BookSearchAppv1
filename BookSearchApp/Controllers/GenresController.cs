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
    public class GenresController : ControllerBase
    {
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;

        public GenresController(IDbCRUD dbCrud, ILogger<GenresController> logger)
        {
            _dbCrud = dbCrud;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GenreModel> GetAllGenres()
        {
            return _dbCrud.GetAllGenres();
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre([FromRoute] int id)
        {
            var genre = _dbCrud.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        public IActionResult CreateGenre([FromBody] GenreModel genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GenreModel genreModel = new GenreModel
            {
                NameGenre = genre.NameGenre,
                Genre_Books = genre.Genre_Books
            };
            try
            {
                _dbCrud.CreateGenre(genre);
                _logger.LogInformation("Создание проекта id: " + genreModel.GenreId + " успешно!");
            }
            catch (DataException e)
            {
                _logger.LogError("Ошибка при записи в бд: " + e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetGenre", new { id = genreModel.GenreId }, genreModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody] GenreModel genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.UpdateGenre(genre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.DeleteGenre(id);
            return NoContent();
        }
    }
}