CREATE TABLE [dbo].[CustomerPreference]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Preference] NVARCHAR(200) NOT NULL, 
    [CustomerId] INT NOT NULL, 
    CONSTRAINT FK_CustomerPreferenceCustomer FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)