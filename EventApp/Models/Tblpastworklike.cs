namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tblpastworklike")]
    public partial class Tblpastworklike
    {
        [Key]
        public int Pastworklikeid { get; set; }

        public int Pastworkid { get; set; }

        public int Clientid { get; set; }

        public DateTime Createddate { get; set; }

        public virtual Tblclient Tblclient { get; set; }

        public virtual Tblpastwork Tblpastwork { get; set; }
    }
}
