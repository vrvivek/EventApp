namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tblmanagertenderbidimage
    {
        [Key]
        public int Managertenderbidimagesid { get; set; }

        public int Managertenderbidid { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageURL { get; set; }

        public virtual Tblmanagertenderbid Tblmanagertenderbid { get; set; }
    }
}
