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
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(SubmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Submission submission = new Submission { Code = model.Code };
                return RedirectToAction("Index", "Submission");
            }
            return View();
        }
    }
}