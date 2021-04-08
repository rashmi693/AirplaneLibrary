namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Passenger")]
    public partial class Passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger()
        {
            Payments = new HashSet<Payment>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [StringLength(25)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(25)]
        public string FNAME { get; set; }

        [Required]
        [StringLength(25)]
        public string LNAME { get; set; }

        [StringLength(15)]
        public string PHONE { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PID { get; set; }

        public int Age { get; set; }

        [StringLength(50)]
        public string pwd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
