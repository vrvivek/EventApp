namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblpastwork")]
    public partial class Tblpastwork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblpastwork()
        {
            Tblpastworkimages = new HashSet<Tblpastworkimage>();
            Tblpastworklikes = new HashSet<Tblpastworklike>();
            Tblpastworkvideos = new HashSet<Tblpastworkvideo>();
        }

        [Key]
        public int Pastworkid { get; set; }

        public int Eventmanagerid { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime Createddate { get; set; }

        public byte Status { get; set; }

        public int Subcategoryid { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }

        public virtual Tblsubcategory Tblsubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastworkimage> Tblpastworkimages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastworklike> Tblpastworklikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastworkvideo> Tblpastworkvideos { get; set; }
    }
}
