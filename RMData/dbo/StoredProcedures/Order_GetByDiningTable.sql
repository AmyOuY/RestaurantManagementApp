CREATE PROCEDURE [dbo].[Order_GetByDiningTable]
	@DiningTableId int

AS
	select *
	from dbo.[Order]
	where DiningTableId = @DiningTableId;

RETURN 0
