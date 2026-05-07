using System;
using System.Collections.Generic;

namespace project01
{
    // Base Class
    class Employee
    {
        // Private Fields
        private int id;
        private double salary;

        // Public Properties with Validation
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("ID must be greater than 0.");
                }
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Salary cannot be negative.");
                }
            }
        }

        // Additional Public Members
        public string Name { get; set; }
        public string Department { get; set; }

        // Constructor
        public Employee(int id, string name, string department, double salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }

        // Virtual Method
        public virtual void Work()
        {
            Console.WriteLine("Employee is working");
        }

        // Display Information
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    // Derived Class: Developer
    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(int id, string name, string department,
                         double salary, string programmingLanguage)
            : base(id, name, department, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        // Override Work Method
        public override void Work()
        {
            Console.WriteLine("Developer is writing code");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }

    // Derived Class: Designer
    class Designer : Employee
    {
        public string DesignTool { get; set; }

        public Designer(int id, string name, string department,
                        double salary, string designTool)
            : base(id, name, department, salary)
        {
            DesignTool = designTool;
        }

        // Override Work Method
        public override void Work()
        {
            Console.WriteLine("Designer is creating UI designs");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Design Tool: {DesignTool}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Polymorphism using List<Employee>
            List<Employee> employees = new List<Employee>();

            employees.Add(new Developer(
                1,
                "Ahmed",
                "IT",
                1200,
                "C#"
            ));

            employees.Add(new Designer(
                2,
                "Sara",
                "Creative",
                1000,
                "Figma"
            ));

            // Loop through employees
            foreach (Employee emp in employees)
            {
                emp.DisplayInfo();
                emp.Work();
                Console.WriteLine("-------------------");
            }

            // Encapsulation Validation Example
            Developer dev = new Developer(0, "Ali", "IT", -500, "Java");

            Console.ReadLine();
        }
    }
}