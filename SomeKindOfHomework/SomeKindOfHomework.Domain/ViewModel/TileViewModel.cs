using SomeKindOfHomework.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeKindOfHomework.Core.ViewModel
{
    public class TileViewModel
    {
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public TileType Type { get; set; }

        public TileViewModel(int longitude, int latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Type = TileType.Grass;
        }

        public void SwitchType()
        {
            Type= Type == TileType.Tree ? TileType.Grass : TileType.Tree;
        }
    }
}
