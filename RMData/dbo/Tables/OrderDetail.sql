CREATE TABLE [dbo].[OrderDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [FoodId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [OrderPrice] MONEY NOT NULL, 
    CONSTRAINT [FK_OrderDetail_ToOrder] FOREIGN KEY (OrderId) REFERENCES [Order](Id), 
    CONSTRAINT [FK_OrderDetail_ToFood] FOREIGN KEY (FoodId) REFERENCES Food(Id)
)