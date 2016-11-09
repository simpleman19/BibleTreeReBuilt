DELETE FROM [BibleTree].[dbo].[awardedbadge]
WHERE [awardedbadge].[user_id] = @user_id
	AND [awardedbadge].[badge_id] = @badge_id