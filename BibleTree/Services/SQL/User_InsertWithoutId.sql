INSERT INTO [BibleTree].[dbo].[user]
(
	[user_email],
	[user_name],
	[user_token],
	[user_type],
	[user_active]
)
VALUES
(
	@user_email,
	@user_name,
	@user_token,
	@user_type,
	1
)