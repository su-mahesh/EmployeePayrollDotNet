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
    }
}