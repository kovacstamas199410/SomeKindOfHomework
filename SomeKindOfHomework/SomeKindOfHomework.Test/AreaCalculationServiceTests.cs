using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeKindOfHomework.Core.Enums;
using SomeKindOfHomework.Core.Interfaces;
using SomeKindOfHomework.Core.Services;
using SomeKindOfHomework.Core.ViewModel;
using SomeKindOfHomework.Test.Helpers;
using System.IO;
using System.Text.Json;

namespace SomeKindOfHomework.Test
{
    [TestClass]
    [DoNotParallelize]
    public class AreaCalculationServiceTests
    {
        TileViewModel[,] _tileMatrix;
        IAreaCalculationService _areaCalculationService;
        TileViewModel[][] _feed;

        public AreaCalculationServiceTests()
        {
            _areaCalculationService = new AreaCalculationService();
            _tileMatrix = new TileViewModel[0, 0];
            _feed = FeedGenerationHelper.CreateFeed();
        }

        [TestInitialize]
        public void Initialize()
        {
            _tileMatrix = FeedGenerationHelper.CreateMatrixFromFeed(_feed);
        }

        [TestMethod]
        public void TestAreaSearch()
        {
            var boundaries = _areaCalculationService.FindLargestOpenSpace(_tileMatrix);

            Assert.AreEqual(2, boundaries.Item1.Longitude);
            Assert.AreEqual(2, boundaries.Item1.Latitude);
            Assert.AreEqual(5, boundaries.Item2.Longitude);
            Assert.AreEqual(6, boundaries.Item2.Latitude);
        }

        [TestMethod]
        public void TestAreaColoring()
        {
            _areaCalculationService.MarkArea(_tileMatrix);

            for (int i = 0; i < _tileMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _tileMatrix.GetLength(1); j++)
                {
                    if (i > 1 && i < 6
                     && j > 1 && j < 7)
                    {
                        Assert.AreEqual(TileType.Marked, _tileMatrix[i, j].Type);
                    }
                    else
                    {
                        Assert.AreNotEqual(TileType.Marked, _tileMatrix[i, j].Type);
                    }
                }
            }
        }
    }
}
