CREATE TABLE [dbo].[WeatherForecast]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [TemperatureC] INT NOT NULL, 
    [WeatherStationId] INT NOT NULL,
    [ForecastDate] DATE NOT NULL,
    [createdDate] DATETIME NOT NULL, 
    [modifiedDate] DATETIME NOT NULL, 
    [deletedDate] DATETIME NULL, 
    CONSTRAINT [FK_WeatherForecast_WeatherStation] FOREIGN KEY([WeatherStationId])
    REFERENCES [dbo].[WeatherStation] ([Id])
)
