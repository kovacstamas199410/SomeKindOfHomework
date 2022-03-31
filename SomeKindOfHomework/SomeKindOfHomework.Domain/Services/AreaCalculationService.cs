using SomeKindOfHomework.Core.Enums;
using SomeKindOfHomework.Core.Extensions;
using SomeKindOfHomework.Core.Helpers;
using SomeKindOfHomework.Core.Interfaces;
using SomeKindOfHomework.Core.ViewModel;
using System.Linq;

namespace SomeKindOfHomework.Core.Services
{
    public class AreaCalculationService : IAreaCalculationService
    {
        public void MarkArea(TileViewModel[,] tileMatrix)
        {
            var boundaries = FindLargestOpenSpace(tileMatrix);
            TileMatrixHelper.ColorTiles(tileMatrix, boundaries);
        }

        public Tuple<TileViewModel, TileViewModel> FindLargestOpenSpace(TileViewModel[,] tileMatrix)
        {
            var treeTiles = TileMatrixHelper.GetTreeTiles(tileMatrix);
            var grassTiles = TileMatrixHelper.GetGrassTiles(tileMatrix);

            var largestAreaPoints = new Tuple<TileViewModel, TileViewModel>(grassTiles.First(), grassTiles.First());
            var largestArea = 0;

            foreach (var grass in grassTiles)
            {
                var boundaries = grassTiles
                    .AsParallel()
                    .Where(item =>
                    {
                        if (item == grass) return false;
                        if (treeTiles.Any(tree => tree.IsBetween(grass, item)))
                        {
                            return false;
                        }

                        return true;
                    })
                    .Select(item => new
                    {
                        Boundary = item,
                        Area = TileMatrixHelper.CalculateArea(grass, item)
                    });

                if (!boundaries.Any())
                {
                    continue;
                }

                var maxBoundary = boundaries
                    .AsParallel()
                    .First(item => item.Area == boundaries.Max(x => x.Area));

                if (maxBoundary.Area > largestArea)
                {
                    largestArea = maxBoundary.Area;
                    largestAreaPoints = new Tuple<TileViewModel, TileViewModel>(
                        grass,
                        maxBoundary.Boundary);
                }
            }

            return largestAreaPoints;
        }
    }
}