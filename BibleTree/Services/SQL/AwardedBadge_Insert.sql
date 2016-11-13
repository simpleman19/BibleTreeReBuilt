INSERT INTO [BibleTree].[dbo].[awardedbadge]
(
	[user_id], 
	[badge_id], 
	[award_sentId], 
	[award_date], 
	[award_comment]
)
VALUES 
(
	@user_id,
	@badge_id,
	@award_sentid,
	@award_date,
	@award_comment
);