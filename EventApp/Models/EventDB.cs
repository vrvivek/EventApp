namespace EventApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventDB : DbContext
    {
        public EventDB()
            : base("name=EventDB")
        {
        }

        public virtual DbSet<Tbladmin> Tbladmins { get; set; }
        public virtual DbSet<Tblcategory> Tblcategories { get; set; }
        public virtual DbSet<Tblchat> Tblchats { get; set; }
        public virtual DbSet<Tblcity> Tblcities { get; set; }
        public virtual DbSet<Tblclient> Tblclients { get; set; }
        public virtual DbSet<Tbleventmanager> Tbleventmanagers { get; set; }
        public virtual DbSet<Tblmanagertender> Tblmanagertenders { get; set; }
        public virtual DbSet<Tblmanagertenderbid> Tblmanagertenderbids { get; set; }
        public virtual DbSet<Tblmanagertenderbidimage> Tblmanagertenderbidimages { get; set; }
        public virtual DbSet<Tblnotification> Tblnotifications { get; set; }
        public virtual DbSet<Tblpastwork> Tblpastworks { get; set; }
        public virtual DbSet<Tblpastworkimage> Tblpastworkimages { get; set; }
        public virtual DbSet<Tblpastworklike> Tblpastworklikes { get; set; }
        public virtual DbSet<Tblpastworkvideo> Tblpastworkvideos { get; set; }
        public virtual DbSet<Tblreporteventmnager> Tblreporteventmnagers { get; set; }
        public virtual DbSet<Tblreportuser> Tblreportusers { get; set; }
        public virtual DbSet<Tblreview> Tblreviews { get; set; }
        public virtual DbSet<Tblstate> Tblstates { get; set; }
        public virtual DbSet<Tblsubcategory> Tblsubcategories { get; set; }
        public virtual DbSet<Tbluser> Tblusers { get; set; }
        public virtual DbSet<Tblusertender> Tblusertenders { get; set; }
        public virtual DbSet<Tblusertenderbid> Tblusertenderbids { get; set; }
        public virtual DbSet<Tblusertenderbidimage> Tblusertenderbidimages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbladmin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Tbladmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Tbladmin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tbladmin>()
                .Property(e => e.Profilepic)
                .IsUnicode(false);

            modelBuilder.Entity<Tbladmin>()
                .Property(e => e.Contactno)
                .IsUnicode(false);

            modelBuilder.Entity<Tblcategory>()
                .Property(e => e.Categoryname)
                .IsUnicode(false);

            modelBuilder.Entity<Tblcategory>()
                .HasMany(e => e.Tblsubcategories)
                .WithRequired(e => e.Tblcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblchat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Tblcity>()
                .Property(e => e.Cityname)
                .IsUnicode(false);

            modelBuilder.Entity<Tblcity>()
                .HasMany(e => e.Tblmanagertenders)
                .WithRequired(e => e.Tblcity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblcity>()
                .HasMany(e => e.Tblusertenders)
                .WithRequired(e => e.Tblcity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblclient>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Tblclient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tblclient>()
                .HasMany(e => e.Tblpastworklikes)
                .WithRequired(e => e.Tblclient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblclient>()
                .HasMany(e => e.Tblreporteventmnagers)
                .WithRequired(e => e.Tblclient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblclient>()
                .HasMany(e => e.Tblreportusers)
                .WithRequired(e => e.Tblclient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblclient>()
                .HasMany(e => e.Tblreviews)
                .WithRequired(e => e.Tblclient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblclient>()
                .HasMany(e => e.Tblusertenders)
                .WithRequired(e => e.Tblclient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .Property(e => e.Companyname)
                .IsUnicode(false);

            modelBuilder.Entity<Tbleventmanager>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Tbleventmanager>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tbleventmanager>()
                .Property(e => e.About)
                .IsUnicode(false);

            modelBuilder.Entity<Tbleventmanager>()
                .Property(e => e.Coverpic)
                .IsUnicode(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblmanagertenders)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblmanagertenderbids)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblpastworks)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblreporteventmnagers)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblreportusers)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblreviews)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbleventmanager>()
                .HasMany(e => e.Tblusertenderbids)
                .WithRequired(e => e.Tbleventmanager)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblmanagertender>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tblmanagertender>()
                .HasMany(e => e.Tblmanagertenderbids)
                .WithRequired(e => e.Tblmanagertender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblmanagertenderbid>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tblmanagertenderbid>()
                .HasMany(e => e.Tblmanagertenderbidimages)
                .WithRequired(e => e.Tblmanagertenderbid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblmanagertenderbidimage>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<Tblnotification>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Tblpastwork>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tblpastwork>()
                .HasMany(e => e.Tblpastworkimages)
                .WithRequired(e => e.Tblpastwork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblpastwork>()
                .HasMany(e => e.Tblpastworklikes)
                .WithRequired(e => e.Tblpastwork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblpastwork>()
                .HasMany(e => e.Tblpastworkvideos)
                .WithRequired(e => e.Tblpastwork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblpastworkimage>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<Tblpastworkvideo>()
                .Property(e => e.VideoURL)
                .IsUnicode(false);

            modelBuilder.Entity<Tblreporteventmnager>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<Tblreportuser>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<Tblreview>()
                .Property(e => e.Review)
                .IsUnicode(false);

            modelBuilder.Entity<Tblstate>()
                .Property(e => e.Statename)
                .IsUnicode(false);

            modelBuilder.Entity<Tblstate>()
                .HasMany(e => e.Tblcities)
                .WithRequired(e => e.Tblstate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblsubcategory>()
                .Property(e => e.Subcategoryname)
                .IsUnicode(false);

            modelBuilder.Entity<Tblsubcategory>()
                .HasMany(e => e.Tblmanagertenders)
                .WithRequired(e => e.Tblsubcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblsubcategory>()
                .HasMany(e => e.Tblpastworks)
                .WithRequired(e => e.Tblsubcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblsubcategory>()
                .HasMany(e => e.Tblusertenders)
                .WithRequired(e => e.Tblsubcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Tbluser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Tbluser>()
                .Property(e => e.Contactno)
                .IsUnicode(false);

            modelBuilder.Entity<Tbluser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tbluser>()
                .Property(e => e.Profilepic)
                .IsUnicode(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tblchats)
                .WithRequired(e => e.Tbluser)
                .HasForeignKey(e => e.Senderid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tblchats1)
                .WithRequired(e => e.Tbluser1)
                .HasForeignKey(e => e.Receiverid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tblclients)
                .WithRequired(e => e.Tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tbleventmanagers)
                .WithRequired(e => e.Tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tblnotifications)
                .WithRequired(e => e.Tbluser)
                .HasForeignKey(e => e.Fromuserid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbluser>()
                .HasMany(e => e.Tblnotifications1)
                .WithRequired(e => e.Tbluser1)
                .HasForeignKey(e => e.Touserid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblusertender>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tblusertender>()
                .HasMany(e => e.Tblusertenderbids)
                .WithRequired(e => e.Tblusertender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblusertenderbid>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tblusertenderbid>()
                .HasMany(e => e.Tblusertenderbidimages)
                .WithRequired(e => e.Tblusertenderbid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tblusertenderbidimage>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);
        }
    }
}
