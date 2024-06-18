using System.Text;
using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public class CompanyProfile
{
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
    
    [JsonPropertyName("exchange")]
    public string Exchange { get; set; } = string.Empty;
    
    [JsonPropertyName("finnhubindustry")]
    public string FinnHubIndustry { get; set; } = string.Empty;
    
    [JsonPropertyName("name")]
    public string CompanyName { get; set; } = string.Empty;
    
    [JsonPropertyName("phone")]
    public string CompanyPhone { get; set; } = string.Empty;
    
    [JsonPropertyName("ticker")]
    public string Ticker { get; set; } = string.Empty;

    [JsonPropertyName("marketCapitalization")]
    public decimal MarketCapitalization { get; set; } = -1;
    
    [JsonPropertyName("shareOutstanding")]
    public decimal ShareOutstanding { get; set; } = -1;
    
    [JsonPropertyName("ipo")]
    public DateOnly IpoDate { get; set; } = new();
    
    [JsonPropertyName("logo")]
    public string Logo { get; set; } = string.Empty;
    
    [JsonPropertyName("weburl")]
    public string WebUrl { get; set; } = string.Empty;

    public override string ToString()
    {
        StringBuilder sb = new();
        if (!string.IsNullOrWhiteSpace(CompanyName))
        {
            sb.AppendLine($"Company Name: {CompanyName}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Country))
        {
            sb.AppendLine($"Country: {Country}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Currency))
        {
            sb.AppendLine($"Currency: {Currency}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Exchange))
        {
            sb.AppendLine($"Exchange: {Exchange}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Logo))
        {
            sb.AppendLine($"Logo Link: {Logo}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(WebUrl))
        {
            sb.AppendLine($"Web URL: {WebUrl}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Ticker))
        {
            sb.AppendLine($"Ticker: {Ticker}".Trim());
        }
        if (MarketCapitalization != -1)
        {
            sb.AppendLine($"Market Capitalization: {MarketCapitalization}".Trim());
        }
        if (ShareOutstanding != -1)
        {
            sb.AppendLine($"Share Outstanding: {ShareOutstanding}".Trim());
        }
        if (IpoDate != new DateOnly())
        {
            sb.AppendLine($"IPO Date: {IpoDate}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(CompanyPhone))
        {
            sb.AppendLine($"Company Phone: {CompanyPhone}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(FinnHubIndustry))
        {
            sb.AppendLine($"Finn Hun Industry: {FinnHubIndustry}".Trim());
        }

        return sb.ToString().Trim();
    }
}