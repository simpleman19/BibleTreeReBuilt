IF NOT EXISTS 
( 
	SELECT 1 
	FROM [BibleTree].[dbo].[user] 
	WHERE [user_id] = @user_id 
)
BEGIN
SET IDENTITY_INSERT [BibleTree].[dbo].[user] ON
INSERT INTO [BibleTree].[dbo].[user]
(
	[user_id],
	[user_email],
	[user_name],
	[user_token],
	[user_type],
	[user_active]
)
VALUES
(
	@user_id,
	@user_email,
	@user_name,
	@user_token,
	@user_type,
	1
)
SET IDENTITY_INSERT [BibleTree].[dbo].[user] OFF
END
ELSE
BEGIN
UPDATE [BibleTree].[dbo].[user]
SET
	[user_email] = @user_email,
	[user_name] = @user_name,
	[user_token] = @user_token,
	[user_type] = @user_type,
	[user_active] = 1
WHERE [user].[user_id] = @user_id
END