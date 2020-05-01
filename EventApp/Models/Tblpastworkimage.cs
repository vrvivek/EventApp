namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblpastworkimage")]
    public partial class Tblpastworkimage
    {
        [Key]
        public int Pastworkimageid { get; set; }

        public int Pastworkid { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageURL { get; set; }

        public virtual Tblpastwork Tblpastwork { get; set; }
    }
}
