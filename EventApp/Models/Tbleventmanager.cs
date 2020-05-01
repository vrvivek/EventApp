namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tbleventmanager")]
    public partial class Tbleventmanager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbleventmanager()
        {
            Tblmanagertenders = new HashSet<Tblmanagertender>();
            Tblmanagertenderbids = new HashSet<Tblmanagertenderbid>();
            Tblpastworks = new HashSet<Tblpastwork>();
            Tblreporteventmnagers = new HashSet<Tblreporteventmnager>();
            Tblreportusers = new HashSet<Tblreportuser>();
            Tblreviews = new HashSet<Tblreview>();
            Tblusertenderbids = new HashSet<Tblusertenderbid>();
        }

        [Key]
        public int Eventmanagerid { get; set; }

        [StringLength(100)]
        public string Companyname { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int Userid { get; set; }

        [StringLength(100)]
        public string About { get; set; }

        [StringLength(100)]
        public string Coverpic { get; set; }

        public virtual Tbluser Tbluser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertender> Tblmanagertenders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertenderbid> Tblmanagertenderbids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblpastwork> Tblpastworks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreporteventmnager> Tblreporteventmnagers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreportuser> Tblreportusers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblreview> Tblreviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertenderbid> Tblusertenderbids { get; set; }
    }
}
