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
                yield return TryRefundCoin(Coin.Dollar) ??
                             TryRefundCoin(Coin.Quarter) ??
                             TryRefundCoin(Coin.Dime) ??
                             TryRefundCoin(Coin.Nickel) ??
                             AlertCoinNotRecognised();
            }
        }

        private Coin AlertCoinNotRecognised()
        {
            throw new ArithmeticException("Not sure how to refund: " + _currentBalance);
        }

        private Coin? TryRefundCoin(Coin coin)
        {
            if (_currentBalance < coin.Value)
                return null;

            _currentBalance -= coin.Value;
            return coin;
        }
    }
}