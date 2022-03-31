using SomeKindOfHomework.Core.Enums;
using SomeKindOfHomework.Core.Extensions;
using SomeKindOfHomework.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Core.Helpers
{
    public class TileMatrixHelper
    {
        public static int CalculateArea(TileViewModel tileOne, TileViewModel tileTwo)
        {
            var longitudeLength = Math.Abs(tileOne.Longitude - tileTwo.Longitude);
            var latitudeLength = Math.Abs(tileOne.Latitude - tileTwo.Latitude);

            return Math.Abs(longitudeLength * latitudeLength);
        }

        public static void ColorTiles(TileViewModel[,] tileMatrix, Tuple<TileViewModel, TileViewModel> boundaries)
        {
            tileMatrix
                .OfType<TileViewModel>()
                .Where(mid => mid.Type == TileType.Grass
                           && mid.IsBetween(boundaries.Item1, boundaries.Item2))
                .ToList()
                .ForEach(item => item.Type = TileType.Marked);
        }

        public static IEnumerable<TileViewModel> GetTreeTiles(TileViewModel[,] tileMatrix)
        {
            var tiles = tileMatrix
                .OfType<TileViewModel>();

            return GetTreeTiles(tiles);
        }

        public static IEnumerable<TileViewModel> GetTreeTiles(IEnumerable<TileViewModel> tiles)
        {
            ValidateTiles(tiles);

            return tiles
                .Where(item => item.Type == TileType.Tree);
        }

        public static IEnumerable<TileViewModel> GetGrassTiles(TileViewModel[,] tileMatrix)
        {
            var tiles = tileMatrix
                .OfType<TileViewModel>();

            return GetGrassTiles(tiles);
        }

        public static IEnumerable<TileViewModel> GetGrassTiles(IEnumerable<TileViewModel> tiles)
        {
            ValidateTiles(tiles);

            return tiles
                .Where(item => item.Type == TileType.Grass);
        }

        public static void ValidateTiles(IEnumerable<TileViewModel> tiles)
        {
            if (tiles?.Any(item => item.Type == TileType.Tree) != true)
            {
                throw new Exception("No tree found on map!");
            }
            if (tiles?.Any(item => item.Type == TileType.Grass) != true)
            {
                throw new Exception("No grass found on map!");
            }
        }
    }
}
