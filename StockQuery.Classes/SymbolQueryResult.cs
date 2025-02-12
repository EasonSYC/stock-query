﻿using System.Text.Json.Serialization;

namespace StockQuery.Classes;

public record SymbolQueryResult
{
    [JsonPropertyName("count")]
    public int Count { get; set; } = 0;

    [JsonPropertyName("result")]
    public List<StockSymbol> Results { get; set; } = [];
}