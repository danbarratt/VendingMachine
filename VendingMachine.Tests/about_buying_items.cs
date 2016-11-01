using System.Linq;
using VendingMachines.Core;
using Xunit;

namespace VendingMachines.Tests.about_buying_items
{
    public class when_no_coins_have_been_inserted : VendingMachineTests
    {
        [Fact]
        public void item_a_cannot_be_bought()
        {
            VendingMachine.MakeSelection(VendingSelection.ItemA);

            Assert.Empty(VendingMachine.TakeOutTray);
        }

        [Fact]
        public void item_b_cannot_be_bought()
        {
            VendingMachine.MakeSelection(VendingSelection.ItemB);

            Assert.Empty(VendingMachine.TakeOutTray);
        }

        [Fact]
        public void item_c_cannot_be_bought()
        {
            VendingMachine.MakeSelection(VendingSelection.ItemC);

            Assert.Empty(VendingMachine.TakeOutTray);
        }
    }


    public class when_not_enough_coins_have_been_added : VendingMachineTests
    {
        public when_not_enough_coins_have_been_added()
        {
            VendingMachine.InsertCoin(new Coin(0.05));

            VendingMachine.MakeSelection(VendingSelection.ItemA);

            _returnedCoins = VendingMachine.CoinReturn();
        }

        [Fact]
        public void item_a_cannot_be_bought()
        {
            Assert.Empty(VendingMachine.TakeOutTray);
        }

        [Fact]
        public void the_same_value_of_coins_have_been_returned()
        {
            Assert.Equal(0.05m, SumValueOfCoins(_returnedCoins));
        }
    }


    public class when_enough_coins_for_item_A_have_been_inserted : VendingMachineTests
    {
        public when_enough_coins_for_item_A_have_been_inserted()
        {
            VendingMachine.InsertCoin(new Coin(0.25));
            VendingMachine.InsertCoin(new Coin(0.25));
            VendingMachine.InsertCoin(new Coin(0.25));

            VendingMachine.MakeSelection(VendingSelection.ItemA);

            _returnedCoins = VendingMachine.CoinReturn();
        }

        [Fact]
        public void item_A_is_in_the_takeout_tray()
        {
            Assert.IsType<ItemA>(VendingMachine.TakeOutTray.FirstOrDefault());
        }

        [Fact]
        public void no_coins_have_been_returned()
        {
            Assert.Null(_returnedCoins);
        }
    }


    public class when_enough_coins_for_item_A_and_item_B_have_been_inserted : VendingMachineTests
    {
        public when_enough_coins_for_item_A_and_item_B_have_been_inserted()
        {
            VendingMachine.InsertCoin(new Coin(1.85));

            VendingMachine.MakeSelection(VendingSelection.ItemA);
            VendingMachine.MakeSelection(VendingSelection.ItemB);

            _returnedCoins = VendingMachine.CoinReturn();
        }

        [Fact]
        public void there_are_2_items_in_the_takeout_tray()
        {
            Assert.Equal(2, VendingMachine.TakeOutTray.Count);
        }

        [Fact]
        public void item_A_is_in_the_takeout_tray()
        {
            Assert.IsType<ItemA>(VendingMachine.TakeOutTray.FirstOrDefault());
        }
        
        [Fact]
        public void no_coins_have_been_returned()
        {
            Assert.Null(_returnedCoins);
        }
    }
}
