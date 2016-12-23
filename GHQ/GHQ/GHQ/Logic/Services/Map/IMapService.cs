using System.Collections.Generic;
using GHQ.Logic.Models.Data.Map;

using Xamarin.Forms.Maps;

namespace GHQ.Logic.Service.Map
{
    public interface IMapService
    {
       List<MapData> GetLocation();
    }
}
