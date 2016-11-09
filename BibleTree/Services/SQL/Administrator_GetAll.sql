SELECT [administrator].*, [user].* 
FROM [BibleTree].[dbo].[administrator], [BibleTree].[dbo].[user] 
WHERE [administrator].[user_id] = [user].[user_id]