namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblmanagertenderbid")]
    public partial class Tblmanagertenderbid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tblmanagertenderbid()
        {
            Tblmanagertenderbidimages = new HashSet<Tblmanagertenderbidimage>();
        }

        [Key]
        public int Managertenderbidid { get; set; }

        public int Managertenderid { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }

        public byte? Is_selected { get; set; }

        public int Eventmanagerid { get; set; }

        public DateTime Createddate { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }

        public virtual Tblmanagertender Tblmanagertender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tblmanagertenderbidimage> Tblmanagertenderbidimages { get; set; }
    }
}
