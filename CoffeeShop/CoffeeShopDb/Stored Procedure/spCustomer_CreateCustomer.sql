CREATE PROC spCustomer_CreateCustomer
    @Name nvarchar(100),
    @Address nvarchar(100),
    @PhoneNumber nvarchar(100)
AS
BEGIN
    INSERT INTO [dbo].[Customer] ([Name], [Address], [PhoneNumber])
    VALUES (@Name, @Address, @PhoneNumber);

    SELECT SCOPE_IDENTITY();
END