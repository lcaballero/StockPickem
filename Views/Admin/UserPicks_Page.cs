using LucidEdge.Html;
using StockPickem.Models;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class UserPicks_Page : BaseModule
	{
		public UserPicks_Page_Model Model { get; set; }

		public UserPicks_Page()
			: base("div#user-picks-page") { }

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				new MainNav() { ActiveItem = "admin" },
				"div.container".Add(
					"h1".Add("Admin Page"),
					"div.row".Add(
						"div.span3".Add(
							new AdminSideBar_Module() { ActiveItem = "userpicks" }
						),
						"div.span9".Add(
							"div".Add(
								"div.btn-group".Add(
									"button.btn".Add("Select User"),
									"button.btn.dropdown-toggle"
										.Attr("data-toggle", "dropdown")
										.Add(
											"span.caret".Add()
										),
									RenderUserMenu(Model.UserNames)

								)
							)
						)
					)
				)
			);
		}

		private IHtml RenderUserMenu(List<string> list)
		{

			var ul = "ul.dropdown-menu".Add();

			list.ForEach(
				s => ul.Add(
					"li".Add(
						"a".Attr("href", "javascript:void(0);").Add(s)))
			);
			return ul;
		}
	}
}