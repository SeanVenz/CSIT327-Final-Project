CREATE PROCEDURE [dbo].[spOrder_GetAllOrders]
AS
BEGIN
	SELECT 
        p.Name, p.Price, o.Id, o.Date, o.CustomerId
    FROM 
        Orders o 
    INNER JOIN 
        Orders_Product op 
    ON 
        op.OrdersId = o.Id
    INNER JOIN 
        Product p 
    ON 
        p.Id = op.ProductId;
END