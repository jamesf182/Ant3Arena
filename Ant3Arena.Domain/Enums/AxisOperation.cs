using System.Text.Json.Serialization;

namespace Ant3Arena.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AxisOperation
{
    Increase,
    Decrease
}