using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThesisMate.Models;

public partial class ThesisMateContext : DbContext
{
    

    public ThesisMateContext(DbContextOptions<ThesisMateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Proposal> Proposals { get; set; }

    public virtual DbSet<ProposalStatus> ProposalStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supervisee> Supervisees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7CHC0AK;Database=ThesisMate;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
        
    );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proposal>(entity =>
        {
            entity.HasKey(e => e.ProposalId)
                .HasName("PK6")
                .IsClustered(false);

            entity.ToTable("Proposal");

            entity.Property(e => e.ProposalFile).HasMaxLength(50);
            entity.Property(e => e.ProposalName).HasMaxLength(50);

            entity.HasOne(d => d.Status).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefProposalStatus6");

            entity.HasOne(d => d.User).WithMany(p => p.Proposals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefUsers16");
        });

        modelBuilder.Entity<ProposalStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId)
                .HasName("PK3")
                .IsClustered(false);

            entity.ToTable("ProposalStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK1")
                .IsClustered(false);

            entity.ToTable("Role");

            entity.Property(e => e.RoleType).HasMaxLength(50);
        });

        modelBuilder.Entity<Supervisee>(entity =>
        {
            entity.HasKey(e => e.SuperviseeId)
                .HasName("PK8")
                .IsClustered(false);

            entity.ToTable("Supervisee");

            entity.HasOne(d => d.Student).WithMany(p => p.SuperviseeStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefUsers17");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.SuperviseeSupervisors)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefUsers18");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK10")
                .IsClustered(false);

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefRole20");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
