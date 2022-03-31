using SomeKindOfHomework.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Core.Extensions
{
    public static class TileViewModelExtensions
    {
        public static bool IsBetween (
            [NotNull] this TileViewModel middle, 
            [NotNull] TileViewModel left, 
            [NotNull] TileViewModel right)
        {
            return ((left.Longitude >= middle.Longitude && middle.Longitude >= right.Longitude)
                 || (left.Longitude <= middle.Longitude && middle.Longitude <= right.Longitude))
                && ((left.Latitude >= middle.Latitude && middle.Latitude >= right.Latitude)
                 || (left.Latitude <= middle.Latitude && middle.Latitude <= right.Latitude));
        }
    }
}
