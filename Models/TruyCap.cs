namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TruyCap")]
    public partial class TruyCap
    {
        public long ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        public int? SoTruyCap { get; set; }
    }
}
