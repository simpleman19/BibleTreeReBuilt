UPDATE [BibleTree].[dbo].[badge]
SET 
	[badge_id] = @badge_id,
	[badge_name] = @badge_name,
	[badge_description] = @badge_description,
	[badge_level] = @badge_level,
	[badge_activeDate] = @badge_activeDate,
	[badge_expirationDate] = @badge_expirationDate,
	[badge_gifURL] = @badge_gifURL,
	[badge_pngURL] = @badge_pngURL
WHERE [badge].[badge_id] = @badge_id