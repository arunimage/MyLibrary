using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_Clone_DataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                string query = "select * from Employees";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable employees2 = new DataTable();

                sda.Fill(employees2);

                Console.WriteLine("Original data Table");
                foreach (DataRow row in employees2.Rows)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", row[0], row[1], row[2], row[3], row[4]);
                }

                DataTable CopyDataTable = employees2.Copy();

                Console.WriteLine("\nCopy Data Table");

                foreach (DataRow row in CopyDataTable.Rows)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", row[0], row[1], row[2], row[3], row[4]);
                }

                Console.WriteLine("\nClone Data Table");
                DataTable CloneDataTable = employees2.Clone();

                if (CloneDataTable.Rows.Count > 0)
                {

                }

                else
                {
                    Console.WriteLine("No Row found in Clone Data");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            Console.ReadLine();

        }
    }
}
