using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeModel
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public double PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        
    }
}
