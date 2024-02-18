CREATE TABLE [dbo].[WeatherStation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [code] NVARCHAR(50) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [longitude] DECIMAL NOT NULL, 
    [latitude] DECIMAL NOT NULL, 
    [createdDate] DATETIME NOT NULL, 
    [modifiedDate] DATETIME NULL, 
    [deletedDate] DATETIME NULL
)
