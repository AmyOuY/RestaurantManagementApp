CREATE PROCEDURE [dbo].[Food_GetByOrder]
	@OrderId int 

AS
	select * 
	from dbo.Food
	where @OrderId = OrderId;

RETURN 0
