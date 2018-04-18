namespace SkillsMVC.DataLayer.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class SkillsContext : DbContext
	{
		public SkillsContext()
			: base("name=SkillsContext")
		{
		}

		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Artist>()
				.HasMany(e => e.Movies)
				.WithOptional(e => e.Artist)
				.HasForeignKey(e => e.Director);

			modelBuilder.Entity<Artist>()
				.HasMany(e => e.Movies1)
				.WithMany(e => e.Artists)
				.Map(m => m.ToTable("MovieArtists").MapLeftKey("ArtistId").MapRightKey("MovieId"));

			modelBuilder.Entity<Movie>()
				.Property(e => e.Rating)
				.HasPrecision(20, 18);
		}
	}
}
