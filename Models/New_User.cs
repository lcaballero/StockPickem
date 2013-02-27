using LucidEdge.DataMapping;
using LucidEdge.DataMapping.Samples.SqlScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class New_User
	{
		private Random Rand = new Random();

		public void Insert_New_User(string userName, int userGroupId, string pw)
		{
			var dps = new List<DataPoint>()
				.Add("id", Rand.Next())
				.Add("version", Rand.Next())
				.Add("created_at", DateTime.Now)
				.Add("updated_on", DateTime.Now)
				.Add("isactive", true)
				.Add("islocked", true)
				.Add("usergroup_id", userGroupId)
				.Add("password", pw)
				.Add("username", userName);

			UserScripts.Insert_User.Insert(dps);
		}
	}
}