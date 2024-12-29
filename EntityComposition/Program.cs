using System.Diagnostics.Contracts;
using System.Globalization;
using EntityComposition.Entities;
using EntityComposition.Entities.Enums;

namespace EntityComposition;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string deptName = Console.ReadLine();
        
        Console.WriteLine("Enter worker data: ");
        Console.Write("Name: ");
        string workerName = Console.ReadLine();
        
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
        
        Console.Write("Base salary: ");
        double workerBaseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        Department dept = new Department(deptName);
        
        Worker worker = new Worker(workerName, workerLevel, workerBaseSalary, dept);
        
        Console.Write("How many contracts to this worker? ");
        int workerContractsNumber = int.Parse(Console.ReadLine());
        
        
        for (int i = 0; i < workerContractsNumber; i++)
        {
            Console.WriteLine($"Enter #{i + 1} contract data: ");
            
            Console.Write("Date (DD/MM/YYYY): ");
            DateTime hourContractDate = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Value per hour: ");
            double hourValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Console.Write("Duration (hours): ");
            int hoursDuration = int.Parse(Console.ReadLine());
            
            HourContract hourContract = new HourContract(hourContractDate, hourValue, hoursDuration);
            
            worker.AddContract(hourContract);
        }
       
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string monthAndYear = Console.ReadLine();
        int month = int.Parse(monthAndYear.Substring(0, 2));
        int year = int.Parse(monthAndYear.Substring(3));
        
        Console.WriteLine($"Name: {worker.Name}");
        Console.WriteLine($"Department: {worker.Department.Name}");
        Console.WriteLine($"Income for {month}/{year}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
        
    }
}