//Author: Andrei Rico
//Purpose: Employee class 
//Known bugs: None
//Date: 21/11/2017

using System;

namespace Entities
{
    public class Employee
    {
        public string firstName;
        public string lastName;
        public int employeeId;
        public string departmentType;

        public override string ToString()
        {
            var newLine = Environment.NewLine;
            return firstName + newLine + lastName + newLine + employeeId + newLine + departmentType;
        }
    }
}