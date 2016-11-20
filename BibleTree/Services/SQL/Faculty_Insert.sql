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
	[user_type] = 'f'
WHERE [user].[user_id] = @user_id
END
GO

IF NOT EXISTS 
( 
	SELECT 1 
	FROM [BibleTree].[dbo].[faculty] 
	WHERE [user_id] = @user_id 
)
BEGIN
INSERT INTO [BibleTree].[dbo].[faculty]
(
	[user_id],
	[faculty_department],
	[faculty_position]
)
VALUES
(
	@user_id,
	@faculty_department,
	@faculty_position
)
END
GO