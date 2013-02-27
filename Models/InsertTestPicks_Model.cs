using LucidEdge.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class InsertTestPicks_Model : Base_Model
	{
		public void Run()
		{
			Random rand = new Random();
			int count = 5;

			DateTime eDate = DateTime.Today;

			for (int i = 0; i < count; i++)
			{
				int duration_days = rand.Next(1, 5);

				var sDate = eDate.AddDays(duration_days * -1);

				var dps = new List<DataPoint>()
					.Add("symbol", "AAPL")
					.Add("user", AuthUserName)
					.Add("duration_days", duration_days)
					.Add("start_date", sDate)
					.Add("end_date", eDate)
					.Add("insert_date", DateTime.Now);

				"INSERT INTO stock_picks (symbol, username, duration_days, start_date, end_date, insert_date, correct_pick) VALUES (@symbol, @user, @duration_days, @start_date, @end_date, @insert_date, 0)"
					.Insert(dps);

				eDate = sDate;
			}
		}
	}
}