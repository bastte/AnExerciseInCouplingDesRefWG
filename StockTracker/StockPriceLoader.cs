using System;
using System.Net;

internal class StockPriceLoader
{
    public static double Load(string url, StockPriceLoader that)
    {
        double price = 0;
        WebClient webClient = new WebClient();
        string result = webClient.DownloadString(url);
        if (!result.Contains("No symbol matches found"))
        {
            string lastPrice = result.Substring(result.IndexOf("LastPrice"));
            string pricePlus = lastPrice.Substring(lastPrice.IndexOf(":") + 1);
            string priceString = pricePlus.Substring(0, pricePlus.IndexOf(","));
            price = Double.Parse(priceString);
        }
        return price;
    }
}