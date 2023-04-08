CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Date] NVARCHAR(50) NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT [FK_OrdersCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
