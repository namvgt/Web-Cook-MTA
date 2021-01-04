namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Yeu_thich_mon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID_save { get; set; }

        public long? ID_user { get; set; }

        public long? ID_congthuc { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public string TenCongThuc { get; set; }

        public DateTime? Ngay_luu { get; set; }
    }
}
