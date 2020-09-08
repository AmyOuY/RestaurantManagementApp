CREATE PROCEDURE [dbo].[Food_Insert]
	@Id int = 0 output,
	@FoodType nvarchar(100),
	@FoodName nvarchar(100),
	@Price money
AS
	insert into dbo.Food (FoodType, FoodName, Price)
	values (@FoodType, @FoodName, @Price);

	select @Id = SCOPE_IDENTITY();
RETURN 0
