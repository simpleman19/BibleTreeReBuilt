UPDATE [BibleTree].[dbo].[awardedbadge]
SET
	[user_id] = @user_id, 
	[badge_id] = @badge_id, 
	[award_sentid]= @award_sentid, 
	[award_date] = @award_date, 
	[award_comment] = @award_comment
WHERE [awardedbadge].[award_id] = @award_id