//Author: Andrei Rico
//Student Number: 3106107616
//Purpose: double linklist
//Known bugs: None
//Date: 21/11/2017

using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Interfaces;

namespace Implementations
{
    public class EmployeesCollection : IEmployeesCollection, ICloneable
    {
        private int _currentPosition;
        private readonly List<Employee> _employees;

      
        // Wraps list.  
        
      
        public EmployeesCollection(List<Employee> employees, int currentPosition)
        {
            _currentPosition = currentPosition;
            if (employees == null)
                throw new ArgumentException(nameof(employees));

            _employees = employees;
        }

        public int Count => _employees?.Count ?? 0;
        public Employee CurrentEmployee => Count > 0 ? _employees[_currentPosition] : null;

        public Employee NextEmployee =>
            CurrentEmployee != null && _currentPosition <= _employees.Count - 2
                ? _employees[_currentPosition + 1] : null;

        public Employee PreviousEmployee =>
            CurrentEmployee != null && _currentPosition > 0 ? _employees[_currentPosition - 1] : null;

        public void SetCurrentEmployeePosition(int position)
        {
            _currentPosition = position;
        }

        public bool AddEmployee(Employee employee, int position)
        {
            if (employee == null)
                throw new ArgumentException(nameof(employee));

            try
            {
                _employees.Insert(position, employee);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void SortEmployees()
        {
            _employees.Sort();
        }

        public bool RemoveEmployeeAt(int position)
        {
            if (position < 0 || !_employees.Any() || position > _employees.Count - 1)
                throw new ArgumentOutOfRangeException(nameof(position));

            try
            {
                _employees.RemoveAt(position);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<Employee> SearchEmployee()
        {
            throw new NotImplementedException();
        }

        public IEmployeesCollection SearchByLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
                return this;

            var result = _employees.Where(employee => employee.LastName.ToLower().Contains(lastName.ToLower())).ToList();

            return new EmployeesCollection(result, 0);
        }

        
        public object Clone()
        {
            return MemberwiseClone();
        }
        
    }
}