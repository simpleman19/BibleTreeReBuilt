UPDATE [BibleTree].[dbo].[user]
SET
	[user_id] = @user_id,
	[user_email] = @user_email,
	[user_name] = @user_name,
	[user_token] = @user_token,
	[user_type] = @user_type
WHERE [user].[user_id] = @user_id