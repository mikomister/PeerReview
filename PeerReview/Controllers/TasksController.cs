using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeerReview.ViewModels.TasksViewModel;
using PeerReview.Models;
using Microsoft.Extensions.Logging;

namespace PeerReview.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        private AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public TasksController(AppDbContext context, UserManager<User> userManager, ILogger<TasksController> log)
        {
            _db = context;
            _userManager = userManager;
            _logger = log;
        }
        
        public IActionResult Index()
        {
            ViewBag.SolvedTasks = _db.Users.FirstOrDefault( u => u.Id==_userManager.GetUserId(User))?.Submissions?.Select(x=>x.TaskId);
            return View(_db.Tasks.ToList());
        }
        
        [HttpGet]
        public IActionResult Create(string returnUrl = null)
        {
            return View(new CreateViewModel { ReturnUrl = returnUrl });
        }
        
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = new Task { Title = model.Title, Descrition = model.Descrition, ExpirationDate = DateTime.Parse(model.ExpirationDate)};
                _db.Tasks.Add(task);
                _db.SaveChanges();
                return RedirectToAction("Index", "Tasks");
            }
            else
            {
                _logger.LogInformation("Unhandled Exception: {0}, {1}", "TasksController", "Create" );
                return RedirectToAction("Index", "Tasks");
            }

        }
    }
}