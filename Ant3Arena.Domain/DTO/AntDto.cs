﻿namespace Ant3Arena.Domain.DTO;

public class AntDto
{
    public string Color { get; set; } = "";
    public string Hex { get; set; } = "";
    public int HorizontalVelocity { get; set; }
    public int VerticalVelocity { get; set; }
    public int Quantity { get; set; }
    public string Strategy { get; set; } = "";
}

