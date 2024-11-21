using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCenter.MVC.Contracts;
using ShopCenter.MVC.Models;
using ShopCenter.MVC.Services.Base;

namespace ShopCenter.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(CreateUserVM command)
        {
            try
            {
                var response = await _userService.CreateUser(command);
                if (response.Success) 
                {
                return RedirectToAction("Index");
                }
                ModelState.AddModelError("",response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(command);

        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user =await _userService.GetUser(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
