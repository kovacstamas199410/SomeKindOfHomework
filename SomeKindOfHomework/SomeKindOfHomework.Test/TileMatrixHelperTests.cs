using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeKindOfHomework.Core.Enums;
using SomeKindOfHomework.Core.Extensions;
using SomeKindOfHomework.Core.Helpers;
using SomeKindOfHomework.Core.ViewModel;
using SomeKindOfHomework.Test.Helpers;
using System;
using System.IO;
using System.Text.Json;

namespace SomeKindOfHomework.Test
{
    [TestClass]
    public class TileMatrixHelperTests
    {
        TileViewModel[,] _tileMatrix;
        TileViewModel[][] _feed;

        public TileMatrixHelperTests()
        {
            _tileMatrix = new TileViewModel[0, 0];
            _feed = FeedGenerationHelper.CreateFeed();
        }

        [TestInitialize]
        public void Initialize()
        {
            _tileMatrix = FeedGenerationHelper.CreateMatrixFromFeed(_feed);
        }

        [TestMethod]
        public void TestAreaCalculation()
        {
            var firstTile = new TileViewModel(3, 6);
            var secondTile = new TileViewModel(1, 1);

            Assert.AreEqual(10, TileMatrixHelper.CalculateArea(firstTile, secondTile));

            firstTile = new TileViewModel(5, 5);
            secondTile = new TileViewModel(7, 1);

            Assert.AreEqual(8, TileMatrixHelper.CalculateArea(firstTile, secondTile));
        }
    }
}