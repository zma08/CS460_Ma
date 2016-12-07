namespace FinalEx.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Classification
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public int ArtWorkId { get; set; }

        [Required]
        [StringLength(50)]
        public string ArtWorkName { get; set; }

        [Required]
        [StringLength(50)]
        public string GenreName { get; set; }

        public virtual ArtWork ArtWork { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
