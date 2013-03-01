SELECT DISTINCT symbol FROM stock_picks AS p
WHERE p.username = @username;