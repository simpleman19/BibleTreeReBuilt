UPDATE [BibleTree].[dbo].[user]
SET
	[user_email] = @user_email,
	[user_name] = @user_name,
	[user_token] = @user_token,
	[user_type] = @user_type
WHERE [user].[user_id] = @user_id
GO

UPDATE [BibleTree].[dbo].[student]
SET
	[student_id] = @student_id,
	[student_dateEnrolled] = @student_dateEnrolled,
	[student_dateGraduated] = @student_dateGraduated
WHERE [student].[user_id] = @user_id
GO