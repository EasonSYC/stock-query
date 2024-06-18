using System.Text;
using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public class StockResult
{
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("displaySymbol")]
    public string DisplaySymbol { get; set; } = string.Empty;
    
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;
    
    [JsonPropertyName("symbol2")]
    public string Symbol2 { get; set; } = string.Empty;
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    
    [JsonPropertyName("isin")]
    public string Isin { get; set; } = string.Empty;
    
    [JsonPropertyName("figi")]
    public string Figi { get; set; } = string.Empty;
    
    [JsonPropertyName("shareClassFIGI")]
    public string ShareClassFigi { get; set; } = string.Empty;
    
    [JsonPropertyName("mic")]
    public string Mic { get; set; } = string.Empty;

    public override string ToString()
    {
        StringBuilder sb = new();
        if (!string.IsNullOrWhiteSpace(Description))
        {
            sb.AppendLine($"Description: {Description}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(DisplaySymbol))
        {
            sb.AppendLine($"Display Symbol: {DisplaySymbol}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Currency))
        {
            sb.AppendLine($"Currency: {Currency}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Symbol))
        {
            sb.AppendLine($"Symbol: {Symbol}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Symbol2))
        {
            sb.AppendLine($"Alternative Symbol: {Symbol2}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Type))
        {
            sb.AppendLine($"Type: {Type}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Isin))
        {
            sb.AppendLine($"ISIN: {Isin}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Figi))
        {
            sb.AppendLine($"FIGI: {Figi}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(ShareClassFigi))
        {
            sb.AppendLine($"Share Class FIGI: {ShareClassFigi}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Mic))
        {
            sb.AppendLine($"Mic: {Mic}".Trim());
        }

        return sb.ToString().Trim();
    }
}