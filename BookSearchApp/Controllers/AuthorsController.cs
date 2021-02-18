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
    public class AuthorsController : ControllerBase
    {
        private readonly BookSearchContext _context;

        public AuthorsController(BookSearchContext context)// в случае если чит. дневников ещё нет создаётся дневник с Url = "http:\\diary.net" 
        {
            _context = context;
            if (_context.Authors.Count() == 0)
            {
                _context.Authors.Add(new Author { Full_name="Лев Николаевич Толстой" });
                _context.SaveChanges();
            }
        }

        [HttpGet] //  обрабатывает http-запросы GET
        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.Include(a => a.Interesting_fact);
        }

        [HttpGet("{id}")] // обрабатывает запросы GET, но кроме этого, обрабатывает переменную {id}
        public async Task<IActionResult> GetAuthor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = await _context.Authors.SingleOrDefaultAsync(m => m.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost] //  обрабатывает http-запросы POST
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // BadRequest  формирует код состояния HTTP 400, если происходит сбой проверки модели. 
            }

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        [HttpPut("{id}")] // обновление дневника
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Author author)
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
            item.Full_name = author.Full_name;
            _context.Authors.Update(item);
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