namespace gb;

internal class HourlySalaryDepartament : Departament
{
    internal override Employee HireWorker(string name, long salary)
    {
        EmployeeBuilder builder = new EmployeeBuilder(EmployeeType.HourlySalary);

        return builder.
            SetName(name).
            SetSalary(salary).
            Create();
    }
}