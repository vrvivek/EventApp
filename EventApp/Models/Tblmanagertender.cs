namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblmanagertender")]
    public partial class Tblmanagertender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblmanagertender()
        {
            Tblmanagertenderbids = new HashSet<Tblmanagertenderbid>();
        }

        [Key]
        public int Managertenderid { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public byte Status { get; set; }

        public int Cityid { get; set; }

        public int Price { get; set; }

        public int Eventmanagerid { get; set; }

        public int Subcategoryid { get; set; }

        public DateTime Startingdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Endingdate { get; set; }

        public virtual Tblcity Tblcity { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }

        public virtual Tblsubcategory Tblsubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertenderbid> Tblmanagertenderbids { get; set; }
    }
}
