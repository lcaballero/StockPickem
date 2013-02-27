using LucidEdge.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views.Modules
{
	public class AdminSideBar_Module : BaseModule
	{
		public string ActiveItem { get; set; }

		public AdminSideBar_Module()
			: base("div#admin-sidebar-module")
		{

		}
		public override IHtml ToHtml()
		{
			return
			Container.Add(
				"div.well.sidebar-nav".Add(
					"ul.nav.nav-list".Add(
						"li.nav-header".Add("DB setup"),
						"li".Add(
							"a".Attr("href", "/Admin/CreateStockPicksTable").Add("Create/clear 'stock_picks' table")
						),
						"li".Add(
							"a".Attr("href", "/Admin/InsertTestPicks").Add("Insert Test Picks")
						),
						"li.nav-header".Add("Admin tools"),
						"li".Add(
							"a".Attr("href", "/Admin/UserPicks").Add("User picks")
						).AddClassIf(ActiveItem == "userpicks", () => "active")
					)
				)
			);
		}
	}
}