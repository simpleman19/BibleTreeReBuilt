SELECT [user].*
FROM [BibleTree].[dbo].[user]
WHERE [user].[user_id] = @user_id
	AND [user].[user_active] = 1