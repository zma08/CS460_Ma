namespace ScriptApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogInfoContext : DbContext
    {
        public LogInfoContext()
            : base("name=LogInfoContext")
        {
        }

        public virtual DbSet<CallerInfo> CallerInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
