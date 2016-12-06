CREATE DATABASE [BibleTree]
GO

CREATE TABLE [BibleTree].[dbo].[user] 
( 
	[user_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	[user_email] varchar(64) NOT NULL, 
	[user_name] varchar(64) NOT NULL, 
	[user_token] varchar(255), 
	[user_type] char,
	[user_active] bit NOT NULL
)
GO

CREATE TABLE [BibleTree].[dbo].[student]
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[student_id] varchar(7) NOT NULL, 
	[student_dateEnrolled] datetime, 
	[student_dateGraduated] datetime 
)
GO

CREATE TABLE [BibleTree].[dbo].[faculty] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[faculty_department] varchar(64), 
	[faculty_position] varchar(64) 
)
GO

CREATE TABLE [BibleTree].[dbo].[administrator] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[administrator_permLevel] int
)
GO

CREATE TABLE [BibleTree].[dbo].[badge] 
( 
	[badge_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	[badge_name] varchar(64) NOT NULL, 
	[badge_description] varchar(255), 
	[badge_level] int NOT NULL, 
	[badge_activeDate] datetime NOT NULL,
	[badge_expirationDate] datetime NOT NULL,
	[badge_gifURL] varchar(255), 
	[badge_pngURL] varchar(255),
	[badge_active] bit NOT NULL
)
GO

CREATE TABLE [BibleTree].[dbo].[awardedbadge] 
( 
	[award_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[user_id] int FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL,
	[badge_id] int FOREIGN KEY REFERENCES [badge]([badge_id]) NOT NULL, 
	[award_sentid] int FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[award_timestamp] datetime NOT NULL, 
	[award_comment] varchar(255),
	[award_xcoord] int,
	[award_ycoord] int,
	[award_active] bit NOT NULL
)
GO