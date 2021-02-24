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
                EmpID = 10,
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
            string dateString = "May 01, 2020";
            DateTime dateTime = DateTime.Parse(dateString);
            EmployeeModel employee = new EmployeeModel
            {
                EmpName = "AQ",
                Gender = "M",
                StartDate = dateTime,
                Salary = 20000.0000M,
                Department = "IT",
            };
            int identity = EmployeePayroll.InsertEmployeeData(employee);
            Assert.IsTrue(!identity.Equals(0));
        }
    }
}