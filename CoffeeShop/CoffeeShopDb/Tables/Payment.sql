CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Amount] DECIMAL(5, 2) NOT NULL, 
    [PaymentDate] NVARCHAR(50) NOT NULL, 
    [OrdersId] INT NOT NULL,
    CONSTRAINT FK_PaymentOrders FOREIGN KEY ([OrdersId]) REFERENCES [Orders]([Id])
)
