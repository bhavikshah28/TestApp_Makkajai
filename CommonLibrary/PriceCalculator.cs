using System;
using System.Collections.Generic;

namespace CommonLibrary
{
    class PriceCalculator
    {
        private Item[] _items;

        public PriceCalculator(Item[] items)
        {
            _items = items;
        }
        /// <summary>
        /// validate totalprice
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double TotalPrice()
        {
            double TotalPrice = 0;
            foreach (var objitem in _items)
            {
                TotalPrice += objitem.itemTotalPrice;
            }
            return TotalPrice;
        }
        /// <summary>
        /// Generic method calculate TotalSalexTax
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double TotalSalesTax()
        {
            double TotalPrice = 0;
            foreach (var objitem in _items)
            {
                TotalPrice += objitem.itemTotalSalesTax;
            }
            return TotalPrice;
        }
    }
}
