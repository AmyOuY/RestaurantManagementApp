CREATE PROCEDURE [dbo].[OrderDetail_Insert]
	@Id int = 0 output,
	@OrderId int,
	@FoodId int,
	@Quantity int,
	@OrderPrice money

AS
	insert into dbo.OrderDetail (OrderId, FoodId, Quantity, OrderPrice)
	values (@OrderId, @FoodId, @Quantity, @OrderPrice);

	select @Id = SCOPE_IDENTITY();

RETURN 0
