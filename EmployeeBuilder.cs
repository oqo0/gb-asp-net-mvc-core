using System.ComponentModel;

namespace gb;

internal class EmployeeBuilder
{
    private readonly Employee _employee;

    internal EmployeeBuilder(EmployeeType type)
    {
        switch (type)
        {
            case (EmployeeType.FixedSalary):
                _employee = new FixedSalaryWorker();
                break;
            case (EmployeeType.HourlySalary):
                _employee = new HourlySalaryWorker();
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
        
    }
    
    internal Employee Create()
    {
        if (String.IsNullOrEmpty(_employee.Name))
        {
            throw new InvalidOperationException("Employee.Name is a required parameter.");
        }
        if (_employee.Salary == null)
        {
            throw new InvalidOperationException("Employee.Salary is a required parameter.");
        }
        
        return _employee;
    }
    
    internal EmployeeBuilder SetName(string name)
    {
        _employee.Name = name;
        return this;
    }

    internal EmployeeBuilder SetSecondName(string secondName)
    {
        _employee.SecondName = secondName;
        return this;
    }
    
    internal EmployeeBuilder SetSalary(long salary)
    {
        _employee.Salary = salary;
        return this;
    }
}