namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhanHoi()
        {
            TraLoi_PhanHoi = new HashSet<TraLoi_PhanHoi>();
        }

        [Key]
        public long MaPhanHoi { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public long? ID_user { get; set; }

        public long? ID_congthuc { get; set; }

        public long? ID_blog { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual CongThuc CongThuc { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraLoi_PhanHoi> TraLoi_PhanHoi { get; set; }
    }
}
