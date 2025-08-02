using Ant3Arena.Domain.Entities;
using System.Drawing;

namespace Ant3Arena.Application.Interfaces;

public interface IAntService
{
    List<Ant> GetAnts(Bitmap bitmap, Size clientSize);
}

