using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachines.Core;

namespace VendingMachines.Tests
{
    public class VendingMachineTests
    {
        private readonly Lazy<VendingMachine> _vendingMachine = new Lazy<VendingMachine>(() => new VendingMachine());

        protected VendingMachine VendingMachine => _vendingMachine.Value;

        protected decimal SumValueOfCoins(IEnumerable<Coin> result)
        {
            return result.Aggregate(0m, (acc, coin) => acc + coin.Value);
        }
    }
}