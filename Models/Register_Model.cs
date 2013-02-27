using LucidEdge.DataMapping;
using LucidEdge.DataMapping.Samples.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class Register_Model
	{
		public int Status { get; set; }
		public string StatusMsg { get; set; }

		public void Init(string email, int userGroupId, string pw)
		{
			var user_name = HttpContext.Current.Request.Params["email"];
			var user_pw = HttpContext.Current.Request.Params["pw"];

			var dps = new List<DataPoint>()
				.Add("username", email);

			List<User> _users = "select * from _user where username = @username;".Read<User>(dps).ToList();
			User _user = _users.FirstOrDefault();

			if (_user != null)
			{
				Status = -1;
				StatusMsg = "User already exists.";
			}
			else
			{
				New_User user = new New_User();

				user.Insert_New_User(email, userGroupId, pw);

				Status = 1;
				StatusMsg = "Success";
			}
		}
	}
}