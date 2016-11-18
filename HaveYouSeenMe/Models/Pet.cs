namespace HaveYouSeenMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pet")]
    public partial class Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet()
        {
            PetPhotos = new HashSet<PetPhoto>();
        }

        public int PetID { get; set; }

        [Required]
        [StringLength(100)]
        public string PetName { get; set; }

        [Required]
        [StringLength(100)]
        public string PetAgeYears { get; set; }

        [Required]
        [StringLength(100)]
        public string PetAgeMonth { get; set; }

        public int StatusID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastSeenOn { get; set; }

        [StringLength(50)]
        public string LastSeenWhere { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int UserID { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PetPhoto> PetPhotos { get; set; }
    }
}
