using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProektOOP.Business;
using System.Threading.Tasks;

namespace ProektOOP.Presentation
{
    class Display
    {
        public Display()
        {
            ShowMenu();
        }
        private MarketBusiness mb = new MarketBusiness();
        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MENU" + new string(' ', 15));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1 - Add new Market");
            Console.WriteLine("2 - Add new Product");
            Console.WriteLine("3 - Remove a Product");
            Console.WriteLine("4 - Remove a Market");
            int menuInput = int.Parse(Console.ReadLine());
            MenuInteraction(menuInput);
            
        }
        public void MenuInteraction(int input)
        {
            switch (input)
            {
                default:
                    break;
                case 1:
                    AddMarket();
                    ShowMenu();
                    break;
                case 2:
                    AddProduct();
                    ShowMenu();
                    break;
                case 3:
                    RemoveProduct();
                    ShowMenu();
                    break;
                case 4:
                    RemoveMarket();
                    ShowMenu();
                    break;

            }
        }
        public void AddMarket()
        {
            Console.WriteLine("Enter market name:");
            string mName = Console.ReadLine();
            Console.WriteLine("Enter market adress");
            string mAdress = Console.ReadLine();
            mb.AddMarket(mName, mAdress);
        }
        public void AddProduct()
        {
            Console.WriteLine("Enter product name");
            string pName = Console.ReadLine();
            Console.WriteLine("Enter product price");
            float pPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter product's market");
            int pMarket = int.Parse(Console.ReadLine());
            mb.AddProduct(pName, pPrice, pMarket);
        }
        public void RemoveProduct()
        {
            Console.WriteLine("Enter the ID of the product you want to delete");
            int pID = int.Parse(Console.ReadLine());
            mb.RemoveProduct(pID);
        }
        public void RemoveMarket()
        {
            Console.WriteLine("Enter the ID of the market you want to remove");
            int mID = int.Parse(Console.ReadLine());
            if (!mb.CheckMarketForProducts(mID))
            {
                mb.RemoveMarket(mID);
            }
            else
            {
                Console.WriteLine("The market you are trying to delete has products in it!");
                Console.WriteLine("Remove the products first");
            }
        }
    }
}
