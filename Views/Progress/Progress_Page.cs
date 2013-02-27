using LucidEdge.Html;
using StockPickem.Views.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Views
{
	public class Progress_Page : HtmlContainer
	{
		public Progress_Page()
			: base("div#progress-page")	{ }

		public override IHtml ToHtml()
		{
			return
			Container.Add(
				new MainNav() { ActiveItem = "myprogress" },
				"div.container".Add(
					"h1".Add("My Progress"),
					"div#stock-chart"
						.Attr("style", "height: 500px; min-width: 500px")
						.Add("Test chart")
				)
			);
		}
	}
}