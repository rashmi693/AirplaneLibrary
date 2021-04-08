namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flight_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight_Details()
        {
            Seats = new HashSet<Seat>();
            Reservations = new HashSet<Reservation>();
        }

        [Key]
        [StringLength(10)]
        public string Flight_No { get; set; }

        [StringLength(20)]
        public string Arrival_Airport { get; set; }

        [StringLength(20)]
        public string Depart_Airport { get; set; }

        public DateTime arrival_time { get; set; }

        public DateTime? depart_time { get; set; }

        public int? Seating_capacity { get; set; }

        public virtual Fare Fare { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seat> Seats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
