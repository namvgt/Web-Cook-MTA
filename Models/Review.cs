namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaPhanHoi { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public long? ID_congthuc { get; set; }

        public long? ID_blog { get; set; }

        [StringLength(200)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string HinhDaiDien { get; set; }
    }
}
