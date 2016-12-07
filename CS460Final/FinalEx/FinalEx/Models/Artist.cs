namespace FinalEx.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        [Required(ErrorMessage ="this field is required")]
        public DateTime BirthDate { get; set; }

       
        [StringLength(100)]
        [Required(ErrorMessage = "this field is required")]
        public string BirthCity { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
    }
}
