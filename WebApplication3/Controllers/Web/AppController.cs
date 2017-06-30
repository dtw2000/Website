using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers.Web
{
    public class AppController : Controller
    {
        private IConfigurationRoot _config;
        private WebsiteDBContext _context;
        private ICommentRepository _commentRepo;
        
        public AppController(IConfigurationRoot config, WebsiteDBContext context, ICommentRepository commentRepo)
        {
            _config = config;
            _context = context;
            _commentRepo = commentRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }
        public IActionResult Hobbies()
        {
            return View();
        }
        public IActionResult Thanks()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Comments(CommentViewModel model)
        {
            Comment c = (Comment) model;
            _commentRepo.Add(c);
            //return Comments();
            return RedirectToAction("Comments", "App");
        }
        public IActionResult Comments()
        {
            var vm = new CommentViewModel();
            vm.Comment = _commentRepo.GetComments(6, true,"") ;
            return View(vm);
        }


        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            Contact c = (Contact)model;
            _context.Add(c);
            _context.SaveChanges();
            return View("~/Views/App/Thanks.cshtml");
        }
        public IActionResult Contact()
        {
            return View();
        }

        public ActionResult Redirect()
        {
            return RedirectToAction("Index", "App");
        }
    }
}
