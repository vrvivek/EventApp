namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblcity")]
    public partial class Tblcity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblcity()
        {
            Tblmanagertenders = new HashSet<Tblmanagertender>();
            Tblusertenders = new HashSet<Tblusertender>();
        }

        [Key]
        public int Cityid { get; set; }

        [Required]
        [StringLength(50)]
        public string Cityname { get; set; }

        public int Stateid { get; set; }

        public virtual Tblstate Tblstate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertender> Tblmanagertenders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertender> Tblusertenders { get; set; }
    }
}
