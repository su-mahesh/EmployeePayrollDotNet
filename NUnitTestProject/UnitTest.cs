using System.Data;
using EmployeePayrollService;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

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
    }
}