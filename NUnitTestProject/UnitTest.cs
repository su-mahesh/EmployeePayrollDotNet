using System;
using System.Collections.Generic;
using EmployeePayrollService;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        [Test]
        public void GettingAllEmployeeDetail_ShouldReturnExpected()
        {
            List<EmployeeModel> result = EmployeePayroll.GetAllEmployeePayrollData();
            string dateString = "Jan 03, 2018";
            DateTime dateTime = DateTime.Parse(dateString);
            EmployeeModel employee = new EmployeeModel
            {
                EmpID = 1,
                EmpName = "Bil",
                Gender = "M",
                StartDate = dateTime,
                Salary = 100000.0000M,
                Department = "IT"               
            };
            Assert.IsTrue(result.Contains(employee));
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