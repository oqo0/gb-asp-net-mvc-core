namespace gb;

internal abstract class Employee
{
    internal string Name { get; set; }
    internal string SecondName { get; set; }
    internal long? Salary { get; set; }
    
    internal abstract long? CountAverageMonthSalary();
}