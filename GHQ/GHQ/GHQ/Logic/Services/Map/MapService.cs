using System.Collections.Generic;
using GHQ.Logic.Models.Data.Map;
using Xamarin.Forms.Maps;

namespace GHQ.Logic.Service.Map
{
	public class MapService : IMapService
	{
		public List<MapData> GetLocation()
		{
			List<MapData> data = new List<MapData>();
			MapData first = new MapData();
			first.Title = "مركز تدريب العين";
			first.Location = new Position(24.186562,55.78696953999997);

			MapData second = new MapData();
			second.Title = "مركز تدريب المنامة";
			second.Location = new Position(25.3268616,56.02261299999998);

			MapData third = new MapData();
			third.Title = "مركز تدريب خولة بنت الأزور";
			third.Location = new Position(24.3504567, 54.57400210000003);
		
			MapData fourth = new MapData();
			fourth.Title = "مركز تدريب ليوا";
			fourth.Location = new Position(23.657199600000002,53.8359524);

			MapData fifth = new MapData();
			fifth.Title = "مركز تدريب سيح اللحمة";
			fifth.Location = new Position(24.0371493,55.46649460000003);

			MapData sixth = new MapData();
			sixth.Title = "مركز تسجبل معسكر آل نهيان";
			sixth.Location = new Position(24.4663512, 54.396947599999976);

			MapData seventh = new MapData();
			seventh.Title = "مركز تسجبل الرحمانية";
			seventh.Location = new Position(25.3274675, 55.56756640000003);

			MapData eighth = new MapData();
			eighth.Title = "مركز تسجبل العين";
			eighth.Location = new Position(24.186562, 55.78696953999997);

			MapData nineth = new MapData();
			nineth.Title = "مركز تسجبل ليوا";
			nineth.Location = new Position(23.657199600000002, 53.8359524);

			data.Add(first);
			data.Add(second);
			data.Add(third);
			data.Add(fourth);
			data.Add(fifth);
			data.Add(sixth);
			data.Add(seventh);
			data.Add(eighth);
			data.Add(nineth);

			return data;
		}
	}
}