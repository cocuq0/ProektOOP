using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektOOP.Data
{
    class MarketData
    {
        public void AddMarket(string marketName, string marketAdress)
        {
            var con = Database.Connect();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Markets(mName,mAdress) values (@mName,@mAdress);";
                cmd.Parameters.AddWithValue("@mName", marketName);
                cmd.Parameters.AddWithValue("@mAdress", marketAdress);
                cmd.ExecuteNonQuery();
            }
        }
        public void AddProduct(string productName, float productPrice, int productMarket)
        {
            var con = Database.Connect();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Product(pName,pPrice,pMarket) values (@pName,@pPrice,@pMarket);";
                cmd.Parameters.AddWithValue("@pName", productName);
                cmd.Parameters.AddWithValue("@pPrice", productPrice);
                cmd.Parameters.AddWithValue("@pMarket", productMarket);
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveProduct(int productID)
        {
            var con = Database.Connect();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete FROM Product WHERE pID =@pID;";
                cmd.Parameters.AddWithValue("@pID", productID);
                cmd.ExecuteNonQuery();

            }
        }
        public void RemoveMarket(int marketID)
        {
            var con = Database.Connect();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete FROM Markets WHERE mID =@mID;";
                cmd.Parameters.AddWithValue("@mID", marketID);
                cmd.ExecuteNonQuery();

            }
        }
        public bool CheckMarketForProducts(int marketID)
        {
            var con = Database.Connect();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select COUNT(p.pMarket) from Product as p inner join Markets as m on p.pMarket = @mID;";
                cmd.Parameters.AddWithValue("@mID", marketID);
                int productCount = int.Parse(cmd.ExecuteScalar().ToString());
                if (productCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
