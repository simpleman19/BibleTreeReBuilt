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
GO

INSERT INTO [BibleTree].[dbo].[student]
(
	[user_id],
	[student_id],
	[student_dateenrolled],
	[student_dategraduated]
)
VALUES
(
	@user_id,
	@student_id,
	@student_dateenrolled,
	@student_dategraduated
)
GO