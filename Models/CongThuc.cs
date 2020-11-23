namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongThuc")]
    public partial class CongThuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongThuc()
        {
            NguyenLieux = new HashSet<NguyenLieu>();
            NoiDungCTs = new HashSet<NoiDungCT>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        public long ID_congthuc { get; set; }

        public string TenCongThuc { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public string TieuDe { get; set; }

        public int? DoKho { get; set; }

        public int? ThoiGianCB { get; set; }

        public int? ThoiGianNau { get; set; }

        public long? MaLoaiCongThuc { get; set; }

        public int? MaNguoiTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public int? MaNguoiChinhSua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChinhSua { get; set; }

        public bool? TopHot { get; set; }

        public bool? TrangThai { get; set; }

        public int? SLPH { get; set; }

        [StringLength(1000)]
        public string Video { get; set; }

        public long? LuotXem { get; set; }

        public virtual LoaiCongThuc LoaiCongThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguyenLieu> NguyenLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDungCT> NoiDungCTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
