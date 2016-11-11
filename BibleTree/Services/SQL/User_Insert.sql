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