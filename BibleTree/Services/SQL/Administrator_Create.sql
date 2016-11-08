CREATE TABLE [administrator] 
( 
	[user_id] int PRIMARY KEY FOREIGN KEY REFERENCES [user](user_id), 
	[administrator_permlevel] int
)