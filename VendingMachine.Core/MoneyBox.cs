using System;
using System.Collections.Generic;

namespace VendingMachines.Core
{
    public interface IMoneyBox
    {
        bool IsEmpty { get; }

        void TryCreditBalance(IMoney money);

        bool TryDebitBalalnce(VendingSelection selection);

        IEnumerable<IMoney> ReturnBalanceAsCoins();
    }

    public class MoneyBox : IMoneyBox
    {
        private decimal _currentBalance;


        public bool IsEmpty => _currentBalance == 0m;


        public void TryCreditBalance(IMoney money)
        {
            _currentBalance += money.Value;
        }

        public bool TryDebitBalalnce(VendingSelection selection)
        {
            if (_currentBalance < selection.Price)
                return false;
            
            _currentBalance -= selection.Price;

            return true;
        }

        public IEnumerable<IMoney> ReturnBalanceAsCoins()
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