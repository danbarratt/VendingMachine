using System.Linq;
using VendingMachines.Core;
using Xunit;

namespace VendingMachines.Tests.about_inserting_coins
{
    public class when_inserting_a_nickel : VendingMachineTests
    {
        [Fact]
        public void only_a_nickel_is_returned()
        {
            VendingMachine.InsertCoin(Coin.Nickel);

            Assert.Equal(Coin.Nickel, VendingMachine.CoinReturn().Single());
        }
    }

    public class when_inserting_a_dime : VendingMachineTests
    {
        [Fact]
        public void only_a_dime_is_returned()
        {
            VendingMachine.InsertCoin(Coin.Dime);

            Assert.Equal(Coin.Dime, VendingMachine.CoinReturn().Single());
        }
    }

    public class when_inserting_a_quarter : VendingMachineTests
    {
        [Fact]
        public void only_a_dime_is_returned()
        {
            VendingMachine.InsertCoin(Coin.Quarter);

            Assert.Equal(Coin.Quarter, VendingMachine.CoinReturn().Single());
        }
    }

    public class when_inserting_a_dollar : VendingMachineTests
    {
        [Fact]
        public void only_a_dime_is_returned()
        {
            VendingMachine.InsertCoin(Coin.Dollar);

            Assert.Equal(Coin.Dollar, VendingMachine.CoinReturn().Single());
        }
    }

    // Made up coins cannot be used
}
