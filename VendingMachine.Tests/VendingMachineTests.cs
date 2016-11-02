using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachines.Core;

namespace VendingMachines.Tests
{
    public class VendingMachineTests
    {
        protected IEnumerable<IMoney> _returnedCoins;

        private readonly Lazy<VendingMachine> _vendingMachine = new Lazy<VendingMachine>(() => new VendingMachine());

        protected VendingMachine VendingMachine => _vendingMachine.Value;

        protected decimal SumValueOfCoins(IEnumerable<IMoney> result)
        {
            return result.Aggregate(0m, (acc, coin) => acc + coin.Value);
        }

        public class FakeCoin : IMoney
        {
            public decimal Value => 0.37m;
        }
    }
}