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

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC0577\\MSSQL2019;Database=donationSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B76D1F55CEE");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.InverseState)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__Cities__StateId__4222D4EF");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Donation__9B556A3883E01BD6");

            entity.ToTable("Donation");

            entity.Property(e => e.Amount).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("userID");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.User).WithMany(p => p.Donations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Donation__userID__52593CB8");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1ADD5C65E1");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserData__CB9A1CFF2B58FB60");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("userId");
            entity.Property(e => e.AddressLine).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FlatNumber).HasMaxLength(50);
            entity.Property(e => e.InitiationDate).HasColumnType("date");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Lastotp)
                .HasMaxLength(20)
                .HasColumnName("lastotp");
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasColumnName("PhotoURL");
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("userPassword");

            entity.HasOne(d => d.City).WithMany(p => p.UserDatumCities)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__UserData__CityId__46E78A0C");

            entity.HasOne(d => d.Role).WithMany(p => p.UserData)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserData__RoleID__44FF419A");

            entity.HasOne(d => d.State).WithMany(p => p.UserDatumStates)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__UserData__StateI__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
