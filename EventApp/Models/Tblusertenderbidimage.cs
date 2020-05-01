namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tblusertenderbidimage
    {
        [Key]
        public int Usertenderbidimagesid { get; set; }

        public int Usertenderbidid { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageURL { get; set; }

        public virtual Tblusertenderbid Tblusertenderbid { get; set; }
    }
}
