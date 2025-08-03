using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.DTO;

public class NextDirectionDto
{
    public string Condition { get; set; } = "";
    public DirectionEnum Direction { get; set; }
}
