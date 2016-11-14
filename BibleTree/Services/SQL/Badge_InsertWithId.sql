SET IDENTITY_INSERT [BibleTree].[dbo].[badge] ON
INSERT INTO [BibleTree].[dbo].[badge] 
(
	[badge_id], 
	[badge_name], 
	[badge_description], 
	[badge_level], 
	[badge_activeDate], 
	[badge_expirationDate], 
	[badge_gifURL], 
	[badge_pngURL] 
)
VALUES 
( 
	@badge_id, 
	@badge_name, 
	@badge_description, 
	@badge_level, 
	@badge_activeDate, 
	@badge_expirationDate, 
	@badge_gifURL, 
	@badge_pngURL 
)
SET IDENTITY_INSERT [BibleTree].[dbo].[badge] OFF