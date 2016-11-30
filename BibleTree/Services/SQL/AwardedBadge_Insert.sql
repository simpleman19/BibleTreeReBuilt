INSERT INTO [BibleTree].[dbo].[awardedbadge]
(
	[user_id], 
	[badge_id], 
	[award_sentid], 
	[award_timestamp], 
	[award_comment]
)
VALUES 
(
	@user_id,
	@badge_id,
	@award_sentid,
	@award_timestamp,
	@award_comment
);