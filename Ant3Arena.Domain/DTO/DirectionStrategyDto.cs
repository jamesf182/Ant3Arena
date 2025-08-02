using Ant3Arena.Domain.Enums;

namespace Ant3Arena.Domain.DTO;

public class DirectionStrategyDto
{
    public string Direction { get; set; } = "";
    public AxisOperation X { get; set; } 
    public AxisOperation Y { get; set; }
    public List<NextDirectionDto> NextDirection { get; set; } = [];
}
