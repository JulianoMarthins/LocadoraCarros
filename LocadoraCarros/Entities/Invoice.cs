using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros.Entities
{
    internal class Invoice
    {
        public double basicPayment { get; set; }
        public double tax { get; set; } 


        public Invoice(double basicPayment, double tax)
        {
            this.basicPayment = basicPayment;
            this.tax = tax;
        }

        public double TotalPayment
        {
            get
            {
                return this.basicPayment + tax;
            }
        }

        public override string ToString()
        {
            string mensage = $"Basic Payment: {this.basicPayment.ToString("F2")}\nTax: {this.tax.ToString("F2")}\n" +
                $"Total payment: {this.TotalPayment.ToString("F2")}";

            return mensage;
        }


    }
}
