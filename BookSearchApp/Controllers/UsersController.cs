using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IDbCRUD _dbCrud;
        private readonly ILogger _logger;
        public UsersController(IDbCRUD dbCrud, IWebHostEnvironment appEnvironment, ILogger<BooksController> logger)
        {
            _appEnvironment = appEnvironment;

            _dbCrud = dbCrud;

            _logger = logger;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IEnumerable<UserModel> GetAll()
        {
            _logger.LogInformation("Все пользователи");
            return _dbCrud.GetAllUsers();
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            _logger.LogInformation("GetUser id {0}", id);
            var user = _dbCrud.GetUser(id);

            if (user == null)
            {
                _logger.LogWarning("GetUser id {0} не найдена", id);
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync()
        {
            UserModel userModel = new UserModel();
            IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);

            if (userModel.Login == "admin") 
            {
                ModelState.AddModelError("Login", "К сожалению, данное имя пользователя недопустимо");
            }


            string path = null;
            string link = @"images\default_user.png";

            if (FormFields.Files.Count > 0)
            {
                string fileName = String.Format(
                                @"{0}." + FormFields.Files[0].FileName.Substring(FormFields.Files[0].FileName.LastIndexOf(".") + 1, FormFields.Files[0].FileName.Length - FormFields.Files[0].FileName.LastIndexOf(".") - 1), System.Guid.NewGuid());
                //путь к папке FormFields
                path = _appEnvironment.WebRootPath + @"\images\users\" + fileName;
                link = "/images/users/" + fileName;
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

            userModel.ImageLink = link;
            userModel.ImagePath = path;
            userModel.Login = FormFields["Login"];
            userModel.Name = FormFields["Name"];
            userModel.Surname = FormFields["Surname"];
            userModel.Sex = bool.Parse(FormFields["Sex"]);
            userModel.Favorite_books = FormFields["Favorite_books"];
            userModel.Country = FormFields["Country"];
            userModel.Place = FormFields["Place"];
            userModel.Date_of_Birth = DateTime.Parse(FormFields["Date_of_Birth"]);
            userModel.About_me = FormFields["About_me"];

            try
            {
                _dbCrud.CreateUser(userModel);
            }
            catch (DataException ex)
            {
                _logger.LogWarning("uploadFile ошибка при сохранении в БД{0}", ex.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь к администратору системы для решения проблемы");
                throw;
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction("GetUser", new { id = userModel.UserId }, userModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, UserModel user)
        {
            _logger.LogInformation("User Update {0}", id);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("User Update {0} некорректные данные", id);
                return BadRequest(ModelState);
            }

            try
            {
                _dbCrud.UpdateUser(user);
                //await _context.SaveChangesAsync();
            }
            catch (DataException e)
            {
                _logger.LogError("User Update {0} ошибка при записи в БД: {1}", id, e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь в службу поддержки Книгопоиска для решения проблемы");
                throw;
            }
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _logger.LogInformation("User DeleteUser id {1}", id);


            try
            {
                _dbCrud.DeleteUser(id);
            }
            catch (DataException e)
            {
                _logger.LogError("User DeleteUser id {0} ошибка при записи в БД: {1}", id, e.Message);
                ModelState.AddModelError(string.Empty, "Невозможно применить изменения. Обратитесь кв службу поддержки Книгопоиска для решения проблемы");
                throw;
            }

            return NoContent();
        }

    }
}
