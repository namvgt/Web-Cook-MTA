namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [Key]
        [Column("Mã Footer")]
        public long Mã_Footer { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public bool? TrangThai { get; set; }
    }
}
