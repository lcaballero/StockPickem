using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Models
{
	public class Base_Model
	{
		public bool IsAuthenticated
		{
			get
			{
				return HttpContext.Current.User.Identity.IsAuthenticated;
			}
		}

		public string AuthUserName
		{
			get
			{
				return HttpContext.Current.User.Identity.Name;
			}
		}
	}
}