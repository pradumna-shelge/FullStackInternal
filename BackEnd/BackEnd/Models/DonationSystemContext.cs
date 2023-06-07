using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models;

public partial class DonationSystemContext : DbContext
{
    public DonationSystemContext()
    {
    }

    public DonationSystemContext(DbContextOptions<DonationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PRADUMNA\\SQLEXPRESS;Database=donationSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B76A970B002");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.InverseState)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Cities__StateId__4BAC3F29");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A58E42DF3");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserData__CB9A1CFFADB68A56");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("userId");
            entity.Property(e => e.AddressLine).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FlatNumber).HasMaxLength(50);
            entity.Property(e => e.InitiationDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasColumnName("PhotoURL");
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("userPassword");

            entity.HasOne(d => d.City).WithMany(p => p.UserDatumCities)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__UserData__CityId__59063A47");

            entity.HasOne(d => d.Role).WithMany(p => p.UserData)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserData__RoleID__571DF1D5");

            entity.HasOne(d => d.State).WithMany(p => p.UserDatumStates)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__UserData__StateI__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
