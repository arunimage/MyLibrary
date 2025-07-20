using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLConnectionADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.connection();
            Console.ReadLine();
        }

        static void connection()
        {
            //string cs = "Server=DESKTOP-707Q2S3;Database=ado_db;Integrated Security=True;";

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection has been opened");
                }
            };

            /*
             SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection has been opened");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                con.Close();
            }
            */
        }
    }
}
