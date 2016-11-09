INSERT INTO [BibleTree].[dbo].[user]
(
	[user_id],
	[user_email],
	[user_name],
	[user_token],
	[user_type]
)
Values
(
	@user_id,
	@user_email,
	@user_name,
	@user_token,
	@user_type
);