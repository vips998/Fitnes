namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visit")]
    public partial class Visit
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public int TrainingID { get; set; }

        public virtual Client Client { get; set; }

        public virtual Training Training { get; set; }
    }
}
