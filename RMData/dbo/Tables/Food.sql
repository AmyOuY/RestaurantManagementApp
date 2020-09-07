CREATE TABLE [dbo].[Food]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FoodType] NVARCHAR(100) NOT NULL, 
    [FoodName] NVARCHAR(100) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Quantity] INT NULL, 
    [OrderId] INT NULL
)
