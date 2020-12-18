CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock
	FROM dbo.Product
	ORDER BY ProductName
RETURN 0
