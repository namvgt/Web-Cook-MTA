namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguyenLieu")]
    public partial class NguyenLieu
    {
        [Key]
        public long MaNguyenLieu { get; set; }

        public long? MaCongThuc { get; set; }

        [StringLength(50)]
        public string TenNguyenLieu { get; set; }

        [StringLength(50)]
        public string SoLuong { get; set; }

        public virtual CongThuc CongThuc { get; set; }
    }
}
