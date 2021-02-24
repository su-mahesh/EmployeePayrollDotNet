using System;
using System.Collections.Generic;
using EmployeePayrollService;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        /// <summary>
        /// Gettings all employee detail should return expected.
        /// </summary>
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
        /// <summary>
        /// Insertings all employee detail should return when same when accessed.
        /// </summary>
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
            Assert.IsFalse(identity.Equals(0));
        }
        /// <summary>
        /// Updatings the table should return no. of updated rows.
        /// </summary>
        [Test]
        public void UpdatingTable_ShouldReturnNoOfUpdatedRows()
        {
            int result = EmployeePayroll.UpdateSalaryByEmpName("Terissa", 3000000);

            Assert.IsFalse(result.Equals(0));
        }
    }
}