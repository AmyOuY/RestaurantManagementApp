CREATE PROCEDURE [dbo].[PaidBill_Insert]
	@Id int = 0 output,
    @OrderId int,
    @DiningTableId int, 
    @ServerId int, 
    @SubTotal money,
    @Tax money,
    @Total money,
    @BillDate datetime2

AS
	insert into dbo.PaidBill (OrderId, DiningTableId, ServerId, SubTotal, Tax, Total, BillDate)
    values (@OrderId, @DiningTableId, @ServerId, @SubTotal, @Tax, @Total, @BillDate);

    select @Id = SCOPE_IDENTITY();

RETURN 0
