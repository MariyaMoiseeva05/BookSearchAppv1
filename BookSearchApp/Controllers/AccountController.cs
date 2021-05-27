using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookSearchApp.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookSearchApp.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager; //аутентифицируют пользователя 
        private readonly SignInManager<User> _signInManager; //и устанавливают или удаляют его cookie
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IWebHostEnvironment appEnvironment, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("api/Account/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*IFormCollection FormFields = await Request.ReadFormAsync().ConfigureAwait(false);
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
                }*/
                User user = new User { Email = model.Email, UserName = model.Login, Login = model.Login, Name = model.Name, Surname = model.Surname, Sex = model.Sex,
                                       Interest = model.Interest, Favorite_books = model.Favorite_books, Country = model.Country, Place = model.Place, Date_of_Birth = model.Date_of_Birth,
                                       ImageLink = model.ImageLink, ImagePath = model.ImagePath
                };
                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user"); // при регистрации нового пользователя устанавливать ему роль "user" по умолчанию
                    // установка куки
                    await _signInManager.SignInAsync(user, false);  // при удачном добалении пользователя устанавливает аутентификационные cookie для добавленного пользователя 
                    var msg = new
                    {
                        message = "Добавлен новый пользователь: " + user.Login
                    };
                    return Ok(msg);
                }
                else // при неудачном добавлении пользователя формируется ответ, содержащий все возникшие ошибки
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен.",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Ok(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные.",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Ok(errorMsg);
            }
        }


        [HttpPost]
        [Route("api/Account/Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model) // принимает на вход данные модели LoginViewModel и проверяет их корректность
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false); // выполняет всю работу по входу пользователя 
                if (result.Succeeded)
                {
                    var msg = new
                    {
                        message = "Выполнен вход пользователем: " + model.Login
                    };
                    return Ok(msg);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен.",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Ok(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен.",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Ok(errorMsg);
            }
        }

        [HttpPost]
        [Route("api/account/logoff")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff() // удаляет установленную cookie и обнуляет сессию пользователя
        {
            // Удаление куки
            await _signInManager.SignOutAsync();
            var msg = new
            {
                message = "Выполнен выход."
            };
            return Ok(msg);
        }

        [HttpPost]
        [Route("api/Account/isAuthenticated")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogisAuthenticatedOff()  // метод проверки текущей сессии пользователя
        {
            User usr = await GetCurrentUserAsync();
            if (usr != null)
            {
                var message = "Вы вошли как: " + usr.UserName;
                var role = await _userManager.GetRolesAsync(usr).ConfigureAwait(false);
                var id = usr.Id;
                var msg = new
                {
                    message,
                    role,
                    id,
                    isAuthenticated = 1
                };
                return Ok(msg);
            }
            else
            {
                var msg = new
                {
                    message = "Вы Гость. Пожалуйста, выполните вход",
                    isAuthenticated = 0
                };
                return Ok(msg);
            }
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
