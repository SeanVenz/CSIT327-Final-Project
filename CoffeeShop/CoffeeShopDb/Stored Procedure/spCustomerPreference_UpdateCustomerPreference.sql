CREATE PROCEDURE [dbo].[spCustomerPreference_UpdateCustomerPreference]
    @Id INT,
	@Preference nvarchar(100)
AS
BEGIN
    UPDATE [dbo].[CustomerPreference] SET [Preference] = @Preference WHERE Id = @Id
END
