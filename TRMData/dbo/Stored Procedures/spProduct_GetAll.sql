CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	FROM dbo.Product
	ORDER BY ProductName
RETURN 0
