using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;
        public BooksController(IDbCRUD dbCrud, IWebHostEnvironment appEnvironment, ILogger<BooksController> logger)
        {
            _appEnvironment = appEnvironment;

            _dbCrud = dbCrud;

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BookModel> GetAllBooks([FromQuery] BookParameters bookParameters)
        {
            /*var books = _dbCrud.GetAllBooks(bookParameters);

            var metadata = new
            {
                books.TotalCount,
                books.PageSize,
                books.CurrentPage,
                books.TotalPages,
                books.HasNext,
                books.HasPrevious
            };
            Response.Headers.Add("X-номер страницы", JsonConvert.SerializeObject(metadata));

            _logger.LogInformation($"Показано {books.TotalCount} книг из базы данных.");*/


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
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync()
        {

            BookModel bookModel = new BookModel();
            IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);

            string path = null;
            string link = @"images\default_book.jpeg";

            string authors = FormFields["Author"] ;

            string genre = FormFields["Genre"];

            string type_of_literature = FormFields["Type_of_literature"];

            if (FormFields.Files.Count > 0)
            {
                string fileName = String.Format(
                                @"{0}." + FormFields.Files[0].FileName.Substring(FormFields.Files[0].FileName.LastIndexOf(".") + 1, FormFields.Files[0].FileName.Length - FormFields.Files[0].FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());
                //путь к папке FormFields
                path = _appEnvironment.WebRootPath + @"\images\books\" + fileName;
                link = "/images/books/" + fileName;
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
            else
            {
                return BadRequest();
            }

            bookModel.ImageLink = link;
            bookModel.ImagePath = path;
            bookModel.Title = FormFields["Title"];

            bookModel.Description = FormFields["Description"];
            bookModel.Edition = FormFields["Edition"];
            bookModel.Publication_date = FormFields["Publication_date"];
            bookModel.Story = FormFields["Story"];
            bookModel.Screenings = FormFields["Screenings"];

            try
            {
                _dbCrud.CreateBook(bookModel, authors.Split(','), genre.Split(','), type_of_literature.Split(','));
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

        //[HttpPost("upload")]
        //public async Task<IActionResult> UploadFile()
        //{
        //    IFormCollection Files = await Request.ReadFormAsync().ConfigureAwait(false);
        //    foreach (var file in Files.Files) //проходимся по всем файлам
        //    {
        //        //уникальное имя файла
        //        string fileName = String.Format(@"{0}." + file.FileName.Substring(file.FileName.LastIndexOf(".") + 1, file.FileName.Length - file.FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());

        //        //путь к папке Files
        //        string path = _appEnvironment.WebRootPath + "/Files/" + fileName;
        //        try
        //        {

        //            using (FileStream fs = new FileStream(path, FileMode.Create))
        //            {
        //                //записываем файл на сервер
        //                await file.CopyToAsync(fs).ConfigureAwait(false);
        //                _logger.LogInformation("UploadFile успешно по пути {0}", path);
        //            }
        //        }
        //        catch (IOException e)
        //        {
        //            _logger.LogError("uploadFile ошибка при записи файла {0}", e.Message);
        //        }

        //        BookModel book = new BookModel { ImagePath = file.FileName, ImageLink = path };
        //        //сохраняем сведения о документе в БД
        //        try
        //        {
        ////            _dbCrud.CreateBook(book);
        //        }
        //        catch (DataException e)
        //        {
        //            _logger.LogError("uploadFile ошибка при сохранении в БД{0}", e.Message);
        //            ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
        //            throw;

        //        }
        //    }
        //    return Ok("ok");
        //}

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile([FromRoute] int id) // получаем книуг по её id
        {
            _logger.LogInformation("DownloadFile {0}", id);
            BookModel book = _dbCrud.GetBook(id);

            if (book == null)
            {
                _logger.LogInformation("DownloadFile {0} не найдена", id);
                return NotFound();
            }

            string path = book.ImageLink;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                string file_type = "application/" + book.ImagePath.Substring(book.ImagePath.LastIndexOf(".") + 1, book.ImagePath.Length - book.ImagePath.LastIndexOf(".") - 1);
                string file_name = book.ImagePath;
                return File(fs, file_type, file_name);
            }
            catch (IOException e)
            {
                _logger.LogError("DownloadFile {0} ошибка при открытии потока: {1}", id, e.Message);
            }
            return BadRequest("Ошибка на сервере!");
        }

    }
}


