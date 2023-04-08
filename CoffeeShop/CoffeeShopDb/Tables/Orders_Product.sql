CREATE TABLE [dbo].[Orders_Product]
(
	[ProductId] INT NOT NULL, 
    [OrdersId] INT NOT NULL,
	CONSTRAINT [FK_Orders_Product_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
	CONSTRAINT [FK_Orders_Product_Order] FOREIGN KEY ([OrdersId]) REFERENCES [Orders]([Id])
)
