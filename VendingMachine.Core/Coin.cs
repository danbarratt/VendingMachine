using System;

namespace VendingMachines.Core
{
    public interface IMoney
    {
        decimal Value { get; }
    }

    public struct Coin : IMoney
    {
        public static Coin Nickel  => new Coin(0.05m);
        public static Coin Dime    => new Coin(0.10m);
        public static Coin Quarter => new Coin(0.25m);
        public static Coin Dollar  => new Coin(1.00m);

        public decimal Value { get; }

        private Coin(decimal value)
        {
            Value = value;
        }
    }
}