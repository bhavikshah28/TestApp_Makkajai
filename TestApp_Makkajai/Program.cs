using System;
using System.Collections.Generic;
using Towel;
using static Towel.Syntax;

namespace TestApp_Makkajai
{

    #region Item
    public class Item
    {
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string category { get; set; }
        public double salestax { get; set; }
        
        /// <summary>
        /// Calculate TotalPrice of each Item
        /// </summary>
        /// <returns></returns>
        public double TotalPrice()
        {
            return (ItemPrice + (ItemPrice * salestax)) * Quantity;
        }
        /// <summary>
        /// Calculate total sales tax of each item
        /// </summary>
        /// <returns></returns>
        public double TotalSalesTax()
        {
            return ((ItemPrice + (ItemPrice * salestax)) * Quantity) - (ItemPrice * Quantity);
        }
    }
    #endregion
    #region PriceCalculator
    public class PriceCalculator
    {
        /// <summary>
        /// validate totalprice
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double TotalPrice(Item[] items)
        {
            double TotalPrice = 0;
            foreach (var objitem in items)
            {
                TotalPrice += objitem.TotalPrice();
            }
            return TotalPrice;
        }
        /// <summary>
        /// Generic method calculate TotalSalexTax
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double TotalSalesTax(Item[] items)
        {
            double TotalPrice = 0;
            foreach (var objitem in items)
            {
                TotalPrice += objitem.TotalSalesTax();
            }
            return TotalPrice;
        }

    }
    #endregion
    #region GenericInputHelper
    /// <summary>
    /// Generic Input render and validation
    /// </summary>
    public static class GenericInputHelper
    {
        public static T GetInput<T>(
            TryParse<T> tryParse = null,
            string prompt = null,
            string invalidMessage = null,
            Predicate<T> validation = null)
        {
            if (tryParse is null && (typeof(T) != typeof(string) && !typeof(T).IsEnum && Meta.GetTryParseMethod<T>() is null))
            {
                throw new InvalidOperationException($"Using {nameof(GenericInputHelper)}.{nameof(GetInput)} without providing a {nameof(tryParse)} delegate for a non-supported type {typeof(T).Name}.");
            }
            tryParse ??= typeof(T) == typeof(string)
                ? (string s, out T v) => { v = (T)(object)s; return true; }
            : (TryParse<T>)TryParse;
            validation ??= v => true;
            GetInput:
            Console.Write(prompt ?? $"Input a {typeof(T).Name} value: ");
            if (!tryParse(Console.ReadLine(), out T value) || !validation(value))
            {
                Console.WriteLine(invalidMessage ?? $"Invalid input. Try again...");
                goto GetInput;
            }
            return value;
        }
    }
    #endregion
    class Program
    {
        #region InputItems
        static Item[] getInputItems()
        {
            var N = GenericInputHelper.GetInput<int>(
            prompt: "Enter Number of Items to enter : ",
            invalidMessage: "Invalid Number of Item. Enter again...",
            tryParse: int.TryParse,
            validation: v => 0 <= v && v <= 100);
            int Number = N;
            Item[] Items = new Item[Number];

            for (int i = 1; i <= Number; i++)
            {
                Item item = new Item();

                var itemName = GenericInputHelper.GetInput<string>(
                prompt: "Enter " + i + " Item Name : ",
                invalidMessage: "Please Enter " + i + " Item Name",
                validation: v => v != "");
                item.ItemName = itemName;

                var itemPrice = GenericInputHelper.GetInput<double>(
                prompt: "Enter " + i + " Item Price : ",
                invalidMessage: "Please Enter " + i + " Item Price",
                tryParse: double.TryParse,
                validation: v => 0 <= v && v <= 100);
                item.ItemPrice = itemPrice;

                var itemqty = GenericInputHelper.GetInput<int>(
                prompt: "Enter " + i + " Item Quantity : ",
                invalidMessage: "Please Enter " + i + " Item Quantity",
                tryParse: int.TryParse,
                validation: v => 0 <= v && v <= 100);
                item.Quantity = itemqty;


                var category = GenericInputHelper.GetInput<string>(
                prompt: "Enter " + i + " Item Category : ",
                invalidMessage: "Please Enter " + i + " Item Category",
                validation: v => v != "");
                string Category = "Food,Medicine,Fashion,Book,";
                while (!Category.ToLower().Contains(category.ToLower() + ","))
                {
                    Console.WriteLine("Please enter category of " + Category);
                    category = Console.ReadLine();
                }
                item.salestax = category.ToLower() == "fashion" ? item.ItemName.ToLower().Contains("import") ? 0.15 : 0.1 : item.ItemName.ToLower().Contains("import") ? 0.05 : 0.0;

                Items.SetValue(item, (i - 1));
            }
            return Items;
        }
        #endregion
        #region OutputItems
        static void resultOutputItems(Item[] Items)
        {
            PriceCalculator pcalc = new PriceCalculator();
            foreach (var item in Items)
            {
                Console.WriteLine(item.Quantity + " " + item.ItemName + ": " + Math.Round(item.TotalPrice(), 2));
            }

            Console.WriteLine("Total Price: " + Math.Round(pcalc.TotalPrice(Items), 2));
            Console.WriteLine("Total Sales Tax: " + Math.Round(pcalc.TotalSalesTax(Items), 2));
        }
        #endregion
        #region Main
        static void Main(string[] args)
        {
            // Getting Item Details Section
            Item[] Items = getInputItems();

            //start calculation of Total Amount and Sales Tax
            resultOutputItems(Items);

        }
        #endregion
    }
}
