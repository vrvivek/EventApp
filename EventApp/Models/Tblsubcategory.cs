namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblsubcategory")]
    public partial class Tblsubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblsubcategory()
        {
            Tblmanagertenders = new HashSet<Tblmanagertender>();
            Tblpastworks = new HashSet<Tblpastwork>();
            Tblusertenders = new HashSet<Tblusertender>();
        }

        [Key]
        public int Subcategoryid { get; set; }

        [Required]
        [StringLength(50)]
        public string Subcategoryname { get; set; }

        public int Categoryid { get; set; }

        public virtual Tblcategory Tblcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertender> Tblmanagertenders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastwork> Tblpastworks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertender> Tblusertenders { get; set; }
    }
}
