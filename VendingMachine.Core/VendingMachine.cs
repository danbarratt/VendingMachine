using System;
using System.Collections;
using System.Collections.Generic;

namespace VendingMachines.Core
{
    public class VendingMachine
    {
        public double _enteredCoinValue;

        public IEnumerable<Coin> CoinReturn()
        {
            while (_enteredCoinValue > 0d)
            {
                if (_enteredCoinValue >= 0.25d)
                {
                    yield return new Coin(0.25);
                    _enteredCoinValue -= 0.25;
                }
                else if (_enteredCoinValue >= 0.10d)
                {
                    yield return new Coin(0.10);
                    _enteredCoinValue -= 0.10;
                }
                else
                {
                    throw new NotImplementedException("Not sure how to retfund: " + _enteredCoinValue);
                }
            }
        }

        public void InsertCoin(Coin coin)
        {
            _enteredCoinValue += coin.Value;
        }
    }

    public class Coin
    {
        public Coin(double value)
        {
            Value = value;
        }

        public double Value { get; set; }
    }
}
