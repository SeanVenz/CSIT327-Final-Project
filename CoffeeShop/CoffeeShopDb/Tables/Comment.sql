CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Comments] NVARCHAR(200) NOT NULL, 
    [OrdersId] INT NOT NULL,
    CONSTRAINT FK_CommentOrders FOREIGN KEY ([OrdersId]) REFERENCES [Orders]([Id])
)
