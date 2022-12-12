namespace gb;

internal class FixedSalaryWorker : Employee
{
    internal override long? CountAverageMonthSalary()
    {
        return Salary;
    }
}