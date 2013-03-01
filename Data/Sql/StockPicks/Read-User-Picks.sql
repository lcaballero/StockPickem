SELECT * from stock_picks 
	WHERE symbol = @symbol 
	AND username = @username;