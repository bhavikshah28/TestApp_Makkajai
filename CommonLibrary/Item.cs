using System;
using System.Collections.Generic;

namespace CommonLibrary
{
    class Item
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public double SalesTaxPercentage { get; set; }
        /// <summary>
        /// GET Property of Total sales tax of every item
        /// </summary>
        public double itemTotalSalesTax
        {
            get
            {
                return ItemSalesTax();
            }
        }
        /// <summary>
        /// Get Property of Total price of every item
        /// </summary>
        public double itemTotalPrice
        {
            get
            {
                return ItemTotalPrice();
            }
        }

        /// <summary>
        /// Calculate TotalPrice of each Item
        /// </summary>
        /// <returns></returns>
        public double ItemTotalPrice()
        {
            return (ItemPrice + itemTotalSalesTax) * Quantity;
        }
        /// <summary>
        /// calculate item of sales tax
        /// </summary>
        /// <returns></returns>
        public double ItemSalesTax()
        {
            return  (((ItemPrice * SalesTaxPercentage) / 100) * Quantity);
        }
    }
}
