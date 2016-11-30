UPDATE [BibleTree].[dbo].[awardedbadge]
SET
	[award_xcoord] = @award_xcoord,
	[award_ycoord] = @award_ycoord
WHERE [awardedbadge].[award_id] = @award_id