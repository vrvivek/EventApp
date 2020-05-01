namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblchat")]
    public partial class Tblchat
    {
        [Key]
        public int Chatid { get; set; }

        [Required]
        [StringLength(100)]
        public string Message { get; set; }

        public int Senderid { get; set; }

        public int Receiverid { get; set; }

        public byte Status { get; set; }

        public DateTime Createddate { get; set; }

        public virtual Tbluser Tbluser { get; set; }

        public virtual Tbluser Tbluser1 { get; set; }
    }
}
