using LucidEdge.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views.Modules
{
	public class BaseModule : HtmlContainer
	{
		public BaseModule()
		{
			Container = new Html();
		}

		public BaseModule(string tagDef)
		{
			Container = (tagDef ?? "div").Add();
		}

		// TODO: Remove and use the instance from Base_Model
		public bool IsAuthenticated { 
			get {
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