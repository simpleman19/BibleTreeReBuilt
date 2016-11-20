SELECT [badge].*
FROM [BibleTree].[dbo].[badge]
WHERE [badge].[badge_name] = @badge_name
	AND [badge].[badge_gifURL] = @badge_gifURL
	AND [badge].[badge_pngURL] = @badge_pngURL
	AND [badge].[badge_description] = @badge_description
	AND [badge].[badge_activeDate] = @badge_activeDate
	AND [badge].[badge_expirationDate] = @badge_expirationDate
	AND [badge].[badge_level] = @badge_level