-- Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date, and returns a table of all the SalesOrderDetail rows for that Sales Order including Quantity, ProductID, UnitPrice, and the unit price converted to the target currency based on the end of day rate for the date provided. Exchange rates can be found in the Sales.CurrencyRate table. ( Use AdventureWorks)

/*
****ABOUT GENERATED FUNCTION****
	fn_GetSalesOrderDetails() function takes 3 parameters SalesOrderID, Currency Code, date.
	This function uses SalesOrderId to get Quantity, ProductID, UnitPrice AND it uses Curency code and date to convert the UnitPrice from USD to given 'Currency Code' (using the Sales.CurrencyRate table) and Calls it "ConvertedUnitPrice".
*/

CREATE FUNCTION [dbo].[fn_GetSalesOrderDetails](@salesOrderId int, @currencyCode nchar(3), @date datetime)
RETURNS @salesOrderDetails TABLE (Quantity smallint, ProductID int, UnitPrice money, ConvertedUnitPrice money)
AS
BEGIN
DECLARE @endOfDayRate money;
SELECT @endOfDayRate = ISNULL(EndOfDayRate, 1)
		FROM Sales.CurrencyRate
		WHERE ToCurrencyCode = @currencyCode
		AND CurrencyRateDate = @date
	INSERT INTO @salesOrderDetails
		SELECT OrderQty, ProductID, UnitPrice, UnitPrice*@endOfDayRate
		FROM Sales.SalesOrderDetail
		WHERE SalesOrderID = @salesOrderId
	RETURN
END
GO

--Declaring some dummy varibales to pass to fn_GetSalesOrderDetails() function as params.
DECLARE @salesOrderId int = 43661
DECLARE @currencyCode nchar(3) = 'ARS'
DECLARE @date datetime = '2005-07-01'

/*
Displaying the returned table from function which will contain the following columns
		- Quantity
		- ProductID
		- UnitPrice
		- ConvertedUnitPrice
*/
Select * FROM dbo.fn_GetSalesOrderDetails(@salesOrderId, @currencyCode, @date)