namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblpastworkvideo")]
    public partial class Tblpastworkvideo
    {
        [Key]
        public int Pastworkvideoid { get; set; }

        public int Pastworkid { get; set; }

        [Required]
        [StringLength(100)]
        public string VideoURL { get; set; }

        public virtual Tblpastwork Tblpastwork { get; set; }
    }
}
