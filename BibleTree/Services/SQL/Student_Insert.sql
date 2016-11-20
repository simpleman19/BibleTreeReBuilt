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
	[user_type] = 's',
	[user_active] = 1
WHERE [user].[user_id] = @user_id
END
GO

IF NOT EXISTS 
( 
	SELECT 1 
	FROM [BibleTree].[dbo].[student] 
	WHERE [user_id] = @user_id 
)
BEGIN
INSERT INTO [BibleTree].[dbo].[student]
(
	[user_id],
	[student_id],
	[student_dateEnrolled],
	[student_dateGraduated]
)
VALUES
(
	@user_id,
	@student_id,
	@student_dateEnrolled,
	@student_dateGraduated
)
END
GO