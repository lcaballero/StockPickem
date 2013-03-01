using LucidEdge.DataMapping;
using StockPickem.Data.Sql;
using StockPickem.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class UserPerformance_Page_Model : Base_Model
	{
		public List<string> UserNames { get; private set; }
		public UserPerformance_Model UserPerformance { get; set; }

		public void Init()
		{
			var users = SqlRequests.UserScripts.ReadAllUsers.Read<User>(
				new List<DataPoint>());

			UserNames = users.Select(
				u => u.UserName).ToList();
			UserPerformance = new UserPerformance_Model();
			UserPerformance.Init(UserNames.FirstOrDefault());
			
		}

		public void Load()
		{
			UserPerformance.Load();
		}
	}
}