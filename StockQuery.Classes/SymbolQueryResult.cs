using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public class SymbolQueryResult
{
    [JsonPropertyName("count")]
    public int Count { get; set; } = 0;

    [JsonPropertyName("result")]
    public List<StockSymbol> Results { get; set; } = [];
}