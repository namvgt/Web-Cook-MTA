namespace Mix_MTA2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CongThuc> CongThucs { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<GioiThieu> GioiThieux { get; set; }
        public virtual DbSet<LoaiCongThuc> LoaiCongThucs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }
        public virtual DbSet<NoiDung_Blog> NoiDung_Blog { get; set; }
        public virtual DbSet<NoiDungCT> NoiDungCTs { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<TraLoi_PhanHoi> TraLoi_PhanHoi { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<View_traloi> View_traloi { get; set; }
        public virtual DbSet<TruyCap> TruyCaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.AnhMinhHoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.NoiDung_Blog)
                .WithOptional(e => e.Blog)
                .HasForeignKey(e => e.ID_blog);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.PhanHois)
                .WithOptional(e => e.Blog)
                .HasForeignKey(e => e.ID_blog);

            modelBuilder.Entity<CongThuc>()
                .Property(e => e.AnhMinhHoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongThuc>()
                .Property(e => e.Video)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongThuc>()
                .HasMany(e => e.NguyenLieux)
                .WithOptional(e => e.CongThuc)
                .HasForeignKey(e => e.MaCongThuc);

            modelBuilder.Entity<CongThuc>()
                .HasMany(e => e.NoiDungCTs)
                .WithOptional(e => e.CongThuc)
                .HasForeignKey(e => e.MaCongThuc);

            modelBuilder.Entity<CongThuc>()
                .HasMany(e => e.PhanHois)
                .WithOptional(e => e.CongThuc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.CapDo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.TraLoi_PhanHoi)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.MaNguoiDung);

            modelBuilder.Entity<NoiDung_Blog>()
                .Property(e => e.AnhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<NoiDungCT>()
                .Property(e => e.AnhMinhHoa)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.AnhMinhHoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Class)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.HinhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.Username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.PassWord)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.PhanHois)
                .WithOptional(e => e.ThanhVien)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ThanhVien>()
                .HasMany(e => e.TraLoi_PhanHoi)
                .WithOptional(e => e.ThanhVien)
                .HasForeignKey(e => e.MaThanhVien);

            modelBuilder.Entity<Review>()
                .Property(e => e.HinhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<View_traloi>()
                .Property(e => e.HinhDaiDien)
                .IsUnicode(false);
        }
    }
}
