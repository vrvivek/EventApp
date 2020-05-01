namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblnotification")]
    public partial class Tblnotification
    {
        [Key]
        public int Notificationid { get; set; }

        [Required]
        [StringLength(250)]
        public string Message { get; set; }

        public byte Status { get; set; }

        public DateTime Createddate { get; set; }

        public int Fromuserid { get; set; }

        public int Touserid { get; set; }

        public virtual Tbluser Tbluser { get; set; }

        public virtual Tbluser Tbluser1 { get; set; }
    }
}
