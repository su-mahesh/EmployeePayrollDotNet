using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the employee data.
        /// </summary>
        /// <value>
        /// The employee data.
        /// </value>
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string Department { get; set; }
        public decimal BasicPay { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            EmployeeModel employee = (EmployeeModel)obj;
            if (employee == null)
                return false;
            return employee.EmpID == EmpID && employee.EmpName == EmpName && employee.Gender == Gender && employee.Department == Department
                && employee.BasicPay == BasicPay && employee.StartDate == StartDate;
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
