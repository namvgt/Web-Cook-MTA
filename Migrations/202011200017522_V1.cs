namespace Mix_MTA2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        MaBlog = c.Long(nullable: false, identity: true),
                        TieuDe = c.String(),
                        TenBlog = c.String(),
                        AnhMinhHoa = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        MaNguoiTao = c.Int(),
                        NgayTao = c.DateTime(storeType: "date"),
                        MaNguoiChinhSua = c.Int(),
                        NgayChinhSua = c.DateTime(storeType: "date"),
                        TopHot = c.Boolean(),
                        TrangThai = c.Boolean(),
                        LuotXem = c.Long(nullable: false),
                        Video = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.MaBlog);
            
            CreateTable(
                "dbo.NoiDung_Blog",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ID_blog = c.Long(),
                        TieuDe = c.String(),
                        NoiDung = c.String(),
                        AnhMinhHoa = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blog", t => t.ID_blog)
                .Index(t => t.ID_blog);
            
            CreateTable(
                "dbo.PhanHoi",
                c => new
                    {
                        MaPhanHoi = c.Long(nullable: false, identity: true),
                        TieuDe = c.String(),
                        NoiDung = c.String(),
                        NgayDang = c.DateTime(),
                        ID_user = c.Long(),
                        ID_congthuc = c.Long(),
                        ID_blog = c.Long(),
                    })
                .PrimaryKey(t => t.MaPhanHoi)
                .ForeignKey("dbo.CongThuc", t => t.ID_congthuc, cascadeDelete: true)
                .ForeignKey("dbo.ThanhVien", t => t.ID_user, cascadeDelete: true)
                .ForeignKey("dbo.Blog", t => t.ID_blog)
                .Index(t => t.ID_user)
                .Index(t => t.ID_congthuc)
                .Index(t => t.ID_blog);
            
            CreateTable(
                "dbo.CongThuc",
                c => new
                    {
                        ID_congthuc = c.Long(nullable: false, identity: true),
                        TenCongThuc = c.String(),
                        AnhMinhHoa = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        TieuDe = c.String(),
                        DoKho = c.Int(),
                        ThoiGianCB = c.Int(),
                        ThoiGianNau = c.Int(),
                        MaLoaiCongThuc = c.Long(),
                        MaNguoiTao = c.Int(),
                        NgayTao = c.DateTime(storeType: "date"),
                        MaNguoiChinhSua = c.Int(),
                        NgayChinhSua = c.DateTime(storeType: "date"),
                        TopHot = c.Boolean(),
                        TrangThai = c.Boolean(),
                        Video = c.String(),
                    })
                .PrimaryKey(t => t.ID_congthuc)
                .ForeignKey("dbo.LoaiCongThuc", t => t.MaLoaiCongThuc)
                .Index(t => t.MaLoaiCongThuc);
            
            CreateTable(
                "dbo.LoaiCongThuc",
                c => new
                    {
                        MaLoaiCongThuc = c.Long(nullable: false, identity: true),
                        TenLoaiCT = c.String(maxLength: 200),
                        TopHot = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaLoaiCongThuc);
            
            CreateTable(
                "dbo.NguyenLieu",
                c => new
                    {
                        MaNguyenLieu = c.Long(nullable: false, identity: true),
                        MaCongThuc = c.Long(),
                        TenNguyenLieu = c.String(maxLength: 50),
                        SoLuong = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNguyenLieu)
                .ForeignKey("dbo.CongThuc", t => t.MaCongThuc)
                .Index(t => t.MaCongThuc);
            
            CreateTable(
                "dbo.NoiDungCT",
                c => new
                    {
                        MaNoiDungCT = c.Long(nullable: false, identity: true),
                        MaCongThuc = c.Long(),
                        NoiDung = c.String(),
                        AnhMinhHoa = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaNoiDungCT)
                .ForeignKey("dbo.CongThuc", t => t.MaCongThuc)
                .Index(t => t.MaCongThuc);
            
            CreateTable(
                "dbo.ThanhVien",
                c => new
                    {
                        ID_user = c.Long(nullable: false, identity: true),
                        HoTen = c.String(maxLength: 200),
                        GioiTinh = c.String(maxLength: 10),
                        HinhDaiDien = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        NgayDangky = c.DateTime(storeType: "date"),
                        Username = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        PassWord = c.String(maxLength: 100, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.ID_user);
            
            CreateTable(
                "dbo.TraLoi_PhanHoi",
                c => new
                    {
                        MaTraLoi = c.Long(nullable: false, identity: true),
                        MaPhanHoi = c.Long(),
                        TieuDe = c.String(),
                        NoiDung = c.String(),
                        NgayDang = c.DateTime(),
                        MaThanhVien = c.Long(),
                        MaNguoiDung = c.Int(),
                    })
                .PrimaryKey(t => t.MaTraLoi)
                .ForeignKey("dbo.NguoiDung", t => t.MaNguoiDung)
                .ForeignKey("dbo.PhanHoi", t => t.MaPhanHoi)
                .ForeignKey("dbo.ThanhVien", t => t.MaThanhVien)
                .Index(t => t.MaPhanHoi)
                .Index(t => t.MaThanhVien)
                .Index(t => t.MaNguoiDung);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 100, unicode: false),
                        CapDo = c.String(maxLength: 100, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        MãFooter = c.Long(name: "Mã Footer", nullable: false, identity: true),
                        NoiDung = c.String(storeType: "ntext"),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MãFooter);
            
            CreateTable(
                "dbo.GioiThieu",
                c => new
                    {
                        MaGioiThieu = c.Long(nullable: false, identity: true),
                        TieuDe = c.String(maxLength: 250),
                        NoiDung = c.String(storeType: "ntext"),
                        NgayTao = c.DateTime(storeType: "date"),
                        NgayDang = c.DateTime(storeType: "date"),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaGioiThieu);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        MaSlider = c.Long(nullable: false, identity: true),
                        TieuDe = c.String(maxLength: 100),
                        NoiDung = c.String(storeType: "ntext"),
                        AnhMinhHoa = c.String(maxLength: 100, fixedLength: true, unicode: false),
                        TrangThai = c.Boolean(),
                        Class = c.String(maxLength: 100, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.MaSlider);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhanHoi", "ID_blog", "dbo.Blog");
            DropForeignKey("dbo.TraLoi_PhanHoi", "MaThanhVien", "dbo.ThanhVien");
            DropForeignKey("dbo.TraLoi_PhanHoi", "MaPhanHoi", "dbo.PhanHoi");
            DropForeignKey("dbo.TraLoi_PhanHoi", "MaNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.PhanHoi", "ID_user", "dbo.ThanhVien");
            DropForeignKey("dbo.PhanHoi", "ID_congthuc", "dbo.CongThuc");
            DropForeignKey("dbo.NoiDungCT", "MaCongThuc", "dbo.CongThuc");
            DropForeignKey("dbo.NguyenLieu", "MaCongThuc", "dbo.CongThuc");
            DropForeignKey("dbo.CongThuc", "MaLoaiCongThuc", "dbo.LoaiCongThuc");
            DropForeignKey("dbo.NoiDung_Blog", "ID_blog", "dbo.Blog");
            DropIndex("dbo.TraLoi_PhanHoi", new[] { "MaNguoiDung" });
            DropIndex("dbo.TraLoi_PhanHoi", new[] { "MaThanhVien" });
            DropIndex("dbo.TraLoi_PhanHoi", new[] { "MaPhanHoi" });
            DropIndex("dbo.NoiDungCT", new[] { "MaCongThuc" });
            DropIndex("dbo.NguyenLieu", new[] { "MaCongThuc" });
            DropIndex("dbo.CongThuc", new[] { "MaLoaiCongThuc" });
            DropIndex("dbo.PhanHoi", new[] { "ID_blog" });
            DropIndex("dbo.PhanHoi", new[] { "ID_congthuc" });
            DropIndex("dbo.PhanHoi", new[] { "ID_user" });
            DropIndex("dbo.NoiDung_Blog", new[] { "ID_blog" });
            DropTable("dbo.Slider");
            DropTable("dbo.GioiThieu");
            DropTable("dbo.Footer");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.TraLoi_PhanHoi");
            DropTable("dbo.ThanhVien");
            DropTable("dbo.NoiDungCT");
            DropTable("dbo.NguyenLieu");
            DropTable("dbo.LoaiCongThuc");
            DropTable("dbo.CongThuc");
            DropTable("dbo.PhanHoi");
            DropTable("dbo.NoiDung_Blog");
            DropTable("dbo.Blog");
        }
    }
}
