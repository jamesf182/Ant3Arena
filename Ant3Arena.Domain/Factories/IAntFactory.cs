using Ant3Arena.Domain.DTO;
using Ant3Arena.Domain.Entities;
using System.Drawing;

namespace Ant3Arena.Domain.Factories;

public interface IAntFactory
{
    IEnumerable<Ant> CreateAntsFromDto(AntDto dto, Bitmap bitmap, Size borders);
}
