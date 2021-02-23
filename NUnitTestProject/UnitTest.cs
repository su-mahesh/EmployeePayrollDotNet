using System;
using System.Data;
using EmployeePayrollService;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        [Test]
        public void GettingAllEmployeeDetail_ShouldReturnExpected()
        {
            string[] test = { "2", "Terissa", "", "", "sales", "F", "200000.0000", "", "", "","", "13-Nov-19 12:00:00 AM" };
            DataSet dataset = EmployeePayroll.GetAllEmployeeDetail();
            foreach (DataTable table in dataset.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    int i = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        Assert.AreEqual(row[column].ToString(), test[i]);
                        i++;
                    }
                    break;
                }
            }
        }

        [Test]
        public void InsertingAllEmployeeDetail_ShouldReturnWhenSameWhenAccessed()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = "Joy";
            employeeModel.Address = "pune";
            employeeModel.Gender = "M";
            employeeModel.Department = "IT";
            employeeModel.BasicPay = 20000;
            employeeModel.Deduction = 45333;
            employeeModel.IncomeTax = 10000;
            employeeModel.TaxablePay = 30000;
            employeeModel.NetPay = 50000;
            employeeModel.PhoneNumber = 7732934567;
            var parsedDate = DateTime.Parse("May 2, 2020");
            employeeModel.StartDate = parsedDate;
            EmployeePayroll.InsertEmployeeData(employeeModel);
        }
    }
}