using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    class Program
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll;User Id=mahesh;Password=root";

        public static DataSet GetAllEmployeeData()
        {
            EmployeeModel employee = new EmployeeModel();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {                   
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Employee Payroll Service");
            GetAllEmployeeData();
        }
    }
}
