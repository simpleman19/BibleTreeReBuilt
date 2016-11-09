UPDATE [BibleTree].[dbo].[badge]
SET [badge_id] = @id
	,[badge_name] = @name
	,[badge_description] = @description
	,[badge_level] = @level
	,[badge_activeDate] = @activeDate
	,[badge_expirationDate] = @expirationDate
	,[badge_gifURL] = @gifURL
	,[badge_pngURL] = @pngURL
WHERE [badge].[badge_id] = @id