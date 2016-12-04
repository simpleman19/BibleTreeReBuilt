SELECT [awardedbadge].*, [badge].* 
FROM [BibleTree].[dbo].[awardedbadge], [BibleTree].[dbo].[badge] 
WHERE [awardedbadge].[user_id] = @user_id AND [awardedbadge].[badge_id] = [badge].[badge_id]