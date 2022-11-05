using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hentaweb_v2.Models
{
    public partial class hentawebContext : DbContext
    {
        public hentawebContext()
        {
        }

        public hentawebContext(DbContextOptions<hentawebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Episode> Episodes { get; set; } = null!;
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Tesst> Tessts { get; set; } = null!;
        public virtual DbSet<Trailer> Trailers { get; set; } = null!;
        public virtual DbSet<UserSystem> UserSystems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5P237D1\\SQLEXPRESS;Initial Catalog=hentaweb;User ID=sa;Password=1705");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__26E351202EDC264F");

                entity.ToTable("Category");

                entity.HasIndex(e => e.CatId, "Category_Cat_ID");

                entity.Property(e => e.CatId).HasColumnName("Cat_ID");

                entity.Property(e => e.CatName)
                    .HasMaxLength(100)
                    .HasColumnName("Cat_Name");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => new { e.UserUserId, e.FilmFilmId })
                    .HasName("PK__Comment__D7F1560FD74CF8ED");

                entity.ToTable("Comment");

                entity.Property(e => e.UserUserId).HasColumnName("UserUser_ID");

                entity.Property(e => e.FilmFilmId).HasColumnName("FilmFilm_ID");

                entity.Property(e => e.CommentContent)
                    .HasColumnType("ntext")
                    .HasColumnName("Comment_content");

                entity.Property(e => e.CommentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Comment_time");

                entity.HasOne(d => d.FilmFilm)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FilmFilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment360006");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment756075");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.ToTable("Episode");

                entity.HasIndex(e => e.EpisodeId, "Episode_Episode_ID");

                entity.Property(e => e.EpisodeId).HasColumnName("Episode_ID");

                entity.Property(e => e.EpisodeName)
                    .HasMaxLength(255)
                    .HasColumnName("Episode_name");

                entity.Property(e => e.EpisodeTime)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Episode_time");

                entity.Property(e => e.EpisodeUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Episode_url");

                entity.Property(e => e.FilmId).HasColumnName("Film_ID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKEpisode186873");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("Film");

                entity.HasIndex(e => e.FilmId, "Film_Film_ID");

                entity.Property(e => e.FilmId).HasColumnName("Film_ID");

                entity.Property(e => e.FilmArea)
                    .HasMaxLength(255)
                    .HasColumnName("Film_area");

                entity.Property(e => e.FilmCountEp).HasColumnName("Film_countEp");

                entity.Property(e => e.FilmInfo)
                    .HasColumnType("ntext")
                    .HasColumnName("Film_info");

                entity.Property(e => e.FilmName)
                    .HasMaxLength(255)
                    .HasColumnName("Film_name");

                entity.Property(e => e.FilmPoster)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Film_poster");

                entity.Property(e => e.FilmRating).HasColumnName("Film_rating");

                entity.Property(e => e.FilmViewed).HasColumnName("Film_viewed");

                entity.Property(e => e.FilmYear).HasColumnName("Film_year");

                entity.HasMany(d => d.CategoryCats)
                    .WithMany(p => p.FilmFilms)
                    .UsingEntity<Dictionary<string, object>>(
                        "FilmCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryCatId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKFilm_Categ619792"),
                        r => r.HasOne<Film>().WithMany().HasForeignKey("FilmFilmId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKFilm_Categ286864"),
                        j =>
                        {
                            j.HasKey("FilmFilmId", "CategoryCatId").HasName("PK__Film_Cat__E00C6B40E56E2BBD");

                            j.ToTable("Film_Category");

                            j.IndexerProperty<int>("FilmFilmId").HasColumnName("FilmFilm_ID");

                            j.IndexerProperty<int>("CategoryCatId").HasColumnName("CategoryCat_ID");
                        });
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.UserUserId, e.FilmFilmId })
                    .HasName("PK__Rating__D7F1560F90B927D9");

                entity.ToTable("Rating");

                entity.Property(e => e.UserUserId).HasColumnName("UserUser_ID");

                entity.Property(e => e.FilmFilmId).HasColumnName("FilmFilm_ID");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.FilmFilm)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.FilmFilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRating679926");

                entity.HasOne(d => d.UserUser)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRating436155");
            });

            modelBuilder.Entity<Tesst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tesst");

                entity.Property(e => e.Asda32df)
                    .HasColumnType("date")
                    .HasColumnName("asda32df");

                entity.Property(e => e.Asdas)
                    .HasMaxLength(10)
                    .HasColumnName("asdas")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Trailer>(entity =>
            {
                entity.ToTable("Trailer");

                entity.HasIndex(e => e.TrailerId, "Trailer_Trailer_ID");

                entity.Property(e => e.TrailerId).HasColumnName("Trailer_ID");

                entity.Property(e => e.FilmId).HasColumnName("Film_ID");

                entity.Property(e => e.TrailerName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Trailer_name");

                entity.Property(e => e.TrailerUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Trailer_url");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Trailers)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTrailer561528");
            });

            modelBuilder.Entity<UserSystem>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserSyst__206D91906993A17E");

                entity.ToTable("UserSystem");

                entity.HasIndex(e => e.UserId, "UserSystem_User_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Image");

                entity.Property(e => e.UserInfo)
                    .HasColumnType("ntext")
                    .HasColumnName("User_info");

                entity.Property(e => e.UserLevel).HasColumnName("User_level");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
