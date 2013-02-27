using LucidEdge.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views.Modules
{
	public class MainNav : BaseModule
	{
		public bool ShowLogin {get; set;}
		public string ActiveItem { get; set; }

		public MainNav()
			: base("nav.navbar-wrapper.container") { }

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				"div.navbar.navbar-inverse".Add(
					"div.navbar-inner".Add(
						"a.brand".Attr("href", "/Home").Add("Stock Pickem"),
						"ul.nav".Add(
							"li".Add("a".Attr("href", "/Home").Add("Home")
							).AddClassIf(ActiveItem == "home", () => "active"),
							"li".AddIf(IsAuthenticated,
								() => "a".Attr("href", "/Progress/MyProgress").Add("My Progress")
							).AddClassIf(ActiveItem == "myprogress", () => "active"),
							"li".AddIf(IsAuthenticated && AuthUserName == "ryan" || AuthUserName == "lucas",
								() => "a".Attr("href", "/Admin/Index").Add("Admin")
							).AddClassIf(ActiveItem == "admin", () => "active")
						),
						"div.t1.pull-right".AddIf(ShowLogin, 
							() => {
								if(IsAuthenticated) {
									return
									"div".Add(
										"span.navbar-text.frame-h.inline-bock".Add(string.Format("Logged in as {0}", AuthUserName)),
										"form.navbar-form.inline-block"
											.Attr("action", "/Home/SignOut", "method", "POST")
											.Add(
											
												"button.btn.btn-small.flush-t".Attr("type", "submit").Add("Sign out")
											)
									);
								
								} else {
									return
									"ul.nav".Add(
										"li".Add(
											"a".Attr("href", "/Home/SignIn").Add("Sign in")
										),
										"li".Add(
											"span.navbar-text.frame-h.inline-bock".Add("|")
										),
										"li".Add(
											"a".Attr("href", "/Home/Register").Add("Register")
										)
									);
								}
							}
						)
					)
				)
			);
		}
	}
}