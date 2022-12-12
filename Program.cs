namespace gb;

class Program
{
    public static void Main()
    {
        Employee[] workers = new Employee[10];

        var fixedSalaryDep = new FixedSalaryDepartament();
        var hourlySalaryDep = new HourlySalaryDepartament();

        var rnd = new Random();
        
        for (int i = 0; i < 5; i++)
        {
            workers[i] = fixedSalaryDep.HireWorker(
                i.ToString(),
                rnd.Next(2000, 6000)
                );
        }
        
        for (int i = 5; i < 10; i++)
        {
            workers[i] = hourlySalaryDep.HireWorker(
                i.ToString(),
                rnd.Next(5, 40)
            );
        }

        foreach (var e in workers)
        {
            Console.WriteLine($"Name: {e.Name,8} {e.SecondName} | Salary: {e.Salary,6}$ | Month Average: {e.CountAverageMonthSalary(),6}$");
        }
        
    }
}