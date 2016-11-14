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
	[user_type]
)
VALUES
(
	@user_id,
	@user_email,
	@user_name,
	@user_token,
	@user_type
)
SET IDENTITY_INSERT [BibleTree].[dbo].[user] OFF
END

ELSE

BEGIN
UPDATE [BibleTree].[dbo].[user]
SET
	[user_type] = 'a'
WHERE [user].[user_id] = @user_id
END
GO

IF NOT EXISTS 
( 
	SELECT 1 
	FROM [BibleTree].[dbo].[administrator] 
	WHERE [user_id] = @user_id 
)
BEGIN
INSERT INTO [BibleTree].[dbo].[administrator]
(
	[user_id],
	[administrator_permLevel]
)
VALUES
(
	@user_id,
	@administrator_permLevel
)
END
GO