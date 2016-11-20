SELECT [student].*, [user].* 
FROM [BibleTree].[dbo].[student], [BibleTree].[dbo].[user] 
WHERE [student].[user_id] = [user].[user_id] 
	AND [user].[user_id] = @User_id