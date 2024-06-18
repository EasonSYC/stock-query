using System.Text;
using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public class QuoteData
{
    [JsonPropertyName("c")]
    public decimal CurrentPrice { get; set; } = -1;

    [JsonPropertyName("d")]
    public decimal Change { get; set; } = -1;

    [JsonPropertyName("dp")]
    public decimal PercentageChange { get; set; } = -1;

    [JsonPropertyName("h")]
    public decimal HighPrice { get; set; } = -1;

    [JsonPropertyName("l")]
    public decimal LowPrice { get; set; } = -1;

    [JsonPropertyName("o")]
    public decimal OpenPrice { get; set; } = -1;

    [JsonPropertyName("pc")]
    public decimal PreviousClosePrice { get; set; } = -1;

    public override string ToString()
    {
        StringBuilder sb = new();
        if (CurrentPrice != -1)
        {
            sb.AppendLine($"Current Price: {CurrentPrice}".Trim());
        }
        if (Change != -1)
        {
            sb.AppendLine($"Change: {Change}".Trim());
        }
        if (PercentageChange != -1)
        {
            sb.AppendLine($"Percentage Change: {PercentageChange}".Trim());
        }
        if (HighPrice != -1)
        {
            sb.AppendLine($"High Price: {HighPrice}".Trim());
        }
        if (LowPrice != -1)
        {
            sb.AppendLine($"Low Price: {LowPrice}".Trim());
        }
        if (OpenPrice != -1)
        {
            sb.AppendLine($"Open Price: {OpenPrice}".Trim());
        }
        if (PreviousClosePrice != -1)
        {
            sb.AppendLine($"Pervious Close Price: {PreviousClosePrice}".Trim());
        }

        return sb.ToString().Trim();
    }
}