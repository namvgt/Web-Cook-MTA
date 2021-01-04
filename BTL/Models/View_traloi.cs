namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_traloi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaTraLoi { get; set; }

        public long? MaPhanHoi { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public long? MaThanhVien { get; set; }

        public int? MaNguoiDung { get; set; }

        [StringLength(100)]
        public string HinhDaiDien { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }
    }
}
