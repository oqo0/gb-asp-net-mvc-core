namespace gb;

internal class FixedSalaryDepartament : Departament
{
    internal override Employee HireWorker(string name, long salary)
    {
        EmployeeBuilder builder = new EmployeeBuilder(EmployeeType.FixedSalary);

        return builder.
            SetName(name).
            SetSalary(salary).
            Create();
    }
}