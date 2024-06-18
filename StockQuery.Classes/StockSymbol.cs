using System.Text;
using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public class StockSymbol
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("displaySymbol")]
    public string DisplaySymbol { get; set; } = string.Empty;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

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
        if (!string.IsNullOrWhiteSpace(Symbol))
        {
            sb.AppendLine($"Symbol: {Symbol}".Trim());
        }
        if (!string.IsNullOrWhiteSpace(Type))
        {
            sb.AppendLine($"Type: {Type}".Trim());
        }

        return sb.ToString().Trim();
    }
}