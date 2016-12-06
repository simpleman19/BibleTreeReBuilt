SELECT [awardedbadge].*, [badge].* 
FROM [BibleTree].[dbo].[awardedbadge], [BibleTree].[dbo].[badge] 
WHERE [awardedbadge].[user_id] = @user_id and [awardedbadge].[badge_id] = [badge].[badge_id]
	and [awardedbadge].[award_active] = 1