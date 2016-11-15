namespace ScriptApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using ScriptApp.Models;
    public partial class CallerInfo
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        [Required]
        [StringLength(100)]
        public string CallerIp { get; set; }

        [Required]
        [StringLength(200)]
        public string CallerAgent { get; set; }

        [Required]
        [StringLength(200)]
        public string CallerRequestString { get; set; }
    }
}
