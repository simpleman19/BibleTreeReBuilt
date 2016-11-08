CREATE TABLE [faculty] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user](user_id), 
	[faculty_department] varchar(32), 
	[faculty_position] varchar(32) 
)