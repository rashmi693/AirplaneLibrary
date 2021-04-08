namespace AirplaneLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int PaymentID { get; set; }

        [Required]
        [StringLength(10)]
        public string Mode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(25)]
        public string User_Email { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
