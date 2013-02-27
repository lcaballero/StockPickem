using LucidEdge.Html;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class Admin_Page : BaseModule
	{
		public string Msg { get; set; }

		public Admin_Page()
			: base("div#admin-page") {}

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				new MainNav() { ActiveItem = "admin" },
				"div.container".Add(
					"h1".Add("Admin Page"),
					"div.row".Add(
						"div.span3".Add(
							new AdminSideBar_Module()
						),
						"div.span9".Add(
							"p".Add(
								"If this is you first time to this page. Start buy clicking the 'Create/clear stocks_picks table' link. It will create the necessary table for user stock picks."
							),
							"div".AddIf(Msg != null, () => {
								return
								"div.alert.alert-warning".Add(Msg);
							})
						)
					)
				)
			);
		}
	}
}