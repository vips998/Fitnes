namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Client = new HashSet<Client>();
            TimeTable = new HashSet<TimeTable>();
        }

        public int ID { get; set; }

        public int UserTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string Passport { get; set; }

        [Required]
        [StringLength(50)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTable> TimeTable { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
