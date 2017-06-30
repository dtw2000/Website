using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.ViewModel;

namespace WebApplication3.Models
{
    public class CommentRepository : ICommentRepository
    {
        private WebsiteDBContext _context;
        public CommentRepository(WebsiteDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comment.ToList();
        }

        public JsonResult JsonComments(int maxNum, bool reverse, String filter = "")
        {
            JsonResult result = new JsonResult(GetComments(maxNum, reverse, filter));
            return result;
        }

        public IEnumerable<Comment> GetComments(int maxNum, bool reverse, String filter = "")
        {
            var data =  _context.Comment.ToList();
            if (filter != "")
            {
                data = _context.Comment.Where(x => x.Name.ToLower() == filter.ToLower()).ToList();
            }
            else
            {
                data = _context.Comment.ToList();
            }
            var numItems = data.Count;
            
            if ( maxNum != -1 && numItems > maxNum)
            {
                data.RemoveAt(0);
                data.RemoveRange(0, numItems - maxNum - 1);
            }

            if (reverse)
                data.Reverse();
            return data;
        }

        public void Add(Comment c)
        {
            var data = _context.Comment.ToList();

            // hidden delete function
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
                return ;
            }

            if (data.Any(x => x.Name == c.Name && x.Message == c.Message))
            {
                //ignore re-post
                if (data.Last().Name == c.Name && data.Last().Message == c.Message)
                {
                    return;
                }

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

            return;
        }
    }
}
