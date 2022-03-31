using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeKindOfHomework.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Test.Helpers
{
    internal class FeedGenerationHelper
    {
        internal static TileViewModel[][] CreateFeed()
        {
            TileViewModel[][]? tiles = JsonSerializer.Deserialize<TileViewModel[][]>(File.ReadAllText("TestFeed.json"));

            if (tiles == null)
            {
                throw new InternalTestFailureException("Could not read data of TestFeed.json");
            }

            return tiles;
        }

        internal static TileViewModel[,] CreateMatrixFromFeed(TileViewModel[][] feed)
        {
            var tileMatrix = new TileViewModel[feed.GetLength(0), feed[0].Length];

            for (int i = 0; i < feed.GetLength(0); i++)
            {
                for (int j = 0; j < feed[0].Length; j++)
                {
                    tileMatrix[i, j] = new TileViewModel(i, j)
                    {
                        Type = feed[i][j].Type
                    };
                }
            }

            return tileMatrix;
        }
    }
}
