using Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DataLayer.Implementation
{
    public class EmployeeDLL
    {
        string connStr = "Server=AL-LAPBDC064;Database=ado_db;Trusted_Connection=True";
        SqlConnection conn = null;

        public bool SaveEmployee(EmployeeInfo employeeInfo)
        {
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    if (employeeInfo.Id > 0)
                    {
                        //edit
                    }
                    else
                    {

                        string query = "insert into Employees(Name,Gender,Age,Salary,City) values (@name, @gender, @age, @salary, @city)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", employeeInfo.name);
                        cmd.Parameters.AddWithValue("Gender", employeeInfo.gender);
                        cmd.Parameters.AddWithValue("age", employeeInfo.age);
                        cmd.Parameters.AddWithValue("Salary", employeeInfo.salary);
                        cmd.Parameters.AddWithValue("City", employeeInfo.city);
                        conn.Open();
                        int val = cmd.ExecuteNonQuery();
                        //return val > 0 ? true : false;
                        return val > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        public List<EmployeeInfo> GetEmployeesDAL()
        {
            List<EmployeeInfo> listemployeeInfo = new List<EmployeeInfo>();

            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    string query = "select * from Employees";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();
                        employeeInfo.Id = Convert.ToInt32(dataReader["ID"]);
                        employeeInfo.name = dataReader["Name"].ToString();
                        employeeInfo.age = Convert.ToInt32(dataReader["Age"]);
                        employeeInfo.salary = Convert.ToInt32(dataReader["Salary"]);
                        employeeInfo.city = dataReader["City"].ToString();
                        listemployeeInfo.Add(employeeInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return listemployeeInfo;
        }

        public void DeleteEmployeeDLL(int id)
        {
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    string query = "Delete from Employees where Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("ID", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public EmployeeInfo GetEmployeeByIdDLL(int id)
        {
            EmployeeInfo employeeInfo = null;
            using (conn = new SqlConnection(connStr))
            {
                string query = "select * from Employees where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeInfo = new EmployeeInfo();
                    employeeInfo.name = reader["Name"].ToString();
                    employeeInfo.gender = reader["Gender"].ToString();
                    employeeInfo.age = Convert.ToInt32(reader["Age"]);
                    employeeInfo.salary = Convert.ToInt32(reader["Salary"]);
                    employeeInfo.city = reader["City"].ToString();
                }
            }
            return employeeInfo;
        }

        public bool EditEmployeeDLL(int id)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    string query = "Update Employees set Name = @name, Age = @age, Salary=@salary, City=@city where Id=id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("Id", employeeInfo.Id);
                    cmd.Parameters.AddWithValue("Name", employeeInfo.name);
                    cmd.Parameters.AddWithValue("Age", employeeInfo.age);
                    cmd.Parameters.AddWithValue("Salary", employeeInfo.salary);
                    cmd.Parameters.AddWithValue("City", employeeInfo.city);
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    return a > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
    }
}

