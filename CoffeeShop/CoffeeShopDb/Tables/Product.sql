CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Category] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(150) NULL DEFAULT 'No Description',
    [Price] DECIMAL(6, 2) NOT NULL
)

