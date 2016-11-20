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