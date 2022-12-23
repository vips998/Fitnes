namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimeTable")]
    public partial class TimeTable
    {
        public int ID { get; set; }

        public int ServiceTypeID { get; set; }

        public int Cost { get; set; }

        public int UserID { get; set; }

        public int MaxCount { get; set; }

        public DateTime Date { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual User User { get; set; }
    }
}
