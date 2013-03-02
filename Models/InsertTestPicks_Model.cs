using LucidEdge.DataMapping;
using StockPickem.Data.Sql;
using StockPickem.DomainObjects;
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
			int count = 10;

			DateTime eDate = DateTime.Today;
			List<List<IDataPoint>> dbPoints = new List<List<IDataPoint>>();

			var users = SqlRequests.UserScripts.ReadAllUsers.Read<User>();

			for (int i = 0; i < count; i++)
			{
				int duration_days = rand.Next(1, 5);

				var sDate = eDate.AddDays(duration_days * -1);

				var dps = new List<IDataPoint>()
					.Add("symbol", "AAPL")
					.Add("user", "lucas")
					.Add("duration_days", duration_days)
					.Add("start_date", sDate)
					.Add("end_date", eDate)
					.Add("insert_date", DateTime.Now)
					.Add("correct_pick", 
						i == 0
							? 0 // this will end up as the very last pick and won't have a value until EOD
							: rand.Next(0, 2) % 2 == 0 
								? 1 
								: -1);

				dbPoints.Add(dps.ToList());

				eDate = sDate;
			}

			for (int i = dbPoints.Count -1; i >= 0; i--)
			{
				"INSERT INTO stock_picks (symbol, username, duration_days, start_date, end_date, insert_date, correct_pick) VALUES (@symbol, @user, @duration_days, @start_date, @end_date, @insert_date, @correct_pick)"
					.Insert(dbPoints[i]);
			}
		}
	}
}