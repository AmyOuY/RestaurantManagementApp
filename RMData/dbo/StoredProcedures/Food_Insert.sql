CREATE PROCEDURE [dbo].[Food_Insert]
	@Id int = 0 output,
	@FoodType nvarchar(100),
	@FoodName nvarchar(100),
	@Price money,
	@Quantity int,
	@OrderId int
AS
	insert into dbo.Food (FoodType, FoodName, Price, Quantity, OrderId)
	values (@FoodType, @FoodName, @Price, @Quantity, @OrderId);

	select @Id = SCOPE_IDENTITY();
RETURN 0
