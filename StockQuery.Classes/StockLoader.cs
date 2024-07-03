using System.Text.Json;
using System.Web;

namespace StockQuery.Classes;

public class StockLoader(string baseUrl, string apiKey)
{
    private readonly string _baseUrl = baseUrl;
    private readonly string _apiKey = apiKey;
    private readonly HttpClient _httpClient = new();

    public async Task<SymbolQueryResult> LoadSymbolAsync(string queryText)
    {
        string newBaseUrl = _baseUrl + "/search";
        UriBuilder uriBuilder = new(newBaseUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["q"] = queryText;
        query["token"] = _apiKey;
        uriBuilder.Query = query.ToString();

        HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.ToString());
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        SymbolQueryResult result = JsonSerializer.Deserialize<SymbolQueryResult>(responseBody) ?? new();

        return result;
    }

    public async Task<QuoteData> LoadQuoteAsync(string symbol)
    {
        string newBaseUrl = _baseUrl + "/quote";
        UriBuilder uriBuilder = new(newBaseUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["symbol"] = symbol;
        query["token"] = _apiKey;
        uriBuilder.Query = query.ToString();

        HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.ToString());
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        QuoteData result = JsonSerializer.Deserialize<QuoteData>(responseBody) ?? new();

        return result;
    }

    public async Task<CompanyProfile> LoadCompanyProfileAsync(string symbol)
    {
        string newBaseUrl = _baseUrl + "/stock/profile2";
        UriBuilder uriBuilder = new(newBaseUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["symbol"] = symbol;
        query["token"] = _apiKey;
        uriBuilder.Query = query.ToString();

        HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.ToString());
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        CompanyProfile result = JsonSerializer.Deserialize<CompanyProfile>(responseBody) ?? new();

        return result;
    }

    public async Task<List<StockResult>> LoadStockMarketAsync(string exchange)
    {
        string newBaseUrl = _baseUrl + "/stock/symbol";
        UriBuilder uriBuilder = new(newBaseUrl);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["exchange"] = exchange;
        query["token"] = _apiKey;
        uriBuilder.Query = query.ToString();

        HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.ToString());
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<StockResult> result = JsonSerializer.Deserialize<List<StockResult>>(responseBody) ?? new();

        return result;
    }
}