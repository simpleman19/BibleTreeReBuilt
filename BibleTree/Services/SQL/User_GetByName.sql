SELECT [user].*
FROM [BibleTree].[dbo].[user]
WHERE [user].[user_name] = @user_name
	AND [user].[user_active] = 1