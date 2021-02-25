using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollService
{
    public class EmployeeManagement
    {
        static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll;User Id=mahesh;Password=root";
        static SqlConnection connection = new SqlConnection(connectionString);
 
        static bool EstablishConnection()
        {
            if (!connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new EmployeePlayrollException(EmployeePlayrollException.ExceptionType.CONNECTION_FAILED, "connection failed");
                }                
            }
            return true;
        }

        /// <summary>
        /// Gets all employee payroll data.
        /// </summary>
        /// <returns></returns>
        public static List<EmployeeModel> GetAllEmployeePayrollData()
        {
            EmployeeModel employee;
            List<EmployeeModel> EmployeeModelList = new List<EmployeeModel>();
            SqlCommand command = new SqlCommand("dbo.Er_GetAllEmployeePayroll", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                if (EstablishConnection())
                {
                    using (connection)
                    {
                        SqlDataReader rd = command.ExecuteReader();
                        while (rd.Read())
                        {
                            employee = new EmployeeModel();
                            employee.EmpID = rd["EmpID"] == DBNull.Value ? default : (int)rd["EmpID"];
                            employee.EmpName = rd["EmpName"] == DBNull.Value ? default : (string)rd["EmpName"];
                            employee.Gender = rd["Gender"] == DBNull.Value ? default : (string)rd["Gender"];
                            employee.StartDate = rd["StartDate"] == DBNull.Value ? default : (DateTime)rd["StartDate"];
                            employee.BasicPay = rd["BasicPay"] == DBNull.Value ? default : (decimal)rd["BasicPay"];
                            employee.Department = rd["DepartmentName"] == DBNull.Value ? default : (string)rd["DepartmentName"];
                            EmployeeModelList.Add(employee);
                        }
                        if (EmployeeModelList == null)
                        {
                            throw new EmployeePlayrollException(EmployeePlayrollException.ExceptionType.NO_DATA_FOUND, "no data found");
                        }
                        return EmployeeModelList;
                    }
                }
                else
                {
                    throw new EmployeePlayrollException(EmployeePlayrollException.ExceptionType.CONNECTION_FAILED,"connection failed");
                }                                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
        /// <summary>
        /// Gets all employee payroll data from date range.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public static List<EmployeeModel> GetAllEmployeePayrollData_FromDateRange(DateTime fromDate, DateTime toDate)
        {
            EmployeeModel employee;
            List<EmployeeModel> EmployeeModelList = new List<EmployeeModel>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.GetAllEmployeePayrollData_FromDateRange", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        employee = new EmployeeModel
                        {
                            EmpID = rd.IsDBNull(0) ? default : rd.GetInt32(0),
                            EmpName = rd.IsDBNull(1) ? default : rd.GetString(1),
                            Gender = rd.IsDBNull(2) ? default : rd.GetString(2),
                            StartDate = rd.IsDBNull(3) ? default : rd.GetDateTime(3),
                            BasicPay = rd.IsDBNull(4) ? default : rd.GetDecimal(4),
                            Department = rd.IsDBNull(5) ? default : rd.GetString(5)
                        };
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
        /// Gets the averagef salary of all employees.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeePlayrollException">no such sql procedure</exception>
        public static decimal GetAveragefSalary_OfAllEmployees()
        {
            decimal AverageSalary = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.GetAverageOfSalary_OfAllEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        AverageSalary = rd.IsDBNull(0) ? default : rd.GetDecimal(0);
                    }

                    return AverageSalary;
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Could not find stored procedure"))
                {
                    throw new EmployeePlayrollException(EmployeePlayrollException.ExceptionType.NO_SUCH_SQL_PROCEDURE, "no such sql procedure");
                }
                Console.WriteLine(e);
            }
            return AverageSalary;
        }
        /// <summary>
        /// Gets the no of female employees.
        /// </summary>
        /// <returns></returns>
        public static int GetNoOfFemaleEmployees()
        {
            int NumFemaleEmployees = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.Er_GetNoOf_FemaleEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        NumFemaleEmployees = rd.IsDBNull(0) ? default : rd.GetInt32(0);
                    }
                    return NumFemaleEmployees;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return NumFemaleEmployees;
        }
        /// <summary>
        /// Gets the no of male employees.
        /// </summary>
        /// <returns></returns>
        public static int GetNoOfMaleEmployees()
        {
            int NumMaleEmployees = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.Er_GetNoOf_MaleEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        NumMaleEmployees = rd.IsDBNull(0) ? default : rd.GetInt32(0);
                    }
                    return NumMaleEmployees;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return NumMaleEmployees;
        }
        /// <summary>
        /// Gegs the minimum maximum of salary of all male female employee.
        /// </summary>
        /// <returns></returns>
        public static decimal GegMinOfSalary_OfFemaleEmployees()
        {
            decimal MinSalary = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.Er_GetMinOfSalary_OfFemaleEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        MinSalary = rd.IsDBNull(0) ? default : rd.GetDecimal(0);
                    }
                    return MinSalary;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return default;
        }
        /// <summary>
        /// Gets the sum of salary of all male employee.
        /// </summary>
        /// <returns></returns>
        public static decimal GetSumOfSalary_OfAllMaleEmployee()
        {
            decimal totalSalary = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.Er_GetSumOfSalary_OfAllMaleEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        totalSalary = rd.IsDBNull(0) ? default : rd.GetDecimal(0);
                    }
                    return totalSalary;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return totalSalary;
        }

        /// <summary>
        /// Gets the sum of salary of all employee payroll data.
        /// </summary>
        /// <returns></returns>
        public static decimal GetSumOfSalary_OfAllFemaleEmployee()
        {
            decimal totalSalary = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("dbo.Er_GetSumOfSalary_OfAllFemaleEmployees", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                connection.Open();
                using (connection)
                {
                    SqlDataReader rd = command.ExecuteReader();
                    while (rd.Read())
                    {
                        totalSalary = rd.IsDBNull(0) ? default : rd.GetDecimal(0);
                    }
                    return totalSalary;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return totalSalary;
        }

        /// <summary>
        /// Updates the name of the salary by emp.
        /// </summary>
        /// <param name="empName">Name of the emp.</param>
        /// <param name="BasicPay">The salary.</param>
        /// <returns></returns>
        public static EmployeeModel UpdateSalary(EmployeeModel employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("dbo.Er_UpdateEmployeePayrollSalaryByEmpName", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@EmpID", employee.EmpID);
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    var returnParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    employee = new EmployeeModel();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {                        
                        employee.EmpID = rd["EmpID"] == DBNull.Value ? default : (int)rd["EmpID"];
                        employee.EmpName = rd["EmpName"] == DBNull.Value ? default : (string)rd["EmpName"];
                        employee.Gender = rd["Gender"] == DBNull.Value ? default : (string)rd["Gender"];
                        employee.StartDate = rd["StartDate"] == DBNull.Value ? default : (DateTime)rd["StartDate"];
                        employee.BasicPay = rd["BasicPay"] == DBNull.Value ? default : (decimal)rd["BasicPay"];
                        employee.Department = rd["DepartmentName"] == DBNull.Value ? default : (string)rd["DepartmentName"];
                    }
                    if (employee == null)
                    {
                        throw new EmployeePlayrollException(EmployeePlayrollException.ExceptionType.NO_DATA_FOUND, "no data found");
                    }
                    connection.Close();
                    var result = returnParameter.Value;
                    return employee;
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
            Console.WriteLine("Salary".PadRight(12) + ":" + employee.BasicPay);
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
        /// <summary>
        /// Inserts the employee data.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        static public int InsertEmployeeData(EmployeeModel employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("dbo.Er_InsertEmployeePayrollData", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@BasicPay", employee.BasicPay);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);             
                    var returnParameter = cmd.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    
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
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("welcome to Employee Payroll Service");
        }
    }
}
