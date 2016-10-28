using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
    }
}