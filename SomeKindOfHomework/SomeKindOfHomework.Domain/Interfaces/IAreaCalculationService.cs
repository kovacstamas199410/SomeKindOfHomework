using SomeKindOfHomework.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Core.Interfaces
{
    public interface IAreaCalculationService
    {
        /// <summary>
        /// Finds the largest grass area and mark it
        /// </summary>
        /// <param name="tileMatrix">Tree and grass tiles must be included</param>
        public void MarkArea(TileViewModel[,] tileMatrix);

        /// <summary>
        /// Finds the largest grass area on the given map
        /// </summary>
        /// <param name="tileMatrix">The map has to contain grass and tree type tiles</param>
        /// <returns>The two tree type tiles what are the borders of the grass tiles</returns>
        public Tuple<TileViewModel, TileViewModel> FindLargestOpenSpace(TileViewModel[,] tileMatrix);
    }
}
