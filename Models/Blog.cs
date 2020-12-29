namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            Luu_tru = new HashSet<Luu_tru>();
            NoiDung_Blog = new HashSet<NoiDung_Blog>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        public long MaBlog { get; set; }

        public string TieuDe { get; set; }

        public string TenBlog { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public int? MaNguoiTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public int? MaNguoiChinhSua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChinhSua { get; set; }

        public bool? TopHot { get; set; }

        public bool? TrangThai { get; set; }

        public long? SLPH { get; set; }

        public long? LuotXem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luu_tru> Luu_tru { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDung_Blog> NoiDung_Blog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}
