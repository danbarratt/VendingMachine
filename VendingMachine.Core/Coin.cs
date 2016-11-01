using System;

namespace VendingMachines.Core
{
    public class Coin
    {
        public Coin(decimal value)
        {
            Value = value;
        }

        public Coin(double value) : this((decimal) Convert.ToDecimal(value))
        {
        }

        public decimal Value { get; set; }
    }
}