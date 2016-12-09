UPDATE [BibleTree].[dbo].[awardedbadge]
SET
	[award_active] = 0
WHERE [awardedbadge].[award_id] = @award_id