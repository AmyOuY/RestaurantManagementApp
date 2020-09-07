CREATE PROCEDURE [dbo].[Food_Update]
	@Id int,
	@FoodType nvarchar(100),
	@FoodName nvarchar(100),
	@Price money,
	@Quantity int,
	@OrderId int

AS
	update dbo.Food 
	set FoodType = @FoodType, FoodName = @FoodName, Price = @Price, Quantity = @Quantity, OrderId = @OrderId
	where Id = @Id;

RETURN 0
