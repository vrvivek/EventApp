namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblcategory")]
    public partial class Tblcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblcategory()
        {
            Tblsubcategories = new HashSet<Tblsubcategory>();
        }

        [Key]
        public int Categoryid { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoryname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblsubcategory> Tblsubcategories { get; set; }
    }
}
