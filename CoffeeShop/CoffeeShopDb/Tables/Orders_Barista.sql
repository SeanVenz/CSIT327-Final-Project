CREATE TABLE [dbo].[Orders_Barista]
(
	[BaristaId] INT NOT NULL, 
    [OrdersId] INT NOT NULL,
	CONSTRAINT [FK_Orders_Barista_Barista] FOREIGN KEY ([BaristaId]) REFERENCES [Barista]([Id]),
	CONSTRAINT [FK_Orders_Barista_Orders] FOREIGN KEY ([OrdersId]) REFERENCES [Orders]([Id])
)
