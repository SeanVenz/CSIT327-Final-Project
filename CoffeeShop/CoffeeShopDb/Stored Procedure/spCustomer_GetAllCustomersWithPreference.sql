CREATE PROCEDURE spCustomer_GetAllCustomersWithPreference

AS
BEGIN
SELECT * FROM Customer c INNER JOIN CustomerPreference cp on cp.CustomerId = c.Id
END
