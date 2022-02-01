using System;

namespace Assignment_3
{
    [Flags]
    public enum Days
    {
        None = 0b_0000_0000, // 0
        Monday = 0b_0000_0001, // 1
        Tuesday = 0b_0000_0010, // 2
        Wednesday = 0b_0000_0100, // 4
        Thursday = 0b_0000_1000, // 8
        Friday = 0b_0001_0000, // 16
        Saturday = 0b_0010_0000, // 32
        Sunday = 0b_0100_0000, // 64
        Weekend = Saturday | Sunday
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            {
                int numerator, denom, whole_no;
                float float_quo;

                //Inputs
                Console.WriteLine("Enter Numerator : ");
                numerator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Denominator : ");
                denom = Convert.ToInt32(Console.ReadLine());
                
                //Int Division
                int int_quo = numerator / denom;
                int int_rem = numerator % denom;
                Console.WriteLine("Integer division result = {0} with a remainder {1}", int_quo, int_rem);

                //Float Division
                float_quo = (float)numerator / denom;
                Console.WriteLine("Floating point division result = {0}", float_quo);

                //Mixed Fraction
                if (numerator >= denom)
                {
                    whole_no = numerator / denom;
                    numerator = numerator % denom;
                    Console.WriteLine("The result as a mixed fraction is {0} {1}/{2}", whole_no, numerator, denom);
                }
                else if (numerator % denom == 0)
                {
                    whole_no = numerator / denom;
                    Console.WriteLine("The result as a mixed fraction is {0}", whole_no);
                }
            }

            //Question 2
            {
                //Part 1
                string str;

                Console.WriteLine("Enter String:");
                str = Console.ReadLine();

                Console.WriteLine($"String : {str}\nLength of String: {str.Length}");

                //Part 2
                string sentance;
                Console.WriteLine("Enter Sentance:");
                str = Console.ReadLine();

                if(str.EndsWith('.')){
                    Console.WriteLine("This is declarative sentence");
                }
                else if(str.EndsWith('?')){
                    Console.WriteLine("This is interrogatory sentence");
                }
                else if(str.EndsWith('!')){
                    Console.WriteLine("This is exclamation sentence");
                }
                else {
                    Console.WriteLine("This is unknown sentance");
                }

                //Part 3
                string fullName;
                Console.WriteLine("Enter your Name:");
                fullName = Console.ReadLine();

                String[] name = fullName.Split(' ');
                if (name.Length == 1)
                {
                    Console.WriteLine($"Your Name: {name[0]}");
                }
                else
                {
                    Console.WriteLine($"Your Name: {name[1]}, {name[0]}");
                }

            }

            //Question 3
            {
                Days meetingDays = Days.Tuesday | Days.Thursday;
                Console.WriteLine(meetingDays);

                Days workingFromHomeDays = Days.Thursday | Days.Saturday;
                Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");

                bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
                Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");

                var a = (Days)93;
                Console.WriteLine(a);
            }
        }
    }
}
