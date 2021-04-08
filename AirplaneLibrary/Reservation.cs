namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        public int R_ID { get; set; }

        [Required]
        [StringLength(25)]
        public string UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Flight_No { get; set; }

        public short No_of_Tickets { get; set; }

        public virtual Flight_Details Flight_Details { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
