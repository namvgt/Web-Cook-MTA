namespace Mix_MTA2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NoiDung_Blog
    {
        public long ID { get; set; }

        public long? ID_blog { get; set; }

        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
