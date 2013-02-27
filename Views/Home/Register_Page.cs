using LucidEdge.Html;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class Register_Page : HtmlContainer
	{
		public Register_Page()
			: base("div#register-page")
		{

		}

		public override IHtml ToHtml()
		{
			return Container.Add(
				new MainNav(),
				"div.container".Add(
					"form#registrationForm.form-signin"
						.Attr("action", "/Home/SaveUserRegistration", "method", "POST")
						.Add(
							"h2.form-signin-heading".Add("Register"),
							"input.input-block-level".Attr("type", "text", "name", "email", "placeholder", "Email address"),
							"input.input-block-level".Attr("type", "password", "name", "pw", "placeholder", "Password"),
							"button.btn.btn-primary".Attr("type", "submit").Add("Register"),
							"div.alert.frame-t.flush-b.none".Add()
						)
				)				
			);
		}
	}
}
