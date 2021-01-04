namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            Luu_tru = new HashSet<Luu_tru>();
            PhanHois = new HashSet<PhanHoi>();
            TraLoi_PhanHoi = new HashSet<TraLoi_PhanHoi>();
        }

        [Key]
        public long ID_user { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string HinhDaiDien { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangky { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string PassWord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luu_tru> Luu_tru { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraLoi_PhanHoi> TraLoi_PhanHoi { get; set; }
    }
}
