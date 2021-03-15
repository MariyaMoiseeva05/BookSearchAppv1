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
    public class TypesController : ControllerBase
    {
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;

        public TypesController(IDbCRUD dbCrud, ILogger<TypesController> logger)
        {
            _dbCrud = dbCrud;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Type_of_literatureModel> GetAllType_of_literatures()
        {
            return _dbCrud.GetAllType_of_literatures();
        }

        [HttpGet("{id}")]
        public IActionResult GetType_of_literature([FromRoute] int id)
        {
            var type = _dbCrud.GetType_of_literature(id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }
        public IActionResult CreateType_of_literature([FromBody] Type_of_literatureModel type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Type_of_literatureModel typeModel = new Type_of_literatureModel
            {
                Name_Type = type.Name_Type,
                Book = type.Book
            };
            try
            {
                _dbCrud.CreateType_of_literature(type);
                _logger.LogInformation("Создание проекта id: " + typeModel.Type_of_literatureId + " успешно!");
            }
            catch (DataException e)
            {
                _logger.LogError("Ошибка при записи в бд: " + e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetQuote", new { id = typeModel.Type_of_literatureId }, typeModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateType_of_literature([FromBody] Type_of_literatureModel type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.UpdateType_of_literature(type);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteType_of_literature([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.DeleteType_of_literature(id);
            return NoContent();
        }
    }
}