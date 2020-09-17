CREATE PROCEDURE [dbo].[OrderDetail_UpdateBillPaid]
	@DiningTableId int,
	@OrderId int

AS
	update dbo.OrderDetail
	set OrderId = @OrderId
	where DiningTableId = @DiningTableId;

RETURN 0
