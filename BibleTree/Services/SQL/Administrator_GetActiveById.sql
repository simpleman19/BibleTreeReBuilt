SELECT [administrator].*, [user].* 
FROM [BibleTree].[dbo].[administrator], [BibleTree].[dbo].[user] 
WHERE [administrator].[user_id] = [user].[user_id] 
	AND [user].[user_id] = @user_id
	AND [user].[user_active] = 1