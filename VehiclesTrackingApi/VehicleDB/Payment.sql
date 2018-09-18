CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [vehicleId] INT NOT NULL, 
    [day] DATE NOT NULL, 
    [kilometers] DECIMAL NULL, 
    [fuel] DECIMAL NULL, 
    [service] DECIMAL NULL, 
    [parts] DECIMAL NULL, 
    [insurance] DECIMAL NULL, 
    [tax] DECIMAL NULL, 
    [comment] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Payment_ToVehicle] FOREIGN KEY ([vehicleId]) REFERENCES Vehicle(Id) 
)
