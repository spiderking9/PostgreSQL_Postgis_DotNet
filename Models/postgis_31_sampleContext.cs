using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GeoTronic.Models;

namespace GeoTronic.Models
{
    public partial class postgis_31_sampleContext : DbContext
    {
        public postgis_31_sampleContext()
        {
        }

        public postgis_31_sampleContext(DbContextOptions<postgis_31_sampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addr> Addr { get; set; }
        public virtual DbSet<Addrfeat> Addrfeat { get; set; }
        public virtual DbSet<Bg> Bg { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<CountyLookup> CountyLookup { get; set; }
        public virtual DbSet<CountysubLookup> CountysubLookup { get; set; }
        public virtual DbSet<Cousub> Cousub { get; set; }
        public virtual DbSet<DirectionLookup> DirectionLookup { get; set; }
        public virtual DbSet<Edges> Edges { get; set; }
        public virtual DbSet<Faces> Faces { get; set; }
        public virtual DbSet<Featnames> Featnames { get; set; }
        public virtual DbSet<GeocodeSettings> GeocodeSettings { get; set; }
        public virtual DbSet<GeocodeSettingsDefault> GeocodeSettingsDefault { get; set; }
        public virtual DbSet<Layer> Layer { get; set; }
        public virtual DbSet<LoaderLookuptables> LoaderLookuptables { get; set; }
        public virtual DbSet<LoaderPlatform> LoaderPlatform { get; set; }
        public virtual DbSet<LoaderVariables> LoaderVariables { get; set; }
        public virtual DbSet<PagcGaz> PagcGaz { get; set; }
        public virtual DbSet<PagcLex> PagcLex { get; set; }
        public virtual DbSet<PagcRules> PagcRules { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<PlaceLookup> PlaceLookup { get; set; }
        public virtual DbSet<PointcloudFormats> PointcloudFormats { get; set; }
        public virtual DbSet<SecondaryUnitLookup> SecondaryUnitLookup { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StateLookup> StateLookup { get; set; }
        public virtual DbSet<StreetTypeLookup> StreetTypeLookup { get; set; }
        public virtual DbSet<Tabblock> Tabblock { get; set; }
        public virtual DbSet<Topology> Topology { get; set; }
        public virtual DbSet<Tract> Tract { get; set; }
        public virtual DbSet<Wojewodztwa> Wojewodztwa { get; set; }
        public virtual DbSet<Zcta5> Zcta5 { get; set; }
        public virtual DbSet<ZipLookup> ZipLookup { get; set; }
        public virtual DbSet<ZipLookupBase> ZipLookupBase { get; set; }
        public virtual DbSet<ZipState> ZipState { get; set; }
        public virtual DbSet<ZipStateLoc> ZipStateLoc { get; set; }

        // Unable to generate entity type for table 'tiger.zip_lookup_all'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=Sh!ft3891");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("address_standardizer")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("ogr_fdw")
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("pointcloud")
                .HasPostgresExtension("pointcloud_postgis")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_raster")
                .HasPostgresExtension("postgis_sfcgal")
                .HasPostgresExtension("postgis_tiger_geocoder")
                .HasPostgresExtension("postgis_topology");

            modelBuilder.Entity<Addr>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("addr", "tiger");

                entity.HasIndex(e => e.Zip)
                    .HasName("idx_tiger_addr_zip");

                entity.HasIndex(e => new { e.Tlid, e.Statefp })
                    .HasName("idx_tiger_addr_tlid_statefp");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Arid)
                    .HasColumnName("arid")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.Fromarmid).HasColumnName("fromarmid");

                entity.Property(e => e.Fromhn)
                    .HasColumnName("fromhn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Fromtyp)
                    .HasColumnName("fromtyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Plus4)
                    .HasColumnName("plus4")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Side)
                    .HasColumnName("side")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Toarmid).HasColumnName("toarmid");

                entity.Property(e => e.Tohn)
                    .HasColumnName("tohn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Totyp)
                    .HasColumnName("totyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("character varying(5)");
            });

            modelBuilder.Entity<Addrfeat>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("addrfeat", "tiger");

                entity.HasIndex(e => e.Tlid)
                    .HasName("idx_addrfeat_tlid");

                entity.HasIndex(e => e.Zipl)
                    .HasName("idx_addrfeat_zipl");

                entity.HasIndex(e => e.Zipr)
                    .HasName("idx_addrfeat_zipr");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Aridl)
                    .HasColumnName("aridl")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.Aridr)
                    .HasColumnName("aridr")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.EdgeMtfcc)
                    .HasColumnName("edge_mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Lfromhn)
                    .HasColumnName("lfromhn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lfromtyp)
                    .HasColumnName("lfromtyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Linearid)
                    .HasColumnName("linearid")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.Ltohn)
                    .HasColumnName("ltohn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Ltotyp)
                    .HasColumnName("ltotyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Offsetl)
                    .HasColumnName("offsetl")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Offsetr)
                    .HasColumnName("offsetr")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Parityl)
                    .HasColumnName("parityl")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Parityr)
                    .HasColumnName("parityr")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Plus4l)
                    .HasColumnName("plus4l")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Plus4r)
                    .HasColumnName("plus4r")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Rfromhn)
                    .HasColumnName("rfromhn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Rfromtyp)
                    .HasColumnName("rfromtyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Rtohn)
                    .HasColumnName("rtohn")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Rtotyp)
                    .HasColumnName("rtotyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Statefp)
                    .IsRequired()
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Zipl)
                    .HasColumnName("zipl")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Zipr)
                    .HasColumnName("zipr")
                    .HasColumnType("character varying(5)");
            });

            modelBuilder.Entity<Bg>(entity =>
            {
                entity.ToTable("bg", "tiger");


                entity.Property(e => e.BgId)
                    .HasColumnName("bg_id")
                    .HasColumnType("character varying(12)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Blkgrpce)
                    .HasColumnName("blkgrpce")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasColumnType("character varying(13)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasColumnType("character varying(6)");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(e => e.Cntyidfp);

                entity.ToTable("county", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_county");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_county_gid")
                    .IsUnique();

                entity.Property(e => e.Cntyidfp)
                    .HasColumnName("cntyidfp")
                    .HasColumnType("character varying(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Cbsafp)
                    .HasColumnName("cbsafp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Countyns)
                    .HasColumnName("countyns")
                    .HasColumnType("character varying(8)");

                entity.Property(e => e.Csafp)
                    .HasColumnName("csafp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Metdivfp)
                    .HasColumnName("metdivfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<CountyLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.CoCode });

                entity.ToTable("county_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("county_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<CountysubLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.CoCode, e.CsCode });

                entity.ToTable("countysub_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("countysub_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.CsCode).HasColumnName("cs_code");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<Cousub>(entity =>
            {
                entity.HasKey(e => e.Cosbidfp);

                entity.ToTable("cousub", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_cousub_gid")
                    .IsUnique();

                entity.Property(e => e.Cosbidfp)
                    .HasColumnName("cosbidfp")
                    .HasColumnType("character varying(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland)
                    .HasColumnName("aland")
                    .HasColumnType("numeric(14,0)");

                entity.Property(e => e.Awater)
                    .HasColumnName("awater")
                    .HasColumnType("numeric(14,0)");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Cnectafp)
                    .HasColumnName("cnectafp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Cousubfp)
                    .HasColumnName("cousubfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Cousubns)
                    .HasColumnName("cousubns")
                    .HasColumnType("character varying(8)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Nctadvfp)
                    .HasColumnName("nctadvfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Nectafp)
                    .HasColumnName("nectafp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<DirectionLookup>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("direction_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("direction_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(20)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasColumnType("character varying(3)");
            });

            modelBuilder.Entity<Edges>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("edges", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_edges_countyfp");

                entity.HasIndex(e => e.Tlid)
                    .HasName("idx_edges_tlid");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Artpath)
                    .HasColumnName("artpath")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Deckedroad)
                    .HasColumnName("deckedroad")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Divroad)
                    .HasColumnName("divroad")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Exttyp)
                    .HasColumnName("exttyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Featcat)
                    .HasColumnName("featcat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Gcseflg)
                    .HasColumnName("gcseflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Hydroflg)
                    .HasColumnName("hydroflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Lfromadd)
                    .HasColumnName("lfromadd")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Ltoadd)
                    .HasColumnName("ltoadd")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Offsetl)
                    .HasColumnName("offsetl")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Offsetr)
                    .HasColumnName("offsetr")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Olfflg)
                    .HasColumnName("olfflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Passflg)
                    .HasColumnName("passflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Persist)
                    .HasColumnName("persist")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Railflg)
                    .HasColumnName("railflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Rfromadd)
                    .HasColumnName("rfromadd")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Roadflg)
                    .HasColumnName("roadflg")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Rtoadd)
                    .HasColumnName("rtoadd")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Smid)
                    .HasColumnName("smid")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tfidl)
                    .HasColumnName("tfidl")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tfidr)
                    .HasColumnName("tfidr")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Tnidf)
                    .HasColumnName("tnidf")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tnidt)
                    .HasColumnName("tnidt")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Ttyp)
                    .HasColumnName("ttyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Zipl)
                    .HasColumnName("zipl")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Zipr)
                    .HasColumnName("zipr")
                    .HasColumnType("character varying(5)");
            });

            modelBuilder.Entity<Faces>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("faces", "tiger");

                entity.HasIndex(e => e.Countyfp)
                    .HasName("idx_tiger_faces_countyfp");

                entity.HasIndex(e => e.Tfid)
                    .HasName("idx_tiger_faces_tfid");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Aiannhce)
                    .HasColumnName("aiannhce")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Aiannhce00)
                    .HasColumnName("aiannhce00")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Aiannhfp)
                    .HasColumnName("aiannhfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Aiannhfp00)
                    .HasColumnName("aiannhfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Anrcfp)
                    .HasColumnName("anrcfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Anrcfp00)
                    .HasColumnName("anrcfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Atotal).HasColumnName("atotal");

                entity.Property(e => e.Blkgrpce)
                    .HasColumnName("blkgrpce")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Blkgrpce00)
                    .HasColumnName("blkgrpce00")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Blockce)
                    .HasColumnName("blockce")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Blockce00)
                    .HasColumnName("blockce00")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Cbsafp)
                    .HasColumnName("cbsafp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Cd108fp)
                    .HasColumnName("cd108fp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Cd111fp)
                    .HasColumnName("cd111fp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Cnectafp)
                    .HasColumnName("cnectafp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Comptyp)
                    .HasColumnName("comptyp")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Comptyp00)
                    .HasColumnName("comptyp00")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Conctyfp)
                    .HasColumnName("conctyfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Conctyfp00)
                    .HasColumnName("conctyfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Countyfp00)
                    .HasColumnName("countyfp00")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Cousubfp)
                    .HasColumnName("cousubfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Cousubfp00)
                    .HasColumnName("cousubfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Csafp)
                    .HasColumnName("csafp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Elsdlea)
                    .HasColumnName("elsdlea")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Elsdlea00)
                    .HasColumnName("elsdlea00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lwflag)
                    .HasColumnName("lwflag")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Metdivfp)
                    .HasColumnName("metdivfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Nctadvfp)
                    .HasColumnName("nctadvfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Nectafp)
                    .HasColumnName("nectafp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Offset)
                    .HasColumnName("offset")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Placefp)
                    .HasColumnName("placefp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Placefp00)
                    .HasColumnName("placefp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Puma5ce)
                    .HasColumnName("puma5ce")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Puma5ce00)
                    .HasColumnName("puma5ce00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Scsdlea)
                    .HasColumnName("scsdlea")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Scsdlea00)
                    .HasColumnName("scsdlea00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Sldlst)
                    .HasColumnName("sldlst")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Sldlst00)
                    .HasColumnName("sldlst00")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Sldust)
                    .HasColumnName("sldust")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Sldust00)
                    .HasColumnName("sldust00")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Statefp00)
                    .HasColumnName("statefp00")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Submcdfp)
                    .HasColumnName("submcdfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Submcdfp00)
                    .HasColumnName("submcdfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Tazce)
                    .HasColumnName("tazce")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Tazce00)
                    .HasColumnName("tazce00")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Tblkgpce)
                    .HasColumnName("tblkgpce")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Tfid)
                    .HasColumnName("tfid")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Tractce00)
                    .HasColumnName("tractce00")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Trsubce)
                    .HasColumnName("trsubce")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Trsubce00)
                    .HasColumnName("trsubce00")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Trsubfp)
                    .HasColumnName("trsubfp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Trsubfp00)
                    .HasColumnName("trsubfp00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Ttractce)
                    .HasColumnName("ttractce")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Uace)
                    .HasColumnName("uace")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Uace00)
                    .HasColumnName("uace00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Ugace)
                    .HasColumnName("ugace")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Ugace00)
                    .HasColumnName("ugace00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Unsdlea)
                    .HasColumnName("unsdlea")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Unsdlea00)
                    .HasColumnName("unsdlea00")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Vtdst)
                    .HasColumnName("vtdst")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Vtdst00)
                    .HasColumnName("vtdst00")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Zcta5ce)
                    .HasColumnName("zcta5ce")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Zcta5ce00)
                    .HasColumnName("zcta5ce00")
                    .HasColumnType("character varying(5)");
            });

            modelBuilder.Entity<Featnames>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("featnames", "tiger");

                entity.HasIndex(e => new { e.Tlid, e.Statefp })
                    .HasName("idx_tiger_featnames_tlid_statefp");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Linearid)
                    .HasColumnName("linearid")
                    .HasColumnType("character varying(22)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Paflag)
                    .HasColumnName("paflag")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Predir)
                    .HasColumnName("predir")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Predirabrv)
                    .HasColumnName("predirabrv")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.Prequal)
                    .HasColumnName("prequal")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Prequalabr)
                    .HasColumnName("prequalabr")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.Pretyp)
                    .HasColumnName("pretyp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Pretypabrv)
                    .HasColumnName("pretypabrv")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Sufdir)
                    .HasColumnName("sufdir")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Sufdirabrv)
                    .HasColumnName("sufdirabrv")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.Sufqual)
                    .HasColumnName("sufqual")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Sufqualabr)
                    .HasColumnName("sufqualabr")
                    .HasColumnType("character varying(15)");

                entity.Property(e => e.Suftyp)
                    .HasColumnName("suftyp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Suftypabrv)
                    .HasColumnName("suftypabrv")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.Tlid).HasColumnName("tlid");
            });

            modelBuilder.Entity<GeocodeSettings>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("geocode_settings", "tiger");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Setting).HasColumnName("setting");

                entity.Property(e => e.ShortDesc).HasColumnName("short_desc");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<GeocodeSettingsDefault>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("geocode_settings_default", "tiger");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Setting).HasColumnName("setting");

                entity.Property(e => e.ShortDesc).HasColumnName("short_desc");

                entity.Property(e => e.Unit).HasColumnName("unit");
            });

            modelBuilder.Entity<Layer>(entity =>
            {
                entity.HasKey(e => new { e.TopologyId, e.LayerId });

                entity.ToTable("layer", "topology");

                entity.HasIndex(e => new { e.SchemaName, e.TableName, e.FeatureColumn })
                    .HasName("layer_schema_name_table_name_feature_column_key")
                    .IsUnique();

                entity.Property(e => e.TopologyId).HasColumnName("topology_id");

                entity.Property(e => e.LayerId).HasColumnName("layer_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.FeatureColumn)
                    .IsRequired()
                    .HasColumnName("feature_column")
                    .HasColumnType("character varying");

                entity.Property(e => e.FeatureType).HasColumnName("feature_type");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.SchemaName)
                    .IsRequired()
                    .HasColumnName("schema_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Topology)
                    .WithMany(p => p.Layer)
                    .HasForeignKey(d => d.TopologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("layer_topology_id_fkey");
            });

            modelBuilder.Entity<LoaderLookuptables>(entity =>
            {
                entity.HasKey(e => e.LookupName);

                entity.ToTable("loader_lookuptables", "tiger");

                entity.Property(e => e.LookupName)
                    .HasColumnName("lookup_name")
                    .ValueGeneratedNever();

                entity.Property(e => e.ColumnsExclude)
                    .HasColumnName("columns_exclude");

                entity.Property(e => e.InsertMode)
                    .HasColumnName("insert_mode")
                    .HasDefaultValueSql("'c'::bpchar");

                entity.Property(e => e.LevelCounty).HasColumnName("level_county");

                entity.Property(e => e.LevelNation)
                    .HasColumnName("level_nation");

                entity.Property(e => e.LevelState).HasColumnName("level_state");

                entity.Property(e => e.Load)
                    .IsRequired()
                    .HasColumnName("load")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.PostLoadProcess).HasColumnName("post_load_process");

                entity.Property(e => e.PreLoadProcess).HasColumnName("pre_load_process");

                entity.Property(e => e.ProcessOrder)
                    .HasColumnName("process_order")
                    .HasDefaultValueSql("1000");

                entity.Property(e => e.SingleGeomMode)
                    .HasColumnName("single_geom_mode")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SingleMode)
                    .IsRequired()
                    .HasColumnName("single_mode")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name");

                entity.Property(e => e.WebsiteRootOverride)
                    .HasColumnName("website_root_override");
            });

            modelBuilder.Entity<LoaderPlatform>(entity =>
            {
                entity.HasKey(e => e.Os);

                entity.ToTable("loader_platform", "tiger");

                entity.Property(e => e.Os)
                    .HasColumnName("os")
                    .HasColumnType("character varying(50)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountyProcessCommand).HasColumnName("county_process_command");

                entity.Property(e => e.DeclareSect).HasColumnName("declare_sect");

                entity.Property(e => e.EnvironSetCommand).HasColumnName("environ_set_command");

                entity.Property(e => e.Loader).HasColumnName("loader");

                entity.Property(e => e.PathSep).HasColumnName("path_sep");

                entity.Property(e => e.Pgbin).HasColumnName("pgbin");

                entity.Property(e => e.Psql).HasColumnName("psql");

                entity.Property(e => e.UnzipCommand).HasColumnName("unzip_command");

                entity.Property(e => e.Wget).HasColumnName("wget");
            });

            modelBuilder.Entity<LoaderVariables>(entity =>
            {
                entity.HasKey(e => e.TigerYear);

                entity.ToTable("loader_variables", "tiger");

                entity.Property(e => e.TigerYear)
                    .HasColumnName("tiger_year")
                    .HasColumnType("character varying(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataSchema).HasColumnName("data_schema");

                entity.Property(e => e.StagingFold).HasColumnName("staging_fold");

                entity.Property(e => e.StagingSchema).HasColumnName("staging_schema");

                entity.Property(e => e.WebsiteRoot).HasColumnName("website_root");
            });

            modelBuilder.Entity<PagcGaz>(entity =>
            {
                entity.ToTable("pagc_gaz", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<PagcLex>(entity =>
            {
                entity.ToTable("pagc_lex", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .IsRequired()
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Seq).HasColumnName("seq");

                entity.Property(e => e.Stdword).HasColumnName("stdword");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Word).HasColumnName("word");
            });

            modelBuilder.Entity<PagcRules>(entity =>
            {
                entity.ToTable("pagc_rules", "tiger");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsCustom)
                    .HasColumnName("is_custom")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Rule).HasColumnName("rule");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.Plcidfp);

                entity.ToTable("place", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_place_gid")
                    .IsUnique();

                entity.Property(e => e.Plcidfp)
                    .HasColumnName("plcidfp")
                    .HasColumnType("character varying(7)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Cpi)
                    .HasColumnName("cpi")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Pcicbsa)
                    .HasColumnName("pcicbsa")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Pcinecta)
                    .HasColumnName("pcinecta")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Placefp)
                    .HasColumnName("placefp")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Placens)
                    .HasColumnName("placens")
                    .HasColumnType("character varying(8)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<PlaceLookup>(entity =>
            {
                entity.HasKey(e => new { e.StCode, e.PlCode });

                entity.ToTable("place_lookup", "tiger");

                entity.HasIndex(e => e.State)
                    .HasName("place_lookup_state_idx");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.PlCode).HasColumnName("pl_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<PointcloudFormats>(entity =>
            {
                entity.HasKey(e => e.Pcid);

                entity.ToTable("pointcloud_formats");

                entity.Property(e => e.Pcid)
                    .HasColumnName("pcid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Schema).HasColumnName("schema");

                entity.Property(e => e.Srid).HasColumnName("srid");
            });

            modelBuilder.Entity<SecondaryUnitLookup>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("secondary_unit_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("secondary_unit_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(20)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasColumnType("character varying(5)");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.Statefp);

                entity.ToTable("state", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_state_gid")
                    .IsUnique();

                entity.HasIndex(e => e.Stusps)
                    .HasName("uidx_tiger_state_stusps")
                    .IsUnique();

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Division)
                    .HasColumnName("division")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Lsad)
                    .HasColumnName("lsad")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Statens)
                    .HasColumnName("statens")
                    .HasColumnType("character varying(8)");

                entity.Property(e => e.Stusps)
                    .IsRequired()
                    .HasColumnName("stusps")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<StateLookup>(entity =>
            {
                entity.HasKey(e => e.StCode);

                entity.ToTable("state_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("state_lookup_abbrev_key")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("state_lookup_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.Statefp)
                    .HasName("state_lookup_statefp_key")
                    .IsUnique();

                entity.Property(e => e.StCode)
                    .HasColumnName("st_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(40)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character(2)");
            });

            modelBuilder.Entity<StreetTypeLookup>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("street_type_lookup", "tiger");

                entity.HasIndex(e => e.Abbrev)
                    .HasName("street_type_lookup_abbrev_idx");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(50)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrev)
                    .HasColumnName("abbrev")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.IsHw).HasColumnName("is_hw");
            });

            modelBuilder.Entity<Tabblock>(entity =>
            {
                entity.ToTable("tabblock", "tiger");

                entity.Property(e => e.TabblockId)
                    .HasColumnName("tabblock_id")
                    .HasColumnType("character varying(16)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Blockce)
                    .HasColumnName("blockce")
                    .HasColumnType("character varying(4)");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasColumnType("character varying(6)");

                entity.Property(e => e.Uace)
                    .HasColumnName("uace")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Ur)
                    .HasColumnName("ur")
                    .HasColumnType("character varying(1)");
            });

            modelBuilder.Entity<Topology>(entity =>
            {
                entity.ToTable("topology", "topology");

                entity.HasIndex(e => e.Name)
                    .HasName("topology_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hasz).HasColumnName("hasz");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.Srid).HasColumnName("srid");
            });

            modelBuilder.Entity<Tract>(entity =>
            {
                entity.ToTable("tract", "tiger");

                entity.Property(e => e.TractId)
                    .HasColumnName("tract_id")
                    .HasColumnType("character varying(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Countyfp)
                    .HasColumnName("countyfp")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(7)");

                entity.Property(e => e.Namelsad)
                    .HasColumnName("namelsad")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Tractce)
                    .HasColumnName("tractce")
                    .HasColumnType("character varying(6)");
            });

            modelBuilder.Entity<Wojewodztwa>(entity =>
            {
                entity.HasKey(e => e.Gid);

                entity.ToTable("wojewodztwa");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.IdBufor1).HasColumnName("id_bufor_1");

                entity.Property(e => e.IdBufora).HasColumnName("id_bufora_");

                entity.Property(e => e.IdBufora1).HasColumnName("id_bufora1");

                entity.Property(e => e.IdTechnic).HasColumnName("id_technic");

                entity.Property(e => e.IipIdenty)
                    .HasColumnName("iip_identy")
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.IipPrzest)
                    .HasColumnName("iip_przest")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.IipWersja)
                    .HasColumnName("iip_wersja")
                    .HasColumnType("character varying(32)");

                entity.Property(e => e.JptId).HasColumnName("jpt_id");

                entity.Property(e => e.JptJorId).HasColumnName("jpt_jor_id");

                entity.Property(e => e.JptKjI1)
                    .HasColumnName("jpt_kj_i_1")
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.JptKjI2)
                    .HasColumnName("jpt_kj_i_2")
                    .HasColumnType("character varying(32)");

                entity.Property(e => e.JptKjI3)
                    .HasColumnName("jpt_kj_i_3")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptKjIip)
                    .HasColumnName("jpt_kj_iip")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.JptKod1)
                    .HasColumnName("jpt_kod__1")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptKodJe)
                    .HasColumnName("jpt_kod_je")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.JptNazwa)
                    .HasColumnName("jpt_nazwa_")
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.JptNazwa1)
                    .HasColumnName("jpt_nazwa1")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptOpis)
                    .HasColumnName("jpt_opis")
                    .HasColumnType("character varying(254)");

                entity.Property(e => e.JptOrgan)
                    .HasColumnName("jpt_organ_")
                    .HasColumnType("character varying(254)");

                entity.Property(e => e.JptOrgan1)
                    .HasColumnName("jpt_organ1")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptSjrKo)
                    .HasColumnName("jpt_sjr_ko")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptSpsKo)
                    .HasColumnName("jpt_sps_ko")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.JptWazna)
                    .HasColumnName("jpt_wazna_")
                    .HasColumnType("character varying(3)");

                entity.Property(e => e.ShapeArea).HasColumnName("shape_area");

                entity.Property(e => e.ShapeLeng).HasColumnName("shape_leng");

                entity.Property(e => e.WaznyDo)
                    .HasColumnName("wazny_do")
                    .HasColumnType("date");

                entity.Property(e => e.WaznyOd)
                    .HasColumnName("wazny_od")
                    .HasColumnType("date");

                entity.Property(e => e.WersjaDo)
                    .HasColumnName("wersja_do")
                    .HasColumnType("date");

                entity.Property(e => e.WersjaOd)
                    .HasColumnName("wersja_od")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Zcta5>(entity =>
            {
                entity.HasKey(e => new { e.Zcta5ce, e.Statefp });

                entity.ToTable("zcta5", "tiger");

                entity.HasIndex(e => e.Gid)
                    .HasName("uidx_tiger_zcta5_gid")
                    .IsUnique();

                entity.Property(e => e.Zcta5ce)
                    .HasColumnName("zcta5ce")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Aland).HasColumnName("aland");

                entity.Property(e => e.Awater).HasColumnName("awater");

                entity.Property(e => e.Classfp)
                    .HasColumnName("classfp")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Funcstat)
                    .HasColumnName("funcstat")
                    .HasColumnType("character varying(1)");

                entity.Property(e => e.Gid)
                    .HasColumnName("gid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Intptlat)
                    .HasColumnName("intptlat")
                    .HasColumnType("character varying(11)");

                entity.Property(e => e.Intptlon)
                    .HasColumnName("intptlon")
                    .HasColumnType("character varying(12)");

                entity.Property(e => e.Mtfcc)
                    .HasColumnName("mtfcc")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Partflg)
                    .HasColumnName("partflg")
                    .HasColumnType("character varying(1)");
            });

            modelBuilder.Entity<ZipLookup>(entity =>
            {
                entity.HasKey(e => e.Zip);

                entity.ToTable("zip_lookup", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cnt).HasColumnName("cnt");

                entity.Property(e => e.CoCode).HasColumnName("co_code");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.Cousub)
                    .HasColumnName("cousub")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.CsCode).HasColumnName("cs_code");

                entity.Property(e => e.PlCode).HasColumnName("pl_code");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.StCode).HasColumnName("st_code");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<ZipLookupBase>(entity =>
            {
                entity.HasKey(e => e.Zip);

                entity.ToTable("zip_lookup_base", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("character varying(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasColumnType("character varying(90)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("character varying(40)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<ZipState>(entity =>
            {
                entity.HasKey(e => new { e.Zip, e.Stusps });

                entity.ToTable("zip_state", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Stusps)
                    .HasColumnName("stusps")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });

            modelBuilder.Entity<ZipStateLoc>(entity =>
            {
                entity.HasKey(e => new { e.Zip, e.Stusps, e.Place });

                entity.ToTable("zip_state_loc", "tiger");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("character varying(5)");

                entity.Property(e => e.Stusps)
                    .HasColumnName("stusps")
                    .HasColumnType("character varying(2)");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Statefp)
                    .HasColumnName("statefp")
                    .HasColumnType("character varying(2)");
            });
        }
    }
}
