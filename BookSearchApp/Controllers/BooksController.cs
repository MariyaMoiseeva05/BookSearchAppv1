using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;
        public BooksController(IDbCRUD dbCrud, IWebHostEnvironment appEnvironment, ILogger <BooksController> logger)
        {
            _appEnvironment = appEnvironment;

            _dbCrud = dbCrud;

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks()
        {
            return _dbCrud.GetAllBooks();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {
            var book = _dbCrud.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync([FromBody] BookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookModel bookModel = new BookModel();
            IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);

            string path = null;
            string link = @"images\fon1.png";

            if (FormFields.Files.Count > 0)
            {
                string fileName = String.Format(
                                @"{0}." + FormFields.Files[0].FileName.Substring(FormFields.Files[0].FileName.LastIndexOf(".") + 1, FormFields.Files[0].FileName.Length - FormFields.Files[0].FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());
                //путь к папке FormFields
                path = _appEnvironment.WebRootPath + @"\images\" + fileName;
                link = @"images\" + fileName;
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        //записываем файл на сервер
                        await FormFields.Files[0].CopyToAsync(fs).ConfigureAwait(false);
                        _logger.LogInformation("UploadFile успешно сохранен по пути {0}", path);
                    }
                }
                catch (IOException e)
                {
                    _logger.LogWarning("uploadFile ошибка при записи файла {0}", e.Message);
                }
            }

            bookModel.ImageLink = link;
            bookModel.ImagePath = path;
            bookModel.Title = FormFields["Title"];
            bookModel.Author = book.Author;
            bookModel.Description = book.Description;
            bookModel.Edition = book.Edition;
            bookModel.Publication_date = book.Publication_date;
            bookModel.Quote = book.Quote;
            bookModel.Review = book.Review;
            bookModel.Type_of_literature = book.Type_of_literature;
            bookModel.Genre_Books = book.Genre_Books;
            bookModel.Story = book.Story;
            bookModel.Screenings = book.Screenings;
            bookModel.Book_Collections = book.Book_Collections;
            bookModel.Book_Characters = book.Book_Characters;
            bookModel.Adverts = book.Adverts;
            bookModel.Featured_Books = book.Featured_Books;

            try
            {
                _dbCrud.CreateBook(book);
            }
            catch (DataException ex)
            {
                _logger.LogWarning("uploadFile ошибка при сохранении в БД{0}", ex.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetBook", new { id = bookModel.BookID }, bookModel);
            
           // return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] BookModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.BookID = id;
            _dbCrud.UpdateBook(book, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCrud.DeleteBook(id);
            return NoContent();
        }

       /* [HttpPost("upload")]
        public async Task<IActionResult> UploadFile()
        {
            IFormCollection Files = await Request.ReadFormAsync().ConfigureAwait(false);
            //foreach (var file in Files.Files) //проходимся по всем файлам
            //{
            //    //уникальное имя файла
            //    string fileName = String.Format(@"{0}." + file.FileName.Substring(file.FileName.LastIndexOf(".") + 1, file.FileName.Length - file.FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());

            //    //путь к папке Files
            //    string path = _appEnvironment.WebRootPath + "/Files/" + fileName;

            //    using (FileStream fs = new FileStream(path, FileMode.Create))
            //    {
            //        //записываем файл на сервер
            //        await file.CopyToAsync(fs).ConfigureAwait(false);
            //    }

            //    BookModel book = new BookModel { FileName = file.FileName, Link = path };
            //    //сохраняем сведения о документе в БД
            //    _context.Books.Add(book);
            //    _context.SaveChanges();
            //}
            return Ok("ok");
        }*/

        /*[HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile([FromRoute] int id) // получаем книуг по её id
        {
            //BookModel book = _dbCrud.GetBook(id);

            //if (book == null)
            //{
            //    return NotFound();
            //}
            //string path = book.Link;
            //FileStream fs = new FileStream(path, FileMode.Open);
            //string file_type = "application/" + book.FileName.Substring(book.FileName.LastIndexOf(".") + 1, book.FileName.Length - book.FileName.LastIndexOf(".") - 1);
            //string file_name = book.FileName;
            //return File(fs, file_type, file_name);
            return null;
        }*/

    }
}


