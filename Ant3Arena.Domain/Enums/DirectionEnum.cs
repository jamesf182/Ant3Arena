using System.Text.Json.Serialization;

namespace Ant3Arena.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DirectionEnum
{
    LeftUp,
    LeftDown,
    RightUp,
    RightDown
}

