using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros.Entities
{
    internal class Vehicle
    {
        public string model { get; set; }

        public Vehicle(string model)
        {
            this.model = model;
        }

    }
}
