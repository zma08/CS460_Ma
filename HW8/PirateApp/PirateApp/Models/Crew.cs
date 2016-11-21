namespace PirateApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   
    public partial class Crew
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShipId { get; set; }
        [Required]
        public int PirateId { get; set; }
        [Required]
        public decimal Booty { get; set; }
  
        public virtual Pirate Pirate { get; set; }

        public virtual Ship Ship { get; set; }
    }
}
