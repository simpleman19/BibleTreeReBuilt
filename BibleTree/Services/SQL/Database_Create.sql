﻿CREATE DATABASE [BibleTree]
GO

CREATE TABLE [BibleTree].[dbo].[user] 
( 
	[user_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	[user_email] varchar(32) NOT NULL, 
	[user_name] varchar(64) NOT NULL, 
	[user_token] varchar(255), 
	[user_type] char NOT NULL 
);
GO

CREATE TABLE [BibleTree].[dbo].[student]
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[student_id] varchar(7) NOT NULL, 
	[student_dateEnrolled] date, 
	[student_dateGraduated] date 
);
GO

CREATE TABLE [BibleTree].[dbo].[faculty] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[faculty_department] varchar(32), 
	[faculty_position] varchar(32) 
);
GO

CREATE TABLE [BibleTree].[dbo].[administrator] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[administrator_permlevel] int
);
GO

CREATE TABLE [BibleTree].[dbo].[badge] 
( 
	[badge_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	[badge_name] varchar(32) NOT NULL, 
	[badge_description] varchar(255), 
	[badge_level] int NOT NULL, 
	[badge_activeDate] date NOT NULL,
	[badge_expirationDate] date NOT NULL,
	[badge_gifURL] varchar(255), 
	[badge_pngURL] varchar(255)
);
GO

CREATE TABLE [BibleTree].[dbo].[awardedbadge] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL,
	[badge_id] int FOREIGN KEY REFERENCES [badge]([badge_id]) NOT NULL, 
	[award_sentId] int FOREIGN KEY REFERENCES [user]([user_id]) NOT NULL, 
	[award_date] date NOT NULL, 
	[award_comment] varchar(255),
);
GO