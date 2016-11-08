IF DB_ID('BibleTree') IS NOT NULL 
BEGIN
	ALTER DATABASE [BibleTree] SET single_user with rollback immediate 
	DROP DATABASE [BibleTree]
END