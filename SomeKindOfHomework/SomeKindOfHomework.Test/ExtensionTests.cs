using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeKindOfHomework.Core.Extensions;
using SomeKindOfHomework.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Test
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void TestIfBetween()
        {
            var left = new TileViewModel(2, 3);
            var middle = new TileViewModel(6, 5);
            var right = new TileViewModel(7, 8);

            Assert.IsTrue(middle.IsBetween(left, right));
            Assert.IsTrue(middle.IsBetween(right, left));

            Assert.IsFalse(left.IsBetween(middle, right));
            Assert.IsFalse(right.IsBetween(middle, left));

            middle.Latitude = left.Latitude - 1;

            Assert.IsFalse(middle.IsBetween(left, right));
            Assert.IsFalse(middle.IsBetween(right, left));
        }
    }
}
