CREATE TABLE [student] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user](user_id), 
	[student_id] varchar(7), 
	[student_dateEnrolled] date, 
	[student_dateGraduated] date 
)