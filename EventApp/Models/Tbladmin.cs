namespace EventApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tbladmin")]
    public partial class Tbladmin
    {
        [Key]
        public int Adminid { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Profilepic { get; set; }

        [StringLength(10)]
        public string Contactno { get; set; }

        public DateTime? Createddate { get; set; } //= DateTime.Now;
    }
}
