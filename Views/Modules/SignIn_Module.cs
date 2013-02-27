using LucidEdge.Html;
using StockPickem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views.Modules
{
	public class SignIn_Module : BaseModule
	{
		public SignIn_Module()
			: base("div") {	}
	
		public override IHtml ToHtml()
		{
			return
			Container.Add(
				"form#loginForm.form-signin"
					.Attr("action", "/Home/CheckLoginCredentials", "method", "POST")
					.Add(
						"h2.form-signin-heading".Add("Please sign in"),
						"input.input-block-level".Attr("type", "text", "name", "email", "placeholder", "Email"),
						"input.input-block-level".Attr("type", "password", "name", "pw", "placeholder", "Password"),
						"button#submitBtn.btn.btn-primary".Attr("type", "submit").Add("Sign in"),
						"a.frame-h".Attr("href", "/Home/Register").Add(
							"button.btn".Attr("type", "button").Add("Register")
						),
						"div.alert.frame-t.flush-b.none".Add()
					)
			);
		}
	}
}