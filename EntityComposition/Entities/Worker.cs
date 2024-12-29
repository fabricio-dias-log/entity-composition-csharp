using EntityComposition.Entities.Enums;

namespace EntityComposition.Entities;

public class Worker
{
    public string Name { get; set; }
    public WorkerLevel Level { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public List<HourContract> Contracts { get; set; } = new List<HourContract>();

    public Worker()
    {
    }

    public Worker(string name, WorkerLevel level, double baseSalary, Department department)
    {
        this.Name = name;
        this.Level = level;
        this.BaseSalary = baseSalary;
        this.Department = department;
    }

    public void AddContract(HourContract contract)
    {
        this.Contracts.Add(contract);
    }

    public void RemoveContract(HourContract contract)
    {
        this.Contracts.Remove(contract);
    }

    public double Income(int year, int month)
    {
        double sum = this.BaseSalary;

        foreach (HourContract contract in this.Contracts)
        {
            if (contract.Date.Year == year && contract.Date.Month == month)
            {
                sum += contract.TotalValue();
            }
        }
        
        return sum;
    }
}