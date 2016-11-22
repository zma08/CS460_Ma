using System;
using System.ComponentModel.DataAnnotations;

namespace PiratesWeb
{
    using CustomDataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pirate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pirate()
        {
            Crews = new HashSet<Crew>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [CurrentDate(ErrorMessage="Date needs to be before or eaqual to current date")]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}
namespace CustomDataAnnotations
{
    public class CurrentDateAttribute:ValidationAttribute
    {
        public CurrentDateAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            return (date <= System.DateTime.Now) ? true : false;
        }
    }
}