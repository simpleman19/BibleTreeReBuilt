﻿INSERT INTO [BibleTree].[dbo].[badge] 
(
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
	@badge_name, 
	@badge_description, 
	@badge_level, 
	@badge_activeDate, 
	@badge_expirationDate, 
	@badge_gifURL, 
	@badge_pngURL 
)