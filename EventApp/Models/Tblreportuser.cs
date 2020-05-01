namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblreportuser")]
    public partial class Tblreportuser
    {
        [Key]
        public int Reportuserid { get; set; }

        [Required]
        [StringLength(150)]
        public string Reason { get; set; }

        public DateTime Createddate { get; set; }

        public int Eventmanagerid { get; set; }

        public int Clientid { get; set; }

        public byte Status { get; set; }

        public virtual Tblclient Tblclient { get; set; }

        public virtual Tbleventmanager Tbleventmanager { get; set; }
    }
}
