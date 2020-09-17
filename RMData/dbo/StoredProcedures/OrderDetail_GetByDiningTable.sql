CREATE PROCEDURE [dbo].[OrderDetail_GetByDiningTable]
	@DiningTableId int 

AS
	select *
	from dbo.OrderDetail
	where DiningTableId = @DiningTableId and OrderId IS NULL;

RETURN 0
