﻿SELECT [awardedbadge].*, [badge].* 
FROM [BibleTree].[dbo].[awardedbadge] join [BibleTree].[dbo].[badge]
	on [awardedbadge].[badge_id] = [badge].[badge_id]