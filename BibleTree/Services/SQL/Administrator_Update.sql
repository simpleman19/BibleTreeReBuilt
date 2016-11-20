IF NOT EXISTS 
( 
	SELECT 1 
	FROM [BibleTree].[dbo].[user] 
	WHERE [user_id] = @user_id 
		AND [user-active] = 1
)
BEGIN
UPDATE [BibleTree].[dbo].[user]
SET
	[user_email] = @user_email,
	[user_name] = @user_name,
	[user_token] = @user_token,
	[user_type] = @user_type
WHERE [user].[user_id] = @user_id

UPDATE [BibleTree].[dbo].[administrator]
SET
	[administrator_permLevel] = @administrator_permLevel
WHERE [administrator].[user_id] = @user_id
END