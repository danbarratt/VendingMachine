using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VendingMachines.Core
{
    public class VendingMachine
    {
        public ICollection<object> TakeOutTray { get; }
        private readonly IMoneyBox _moneyBox = new MoneyBox();


        public VendingMachine()
        {
            TakeOutTray = new Collection<object>();
        }
        
        public IEnumerable<IMoney> CoinReturn()
        {
            if (_moneyBox.IsEmpty)
                return null;

            return _moneyBox.ReturnBalanceAsCoins();
        }
        
        public void InsertCoin(Coin coin)
        {
            _moneyBox.TryCreditBalance(coin);
        }
        
        public void MakeSelection(VendingSelection selection)
        {
            if (_moneyBox.TryDebitBalalnce(selection))
            {
                TakeOutTray.Add(selection.CreateItem());
            }
        }
    }
}
