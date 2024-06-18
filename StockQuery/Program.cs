using System.Text;
using Microsoft.Extensions.Configuration;
using StockQuery.Classes;

namespace StockQuery;
internal class Program
{
    static async Task Main()
    {
        Console.WriteLine("Welcome to the stock query app");

        var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
        string baseApi = config["BaseApi"] ?? string.Empty;
        string apiKey = config["ApiKey"] ?? string.Empty;

        StockLoader loader = new(baseApi, apiKey);

        bool carryOn = true;
        while (carryOn)
        {
            Console.WriteLine("Please enter: ");
            Console.WriteLine("1. Look up a stock symbol");
            Console.WriteLine("2. Look up stocks in an exchange");
            Console.WriteLine("3. Look up a company");
            Console.WriteLine("4. Look up quote data (US only)");
            Console.WriteLine("Any other key to quit");

            string input = Console.ReadLine() ?? string.Empty;
            if (input == "1")
            {
                Console.WriteLine("Please input query text: ");
                string queryText = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();
                Console.WriteLine("Loading data ...");
                Console.WriteLine();

                try
                {
                    SymbolQueryResult result = await loader.LoadSymbolAsync(queryText);
                    Console.WriteLine($"Result Count: {result.Count}");
                    Console.WriteLine();
                    if (result.Count != 0)
                    {
                        Console.WriteLine("Result Details:");
                        Console.WriteLine();
                        StringBuilder sb = new();
                        result.Results.ForEach(ss => { sb.AppendLine(ss.ToString()); sb.AppendLine(); });
                        Console.WriteLine(sb.ToString().Trim());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Please input stock exchange: ");
                string queryText = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();
                Console.WriteLine("Loading data ...");
                Console.WriteLine();

                try
                {
                    List<StockResult> result = await loader.LoadStockMarketAsync(queryText);

                    Console.WriteLine($"Result Count: {result.Count}");
                    Console.WriteLine();
                    if (result.Count != 0)
                    {
                        Console.WriteLine("Result Details:");
                        Console.WriteLine();
                        StringBuilder sb = new();
                        result.ForEach(ss => { sb.AppendLine(ss.ToString()); sb.AppendLine(); });
                        Console.WriteLine(sb.ToString().Trim());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
            else if (input == "3")
            {
                Console.WriteLine("Please input query stock symbol: ");
                string symbol = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();
                Console.WriteLine("Loading data ...");
                Console.WriteLine();

                try
                {
                    CompanyProfile result = await loader.LoadCompanyProfileAsync(symbol);

                    Console.WriteLine("Company Profile: ");
                    Console.WriteLine(result.ToString().Trim());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
            else if (input == "4")
            {
                Console.WriteLine("Please input query stock symbol: ");
                string symbol = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();
                Console.WriteLine("Loading data ...");
                Console.WriteLine();

                try
                {
                    QuoteData result = await loader.LoadQuoteAsync(symbol);

                    Console.WriteLine("Quote Data: ");
                    Console.WriteLine(result.ToString().Trim());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
            else
            {
                carryOn = false;
            }

            Console.WriteLine();
        }
    }
}