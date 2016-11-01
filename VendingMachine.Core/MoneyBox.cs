using System;
using System.Collections.Generic;

namespace VendingMachines.Core
{
    public class MoneyBox
    {
        private decimal _currentBalance;


        public bool IsEmpty => _currentBalance == 0m;


        public void InsertCoin(Coin coin)
        {
            _currentBalance += coin.Value;
        }

        public bool TryMakeSale(VendingSelection selection)
        {
            if (_currentBalance < selection.Price)
                return false;
            
            _currentBalance -= selection.Price;

            return true;
        }

        public IEnumerable<Coin> ReturnBalanceAsCoins()
        {
            while (_currentBalance > 0m)
            {
                yield return TryRefundCoin(ref _currentBalance, Coin.Dollar) ??
                             TryRefundCoin(ref _currentBalance, Coin.Quarter) ??
                             TryRefundCoin(ref _currentBalance, Coin.Dime) ??
                             TryRefundCoin(ref _currentBalance, Coin.Nickel) ??
                             AssertInvalidCoinValue();
            }
        }

        private Coin AssertInvalidCoinValue()
        {
            throw new ArithmeticException("Not sure how to refund: " + _currentBalance);
        }

        private static Coin? TryRefundCoin(ref decimal currentBalance, Coin coin)
        {
            if (currentBalance >= coin.Value)
            {
                currentBalance -= coin.Value;
                return coin;
            }

            return null;
        }
    }
}