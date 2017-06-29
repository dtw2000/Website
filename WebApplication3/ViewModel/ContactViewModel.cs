using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.ViewModel
{
   public class ContactViewModel
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength (4000, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please leave a message!")]
        [StringLength(4000, MinimumLength = 5, ErrorMessage = "There's a 5 character minimum!")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Please leave your address!")]
        [EmailAddress(ErrorMessage = "A valid address is required!")]
        public string Email { get; set; }
    }
}
