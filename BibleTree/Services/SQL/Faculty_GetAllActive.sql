SELECT [faculty].*, [user].* 
FROM [BibleTree].[dbo].[faculty], [BibleTree].[dbo].[user] 
WHERE [faculty].[user_id] = [user].[user_id]
	AND [user].[user_active] = 1