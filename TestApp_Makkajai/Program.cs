using System;

namespace TestApp_Makkajai
{
    #region interface
    public interface IItem
    {
        double TotalPrice();
        double TotalSalesTax();
    }
    #endregion

    #region Book
    public class Book : IItem
    {
        double ItemPrice;
        string ItemName;
        int Quantity;
        double salestax;
        public Book(string _itemname, double _itemprice, int _Quantity, double _salestax)
        {
            ItemPrice = _itemprice;
            ItemName = _itemname;
            Quantity = _Quantity;
            salestax = _salestax;
        }
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
    #region Food
    public class Food : IItem
    {
        double ItemPrice;
        string ItemName;
        int Quantity;
        double salestax;
        public Food(string _itemname, double _itemprice, int _Quantity, double _salestax)
        {
            ItemPrice = _itemprice;
            ItemName = _itemname;
            Quantity = _Quantity;
            salestax = _salestax;
        }
        /// <summary>
        /// caclulate totalprice of Food Item
        /// </summary>
        /// <returns></returns>
        public double TotalPrice()
        {
            return (ItemPrice + (ItemPrice * salestax)) * Quantity;
        }
        /// <summary>
        /// calculate salex tax of Food Item
        /// </summary>
        /// <returns></returns>
        public double TotalSalesTax()
        {
            return ((ItemPrice + (ItemPrice * salestax)) * Quantity) - (ItemPrice * Quantity);
        }
    }
    #endregion
    #region Fashion
    public class Fashion : IItem
    {
        double ItemPrice;
        string ItemName;
        int Quantity;
        double salestax;
        public Fashion(string _itemname, double _itemprice, int _Quantity, double _salestax)
        {
            ItemPrice = _itemprice;
            ItemName = _itemname;
            Quantity = _Quantity;
            salestax = _salestax;
        }
        /// <summary>
        /// Caclulate Total Price of Fashion Item
        /// </summary>
        /// <returns></returns>
        public double TotalPrice()
        {
            return (ItemPrice + (ItemPrice * salestax)) * Quantity;
        }
        /// <summary>
        /// Calculate Total Sales Tax of Fashion Item
        /// </summary>
        /// <returns></returns>
        public double TotalSalesTax()
        {
            return ((ItemPrice + (ItemPrice * salestax)) * Quantity) - (ItemPrice * Quantity);
        }
    }
    #endregion
    #region Medical
    public class Medical : IItem
    {
        string ItemName;
        double ItemPrice;
        int Quantity;
        double salestax;
        public Medical(string _itemname, double _itemprice, int _Quantity, double _salestax)
        {
            ItemPrice = _itemprice;
            ItemName = _itemname;
            Quantity = _Quantity;
            salestax = _salestax;
        }
        /// <summary>
        /// Calculate Total Price of Medical Item
        /// </summary>
        /// <returns></returns>
        public double TotalPrice()
        {
            return (ItemPrice + (ItemPrice * salestax)) * Quantity;
        }
        /// <summary>
        /// Calculate Total Sales Tax of Medical Item
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
        public double TotalPrice(IItem[] items)
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
        public double TotalSalesTax(IItem[] items)
        {
            double TotalPrice = 0;
            foreach (var objitem in items)
            {
                TotalPrice += objitem.TotalSalesTax();
            }
            return TotalPrice;
        }
        /// <summary>
        /// Validate all required element of values
        /// </summary>
        /// <param name="invalue"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string validatevalue(string invalue, string message, string type)
        {
            var N = invalue;
            double Num;
            int nom;
            if (type.ToLower() == "number")
            {
                while (!double.TryParse(N, out Num))
                {
                    Console.WriteLine(message);
                    N = Console.ReadLine();
                }
            }
            else if (type.ToLower() == "int")
            {
                while (!int.TryParse(N, out nom))
                {
                    Console.WriteLine(message);
                    N = Console.ReadLine();
                }
            }
            else
            {
                while (string.IsNullOrEmpty(N))
                {
                    Console.WriteLine(message);
                    N = Console.ReadLine();
                }
            }
            return N;
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            string Item = string.Empty;
            #region Getting Item Details Section
            PriceCalculator pcalc = new PriceCalculator();

            Console.Write("Enter Number of Items to enter : ");
            double Num;
            var N = pcalc.validatevalue(Console.ReadLine(), "Number of Items can't be Empty. Please Enter Number of Items to enter details", "Int");
            int Number = Convert.ToInt32(N);
            string[] Items = new String[Number];
            IItem[] items = new IItem[Number];

            for (int i = 1; i <= Number; i++)
            {
                Item = string.Empty;
                Console.Write("Enter " + i + " Item Name : ");
                N = pcalc.validatevalue(Console.ReadLine(), "Please Enter " + i + " Item Name", "Text");
                Item += N + "|";
                Console.Write("Enter " + i + " Item Price : ");
                N = pcalc.validatevalue(Console.ReadLine(), "Please Enter " + i + " Item Price", "Number");
                Num = Convert.ToDouble(N);
                Item += Num + "|";
                Console.Write("Enter " + i + " Item Quantity : ");
                N = pcalc.validatevalue(Console.ReadLine(), "Please Enter " + i + " Item Quantity", "Int");
                Num = Convert.ToInt32(N);
                Item += Num + "|";
                Console.Write("Enter " + i + " Item Category : ");
                N = pcalc.validatevalue(Console.ReadLine(), "Please Enter " + i + " Item Category", "Text");
                string Category = "Food,Medicine,Fashion,Book,";
                while (!Category.ToLower().Contains(N.ToLower() + ","))
                {
                    Console.WriteLine("Please enter category of " + Category);
                    N = Console.ReadLine();
                }
                Item += N;
                Items.SetValue(Item, (i - 1));
            }
            #endregion
            #region start calculation of Total Amount and Sales Tax
            int count = 0;
            IItem bitem;
            foreach (var item in Items)
            {
                string[] pitems = item.Split('|');
                if (pitems[3].ToLower() == "book")
                {
                    if (pitems[0].ToLower().Contains("import"))
                        bitem = new Book(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.05);
                    else
                        bitem = new Book(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.0);
                    Console.WriteLine(pitems[2] + " " + pitems[0] + ": " + Math.Round(bitem.TotalPrice(), 2));
                }
                else if (pitems[3].ToLower() == "fashion")
                {
                    if (pitems[0].ToLower().Contains("import"))
                        bitem = new Fashion(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.15);
                    else
                        bitem = new Fashion(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.1);
                    Console.WriteLine(pitems[2] + " " + pitems[0] + ": " + Math.Round(bitem.TotalPrice(), 2));
                }
                else if (pitems[3].ToLower() == "food")
                {
                    if (pitems[0].ToLower().Contains("import"))
                        bitem = new Food(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.05);
                    else
                        bitem = new Food(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.0);
                    Console.WriteLine(pitems[2] + " " + pitems[0] + ": " + Math.Round(bitem.TotalPrice(), 2));
                }
                else
                {
                    if (pitems[0].ToLower().Contains("import"))
                        bitem = new Medical(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.05);
                    else
                        bitem = new Medical(pitems[0], Convert.ToDouble(pitems[1]), Convert.ToInt32(pitems[2]), 0.0);
                    Console.WriteLine(pitems[2] + " " + pitems[0] + ": " + Math.Round(bitem.TotalPrice(), 2));
                }

                items.SetValue(bitem, count);
                count++;
            }

            Console.WriteLine("Total Price: " + Math.Round(pcalc.TotalPrice(items), 2));
            Console.WriteLine("Total Sales Tax: " + Math.Round(pcalc.TotalSalesTax(items), 2));
            #endregion
        }
    }
}
