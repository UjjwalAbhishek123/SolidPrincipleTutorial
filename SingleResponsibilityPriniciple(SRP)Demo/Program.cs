using System.Xml.Linq;

namespace SingleResponsibilityPriniciple_SRP_Demo
{

    /*
     * Suppose we have a class Employee that has some properties
     and some Methods that are not related to Employees class directly, have some functionality related to them, but not related 
        ,but even then they are implemented in Employees class
     */
    //public class Employee
    //{
    //    public string? Name { get; set; }
    //    public int HoursWorked { get; set; }
    //    public decimal HourlyRate { get; set; }

    //    public void SaveToFile()
    //    {
    //        //Method to save employee details to file
    //        File.WriteAllText("emp.txt", $"Name: {Name}, Hours: {HoursWorked}, Hourly Rate: {HourlyRate}");

    //        Console.WriteLine("Employee data is saved to file.");
    //    }

    //    public decimal CalculateSalary()
    //    {
    //        //Method to calculate salary
    //        return HoursWorked * HourlyRate;
    //    }
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");

    //        Employee emp = new Employee()
    //        {
    //            Name = "John",
    //            HourlyRate = 20,
    //            HoursWorked = 40
    //        };

    //        emp.SaveToFile(); //It will work, But it Violates SRP because it is not related to particular Employee,
    //                          //it can be created separately

    //        Console.WriteLine("Salary: " + emp.CalculateSalary()); //It will work, But it Violates SRP because it is not related to particular Employee,
    //                                                               //it can be created separately
    //    }
    //}

    /*  It will work fine but it is not following SRP*/

    /* Solution based on SRP */
    public class Employee
    {
        //Only properties related to Employee
        public string? Name { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
    }

    //Class for saving Employee data
    public class EmployeeDataSaver
    {
        public void SaveToFile(Employee emp)
        {
            File.WriteAllText("emp.txt", $"Name: {emp.Name}, Hours: {emp.HoursWorked}, Hourly Rate: {emp.HourlyRate}");

            Console.WriteLine("Employee saved to file.");
        }
    }

    //class for Calculating Employe Salary
    public class SalaryCalculator
    {
        public decimal CalculateSalary(Employee emp)
        {
            return emp.HourlyRate * emp.HoursWorked;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Employee emp = new Employee()
            {
                Name = "John",
                HourlyRate = 20,
                HoursWorked = 40
            };

            //Saving Employee Data to file using dedicated file
            EmployeeDataSaver empDataSaver = new EmployeeDataSaver();
            empDataSaver.SaveToFile(emp);

            //Calculating Salary using dedicated file
            SalaryCalculator salaryCalc = new SalaryCalculator();
            Console.WriteLine("Salary: " + salaryCalc.CalculateSalary(emp));
        }
    }
}
