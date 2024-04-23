using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFromDatabase.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC071A534831");

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07B52208F8");

            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CivilId).HasMaxLength(50);
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Students)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Student__Departm__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
