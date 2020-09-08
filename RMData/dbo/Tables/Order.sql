CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TableID] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [FoodID] INT NOT NULL, 
    CONSTRAINT [FK_Order_ToDiningTable] FOREIGN KEY ([TableID]) REFERENCES [DiningTable]([Id]), 
    CONSTRAINT [FK_Order_ToPeople] FOREIGN KEY ([PersonID]) REFERENCES [People]([Id]), 
    CONSTRAINT [FK_Order_ToFood] FOREIGN KEY ([FoodID]) REFERENCES [Food]([Id])
)
