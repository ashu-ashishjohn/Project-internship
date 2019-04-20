using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MVCAgenty.Models
{
    public class ResumeContext : DbContext
    {
        public DbSet<MyResume> myResumes { get; set; }
    }
}