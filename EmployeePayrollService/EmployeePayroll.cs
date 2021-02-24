using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll;User Id=mahesh;Password=root";

        /// <summary>
        /// Gets all employee payroll data.
        /// </summary>
        /// <returns></returns>
        public static List<EmployeeModel> GetAllEmployeePayrollData()
        {
            EmployeeModel employee;
            List<EmployeeModel> EmployeeModelList = new List<EmployeeModel>();
           
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.GetEmployeePayrollAllData", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        employee = new EmployeeModel();
                        employee.EmpID = rd.IsDBNull(0) ? default : rd.GetInt32(0);
                        employee.EmpName = rd.IsDBNull(1) ? default : rd.GetString(1);
                        employee.Gender = rd.IsDBNull(2) ? default : rd.GetString(2);
                        employee.StartDate = rd.IsDBNull(3) ? default : rd.GetDateTime(3);
                        employee.Salary = rd.IsDBNull(4) ? default : rd.GetDecimal(4);
                        employee.Department = rd.IsDBNull(5) ? default : rd.GetString(5);
                        EmployeeModelList.Add(employee);
                    }
                    return EmployeeModelList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        /// <summary>
        /// Prints the employee data.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public static void PrintEmployeeData(EmployeeModel employee)
        {
            Console.WriteLine("EmpID".PadRight(12) + ": " + employee.EmpID);
            Console.WriteLine("EmpName".PadRight(12) + ": " + employee.EmpName);
            Console.WriteLine("Gender".PadRight(12) + ": " + employee.Gender);
            Console.WriteLine("Start date".PadRight(12) + ": " + employee.StartDate);
            Console.WriteLine("Salary".PadRight(12) + ":" + employee.Salary);
            Console.WriteLine("Department".PadRight(12) + ": " + employee.Department);
        }
        public static void PrintEmployeeData(List<EmployeeModel> employeeList)
        {
            if (employeeList != null)
            {
                foreach (var employee in employeeList)
                {
                    PrintEmployeeData(employee);
                }
            }
        }

        static public int InsertEmployeeData(EmployeeModel employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("dbo.AddEmployeePayrollData", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);             
                    var returnParameter = cmd.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    int rows = cmd.ExecuteNonQuery();
                    
                    connection.Close();
                    var result = returnParameter.Value;
                    return (int)result; 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Employee Payroll Service");
        }
    }
}
