using LocadoraCarros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros.Services
{
    internal class RentalService
    {
        public double pricePerHour { get; private set; }
        public double pricePerDay { get; private set; }

        private BrazilTaxServices _brazilTaxService = new BrazilTaxServices();


        public RentalService(double pricePerHour, double pricePerDay)
        {
            this.pricePerHour = pricePerHour;
            this.pricePerDay = pricePerDay;
        }


        
        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.finish.Subtract(carRental.start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12)
            {
                basicPayment = pricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else 
            {
                // O metodo Ceiling da biblioteca Math realiza arredondamento para cima dos números.
                basicPayment = pricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxService.Tax(basicPayment);

            carRental.invoice = new Invoice(basicPayment, tax);

        }

    }
}
