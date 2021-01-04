namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TraLoi_PhanHoi
    {
        [Key]
        public long MaTraLoi { get; set; }

        public long? MaPhanHoi { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public long? MaThanhVien { get; set; }

        public int? MaNguoiDung { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual PhanHoi PhanHoi { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
