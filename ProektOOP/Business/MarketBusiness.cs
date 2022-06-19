using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProektOOP.Data;

namespace ProektOOP.Business
{
    class MarketBusiness
    {
        MarketData marketData = new MarketData();
        public void AddMarket(string marketName, string marketAdress)
        {
            marketData.AddMarket(marketName, marketAdress);
        }
        public void AddProduct(string productName, float productPrice, int productMarket)
        {
            marketData.AddProduct(productName,productPrice,productMarket);
        }
        public void RemoveProduct(int productID)
        {
            marketData.RemoveProduct(productID);
        }
        public void RemoveMarket(int marketID)
        {
            marketData.RemoveMarket(marketID);
        }
        public bool CheckMarketForProducts(int marketID)
        {
            bool checkMarket = marketData.CheckMarketForProducts(marketID);
            return checkMarket;
        }
    }
}
