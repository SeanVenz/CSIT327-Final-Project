CREATE PROCEDURE [dbo].[spOrder_GetOrdersByCustomer]
	@customerId INT
AS
BEGIN
    SELECT 
        p.Name, p.Price, c.Id, c.Name, o.Id, o.Date
    FROM 
        Product p
    INNER JOIN 
        Orders_Product op
    ON 
        op.ProductId = p.Id
    INNER JOIN
        Orders o
    ON
        o.Id = op.OrdersId
    INNER JOIN
        Customer c
    ON
        o.CustomerId = c.Id
    WHERE
        c.Id = @customerId
END