using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendingMachines.Core
{
    public class VendingMachine
    {
        public ICollection<object> TakeOutTray { get; }
        private readonly MoneyBox _moneyBox = new MoneyBox();


        public VendingMachine()
        {
            TakeOutTray = new Collection<object>();
        }
        
        public IEnumerable<Coin> CoinReturn()
        {
            if (_moneyBox.IsEmpty)
                return null;

            return _moneyBox.ReturnBalanceAsCoins();
        }
        
        public void InsertCoin(Coin coin)
        {
            _moneyBox.InsertCoin(coin);
        }
        
        public void MakeSelection(VendingSelection selection)
        {
            if (_moneyBox.TryMakeSale(selection))
            {
                TakeOutTray.Add(selection.CreateItem());
            }
        }
    }
}
