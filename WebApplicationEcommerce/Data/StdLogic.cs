using System.Data;
using System.Data.SqlClient;
using WebApplicationEcommerce.Models;

namespace WebApplicationEcommerce.Data
{
    public class StdLogic
    {
        public static bool Insertdata(RegisterForm obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_Tb_Register_Insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                    cmd.Parameters.AddWithValue("@PassWord", obj.PassWord);
                    cmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                   
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
    }
}
