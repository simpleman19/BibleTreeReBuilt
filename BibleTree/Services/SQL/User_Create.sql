CREATE TABLE [user] 
( 
	[user_id] int PRIMARY KEY IDENTITY(1,1), 
	[user_email] varchar(32), 
	[user_name] varchar(64), 
	[user_token] varchar(255), 
	[user_type] char 
);