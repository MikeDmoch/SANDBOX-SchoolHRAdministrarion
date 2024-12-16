using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANDBOX_SchoolHRAdministrarion
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    internal class Programs
    {
        static void Main(string[] args)
        {
            //decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            /// without Linq
            //foreach (IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            //Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");

            /// using Linq 
            Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)}");

            Console.ReadKey();
        }
        public static void SeedData(List<IEmployee> employees)
        {
            //IEmployee teacher1 = new Teacher
            //{
            //    Id = 1,
            //    FirstName = "Anna",
            //    LastName = "Brown",
            //    Salary = 50000
            //};
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Anna", "Brown", 50000);
            employees.Add(teacher1);

            //IEmployee teacher2 = new Teacher
            //{
            //    Id = 2,
            //    FirstName = "Mark",
            //    LastName = "Hoggins",
            //    Salary = 40000
            //};
            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Mark", "Hoggins", 40000);
            employees.Add(teacher2);

            //IEmployee headOfDepartment = new HeadOfDepartment
            //{
            //    Id = 3,
            //    FirstName = "Thomas",
            //    LastName = "Rock",
            //    Salary = 60000
            //};
            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Thomas", "Rock", 60000);
            employees.Add(headOfDepartment);

            //IEmployee deputyHeadMaster = new DeputyHeadMaster
            //{
            //    Id = 4,
            //    FirstName = "Martha",
            //    LastName = "Black",
            //    Salary = 65000
            //};
            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Martha", "Black", 65000);
            employees.Add(deputyHeadMaster);

            //IEmployee headMaster = new HeadMaster
            //{
            //    Id = 5,
            //    FirstName = "Olaf",
            //    LastName = "Bond",
            //    Salary = 80000
            //};
            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Olaf", "Bond", 80000);
            employees.Add(headMaster);
        }
    }
    public class Teacher : EmployeeBase
    {
        public override decimal Salary
        {
            get => base.Salary * 1.02m;            
        }
         
    }
    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary
        {
            get => base.Salary * 1.03m;
        }
    }
    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary
        {
            get => base.Salary * 1.04m;
        }
    }
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary
        {
            get => base.Salary * 1.05m;
        }
    }
    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstname, string lastname, decimal salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    //employee = new Teacher { Id = id, FirstName = firstname, LastName = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    //employee = new HeadOfDepartment { Id = id, FirstName = firstname, LastName = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    //employee = new DeputyHeadMaster { Id = id, FirstName = firstname, LastName = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    //employee = new HeadMaster { Id = id, FirstName = firstname, LastName = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstname;
                employee.LastName = lastname;
                employee.Salary = salary;
            }
            return employee;
        }
    }
}
