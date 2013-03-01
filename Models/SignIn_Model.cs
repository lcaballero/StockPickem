using LucidEdge.DataMapping;
using StockPickem.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StockPickem.Models
{
	public class SignIn_Model
	{
		//public bool UserExists { get; private set; }
		public bool IsAuthenticated { get; private set; }

		//public string Email { get; set; }
		//public string PW { get; set; }

		public void CheckUserCredentials()
		{
			var user_name = HttpContext.Current.Request.Params["email"];
			var user_pw = HttpContext.Current.Request.Params["pw"];

			if (user_name != null && user_pw != null)
			{
				var dps = new List<DataPoint>()
					.Add("username", user_name)
					.Add("pw", user_pw);

				List<User> _users = "select * from _user where username = @username AND password = @pw;".Read<User>(dps).ToList();
				User _user = _users.FirstOrDefault();

				IsAuthenticated = _user != null;

				if (IsAuthenticated)
				{
					string userData = "ApplicationSpecific data for this user.";
					var isPersistent = false;

					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
						_user.UserName,
						DateTime.Now,
						DateTime.Now.AddMinutes(30),
						isPersistent,
						userData,
						FormsAuthentication.FormsCookiePath);

					// Encrypt the ticket.
					string encTicket = FormsAuthentication.Encrypt(ticket);

					// Create the cookie.
					HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
				}
			}
		}

	}
}