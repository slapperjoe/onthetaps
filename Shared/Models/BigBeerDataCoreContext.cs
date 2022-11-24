using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using OnTheTaps.Shared.Models.Taps;

namespace OnTheTaps.Shared.Models;

public partial class BigBeerDataCoreContext : DbContext
{
	public BigBeerDataCoreContext()
	{
	}

	public BigBeerDataCoreContext(DbContextOptions<BigBeerDataCoreContext> options)
		 : base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Venue> Venues { get; set; }
	public DbSet<Tap> Taps { get; set; }


	public virtual DbSet<Beer> Beers { get; set; }

	public virtual DbSet<BeerColour> BeerColours { get; set; }

	public virtual DbSet<BeerFamily> BeerFamilies { get; set; }

	public virtual DbSet<BeerStyle> BeerStyles { get; set; }

	public virtual DbSet<BeerType> BeerTypes { get; set; }

	public virtual DbSet<BeerYeast> BeerYeasts { get; set; }

	public virtual DbSet<Brewer> Brewers { get; set; }

	public virtual DbSet<Checkin> Checkins { get; set; }

	public virtual DbSet<Establishment> Establishments { get; set; }

	public virtual DbSet<Location> Locations { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		 => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BigBeerData.Core;Trusted_Connection=True;");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Beer>(entity =>
		{
			entity.HasKey(e => e.Bid);

			entity.HasIndex(e => e.BrewerId, "IX_Beers_BrewerId");

			entity.Property(e => e.Bid).ValueGeneratedNever();
			entity.Property(e => e.Abv).HasColumnName("ABV");
			entity.Property(e => e.BaseStyle).HasComputedColumnSql("(case when charindex(' - ',[Style])=(0) then [Style] else rtrim(left([Style],charindex(' - ',[Style]))) end)", false);
			entity.Property(e => e.Slug).HasColumnName("SLUG");

			entity.HasOne(d => d.Brewer).WithMany(p => p.Beers).HasForeignKey(d => d.BrewerId);
		});

		modelBuilder.Entity<BeerColour>(entity =>
		{
			entity.ToTable("BeerColour");

			entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
		});

		modelBuilder.Entity<BeerFamily>(entity =>
		{
			entity.ToTable("BeerFamily");

			entity.HasIndex(e => e.BeerTypeId, "IX_BeerFamily_BeerTypeID");

			entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
			entity.Property(e => e.BeerTypeId).HasColumnName("BeerTypeID");

			entity.HasOne(d => d.BeerType).WithMany(p => p.BeerFamilies).HasForeignKey(d => d.BeerTypeId);
		});

		modelBuilder.Entity<BeerStyle>(entity =>
		{
			entity.ToTable("BeerStyle");

			entity.HasIndex(e => e.FamilyId, "IX_BeerStyle_FamilyID");

			entity.HasIndex(e => e.SrmhighId, "IX_BeerStyle_SRMHighID");

			entity.HasIndex(e => e.SrmlowId, "IX_BeerStyle_SRMLowID");

			entity.HasIndex(e => e.TypeId, "IX_BeerStyle_TypeID");

			entity.HasIndex(e => e.YeastId, "IX_BeerStyle_YeastID");

			entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
			entity.Property(e => e.Abvhigh).HasColumnName("ABVHigh");
			entity.Property(e => e.Abvlow).HasColumnName("ABVLow");
			entity.Property(e => e.FamilyId).HasColumnName("FamilyID");
			entity.Property(e => e.Ibuhigh).HasColumnName("IBUHigh");
			entity.Property(e => e.Ibulow).HasColumnName("IBULow");
			entity.Property(e => e.SrmhighId).HasColumnName("SRMHighID");
			entity.Property(e => e.SrmlowId).HasColumnName("SRMLowID");
			entity.Property(e => e.TypeId).HasColumnName("TypeID");
			entity.Property(e => e.YeastId).HasColumnName("YeastID");

			entity.HasOne(d => d.Family).WithMany(p => p.BeerStyles).HasForeignKey(d => d.FamilyId);

			entity.HasOne(d => d.Srmhigh).WithMany(p => p.BeerStyleSrmhighs)
					.HasForeignKey(d => d.SrmhighId)
					.OnDelete(DeleteBehavior.ClientSetNull);

			entity.HasOne(d => d.Srmlow).WithMany(p => p.BeerStyleSrmlows)
					.HasForeignKey(d => d.SrmlowId)
					.OnDelete(DeleteBehavior.ClientSetNull);

			entity.HasOne(d => d.Type).WithMany(p => p.BeerStyles)
					.HasForeignKey(d => d.TypeId)
					.OnDelete(DeleteBehavior.ClientSetNull);

			entity.HasOne(d => d.Yeast).WithMany(p => p.BeerStyles).HasForeignKey(d => d.YeastId);
		});

		modelBuilder.Entity<BeerType>(entity =>
		{
			entity.ToTable("BeerType");

			entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
		});

		modelBuilder.Entity<BeerYeast>(entity =>
		{
			entity.ToTable("BeerYeast");

			entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");
		});

		modelBuilder.Entity<Brewer>(entity =>
		{
			entity.Property(e => e.BrewerId).ValueGeneratedNever();
			entity.Property(e => e.Slug).HasColumnName("SLUG");
			entity.Property(e => e.Url).HasColumnName("URL");
		});

		modelBuilder.Entity<Checkin>(entity =>
		{
			entity.HasIndex(e => e.Bid, "IX_Checkins_Bid");

			entity.HasIndex(e => e.EstablishmentId, "IX_Checkins_EstablishmentId");

			entity.HasOne(d => d.BidNavigation).WithMany(p => p.Checkins).HasForeignKey(d => d.Bid);

			entity.HasOne(d => d.Establishment).WithMany(p => p.Checkins).HasForeignKey(d => d.EstablishmentId);
		});

		modelBuilder.Entity<Establishment>(entity =>
		{
			entity.HasIndex(e => e.LocationId, "IX_Establishments_LocationId");

			entity.Property(e => e.EstablishmentId).ValueGeneratedNever();

			entity.HasOne(d => d.Location).WithMany(p => p.Establishments).HasForeignKey(d => d.LocationId);
		});

		modelBuilder.Entity<Location>(entity =>
		{
			entity.Property(e => e.LocationId).ValueGeneratedNever();
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
