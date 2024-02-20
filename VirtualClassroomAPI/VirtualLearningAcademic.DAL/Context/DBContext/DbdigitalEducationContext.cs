using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VirtualLearningAcademic.Model;

namespace VirtualLearningAcademic.DAL.Context.DBContext;

public partial class DbdigitalEducationContext : DbContext
{
    public DbdigitalEducationContext()
    {
    }

    public DbdigitalEducationContext(DbContextOptions<DbdigitalEducationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Communication> Communications { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<ForumPost> ForumPosts { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<StudentEnrollment> StudentEnrollments { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E771E9745F5");

            entity.ToTable("Assignment");

            entity.Property(e => e.AssignmentDescription).HasColumnType("text");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Assignmen__Cours__4D94879B");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__Assignmen__UserI__4E88ABD4");
        });

        modelBuilder.Entity<Communication>(entity =>
        {
            entity.HasKey(e => e.CommunicationId).HasName("PK__Communic__53E565EF79FC0F4A");

            entity.ToTable("Communication");

            entity.Property(e => e.MessageCommunicactions).HasColumnType("text");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.Communications)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Communica__Cours__60A75C0F");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.Communications)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__Communica__UserI__619B8048");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7523E8B71");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__Course__UserInfo__44FF419A");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Forum__E210AC6FF17A419E");

            entity.ToTable("Forum");

            entity.Property(e => e.Descriptionforums).HasColumnType("text");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Forums)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Forum__CourseId__571DF1D5");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.Forums)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__Forum__UserInfor__5812160E");
        });

        modelBuilder.Entity<ForumPost>(entity =>
        {
            entity.HasKey(e => e.ForumPostId).HasName("PK__ForumPos__415AEB6C653AA9DB");

            entity.ToTable("ForumPost");

            entity.Property(e => e.PostText).HasColumnType("text");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Forum).WithMany(p => p.ForumPosts)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__ForumPost__Forum__5BE2A6F2");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.ForumPosts)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__ForumPost__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A5728BE03F4");

            entity.ToTable("Grade");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.GradeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK__Grade__Assignmen__534D60F1");

            entity.HasOne(d => d.Course).WithMany(p => p.Grades)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Grade__CourseId__52593CB8");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.Grades)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__Grade__UserInfor__5165187F");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED230A715B2C2");

            entity.ToTable("Menu");

            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MenuUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameMenu)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.MenuIdRol).HasName("PK__MenuRol__967269D391020BE1");

            entity.ToTable("MenuRol");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__MenuRol__MenuId__3C69FB99");

            entity.HasOne(d => d.Rol).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__MenuRol__RolId__3D5E1FD2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F16621B3AC");

            entity.ToTable("Rol");

            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<StudentEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__StudentE__7F68771B00A8CBB8");

            entity.ToTable("StudentEnrollment");

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentEnrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__StudentEn__Cours__49C3F6B7");

            entity.HasOne(d => d.UserInformation).WithMany(p => p.StudentEnrollments)
                .HasForeignKey(d => d.UserInformationId)
                .HasConstraintName("FK__StudentEn__UserI__48CFD27E");
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasKey(e => e.UserInformationId).HasName("PK__UserInfo__85D6D66C2F8EA1EF");

            entity.ToTable("UserInformation");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Rol).WithMany(p => p.UserInformations)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfor__RolId__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}