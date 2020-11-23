namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiDungCT")]
    public partial class NoiDungCT
    {
        [Key]
        public long MaNoiDungCT { get; set; }

        public long? MaCongThuc { get; set; }

        public string NoiDung { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public virtual CongThuc CongThuc { get; set; }
    }
}
