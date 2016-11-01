using System;

namespace VendingMachines.Core
{
    public struct Coin
    {
        public Coin(decimal value)
        {
            Value = value;
        }

        public Coin(double value) : this((decimal) Convert.ToDecimal(value))
        {
        }

        public decimal Value { get; set; }

        public static Coin Nickel  => new Coin(0.05m);
        public static Coin Dime    => new Coin(0.10m);
        public static Coin Quarter => new Coin(0.25m);
        public static Coin Dollar  => new Coin(1.00m);
    }
}