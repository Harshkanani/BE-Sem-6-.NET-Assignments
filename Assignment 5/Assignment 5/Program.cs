using System;
using System.Collections.Generic;

namespace Assignment_5
{
    public interface IVehicle
    {
        internal enum Renttype
        {
            KM, Day
        }

        public decimal CalculateRent(int Units);
        public void getDetails();
        public DateTime getLastMaintenanceDate();
    }

    internal class Indica : IVehicle
    {
        internal string? type, number;
        internal IVehicle.Renttype renttype;
        internal int age, rentperunit, seater;
        internal DateTime last_maintenance_date;

        internal Indica(string type, int seater, string number, IVehicle.Renttype rentType, int age, int rentperunit, DateTime last_maintenance_date)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            renttype = rentType;
            this.age = age;
            this.rentperunit = rentperunit;
            this.last_maintenance_date = last_maintenance_date;
        }

        public decimal CalculateRent(int Units)
        {
            return (decimal)rentperunit * Units;
        }

        public void getDetails()
        {
            Console.Write("\nBrand : Indica \n");
            Console.Write($"Car Number : {number}\n");
            Console.Write($"Total Seats : {seater}\n");
            Console.Write($"Type : {type}\n");
            Console.Write($"Car age : {age}\n");
            Console.Write($"Rent per unit : {rentperunit}\n");

        }

        public DateTime getLastMaintenanceDate()
        {
            return last_maintenance_date;
        }
    }

    internal class Qualis : IVehicle
    {
        internal string? type, number;
        internal IVehicle.Renttype renttype;
        internal int age, rentperunit, seater;
        internal DateTime last_maintenance_date;

        internal Qualis(string type, int seater, string number, IVehicle.Renttype rentType, int age, int rentperunit, DateTime last_maintenance_date)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            renttype = rentType;
            this.age = age;
            this.rentperunit = rentperunit;
            this.last_maintenance_date = last_maintenance_date;
        }

        public decimal CalculateRent(int Units)
        {
            return (decimal)rentperunit * Units;
        }

        public void getDetails()
        {
            Console.Write("\nBrand : Qualis \n");
            Console.Write($"Car Number : {number}\n");
            Console.Write($"Total Seats : {seater}\n");
            Console.Write($"Type : {type}\n");
            Console.Write($"Car age : {age}\n");
            Console.Write($"Rent per unit : {rentperunit}\n");

        }

        public DateTime getLastMaintenanceDate()
        {
            return last_maintenance_date;
        }
    }

    internal class HarleyDavid : IVehicle
    {
        internal string? type, number;
        internal IVehicle.Renttype renttype;
        internal int age, rentperunit, seater;
        internal DateTime last_maintenance_date;

        internal HarleyDavid(string type, int seater, string number, IVehicle.Renttype rentType, int age, int rentperunit, DateTime last_maintenance_date)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            renttype = rentType;
            this.age = age;
            this.rentperunit = rentperunit;
            this.last_maintenance_date = last_maintenance_date;
        }

        public decimal CalculateRent(int Units)
        {
            return (decimal)rentperunit * Units;
        }

        public void getDetails()
        {
            Console.Write("\nBrand : HarleyDavid \n");
            Console.Write($"Car Number : {number}\n");
            Console.Write($"Total Seats : {seater}\n");
            Console.Write($"Type : {type}\n");
            Console.Write($"Car age : {age}\n");
            Console.Write($"Rent per unit : {rentperunit}\n");

        }

        public DateTime getLastMaintenanceDate()
        {
            return last_maintenance_date;
        }
    }

    internal class MercedesBenz : IVehicle
    {
        internal string? type, number;
        internal IVehicle.Renttype renttype;
        internal int age, rentperunit, seater;
        internal DateTime last_maintenance_date;

        internal MercedesBenz(string type, int seater, string number, IVehicle.Renttype rentType, int age, int rentperunit, DateTime last_maintenance_date)
        {
            this.type = type;
            this.seater = seater;
            this.number = number;
            renttype = rentType;
            this.age = age;
            this.rentperunit = rentperunit;
            this.last_maintenance_date = last_maintenance_date;
        }

        public decimal CalculateRent(int Units)
        {
            return (decimal)rentperunit * Units;
        }

        public void getDetails()
        {
            Console.Write("\nBrand : HarleyDavid \n");
            Console.Write($"Car Number : {number}\n");
            Console.Write($"Total Seats : {seater}\n");
            Console.Write($"Type : {type}\n");
            Console.Write($"Car age : {age}\n");
            Console.Write($"Rent per unit : {rentperunit}\n");

        }

        public DateTime getLastMaintenanceDate()
        {
            return last_maintenance_date;
        }
    }

    public class CarType<T>
    {
        internal T carobj;
        internal DateTime startDate, endDate;
        internal int Units;
        internal decimal advPayment;

        internal CarType(T carobj, DateTime startDate, DateTime endDate, decimal advPayment)
        {
            this.carobj = carobj;
            this.advPayment = advPayment;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        internal CarType(T carobj)
        {
            this.carobj = carobj;
        }

        internal int CalculateDays()
        {
            int year = endDate.Year - startDate.Year;
            int month = endDate.Month - startDate.Month;
            int day = endDate.Day - startDate.Day;

            return year + month + day;
        }
    }

    internal class RentedVehicle<T>
    {

        List<CarType<T>> Vehiclelist;

        internal RentedVehicle()
        {

            Vehiclelist = new List<CarType<T>>();
        }

        internal void AddVehicle(T carobj)
        {

            CarType<T> c = new CarType<T>(carobj);
        }

        internal void GiveForRent(T carobj, DateTime startDate, DateTime endDate, decimal adv_pay)
        {

            CarType<T> c = new CarType<T>(carobj, startDate, endDate, adv_pay);
            Vehiclelist.Add(c);
        }

        internal decimal CalculateRent(T carobj, int Units)
        {

            foreach (CarType<T> c in Vehiclelist)
            {

                if (c.carobj!.Equals(carobj))
                {

                    c.Units = Units;
                    return ((IVehicle)carobj).CalculateRent(Units) - c.advPayment;
                }
            }

            return 0;
        }


        internal decimal CalculateTotalRentToday(T carobj, int TrvaelUnits)
        {

            foreach (CarType<T> c in Vehiclelist)
            {

                if (c.carobj!.Equals(carobj))
                {

                    return (((IVehicle)carobj).CalculateRent(TrvaelUnits) - c.advPayment) / c.CalculateDays();
                }
            }

            return 0;
        }

        internal void GetCheckListRentedVehicle()
        {

            foreach (CarType<T> c in Vehiclelist)
            {

                ((IVehicle)c.carobj!).getDetails();
                Console.Write($"\nRented From {c.startDate.ToShortDateString()} to {c.endDate.ToShortDateString()}");
            }
        }

        internal bool CheckVehiclesInMaintenance(T carobj)
        {

            DateTime today = DateTime.Now;

            foreach (CarType<T> c in Vehiclelist)
            {

                IVehicle car = ((IVehicle)c.carobj!);
                if (c.carobj!.Equals(carobj) && car.getLastMaintenanceDate().CompareTo(today) > 0)
                    return true;
            }

            return false;
        }

        internal void ShowAvailableByDate(DateTime date)
        {

            Console.Write($"\n\nAvailable Vehicles on {date}");

            foreach (CarType<T> c in Vehiclelist)
            {

                if (c.startDate.CompareTo(date) > 0)
                {

                    ((IVehicle)c.carobj!).getDetails();
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Indica i1 = new Indica("Petrol", 5, "GJ-05-RS-1204", IVehicle.Renttype.Day, 25, 7, new DateTime(2021, 1, 2));

            MercedesBenz mb1 = new MercedesBenz("Diesel", 7, "GJ-014-SE-4582", IVehicle.Renttype.KM, 7, 3000, new DateTime(2022, 01, 21));

            Qualis q1 = new Qualis("Petrol", 7, "KN-12-HR-3105", IVehicle.Renttype.KM, 16, 4, new DateTime(2021, 4, 6));

            Qualis q2 = new Qualis("CNG", 4, "DL-08-FW-7222", IVehicle.Renttype.Day, 12, 17, new DateTime(2021, 3, 17));

            MercedesBenz mb2 = new MercedesBenz("Diesel", 7, "GJ-03-VC-2390", IVehicle.Renttype.Day, 12, 4000, new DateTime(2021, 2, 7));

            RentedVehicle<IVehicle> rv = new RentedVehicle<IVehicle>();

            rv.AddVehicle(i1);
            rv.AddVehicle(mb1);
            rv.AddVehicle(q1);
            rv.AddVehicle(q2);
            rv.AddVehicle(mb2);

            rv.GiveForRent(i1, new DateTime(2021, 1, 10), new DateTime(2021, 1, 27), 10);
            rv.GiveForRent(q2, new DateTime(2021, 10, 23), new DateTime(2021, 10, 27), 800);
            rv.GiveForRent(mb2, new DateTime(2022, 09, 05), new DateTime(2022, 09, 29), 1500);

            Console.Write("\nTotal rent per day for the given car ->");
            q2.getDetails();

            Console.Write($"\n\nTotal rent per day : {rv.CalculateTotalRentToday(mb2, 5):C2}");

            Console.Write("\n===================================================================");

            Console.Write("\n\nVehicles available before 3-April-2022 are ->");


            rv.ShowAvailableByDate(new DateTime(2022, 4, 3));

            Console.Write("\n===================================================================");

            Console.Write("\n\nVehicles that are currently rented are ->\n");

            rv.GetCheckListRentedVehicle();
        }
    }
}
