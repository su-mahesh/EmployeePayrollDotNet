using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeModel
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override bool Equals(object obj)
        {
            EmployeeModel employee = (EmployeeModel)obj;// as EmployeeModel;
            if (employee == null)
                return false;
            return employee.EmpID == EmpID && employee.EmpName == EmpName && employee.Gender == Gender && employee.Department == Department
                && employee.Salary == Salary && employee.StartDate == StartDate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
