using LucidEdge.DataMapping;
using StockPickem.Data.Sql;
using StockPickem.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class UserPerformance_Model
	{
		public PerformanceChart_Model ChartData { get; set; }
		public List<string> Symbols { get; private set; }
		public void Init(string username)
		{
			ReadSymbols(username);

			// grab the all the user's picks for the first stock symbol
			ChartData = new PerformanceChart_Model() { 
				Symbol = Symbols.FirstOrDefault(), 
				UserName = username 
			};
			ChartData.Init();
		}

		public void Load()
		{
			ChartData.Load();
		}

		private void ReadSymbols(string username)
		{
			var dps = new List<DataPoint>()
				.Add("username", username);

			// grab symbols
			var symbols = SqlRequests.StockPicks.ReadUsersSymbols.Read<UserPick>(
				dps);

			// convert symbols to a List<string>
			Symbols = symbols.Select(
				p => p.Symbol).ToList();
		}
	}

	public class SimpleHighChartData
	{
		public double x { get; set; }
		public int y { get; set; }
	}

	public class PerformanceChart_Model : Base_Model
	{
		private IEnumerable<UserPick> ChartDataRequest { get; set; }
		public List<SimpleHighChartData> ChartData { get; set; }
		public string Symbol { get; set; }
		public string UserName { get; set; }

		public void Init()
		{
			var dps = new List<DataPoint>()
					.Add("symbol", Symbol)
					.Add("username", UserName);

			ChartDataRequest = SqlRequests.StockPicks.ReadUserPicks.Read<UserPick>(
				dps);
		}

		public void Load()
		{
			var sqlData = ChartDataRequest.ToList();
			//sqlData.Reverse();

			// TODO: there has to be a better way to do this...but I want to see a chart.
			DateTime _1970 = new DateTime(1970, 1, 1, 0, 0, 0);

			var progress = 0;
			ChartData = sqlData.Select(
				row => new SimpleHighChartData()
				{
					x = (row.StartDate - _1970).TotalMilliseconds,
					y = progress += row.CorrectPick
				}
			).ToList();
		}
	}
}