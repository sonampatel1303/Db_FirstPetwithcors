using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Db_FirstPet.Models
{
    public partial class PetPalsContext : DbContext
    {
        public PetPalsContext()
        {
        }

        public PetPalsContext(DbContextOptions<PetPalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdoptionEvent> AdoptionEvents { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<Shelter> Shelters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JR3HKNSE\\SQLEXPRESS;Database=PetPals;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdoptionEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__Adoption__7944C870B3171DE8");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventID");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.DonationId)
                    .ValueGeneratedNever()
                    .HasColumnName("DonationID");

                entity.Property(e => e.DonationAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DonationDate).HasColumnType("date");

                entity.Property(e => e.DonationItem)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DonationType)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DonorName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ShelterId).HasColumnName("ShelterID");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.ShelterId)
                    .HasConstraintName("FK_Donations_Shelters");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.ParticipanntId)
                    .HasName("PK__Particip__D063E98725FE4321");

                entity.Property(e => e.ParticipanntId)
                    .ValueGeneratedNever()
                    .HasColumnName("ParticipanntID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ParticipantName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParticipantType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Participants_AdoptionEvents");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.PetId)
                    .ValueGeneratedNever()
                    .HasColumnName("PetID");

                entity.Property(e => e.Breed)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.ShelterId).HasColumnName("ShelterID");

                entity.Property(e => e.Type)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Pets_Participants");

                entity.HasOne(d => d.Shelter)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.ShelterId)
                    .HasConstraintName("FK_Pets_Shelters");
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.Property(e => e.ShelterId)
                    .ValueGeneratedNever()
                    .HasColumnName("ShelterID");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
