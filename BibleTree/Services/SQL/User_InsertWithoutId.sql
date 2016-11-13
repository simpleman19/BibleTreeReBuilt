INSERT INTO [BibleTree].[dbo].[user]
(
	[user_email],
	[user_name],
	[user_token],
	[user_type]
)
VALUES
(
	@user_email,
	@user_name,
	@user_token,
	@user_type
)