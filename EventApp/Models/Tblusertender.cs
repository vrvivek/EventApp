namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblusertender")]
    public partial class Tblusertender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblusertender()
        {
            Tblusertenderbids = new HashSet<Tblusertenderbid>();
        }

        [Key]
        public int Usertenderid { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }

        public int Clientid { get; set; }

        public byte Status { get; set; }

        public int Cityid { get; set; }

        public int Price { get; set; }

        public int Subcategoryid { get; set; }

        public DateTime Startingdate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Endingdate { get; set; }

        public virtual Tblcity Tblcity { get; set; }

        public virtual Tblclient Tblclient { get; set; }

        public virtual Tblsubcategory Tblsubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertenderbid> Tblusertenderbids { get; set; }
    }
}
