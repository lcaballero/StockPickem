using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockPickem.Data.Sql
{
	public static class SqlRequests
	{
		public static class UserScripts
		{
			public static string CreateTables { get { return UserSqlScripts.Create_Tables; } }
			public static string DropTables { get { return UserSqlScripts.Drop_Tables; } }
			public static string InsertUser { get { return UserSqlScripts.Insert_User; } }
			public static string ReadAllUsers { get { return UserSqlScripts.Read_All_Users; } }
			public static string ReadUser { get { return UserSqlScripts.Read_User; } }
		}

		public static class StockPicks
		{
			public static string CreateStockPicksTable { get { return StockPicksSqlScripts.Create_Stock_Picks_Table; } }
			public static string ReadUserPicks { get { return StockPicksSqlScripts.Read_User_Picks; } }
			public static string ReadUsersSymbols { get { return StockPicksSqlScripts.Read_Users_Symbols; } }
		}
	}
}
