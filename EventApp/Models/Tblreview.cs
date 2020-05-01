namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblreview")]
    public partial class Tblreview
    {
        [Key]
        public int Reviewid { get; set; }

        [Required]
        [StringLength(150)]
        public string Review { get; set; }

        public int Clientid { get; set; }

        public DateTime Createddate { get; set; }

        public byte Status { get; set; }

        public int Eventmanagerid { get; set; }

        public int Rating { get; set; }

        public virtual Tblclient Tblclient { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }
    }
}
