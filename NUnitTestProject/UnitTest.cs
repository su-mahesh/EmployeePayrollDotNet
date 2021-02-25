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
            List<EmployeeModel> result = EmployeeManagement.GetAllEmployeePayrollData();
            string dateString = "Jan 03, 2018";
            DateTime dateTime = DateTime.Parse(dateString);
            EmployeeModel employee = new EmployeeModel
            {
                EmpID = 1,
                EmpName = "Bil",
                Gender = "M",
                StartDate = dateTime,
                BasicPay = 100000M,
                Department = "IT"               
            };
            Assert.IsTrue(result.Contains(employee));
        }
        /// <summary>
        /// Insertings all employee detail should return when same when accessed.
        /// </summary>
        [Test]
        public void InsertingAllEmployeeDetail_ShouldReturnIndetityKey()
        {
            string dateString = "May 01, 2020";
            DateTime dateTime = DateTime.Parse(dateString);
            EmployeeModel employee = new EmployeeModel
            {
                EmpName = "Sim",
                Gender = "F",
                StartDate = dateTime,
                BasicPay = 350000M,
                Department = "ART",
            };
            int identity = EmployeeManagement.InsertEmployeeData(employee);
            Assert.IsFalse(identity.Equals(0));
        }
        /// <summary>
        /// Updatings the table should return no. of updated rows.
        /// </summary>
        [Test]
        public void UpdatingSalary_ShouldReturnNoOfUpdatedEmpObject()
        {
            string dateString = "2019-11-13";
            DateTime dateTime = DateTime.Parse(dateString);
            EmployeeModel employee = new EmployeeModel
            {
                EmpID = 2,
                EmpName = "Terissa",
                Gender = "F",
                StartDate = dateTime,
                BasicPay = 3000000M,
                Department = "marketing"
            };
            var result = EmployeeManagement.UpdateSalary(employee);
            Assert.AreEqual(employee, result);
        }

        [Test]
        public void RetrievingEmployeePayrollWithinDateRange_ShouldReturnList()
        {
            DateTime FromDate = DateTime.Parse("2019-11-13"); 
            DateTime ToDate = DateTime.Parse("2020-05-21");
            List<EmployeeModel> result = EmployeeManagement.GetAllEmployeePayrollData_FromDateRange(FromDate, ToDate);
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Retrievings the sum of salary should return expected.
        /// </summary>
        [Test]
        public void RetrievingSumOfSalaryOfAllFemaleEmloyees_ShouldReturnExpected()
        {
            decimal result = EmployeeManagement.GetSumOfSalary_OfAllFemaleEmployee();
            Assert.AreEqual(4050000M, result);
        }
        /// <summary>
        /// Retrievings the sum of salary of all male emloyees should return expected.
        /// </summary>
        [Test]
        public void RetrievingSumOfSalaryOfAllMaleEmloyees_ShouldReturnExpected()
        {
            decimal result = EmployeeManagement.GetSumOfSalary_OfAllMaleEmployee();
            Assert.AreEqual(420000M, result);
        }
        /// <summary>
        /// Retrievings the average of salary of all male emloyees should return expected.
        /// </summary>
        [Test]
        public void RetrievingAverageSalaryOfAllEmloyees_ShouldReturnExpected()
        {
            decimal result = EmployeeManagement.GetAveragefSalary_OfAllEmployees();
            Assert.AreEqual(638571.4285M, result);
        }
        /// <summary>
        /// Retrievings the minimum maximum of salary of male female emloyees should return expected.
        /// </summary>
        [Test]
        public void RetrievingMinSalaryOfFemaleEmloyees_ShouldReturnExpected()
        {
            decimal result = EmployeeManagement.GegMinOfSalary_OfFemaleEmployees();
            Assert.AreEqual(350000M, result);
        }
        /// <summary>
        /// Retrievings the no of female emloyees should return expected.
        /// </summary>
        [Test]
        public void RetrievingNoOfFemaleEmloyees_ShouldReturnExpected()
        {
            int result = EmployeeManagement.GetNoOfFemaleEmployees();
            Assert.AreEqual(4, result);
        }
        /// <summary>
        /// Retrievings the no of male emloyees should return expected.
        /// </summary>
        [Test]
        public void RetrievingNoOfMaleEmloyees_ShouldReturnExpected()
        {
            int result = EmployeeManagement.GetNoOfMaleEmployees();
            Assert.AreEqual(4, result);
        }

    }
}