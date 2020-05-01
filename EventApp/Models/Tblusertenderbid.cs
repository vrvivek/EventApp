namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblusertenderbid")]
    public partial class Tblusertenderbid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblusertenderbid()
        {
            Tblusertenderbidimages = new HashSet<Tblusertenderbidimage>();
        }

        [Key]
        public int Usertenderbidid { get; set; }

        public int Usertenderid { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }

        public byte? Is_selected { get; set; }

        public int Eventmanagerid { get; set; }

        public DateTime Createddate { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }

        public virtual Tblusertender Tblusertender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblusertenderbidimage> Tblusertenderbidimages { get; set; }
    }
}
