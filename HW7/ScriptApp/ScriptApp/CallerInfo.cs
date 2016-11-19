namespace ScriptApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CallerInfo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
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
