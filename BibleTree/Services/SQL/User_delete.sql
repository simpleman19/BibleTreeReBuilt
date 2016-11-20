UPDATE [BibleTree].[dbo].[user]
SET
	[user_active] = 0
WHERE [user].[user_id] = @user_id