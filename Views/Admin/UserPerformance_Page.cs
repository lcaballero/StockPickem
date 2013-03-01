using LucidEdge.Html;
using StockPickem.Models;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class UserPerformance_Page : BaseModule
	{
		public UserPerformance_Page_Model Model { get; set; }

		public UserPerformance_Page()
			: base("div#user-performance-page") { }

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				new MainNav() { ActiveItem = "Admin" },
				"div.container".Add(
					"h1".Add("Admin Page"),
					"div.row".Add(
						"div.span3".Add(
							new AdminSideBar_Module() { ActiveItem = "UserPerformance" }
						),
						"div.span9".Add(
							"div".Add(
								RenderUserMenu(Model.UserNames)
							),
							"div#scUserPerformance".Add(
								new UserPerformance_MainModule() { Model = Model.UserPerformance }							
							)
						)						
					)
				)
			);
		}

		private IHtml RenderUserMenu(List<string> list)
		{
			
			var sel = "select#selected-user".Add();

			list.ForEach(
				s => sel.Add(
					"option".Attr("value", s).Add(s))
			);

			return sel;
		}
	}

	public class UserPerformance_MainModule : BaseModule
	{
		public UserPerformance_Model Model { get; set; }

		public UserPerformance_MainModule()
			: base("div#user-performance") { }

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				"div.hero-unit".Add(
					"div".Add(
						RenderSymbolsMenu(Model.Symbols)
					),
					"p".Add("User pick performance"),
					"div#chart-wrapper".Add()
				)
			);
		}

		private IHtml RenderSymbolsMenu(List<string> list)
		{
			var sel = "select#selected-symbol".Add();

			list.ForEach(
				s => sel.Add(
					"option".Attr("value", s).Add(s))
			);

			return sel;
		}
	}
}