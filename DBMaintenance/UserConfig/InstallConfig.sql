IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' AND  
                 TABLE_NAME = 'Configuration'))
BEGIN
    
	EXEC ('SET ANSI_NULLS ON')

	EXEC('SET QUOTED_IDENTIFIER ON')

	EXEC('SET ANSI_PADDING ON')

	DECLARE @SQLString VARCHAR(MAX)
	SET @SQLString = N'CREATE TABLE [dbo].[Configuration](' +
		N'[Id] [int] IDENTITY(1,1) NOT NULL,' +
		N'[ParameterName] [varchar](200) NOT NULL,' +
		N'[ParameterValue] [varchar](max) NOT NULL,' +
		N'[Domain] [varchar](200) NOT NULL,' +
	N'CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED ' +
	N'(' +
		N'[Id] ASC' +
	N')	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]' +
	N') ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]'

	EXEC (@SQLString)

	SET @SQLString = N'CREATE UNIQUE NONCLUSTERED INDEX [ParameterName] ON [dbo].[Configuration]' +
	N'(' +
		N'[ParameterName] ASC,' +
		N'[Domain] ASC' +
	N')WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)'
	
	EXEC (@SQLString)

	EXEC ('SET ANSI_PADDING OFF')
END 
GO