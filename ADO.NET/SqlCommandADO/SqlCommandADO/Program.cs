using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Connection();
            Console.ReadLine();
        }

        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter Id= ");
                    string id = Console.ReadLine();

                    string query = "delete from Employees where id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data has been deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Data deletion failed..");
                    }
                }
            }
            /*using (con = new SqlConnection(cs))
            {
                Console.WriteLine("Employee Id: ");
                string id = Console.ReadLine();
                Console.WriteLine("Employee Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Employee Gender: ");
                string gender = (Console.ReadLine());
                Console.WriteLine("Employee Age: ");
                string age = (Console.ReadLine());
                Console.WriteLine("Employee Salary: ");
                string salary = (Console.ReadLine());
                Console.WriteLine("Employee City: ");
                string city = Console.ReadLine();

                //string query = "insert into Employees(Name, Gender, Age, Salary, City) values(@Name, @Gender, @Age, @Salary, @City)";
                string query = "update Employees set name = @name, gender = @gender, age = @age, salary = @salary, city = @city where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@City", city);

                con.Open();

                Console.WriteLine("Connection Open");

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    Console.WriteLine("Data updated");
                }
                else
                {
                    Console.WriteLine("Data Updation fail");
                }

                /*string query = "spGetEmployees";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(" Id= " + dr["Id"] + " Name= " + dr["Name"] + " Gender= " + dr["Gender"]
                        + " age= " + dr["Age"] + " salary= " + dr["Salary"] + " city= " + dr["City"]);
                }

            }
        */

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
