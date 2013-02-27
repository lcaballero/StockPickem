using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StockPickem.Models
{
	public class SignOut_Model
	{
		public void SignOut()
		{
			FormsAuthentication.SignOut();
		}
	}
}