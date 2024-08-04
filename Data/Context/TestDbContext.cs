using System;
using System.Collections.Generic;
using HumanResource.Data.Entities;
using Microsoft.EntityFrameworkCore;
using HumanResource.Data.Entities;

namespace HumanResource.Data.Context;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.1.2.11;Initial Catalog=TestDb;User=mohamadali;Password=hr2p2cf5KmyZ8UZbLgeezVov6bCfKp;MultipleActiveResultSets=true;PersistSecurityInfo=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("Addresses_pk");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
            entity.Property(e => e.Address1)
                .HasMaxLength(1)
                .HasColumnName("Address");

            entity.HasOne(d => d.CreatePersonModel).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Addresses_Persons_PersonId_fk");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Photo).HasMaxLength(1);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("Phones_pk");

            entity.Property(e => e.PhoneNumber).HasMaxLength(1);

            entity.HasOne(d => d.CreatePersonModel).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Phones_Persons_PersonId_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
