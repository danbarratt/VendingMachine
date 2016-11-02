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
}