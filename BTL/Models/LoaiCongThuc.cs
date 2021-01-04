namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCongThuc")]
    public partial class LoaiCongThuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiCongThuc()
        {
            CongThucs = new HashSet<CongThuc>();
        }

        [Key]
        public long MaLoaiCongThuc { get; set; }

        [StringLength(200)]
        public string TenLoaiCT { get; set; }

        public bool? TopHot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongThuc> CongThucs { get; set; }
    }
}
