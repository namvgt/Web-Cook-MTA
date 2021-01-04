namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        [Key]
        public long MaSlider { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(100)]
        public string Class { get; set; }
    }
}
