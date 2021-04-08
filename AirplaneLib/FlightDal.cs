using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneLib
{
    public class FlightDal
    {
        SqlConnection cn;
        public FlightDal()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALRS"].ConnectionString);
        }
        public int FindSeat(String fid)
        {

            SqlCommand cmd = new SqlCommand("SeatAvailaiblity", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flightno", fid);
            cmd.Parameters.Add("@avlbl", SqlDbType.Int);
            cmd.Parameters["@avlbl"].Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();
           int  loginStatus = Convert.ToInt32(cmd.Parameters["@avlbl"].Value);
            cn.Close();
            return loginStatus;
        }
        public List<FlightDetails> FindFlights(FlightDetails fd)
        {
            List<FlightDetails> myl = new List<FlightDetails>();
            SqlCommand cmd = new SqlCommand("FindFlights", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ar",fd.Arrival_Airport);
            cmd.Parameters.AddWithValue("@dp", fd.Depart_Airport);
            cmd.Parameters.AddWithValue("@date", fd.Depart_Time);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FlightDetails f = new FlightDetails();
                f.Flightno = dr[0].ToString();
                f.Arrival_Airport = dr[1].ToString();
                f.Depart_Airport = dr[2].ToString();
                f.Arrival_Time = Convert.ToDateTime(dr[3]);
                f.Depart_Time= Convert.ToDateTime(dr[4]);
                f.Seating_Capacity= Convert.ToInt32(dr[5]);
                f.Amount = Convert.ToDouble(dr[6]);
                myl.Add(f);
            }
            cn.Close();
            return myl;

        }
        public List<String> GetArrivalCitiesS()
        {
            List<String> acity = new List<string>();
            SqlCommand cmd = new SqlCommand("select Distinct(Arrival_Airport)from  Flight_Details", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                acity.Add(dr[0].ToString());
            }
            cn.Close();
            return acity;
        }
        public List<String> GetDepartCities()
        {
            List<String> acity = new List<string>();
            SqlCommand cmd = new SqlCommand("select Distinct(Depart_Airport) from  Flight_Details", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                acity.Add(dr[0].ToString());
            }
            cn.Close();
            return acity;
        }
    }
}
