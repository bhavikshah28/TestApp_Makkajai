using System;
using System.Collections.Generic;


namespace CommonLibrary
{
    public class FormHandler
    {
        private Item[] _items;
        private PriceCalculator _pcalc;
        public void Start()
        {
            while (true)
            {
                int N = ConsoleHandler.GetInput<int>(
                prompt: "Enter Number of Items to enter : ",
                invalidMessage: "Invalid Number of Item. Enter again...",
                tryParse: int.TryParse,
                validation: v => 0 <= v && v <= 100);

                _items = new Item[N];

                GetInputItems(N);

                GetOutputItems();
            }
        }
        public void GetInputItems(int Number)
        {

            for (int i = 1; i <= Number; i++)
            {
                Item item = new Item();

                var itemName = ConsoleHandler.GetInput<string>(
                prompt: "Enter " + i + " Item Name : ",
                invalidMessage: "Please Enter " + i + " Item Name",
                validation: v => v != "");
                item.ItemName = itemName;

                var itemPrice = ConsoleHandler.GetInput<double>(
                prompt: "Enter " + i + " Item Price : ",
                invalidMessage: "Please Enter " + i + " Item Price",
                tryParse: double.TryParse,
                validation: v => 0 <= v && v <= 100);
                item.ItemPrice = itemPrice;

                var itemqty = ConsoleHandler.GetInput<int>(
                prompt: "Enter " + i + " Item Quantity : ",
                invalidMessage: "Please Enter " + i + " Item Quantity",
                tryParse: int.TryParse,
                validation: v => 0 <= v && v <= 100);
                item.Quantity = itemqty;


                var salestaxpercentage = ConsoleHandler.GetInput<double>(
                prompt: "Enter " + i + " Item Tax % : ",
                invalidMessage: "Please Enter " + i + " Item Tax % ",
                tryParse: double.TryParse,
                validation: v => 0 <= v && v <= 100);

                item.SalesTaxPercentage = salestaxpercentage;

                _items.SetValue(item, (i - 1));
            }
        }
        public void GetOutputItems()
        {
            _pcalc = new PriceCalculator(_items);

            foreach (var item in _items)
            {
                Console.WriteLine(item.Quantity + " " + item.ItemName + ": " + Math.Round(item.itemTotalPrice, 2));
            }

            Console.WriteLine("Total Price: " + Math.Round(_pcalc.TotalPrice(), 2));

            Console.WriteLine("Total Sales Tax: " + Math.Round(_pcalc.TotalSalesTax(), 2));
        }
    }
}
