using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using VendingMachines.Core;

namespace VendingMachines.Tests
{
    public class when_no_coins_have_been_inserted : VendingMachineTests
    {
        [Fact]
        public void the_coin_return_gives_nothing_back()
        {
            var result = VendingMachine.CoinReturn();

            Assert.Null(result);
        }
    }

    public class when_one_coin_has_been_inserted : VendingMachineTests
    {
        private readonly IEnumerable<Coin> _returnedCoins;

        public when_one_coin_has_been_inserted()
        {
            VendingMachine.InsertCoin(new Coin(0.25));

            _returnedCoins = VendingMachine.CoinReturn();
        }

        [Fact]
        public void one_coin_is_returned()
        {
            Assert.Equal(1, _returnedCoins.Count());
        }

        [Fact]
        public void the_coin_return_gives_back_the_same_value_of_coins()
        {
            Assert.Equal(0.25, SumValueOfCoins(_returnedCoins));
        }
    }

    public class when_two_coin_have_been_inserted : VendingMachineTests
    {
        private readonly IEnumerable<Coin> _returnedCoins;

        public when_two_coin_have_been_inserted()
        {
            VendingMachine.InsertCoin(new Coin(0.25));
            VendingMachine.InsertCoin(new Coin(0.10));

            _returnedCoins = VendingMachine.CoinReturn();
        }

        [Fact]
        public void two_coins_are_returned()
        {
            Assert.Equal(2, _returnedCoins.Count());
        }

        [Fact]
        public void the_coin_return_gives_back_the_same_value_of_coins_entered()
        {
            Assert.Equal(0.35, SumValueOfCoins(_returnedCoins));
        }
    }
}
