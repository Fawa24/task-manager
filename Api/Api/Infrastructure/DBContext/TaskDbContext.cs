using System;
using System.Collections.Generic;
using Api.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.DBContext;

public partial class TaskDbContext : DbContext
{
    public TaskDbContext()
    {
    }

    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskCard> TaskCards { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=TaskManagerDatabase;Username=postgres;Password=00000000");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskCard>(entity =>
        {
            entity.HasKey(e => e.Taskid).HasName("task_cards_pkey");

            entity.ToTable("task_cards");

            entity.Property(e => e.Taskid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("taskid");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Listid).HasColumnName("listid");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Priority)
                .HasMaxLength(4)
                .HasColumnName("priority");

            entity.HasOne(d => d.List).WithMany(p => p.TaskCards)
                .HasForeignKey(d => d.Listid)
                .HasConstraintName("task_cards_listid_fkey");
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.Listid).HasName("task_lists_pkey");

            entity.ToTable("task_lists");

            entity.Property(e => e.Listid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("listid");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
