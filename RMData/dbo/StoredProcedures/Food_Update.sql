CREATE PROCEDURE [dbo].[Food_Update]
	@Id int,
	@FoodType nvarchar(100),
	@FoodName nvarchar(100),
	@Price money

AS
	update dbo.Food 
	set FoodType = @FoodType, FoodName = @FoodName, Price = @Price
	where Id = @Id;

RETURN 0
