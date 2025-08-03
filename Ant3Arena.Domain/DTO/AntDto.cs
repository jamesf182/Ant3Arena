using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.DTO;

public class AntDto
{
    public string Color { get; set; } = "";
    public DirectionEnum Direction { get; set; }
    public int HorizontalVelocity { get; set; }
    public int VerticalVelocity { get; set; }
    public int Quantity { get; set; }
    public List<DirectionStrategyDto> Strategies { get; set; } = [];
}

