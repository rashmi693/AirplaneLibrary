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
   public class LoginDal
    {
        SqlConnection cn;
        public LoginDal()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALRS"].ConnectionString);
        }

        public int VerifyData(Passenger p)
        {
            int loginStatus ;
            
            SqlCommand cmd = new SqlCommand("sp_ValidateUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", p.Email);
            cmd.Parameters.AddWithValue("@pwd", p.Pwd);
            cmd.Parameters.Add("@status", SqlDbType.SmallInt);
            cmd.Parameters["@status"].Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();  
            loginStatus=Convert.ToInt32( cmd.Parameters["@status"].Value);
            cn.Close();


            return loginStatus;
        }

        public void InsetData(Passenger p)
        {
            SqlCommand cmd = new SqlCommand("PassengerInsert", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", p.Email);
            cmd.Parameters.AddWithValue("@fname", p.FName);
            cmd.Parameters.AddWithValue("@lname", p.LName);
            cmd.Parameters.AddWithValue("@phone", p.PhoneNo);
            cmd.Parameters.AddWithValue("@age", p.Age);
            cmd.Parameters.AddWithValue("@pass", p.Pwd);
            cn.Open();
            cmd.ExecuteNonQuery();
           
            cn.Close();

        }
        public void ChangePassword(Passenger p)
        {
            SqlCommand cmd = new SqlCommand("ChangePass", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", p.Email);
            cmd.Parameters.AddWithValue("@pwd", p.Pwd);
            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public bool EmailExist(String p)
        {
            SqlCommand cmd = new SqlCommand("CheckEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", p);
            cmd.Parameters.Add("@c", SqlDbType.Int);
            cmd.Parameters["@c"].Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();
            byte loginStatus = Convert.ToByte(cmd.Parameters["@c"].Value);
            
            cn.Close();
            return (loginStatus == 1);

        }
    }
}
