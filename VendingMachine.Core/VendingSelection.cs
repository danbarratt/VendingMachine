using System;

namespace VendingMachines.Core
{
    public struct VendingSelection
    {
        public static VendingSelection ItemA => new VendingSelection(0.75m, typeof(ItemA));
        public static VendingSelection ItemB => new VendingSelection(1.10m, typeof(ItemB));
        public static VendingSelection ItemC => new VendingSelection(1.65m, typeof(ItemC));

        public decimal Price { get; }
        private Type ItemForSale { get; }

        public VendingSelection(decimal price, Type itemForSale)
        {
            Price = price;
            ItemForSale = itemForSale;
        }

        internal object CreateItem()
        {
            return Activator.CreateInstance(ItemForSale);
        } 
    }
}