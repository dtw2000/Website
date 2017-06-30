using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class WebsiteDBContext : DbContext
    {
        private IConfigurationRoot _config;
        //public bool _local { get; set; }
        
        public WebsiteDBContext(IConfigurationRoot  config, DbContextOptions options) : base()
        {
            _config = config;
            //_local = true;
        }

        public DbSet<Comment> Comment { get; set; }
         

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DBContextConnection"]);
            //if(_local)
            //    optionsBuilder.UseSqlServer(_config["ConnectionStrings:CommentContextConnectionLocal"]);
            //else
            //    optionsBuilder.UseSqlServer(_config["ConnectionStrings:CommentContextConnectionRemote"]);
        }

        public DbSet<Contact> Contact { get; set; }


    }
}
