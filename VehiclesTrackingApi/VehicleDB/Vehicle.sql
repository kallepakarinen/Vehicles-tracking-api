CREATE TABLE [dbo].[Vehicle]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [registration] NCHAR(10) NULL, 
    [mark] NVARCHAR(50) NOT NULL, 
    [acquisitionDay] DATE NULL, 
    [price] DECIMAL NULL, 
    [resaleValue] DECIMAL NULL, 
    [active] BIT NOT NULL 
)
