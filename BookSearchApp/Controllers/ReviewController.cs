using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;
        public ReviewController(IDbCRUD dbCrud, ILogger<BooksController> logger)
        {
            _logger = logger;
            _dbCrud = dbCrud;
        }

        [HttpGet] //  обрабатывает http-запросы GET
        public IEnumerable<ReviewModel> GetAll()
        {
            return _dbCrud.GetAllReviews();
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
        public IActionResult CreateReview([FromBody] ReviewModel review)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewModel reviewModel = new ReviewModel
            {
                BookID = review.BookID,
                UserID = review.UserID,
                Title = review.Title,
                Text = review.Text,
                Rating = review.Rating,
                Type = review.Type
            };
            try
            {
                _dbCrud.CreateReview(review);
                _logger.LogInformation("Создание рецензии id: " + reviewModel.RewiewId + " успешно!");
            }
            catch (DataException e)
            {
                _logger.LogError("Ошибка при записи в бд: " + e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetReview", new { id = reviewModel.RewiewId }, reviewModel);

        }
          /*  ReviewModel reviewModel = new ReviewModel();
            IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);
            string comments = FormFields["Comment_Review"];
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest  формирует код состояния HTTP 400, если происходит сбой проверки модели. 
            }
            reviewModel.Title = FormFields["Title"];
            reviewModel.Text = FormFields["Text"];
            if (FormFields["Rating"] != "")
                reviewModel.Rating = int.Parse(FormFields["Rating"]);
            if (FormFields["Type"] != "")
                reviewModel.Type = bool.Parse(FormFields["Type"]);

            try
            {
                _dbCrud.CreateReview(reviewModel, comments.Split(','));
            }
            catch (DataException ex)
            {
                _logger.LogWarning("uploadFile ошибка при сохранении в БД{0}", ex.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetReview", new { id = reviewModel.RewiewId }, reviewModel);
        }*/
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ReviewModel review)
        {
            ReviewModel reviewModel = new ReviewModel();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            review.Title = reviewModel.Title;
            review.Text = reviewModel.Text;
            review.Type = reviewModel.Type;
            review.Rating = reviewModel.Rating;

            _dbCrud.UpdateReview(review, id);
            return NoContent();
        }

        [Authorize(Roles = "admin")] // разграничение прав по ролям 
        [HttpDelete("{id}")] // рецензии
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewModel reviewModel = new ReviewModel();
            if (reviewModel == null)
            {
                return NotFound();
            }
            _dbCrud.DeleteReview(id);
            return NoContent();
        }
    }
}