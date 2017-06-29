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
        private MyDBContext _context;

        //public bool _local = false;

        public AppController(IConfigurationRoot config, MyDBContext context)
        {
            _config = config;
            _context = context;
            //_context._local = _local;
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
        public IActionResult ThankYou()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Comments(CommentViewModel model)
        {
            Comment c = (Comment)model;
            var data = _context.Comment.ToList();

            if (c.Name.ToLower() == "delete" && data.Any(x => x.Message == c.Message))
            {
                foreach (Comment e in data)
                {
                    if (e.Message == c.Message)
                    {
                        _context.Comment.Remove(e);
                    }
                }
                _context.SaveChanges();
                return Comments();
            }

            if (data.Any(x => x.Name == c.Name && x.Message == c.Message))
            {
                foreach (Comment e in data)
                {
                    if (e.Name == c.Name && e.Message == c.Message)
                    {
                        _context.Comment.Remove(e);
                    }
                }
                _context.SaveChanges();
            }

            if (c.isPostable())
            {
                _context.Comment.Add(c);
                _context.SaveChanges();
            }

            return Comments();
        }


        public IActionResult Comments()
        {
            var data = _context.Comment.ToList();
            var num = data.Count;
            var maxNum = 10;

            if (num > maxNum)
            {
                data.RemoveAt(0);
                data.RemoveRange(0, num - maxNum - 1);
            }
            data.Reverse();
            
            var vm = new CommentViewModel();
            vm.Comment = data;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            Contact c = (Contact)model;
            _context.Add(c);
            _context.SaveChanges();
            return View("~/Views/App/ThankYou.cshtml");
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
