using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModel
{
    public class CommentViewModel
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(4000, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please leave a message!")]
        [StringLength(4000, MinimumLength = 5, ErrorMessage = "There's a 5 character minimum!")]
        public string Message { get; set; }

        public IEnumerable<Comment> Comment { get; set; }
    }
}
