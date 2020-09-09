CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ServerId] INT NOT NULL, 
    [DiningTableId] INT NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL DEFAULT getutcdate() , 
    [SubTotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL, 
    CONSTRAINT [FK_Order_ToDiningTable] FOREIGN KEY (ServerId) REFERENCES People(Id), 
    CONSTRAINT [FK_Order_ToPeople] FOREIGN KEY (DiningTableId) REFERENCES DiningTable(Id) 
   
)
