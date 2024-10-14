using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF.Models;

public partial class RamandContext : DbContext
{
    public RamandContext()
    {
    }

    public RamandContext(DbContextOptions<RamandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G79AH4U;Initial Catalog=Ramand;Persist Security Info=True;User ID=sa;Password=Kiau@123%J;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07F8D5C758");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserName, "UQ__User__C9F28456891B1220").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
