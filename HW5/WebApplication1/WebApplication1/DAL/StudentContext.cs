using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    /// <summary>
    /// entity framework also called ORM(Object Relation mapper), 
    /// they will allow us to get access data from the database, and interacting with them
    /// </summary>
    public class StudentContext : DbContext
    {
        /// <summary>
        /// connect to the Students Table also Notice that the name convention *not be singler
        /// </summary>
        public DbSet<Student> Students { get; set; }
        
    }
}