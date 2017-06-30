using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Api
{
    public class CommentsController : Controller
    {
       
        private IConfigurationRoot _config;
        private WebsiteDBContext _context;
        private ICommentRepository _commentRepo;

        public CommentsController(IConfigurationRoot config, WebsiteDBContext context, ICommentRepository commentRepo)
        {
            _config = config;
            _context = context;
            _commentRepo = commentRepo;
        }

        //private ICommentRepository _repository;

        //public CommentsController(ICommentRepository repository)
        //{
        //    _repository = repository;
        //}

        //public IActionResult ApiComments() //string id)
        //{
        //    return _commentRepo.JsonComments(-1, false, "");
        //}

        [HttpGet("api/comments")]
        public IActionResult Get()
        {
            //return Ok(_repository.GetAllComments());
            return _commentRepo.JsonComments(-1, false, "");
        }

        [HttpGet()]
        public JsonResult ApiComments(string id)
        {
            //return Json(_repository.GetComments( maxNum,  reverse,  filter ));
            return new JsonResult(_commentRepo.GetComments(-1, false, id));
        }
    }
}
 