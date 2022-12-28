using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WebApplicationEcommerce.Models;
namespace WebApplicationEcommerce.Data
{
    public class File_bl
    {
        public  static int Method()
        {
            var prevDate = new DateTime(2021, 7, 15); //15 July 2021
            var today = DateTime.Now;

            Console.WriteLine("prevDate: {0}", prevDate);
            Console.WriteLine("today: {0}", today);

            //get difference of two dates
            var diffOfDates = today - prevDate;
            Console.WriteLine("Difference in Timespan: {0}", diffOfDates);
            Console.WriteLine("Difference in Days: {0}", diffOfDates.Days);
            Console.WriteLine("Difference in Hours: {0}", diffOfDates.Hours);
            Console.WriteLine("Difference in Miniutes: {0}", diffOfDates.Minutes);
            Console.WriteLine("Difference in Seconds: {0}", diffOfDates.Seconds);
            Console.WriteLine("Difference in Milliseconds: {0}", diffOfDates.Milliseconds);
            Console.WriteLine("Difference in Ticks: {0}", diffOfDates.Ticks);
            return 1;
        }
        public static bool DeleteData(int id)
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
                    SqlCommand cmd = new SqlCommand("sp_delete_UploadFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
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
