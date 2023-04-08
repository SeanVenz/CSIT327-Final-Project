CREATE PROCEDURE [dbo].[spCustomer_DeleteCustomer]
	@id INT
AS
BEGIN
DELETE FROM CustomerPreference WHERE CustomerId = @id
DELETE FROM Customer WHERE Id = @id
END
