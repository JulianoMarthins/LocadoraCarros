using LocadoraCarros.Entities;
using LocadoraCarros.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter rental data");
            
            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Pickup (dd/mm/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm" ,CultureInfo.InvariantCulture);

            Console.Write("Return (dd/mm/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("\nEnter price per hour: ");
            double hour = double.Parse(Console.ReadLine());

            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine());


            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("\n\nInvoice: ");
            Console.WriteLine(carRental.invoice.ToString());

            

        }
    }
}
