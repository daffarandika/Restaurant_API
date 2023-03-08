using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DbRestaurantContext : DbContext
{
    public DbRestaurantContext()
    {
    }

    public DbRestaurantContext(DbContextOptions<DbRestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detailorder> Detailorders { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Headorder> Headorders { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-GHNE639;Initial Catalog=DbRestaurant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detailorder>(entity =>
        {
            entity.HasKey(e => e.Detailid).HasName("PK__Detailor__13674D7599A16DBE");

            entity.ToTable("Detailorder");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Menu).WithMany(p => p.Detailorders)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detailord__MenuI__2F10007B");

            entity.HasOne(d => d.Order).WithMany(p => p.Detailorders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detailord__Order__2E1BDC42");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1016A1C31");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Handphone).HasMaxLength(13);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<Headorder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Headorde__C3905BAF6933D4D4");

            entity.ToTable("Headorder");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.Bank).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Payment).HasMaxLength(13);

            entity.HasOne(d => d.Employee).WithMany(p => p.Headorders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Headorder__Emplo__2A4B4B5E");

            entity.HasOne(d => d.Member).WithMany(p => p.Headorders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Headorder__Membe__2B3F6F97");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B381E1E7B5A");

            entity.ToTable("Member");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Handphone).HasMaxLength(13);
            entity.Property(e => e.Joindate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED25026AD429B");

            entity.ToTable("Menu");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Photo).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
