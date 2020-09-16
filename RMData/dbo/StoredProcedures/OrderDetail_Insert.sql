CREATE PROCEDURE [dbo].[OrderDetail_Insert]
	@Id int = 0 output,
    @DiningTableId int, 
    @ServerId int,
    @FoodId int,
    @Quantity int,
    @OrderDate datetime2

AS
	insert into dbo.OrderDetail (DiningTableId, ServerId, FoodId, Quantity, OrderDate)
    values (@DiningTableId, @ServerId, @FoodId, @Quantity, @OrderDate);

    select @Id = SCOPE_IDENTITY();

RETURN 0
