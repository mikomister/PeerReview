using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeerReview.Models;
using PeerReview.ViewModels.SubmissionViewModel;

namespace PeerReview.Controllers
{
    [Authorize(Roles="student")]
    public class SubmissionController : Controller
    {
        
        private AppDbContext _db;
        private readonly UserManager<User> _userManager;
        public SubmissionController(AppDbContext context, UserManager<User> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var user = _db.Users.FirstOrDefault( u => u.Id==_userManager.GetUserId(User));
            return View(user.Submissions);
        }
        
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.taskId = id;
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(SubmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Submission submission = new Submission { Code = model.Code, TaskId = model.TaskId, Task = _db.Tasks.FirstOrDefault(x=>x.Id == model.TaskId)};
                _db.Submissions.Add(submission);
                _db.SaveChanges();
                return RedirectToAction("Index", "Submission");
            }
            return View();
        }
    }
}