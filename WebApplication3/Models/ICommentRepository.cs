using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetComments(int maxNum, bool reverse, string filter);
        JsonResult JsonComments(int maxNum, bool reverse, string filter);
        void Add(Comment c);
        
    }
}