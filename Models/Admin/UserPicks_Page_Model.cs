using LucidEdge.DataMapping;
using LucidEdge.DataMapping.Samples.DomainObjects;
using LucidEdge.DataMapping.Samples.SqlScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class UserPicks_Page_Model : Base_Model
	{
		public List<string> UserNames { get; private set; }

		public void Init()
		{
			var users = UserScripts.Read_All_Users.Read<User>(
				new List<DataPoint>());

			UserNames = users.Select(
				u => u.UserName).ToList();
		}

		public void Load()
		{

		}
	}
}