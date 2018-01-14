using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingApp.API.Models
{
    public partial class CURSOPHPContext : DbContext
    {
        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<Followers> Followers { get; set; }
        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<PasswordResets> PasswordResets { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=CARLOS;Database=CURSOPHP;PWD=sa;user id=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.ToTable("BLOG_POST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contenido)
                    .HasColumnName("CONTENIDO")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .HasColumnName("TITULO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Followers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowedId });

                entity.ToTable("followers");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.FollowedId).HasColumnName("followed_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Followed)
                    .WithMany(p => p.FollowersFollowed)
                    .HasForeignKey(d => d.FollowedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("followers_followed_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowersUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("followers_user_id_foreign");
            });

            modelBuilder.Entity<Mensajes>(entity =>
            {
                entity.ToTable("mensajes");

                entity.HasIndex(e => e.CreatedAt)
                    .HasName("indx_mensajes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasMaxLength(255);

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("mensaje")
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Mensajes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mensajes_user_id_foreign");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PasswordResets>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email)
                    .HasName("password_resets_email_index");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("users_username_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("CONTRASENA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("UPDATED_AT")
                    .HasColumnType("datetime");
            });
        }
    }
}
