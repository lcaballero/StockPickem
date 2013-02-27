
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LucidEdge.Html;
using StockPickem.Views.Modules;

namespace StockPickem.Views
{
	public class Home_Page : HtmlContainer 
	{
		public Home_Page()
			: base("div#home-page")
		{

		}

		public override IHtml ToHtml()
		{
			return Container.Add(
				new MainNav() { ShowLogin = true, ActiveItem = "home" },
				"div.container".Add(
					"h1".Add("Home"),
					"div.container.marketing".Add(
						"div.row".Add(
							"div.span4".Add(
								"h2".Add("Heading"),
								"p".Add("Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna, vel scelerisque nisl consectetur et")
							)
						)
					)
				)
			);
		}
	}
}