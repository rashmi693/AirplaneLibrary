namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fare")]
    public partial class Fare
    {
        [Key]
        [StringLength(10)]
        public string Flight_No { get; set; }

        public decimal Amount { get; set; }

        public decimal Final_Amount { get; set; }

        public decimal Tax { get; set; }

        public virtual Flight_Details Flight_Details { get; set; }
    }
}
