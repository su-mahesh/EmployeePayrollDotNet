﻿using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleTables;

namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeePayroll;User Id=mahesh;Password=root";

        public static DataSet GetAllEmployeeDetail()
        {
            EmployeeModel employee = new EmployeeModel();
            SqlConnection connection = new SqlConnection(connectionString);
            DataSet dataset = new DataSet();
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("GetAllEmployeeData", connection);
                    adapter.Fill(dataset);
                    connection.Close();
                    return dataset;
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
            DataSet dataset = GetAllEmployeeDetail();
            PrintDataSet(dataset);
        }

        public static void PrintDataSet(DataSet dataset)
        {
            if (dataset != null)
            {
                foreach (DataTable table in dataset.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            Console.WriteLine(column.ColumnName.PadRight(20) + ": " + row[column]);
                        }
                        Console.WriteLine();
                    }
                }
            }           
        }
    }
}