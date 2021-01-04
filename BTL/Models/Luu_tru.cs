namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Luu_tru
    {
        public long? ID_congthuc { get; set; }

        public long? ID_user { get; set; }

        public DateTime? Ngay_luu { get; set; }

        [Key]
        public long ID_save { get; set; }

        public long? ID_blog { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual CongThuc CongThuc { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
