using System;
using System.Globalization;
using work.Entites;
using work.Entites.Enums;

namespace work
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department name ! ");
            string depName= Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter Works Data: ");
            Console.Write("Enter Name: ");
            string nameFunc = Console.ReadLine();
            Console.Write("Level (Junior / MidLevel /Senior) ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department  dep = new Department(depName);
            Worker worker = new Worker(nameFunc,level,baseSalary,dep);
           
             Console.Write("How many contracts to thod woker ? ");
             int n = int.Parse(Console.ReadLine());

             for (int i =1; i <= n;i++)
             {
                 Console.WriteLine("-------------------------------------------------------");
                 Console.WriteLine($"Enter #{i} contracts data:");
                 Console.Write("Date (DD/MM/YYYY): ");
                 DateTime date = DateTime.Parse(Console.ReadLine());
                 Console.Write("Value per hour: ");
                 double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                 Console.Write("duration (hours) :");
                 int hours =int.Parse(Console.ReadLine());

                 HourContract contract= new HourContract(date,valuePerHour,hours);
                 worker.AddContract(contract);
             }
             Console.WriteLine();
             Console.WriteLine("-------------------------------------------------------");
             Console.Write("Enter month and year to calculate income (MM/YYYY): ");
             string monthAndYear = Console.ReadLine();
             int month = int.Parse(monthAndYear.Substring(0,2));
             int year = int.Parse(monthAndYear.Substring(3));
             Console.WriteLine("Name: "+ worker.Name);
             Console.WriteLine("Department: "+worker.Department.Name);
             Console.WriteLine("Income for "+monthAndYear+": "+worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));




        }


    }
}
