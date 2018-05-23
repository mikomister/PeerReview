using Microsoft.AspNetCore.Mvc;

namespace PeerReview.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(string JSON)
        {
            return View();
        }

    }
}