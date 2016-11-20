SELECT [user].*
FROM [BibleTree].[dbo].[user]
WHERE [user].[user_email] = @user_email
	AND [user].[user_active] = 1