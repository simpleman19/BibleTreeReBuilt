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
	[badge_pngURL],
	[badge_active]
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
	@badge_pngURL,
	1 
)
SET IDENTITY_INSERT [BibleTree].[dbo].[badge] OFF