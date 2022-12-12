namespace gb;

internal class HourlySalaryWorker : Employee
{
    internal override long? CountAverageMonthSalary()
    {
        return (long) 20.8 * 8 * Salary;
    }
}