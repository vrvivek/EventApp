namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblclient")]
    public partial class Tblclient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblclient()
        {
            Tblpastworklikes = new HashSet<Tblpastworklike>();
            Tblreporteventmnagers = new HashSet<Tblreporteventmnager>();
            Tblreportusers = new HashSet<Tblreportuser>();
            Tblreviews = new HashSet<Tblreview>();
            Tblusertenders = new HashSet<Tblusertender>();
        }

        [Key]
        public int Clientid { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public int? Zip { get; set; }

        public byte? Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dateofbirth { get; set; }

        public int Userid { get; set; }

        public virtual Tbluser Tbluser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastworklike> Tblpastworklikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreporteventmnager> Tblreporteventmnagers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreportuser> Tblreportusers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreview> Tblreviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertender> Tblusertenders { get; set; }
    }
}
