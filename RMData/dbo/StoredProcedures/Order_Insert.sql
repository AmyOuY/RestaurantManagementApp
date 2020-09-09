CREATE PROCEDURE [dbo].[Order_Insert]
	@Id int = 0 output,
	@ServerId int,
	@DiningTableId int,
	@OrderDate datetime2,
	@SubTotal money,
	@Tax money,
	@Total money

AS
	insert into dbo.[Order] (ServerId, DiningTableId, OrderDate, SubTotal, Tax, Total)
	values (@ServerId, @DiningTableId, @OrderDate, @SubTotal, @Tax, @Total);

	select @Id = SCOPE_IDENTITY();

RETURN 0
