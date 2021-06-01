namespace Kariyerim2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KARIYER : DbContext
    {
        public KARIYER()
            : base("name=KARIYER13")
        {
        }

        public virtual DbSet<departman> departmen { get; set; }
        public virtual DbSet<egitim> egitims { get; set; }
        public virtual DbSet<il> ils { get; set; }
        public virtual DbSet<ilce> ilces { get; set; }
        public virtual DbSet<isi> isis { get; set; }
        public virtual DbSet<isisci> isiscis { get; set; }
        public virtual DbSet<isyeri> isyeris { get; set; }
        public virtual DbSet<mesaj> mesajs { get; set; }
        public virtual DbSet<pozisyon> pozisyons { get; set; }
        public virtual DbSet<sektor> sektors { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departman>()
                .Property(e => e.departman_adi)
                .IsUnicode(false);

            modelBuilder.Entity<departman>()
                .Property(e => e.departman_tanimi)
                .IsUnicode(false);

            modelBuilder.Entity<departman>()
                .HasMany(e => e.isis)
                .WithRequired(e => e.departman)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<egitim>()
                .Property(e => e.egitim_adi)
                .IsUnicode(false);

            modelBuilder.Entity<egitim>()
                .Property(e => e.egitim_tanimi)
                .IsUnicode(false);

            modelBuilder.Entity<egitim>()
                .HasMany(e => e.isis)
                .WithRequired(e => e.egitim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<il>()
                .Property(e => e.il_adi)
                .IsUnicode(false);

            modelBuilder.Entity<il>()
                .HasMany(e => e.ilces)
                .WithRequired(e => e.il)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ilce>()
                .Property(e => e.ilce_adi)
                .IsUnicode(false);

            modelBuilder.Entity<ilce>()
                .HasMany(e => e.isyeris)
                .WithRequired(e => e.ilce)
                .HasForeignKey(e => e.ilce_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<isi>()
                .HasMany(e => e.isiscis)
                .WithRequired(e => e.isi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<isyeri>()
                .Property(e => e.is_yeri_adi)
                .IsUnicode(false);

            modelBuilder.Entity<isyeri>()
                .HasMany(e => e.isis)
                .WithRequired(e => e.isyeri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mesaj>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<mesaj>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<mesaj>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<pozisyon>()
                .Property(e => e.pozisyon_adi)
                .IsUnicode(false);

            modelBuilder.Entity<pozisyon>()
                .HasMany(e => e.isis)
                .WithRequired(e => e.pozisyon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sektor>()
                .Property(e => e.sektor_adi)
                .IsUnicode(false);

            modelBuilder.Entity<sektor>()
                .Property(e => e.sektor_tanimi)
                .IsUnicode(false);

            modelBuilder.Entity<sektor>()
                .HasMany(e => e.isyeris)
                .WithRequired(e => e.sektor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.kadi)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.parola)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.isiscis)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
