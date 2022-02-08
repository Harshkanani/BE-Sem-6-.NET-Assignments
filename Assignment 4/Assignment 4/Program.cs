using System;
using System.Reflection;

namespace Assignment_4
{
    //Properties with Backing Fields
    class TimePeriod
    {
        private double _seconds;

        public double Hours
        {
            get { return _seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 and 24.");

                _seconds = value * 3600;
            }
        }
    }

    //Expression body definition
    public class Person
    {
        private string _firstName;
        private string _lastName;

        public Person(string first, string last)
        {
            _firstName = first;
            _lastName = last;
        }

        public string Name => $"{_firstName} {_lastName}";
    }

    //Example
    public class SaleItem
    {
        string _name;
        decimal _cost;

        public SaleItem(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _cost;
            set => _cost = value;
        }
    }

    //Auto-implemented properties
    public class SalesItem
    {
        public string Name
        { get; set; }

        public decimal Price
        { get; set; }
    }

    //Indexers
    //Example 1
    public class TempRecord
    {
        // Array of temperature values
        float[] temps = new float[10]
        {
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
        };

        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
    }

    //Using a string as an indexer value
    class DayCollection
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

        // Indexer with only a get accessor with the expression-bodied definition:
        public int this[string day] => FindDayIndex(day);

        private int FindDayIndex(string day)
        {
            for (int j = 0; j < days.Length; j++)
            {
                if (days[j] == day)
                {
                    return j;
                }
            }

            throw new ArgumentOutOfRangeException(
                nameof(day),
                $"Day {day} is not supported.\nDay input must be in the form \"Sun\", \"Mon\", etc");
        }
    }


    //Question 1
    internal class Employee
    {
        string first_name;
        string last_name;
        double monthly_salary;

        //Default Constructor
        internal Employee()
        {
            first_name = "Harsh";
            last_name = "Kanani";
            monthly_salary = 40000;
        }

        //Parameterized Constructor
        internal Employee(string f_name, string l_name, double sal)
        {
            this.first_name = f_name;
            this.last_name = l_name;
            this.monthly_salary = sal;
        }

        //Properties
        internal string First_Name
        {
            get => this.first_name;
            set => this.first_name = value;
        }

        internal string Last_Name
        {
            get => this.last_name;
            set => this.last_name = value;
        }

        internal double Salary
        {
            get => this.monthly_salary;
            set => this.monthly_salary = value < 0 ? 0.0 : value;
        }

        internal (string, string, double) Property_Initializer
        {
            get => (this.first_name, this.last_name, this.monthly_salary);
            set {
                if (value.Item3 > 0) {
                    this.first_name = value.Item1;
                    this.last_name = value.Item2;
                    this.monthly_salary = value.Item3;
                } else {
                    this.first_name = value.Item1;
                    this.last_name = value.Item2;
                    this.monthly_salary = 0.0;
                }
            }
        }

        internal virtual double giveRaise(double raise)
        {
            this.monthly_salary = this.monthly_salary + ((monthly_salary * raise) / 100);
            return this.monthly_salary;
        }

        public override string ToString()
        {
            return $"First Name : {this.first_name} , Last Name : {this.last_name} , Monthly Salary : {this.monthly_salary}";
        }
    }


    //Question 2
    internal class PermanentEmployee : Employee
    {
        double housing_rent_allowance;
        double dearness_allowance;
        double provident_fund;

        DateTime joining_date;
        DateTime retirement_date;

        internal PermanentEmployee(string f_name, string l_name, double sal, double hra, double da, double pf ,DateTime join_date, DateTime retire_date) : base(f_name , l_name, sal)
        {
            this.housing_rent_allowance = hra;
            this.dearness_allowance = da;
            this.provident_fund = pf;
            this.joining_date = join_date;
            this.retirement_date = retire_date;
            base.Salary = base.Salary + HRA + DA;
        }

        //Properties
        internal double HRA
        {
            get => this.housing_rent_allowance;
        }

        internal double DA
        {
            get => this.dearness_allowance;
        }

        internal double PF
        {
            get => this.provident_fund;
        }

        internal DateTime JD
        {
            get => this.joining_date;
            set => this.joining_date = value;
        }

        internal DateTime RD
        {
            get => this.retirement_date;
            set => this.retirement_date = value;
        }

        //Overriden + Overloaded
        internal override double giveRaise(double raise)
        {
            return base.Salary = base.Salary + ((base.Salary* raise) / 100) + this.HRA + this.DA;
        }

        //Overloaded
        internal double giveRaise(int raise)
        {
            return base.Salary = base.Salary + raise + this.HRA + this.DA;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nJoining Date : {this.JD} , Retirement Date : {this.RD}";
        }
    }

    public class SimpleClass 
    { 
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Harsh Kanani : {now}\n");

            //Properties
            //Properties with Backing Fields
            {
                Console.WriteLine("\nProperties and its variants -> \n");
                Console.WriteLine("Properties with backing fields");
                TimePeriod t = new TimePeriod();
                // The property assignment causes the 'set' accessor to be called.
                t.Hours = 24;

                // Retrieving the property causes the 'get' accessor to be called.
                Console.WriteLine($"Time in hours: {t.Hours}");
            }

            //Expression body definition
            {
                Console.WriteLine("\nExpression body definition");
                var person = new Person("Magnus", "Hedlund");
                Console.WriteLine(person.Name);
            }

            //Example
            {
                Console.WriteLine("\nExample");
                var item = new SaleItem("Shoes", 19.95m);
                Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
            }

            //Auto-implemented properties
            {
                Console.WriteLine("\nAuto-implemented properties");
                var item = new SalesItem { Name = "Shoes", Price = 19.95m };
                Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
            }

            //Indexers
            //Example 1
            {
                Console.WriteLine("\nIndexers -> \n");
                Console.WriteLine("Example 1");
                var tempRecord = new TempRecord();

                // Use the indexer's set accessor
                tempRecord[3] = 58.3F;
                tempRecord[5] = 60.1F;

                // Use the indexer's get accessor
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Element #{i} = {tempRecord[i]}");
                }
            }

            //Using a string as an indexer value
            {
                Console.WriteLine("\nExample 2 : Using a string as an indexer value");
                var week = new DayCollection();
                Console.WriteLine(week["Fri"]);

                try
                {
                    Console.WriteLine(week["Made-up day"]);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Not supported input: {e.Message}");
                }
            }

            //Simple Class
            {
                Console.WriteLine("\nSimple Class\n");

                Type t = typeof(SimpleClass);
                BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                     BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
                MemberInfo[] members = t.GetMembers(flags);
                Console.WriteLine($"Type {t.Name} has {members.Length} members: ");
                foreach (var member in members)
                {
                    string access = "";
                    string stat = "";
                    var method = member as MethodBase;
                    if (method != null)
                    {
                        if (method.IsPublic)
                            access = " Public";
                        else if (method.IsPrivate)
                            access = " Private";
                        else if (method.IsFamily)
                            access = " Protected";
                        else if (method.IsAssembly)
                            access = " Internal";
                        else if (method.IsFamilyOrAssembly)
                            access = " Protected Internal ";
                        if (method.IsStatic)
                            stat = " Static";
                    }
                    var output = $"{member.Name} ({member.MemberType}): {access}{stat}, Declared by {member.DeclaringType}";
                    Console.WriteLine(output);
                }
            }

            //Question 1
            {
                Console.WriteLine("\nQuestion 1 ->\n");
                Employee emp1 = new Employee();
                Employee emp2 = new Employee();

                emp2.Property_Initializer = ("A","B",-500d);

                Console.WriteLine($"\nEmployee 1 -> {emp1}");
                Console.WriteLine($"Employee 2 -> {emp2}");

                Console.WriteLine($"\nYearly Salary of {emp1.First_Name} is {emp1.Salary * 12}");
                Console.WriteLine($"Yearly Salary of {emp2.First_Name} is {emp2.Salary* 12}");

                Console.WriteLine($"\n{emp1.First_Name}, Your salary after raise is {emp1.giveRaise(10d) * 12}");
                Console.WriteLine($"{emp2.First_Name}, Your salary after raise is {emp2.giveRaise(10d) * 12}");
            }

            //Question 2
            {
                Console.WriteLine("\nQuestion 2 ->\n");

                PermanentEmployee pm1 = new PermanentEmployee("Harsh", "Kanani", 50000, 5000, 3000, 4000, new DateTime(2018, 12, 25, 10, 00, 00), new DateTime(2014, 2, 7, 11, 00, 00));
                Console.WriteLine(pm1);
                Console.WriteLine($"\n{pm1.First_Name}, Your salary after raise is {pm1.giveRaise(8d) * 12}");

                PermanentEmployee pm2 = new PermanentEmployee("Tushar", "Gangani", 70000, 7000, 2000, 7000, new DateTime(2017, 11, 30, 12, 00, 00), new DateTime(2016, 5, 17, 11, 00, 00));
                Console.WriteLine(pm2);
                Console.WriteLine($"\n{pm2.First_Name}, Your salary after raise is {pm2.giveRaise(5000) * 12}");
            }
        }
    }
}
