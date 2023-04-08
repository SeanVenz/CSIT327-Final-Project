CREATE PROCEDURE [dbo].[spOrder_DeleteOrder]
	@orderId INT
AS
BEGIN
	DELETE FROM Orders WHERE Id = @orderId
	DELETE FROM Orders_Barista WHERE OrdersId = @orderId
	DELETE FROM Orders_Product WHERE OrdersId = @orderId
	DELETE FROM Payment WHERE OrdersId = @orderId
	DELETE FROM Comment WHERE OrdersId = @orderId;
END
