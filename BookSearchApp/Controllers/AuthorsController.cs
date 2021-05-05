using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;

        public AuthorsController(IDbCRUD dbCrud, IWebHostEnvironment appEnvironment, ILogger<BooksController> logger)// в случае если чит. дневников ещё нет создаётся дневник с Url = "http:\\diary.net" 
        {
            _appEnvironment = appEnvironment;

            _dbCrud = dbCrud;

            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            return _dbCrud.GetAllAuthors();
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor([FromRoute] int id)
        {
            var author = _dbCrud.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync()
        {

            AuthorModel authorModel = new AuthorModel();
            IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);

            string path = null;
            string link = @"images\author_default";

            if (FormFields.Files.Count > 0)
            {
                string fileName = String.Format(
                                @"{0}." + FormFields.Files[0].FileName.Substring(FormFields.Files[0].FileName.LastIndexOf(".") + 1, FormFields.Files[0].FileName.Length - FormFields.Files[0].FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());
                //путь к папке FormFields
                path = _appEnvironment.WebRootPath + @"\images\authors\" + fileName;
                link = "/images/authors/" + fileName;
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

            authorModel.ImageLink = link;
            authorModel.ImagePath = path;
            authorModel.Full_name = FormFields["Full_name"];
            authorModel.Pseudonym = FormFields["Pseudonym"];
            authorModel.Date_of_Birth = DateTime.Parse(FormFields["Date_of_Birth"]);

            if (FormFields["Date_of_Death"] != "")
                authorModel.Date_of_Death = DateTime.Parse(FormFields["Date_of_Death"]);
            authorModel.Place_of_Birth = FormFields["Place_of_Birth"];
            authorModel.Place_of_Death = FormFields["Place_of_Death"];
            authorModel.Citizenship = FormFields["Citizenship"];
            authorModel.Occupation = FormFields["Occupation"];
            authorModel.Years_of_creativity = FormFields["Years_of_creativity"];
            authorModel.Language_of_works = FormFields["Language_of_works"];
            authorModel.Debut = FormFields["Debut"];
            authorModel.Awards = FormFields["Awards"];
            authorModel.Prizes = FormFields["Prizes"];
            authorModel.Details = FormFields["Details"];

            try
            {
                _dbCrud.CreateAuthor(authorModel);
            }
            catch (DataException ex)
            {
                _logger.LogWarning("uploadFile ошибка при сохранении в БД{0}", ex.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }
            return CreatedAtAction("GetAuthor", new { id = authorModel.AuthorId }, authorModel);

            // return Ok();
        }


        [HttpPut("{id}")] // обновление дневника
        public IActionResult Update([FromRoute] int id, [FromBody] AuthorModel author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AuthorModel authorModel = new AuthorModel();
            if (authorModel == null)
            {
                return NotFound();
            }
            authorModel.AuthorId = id;

            _dbCrud.UpdateAuthor(authorModel, id);
            return NoContent();
        }

        [Authorize(Roles = "admin")] // разграничение прав по ролям 
        [HttpDelete("{id}")] // удаление дневника
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbCrud.DeleteAuthor(id);
            return NoContent();
        }
    }
}