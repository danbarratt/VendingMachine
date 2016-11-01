using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendingMachines.Core
{
    public class VendingMachine
    {
        private decimal _currentBalance;

        public ICollection<object> TakeOutTray { get; set; }


        public VendingMachine()
        {
            TakeOutTray = new Collection<object>();
        }


        public IEnumerable<Coin> CoinReturn()
        {
            if (_currentBalance == 0m)
                return null;

            var toReturn = new Collection<Coin>();

            while (_currentBalance > 0m)
            {
                var aCoin = TryRefundCoin(ref _currentBalance, 1.00m) ??
                            TryRefundCoin(ref _currentBalance, 0.25m) ??
                            TryRefundCoin(ref _currentBalance, 0.10m) ??
                            TryRefundCoin(ref _currentBalance, 0.05m) ??
                            AssertInvalidCoinValue();

                toReturn.Add(aCoin);
            }

            return toReturn;
        }


        private Coin AssertInvalidCoinValue()
        {
            throw new ArithmeticException("Not sure how to refund: " + _currentBalance);
        }
        
        private static Coin? TryRefundCoin(ref decimal currentBalance, decimal proposedCoinValue)
        {
            if (currentBalance >= proposedCoinValue)
            {
                currentBalance -= proposedCoinValue;
                return new Coin(proposedCoinValue);
            }

            return null;
        }


        public void InsertCoin(Coin coin)
        {
            _currentBalance += coin.Value;
        }


        public void MakeSelection(VendingSelection selection)
        {
            if (_currentBalance < selection.Price)
                return;

            TakeOutTray.Add(selection.CreateItem());
            _currentBalance -= selection.Price;
        }
    }
}
