using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Net_DataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable employees = new DataTable("employees");

                DataColumn id = new DataColumn("id");
                id.Caption = "Emp_Id";
                id.DataType = typeof(int);
                id.AllowDBNull = false;
                id.AutoIncrement = true;
                id.AutoIncrementSeed = 1;
                id.AutoIncrementStep = 1;
                employees.Columns.Add(id);

                DataColumn name = new DataColumn("name");
                name.Caption = "Emp_Name";
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50;
                name.DefaultValue = "Not Provided";
                name.Unique = true;
                employees.Columns.Add(name);

                DataColumn gender = new DataColumn("gender");
                gender.Caption = "Emp_Gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 20;
                employees.Columns.Add(gender);

                employees.PrimaryKey = new DataColumn[] { id };

                DataRow row1 = employees.NewRow();
                row1["name"] = "Arun";
                row1["gender"] = "male";
                employees.Rows.Add(row1);

                // OR

                employees.Rows.Add(null, "KHuhh", "Male");

                employees.Rows.Add(null, "Jhansm", "Female");

                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine("{0} {1} {2}", row[0], row[1], row[2]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
