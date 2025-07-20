using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataAdapterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter ID:   ");
            string id = Console.ReadLine();

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            var con = new SqlConnection(cs);

            var cmd = new SqlCommand("spGetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            
            var sda = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            sda.Fill(ds);

            var dataRow = ds.Tables[0];

            foreach (DataRow dr in dataRow.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }


            /*var sda = new SqlDataAdapter("select * from Employees", con);
            var ds = new DataSet();
            sda.Fill(ds);

            var tableRows = ds.Tables[0].Rows;
            foreach (DataRow row in tableRows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
            }

            Console.WriteLine("--------------------");

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
            }
            */
        }
    }
}
