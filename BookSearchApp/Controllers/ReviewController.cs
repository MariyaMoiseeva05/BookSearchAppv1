using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly BookSearchContext _context;

        public ReviewController(BookSearchContext context)
        {
            _context = context;
           
        }

        [HttpGet] //  обрабатывает http-запросы GET
        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews
                .Include(a => a.Comments)
                .Include(b =>b.Book).ThenInclude(av => av.Authors).ThenInclude(avt => avt.Author)
                .Include(u => u.User);
        }

        [HttpGet("{id}")] // обрабатывает запросы GET, но кроме этого, обрабатывает переменную {id}
        public async Task<IActionResult> GetReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await _context.Reviews.SingleOrDefaultAsync(m => m.RewiewId == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPost] //  обрабатывает http-запросы POST
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest  формирует код состояния HTTP 400, если происходит сбой проверки модели. 
            }

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.RewiewId }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Reviews.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Title = review.Title;
            item.Text = review.Text;
            item.Type = review.Type;
            item.Rating = review.Rating;

            _context.Reviews.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "admin")] // разграничение прав по ролям 
        [HttpDelete("{id}")] // удаление дневника
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Authors.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}