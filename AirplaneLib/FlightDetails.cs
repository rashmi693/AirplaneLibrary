using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneLib
{
    public class FlightDetails
    {
        public string Flightno { get; set; }
        public string Arrival_Airport { get; set; }
        public string Depart_Airport { get; set; }
        public DateTime Arrival_Time{ get; set; }
        public DateTime Depart_Time { get; set; }
        public int Seating_Capacity { get; set; }
        public double Amount { get; set; }
    }
}
