CREATE PROCEDURE [dbo].[spCustomer_UpdateCustomer]
    @Id INT,
	@Name nvarchar(100),
    @Address nvarchar(100),
    @PhoneNumber nvarchar(100)
AS
BEGIN
    UPDATE [dbo].[Customer] SET [Name] = @Name, [Address] = @Address, [PhoneNumber] = @PhoneNumber WHERE Id = @Id
END
    