using LucidEdge.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.DomainObjects
{
	public class UserPick : DomainObject
	{
		public string Symbol { get { return Map["symbol"].ToValue<string>(); } }
		public string UserName { get { return Map["username"].ToValue<string>(); } }
		public int Duration { get { return Map["duration_days"].ToValue<int>(); } }
		public DateTime StartDate { get { return Map["start_date"].ToValue<DateTime>(); } }
		public DateTime EndDate { get { return Map["end_date"].ToValue<DateTime>(); } }
		public DateTime InsertDate { get { return Map["insert_date"].ToValue<DateTime>(); } }
		public int CorrectPick { get { return Map["correct_pick"].ToValue<int>(); } }
	}
}