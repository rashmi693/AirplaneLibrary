namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seat")]
    public partial class Seat
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Flight_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeatNo { get; set; }

        [Required]
        [StringLength(5)]
        public string Available { get; set; }

        [Required]
        [StringLength(10)]
        public string Seat_Class { get; set; }

        public virtual Flight_Details Flight_Details { get; set; }
    }
}
