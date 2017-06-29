using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.ViewModel;

namespace WebApplication3.Models
{
    public class Comment 
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Message { get; set; }

        public static explicit operator Comment(CommentViewModel v)
        {
            var result = new Comment();
            if(v.Name != null)
                result.Name = v.Name.Trim();
            if(v.Message != null)
                result.Message = v.Message.Trim();

            return result;
        }

        public bool isPostable()
        {
            var result = true;
            if (Name is null || Message is null)
                result = false;
            return result;
        }
        
        
    }
}
