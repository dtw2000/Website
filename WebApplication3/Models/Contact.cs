using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.ViewModel;

namespace WebApplication3.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Message { get; set; }
        public String Email { get; set; }

        public static explicit operator Contact(ContactViewModel v)
        {
            var result = new Contact();
            if(v.Email != null)
                result.Email = v.Email.Trim();
            if (v.Name != null)
                result.Name = v.Name.Trim();
            if (v.Message != null)
                result.Message = v.Message.Trim();
            return result;
        }
    }
}
