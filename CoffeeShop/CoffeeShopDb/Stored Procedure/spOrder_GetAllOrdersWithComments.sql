CREATE PROCEDURE [dbo].[spOrder_GetAllOrdersWithComments]
AS
BEGIN
SELECT * FROM Orders o INNER JOIN Comment cm on cm.OrdersId = o.Id
END
