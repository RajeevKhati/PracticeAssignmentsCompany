-- 1. Display the number of records in the [SalesPerson] table. (Schema(s) involved: Sales)
/*
	BusinessEntityID is unique for every row in SalesPerson table.
	So applying COUNT aggregate function to BusinessEntityID will count the number of different BusinessEntityID present in the table which in turn will represent the number of records.
*/
SELECT COUNT(BusinessEntityID) AS NumberOfRecords
FROM Sales.SalesPerson



--2. Select both the FirstName and LastName of records from the Person table where the FirstName begins with the letter ‘B’. (Schema(s) involved: Person)
/*
	In "FirstName LIKE 'B%'",  % symbol will bear any number of characters or even empty space in place of %.
	So because of this we will get every firstname starting with 'B'.
*/
SELECT FirstName, LastName
FROM Person.Person
WHERE FirstName LIKE 'B%'


-- 3. Select a list of FirstName and LastName for employees where Title is one of Design Engineer, Tool Designer or Marketing Assistant. (Schema(s) involved: HumanResources, Person)
/*
	FirstName and LastName is present in Person table.
	Person's Title(Design Engineer, Tool Designer or Marketing Assistant) is present in HumanResources table.
	So we need to join these two tables ON the condition when:-
	1. BusinessEntityID column(which is common in both the tables) has same value.
	2. JobTitle column in HumanResources table has one of these 3 values
		- Design Engineer
		- Tool Designer
		- Marketing Assistant
*/
SELECT FirstName, Lastname, JobTitle
FROM Person.Person AS P
INNER JOIN HumanResources.Employee AS HRE
ON HRE.BusinessEntityID = P.BusinessEntityID
AND HRE.JobTitle IN ('Design Engineer', 'Tool Designer', 'Marketing Assistant')


-- 4. Display the Name and Color of the Product with the maximum weight. (Schema(s) involved: Production)
/*
	Sorting the table in descending order based on weight, then selecting the top 1 product which will in turn be the maximum weight product.
	Also displaying their name and color.
*/
SELECT TOP(1) [Name], Color, [Weight]
FROM Production.Product
ORDER BY Weight DESC

-- 5. Display Description and MaxQty fields from the SpecialOffer table. Some of the MaxQty values are NULL, in this case display the value 0.00 instead. (Schema(s) involved: Sales)
/*
	ISNULL(MaxQty, 0.00) will display the MaxQty value if present, but if MaxQty is null then it will show the 0 value.
*/
SELECT Description, ISNULL(MaxQty, 0.00) as MaxQty
FROM Sales.SpecialOffer


-- 6. Display the overall Average of the [CurrencyRate].[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’ for the year 2005 i.e. FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’. Note: The field [CurrencyRate].[AverageRate] is defined as 'Average exchange rate for the day.' (Schema(s) involved: Sales)
/*
	Here we are filtering the table for the year 2005 and computing overall average of 'AverageRate' When we need to convert the currency from 'USD' to 'GBP'.
*/
SELECT AVG(AverageRate) AS [Overall Average]
FROM Sales.CurrencyRate
WHERE DATEPART(YEAR,CurrencyRateDate) = 2005
AND FromCurrencyCode = 'USD'
AND ToCurrencyCode = 'GBP'


-- 7. Display the FirstName and LastName of records from the Person table where FirstName contains the letters ‘ss’. Display an additional column with sequential numbers for each row returned beginning at integer 1. (Schema(s) involved: Person)
/*
	ROW_NUMBER() OVER (ORDER BY FirstName) this expresion will print the serial numbers starting from 1.
	'%ss%' makes sure that Firstname must have 'ss' somewhere in the FirstName of the person
*/
SELECT ROW_NUMBER() OVER (ORDER BY FirstName) AS [Row Number], FirstName, LastName
FROM Person.Person
WHERE FirstName LIKE '%ss%'


/*
8. Sales people receive various commission rates that belong to 1 of 4 bands. (Schema(s) involved: Sales)
		CommissionPct		Commission Band
		   0.00					Band 0
		 Up To 1%				Band 1
		 Up To 1.5%				Band 2
		 Greater 1.5%			Band 3

Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate band as above.
*/
/*
	This query uses CASE,
	WHEN {condition} THEN {UseThisValue}
*/
SELECT BusinessEntityID AS [Sales Person ID],
CASE
	WHEN CommissionPct=0.00 THEN 'Band 0'
	WHEN CommissionPct<=0.01 THEN 'Band 1'
	WHEN CommissionPct<=0.015 THEN 'Band 2'
	WHEN CommissionPct>0.015 THEN 'Band 3'
END AS [Commission Band]
FROM Sales.SalesPerson


-- 9. Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez. Hint: use [uspGetEmployeeManagers] (Schema(s) involved: [Person], [HumanResources])

/*
	Here we are executing the store procedure uspGetEmployeeManagers which takes BusinessEntityID as parameter.
	We're getting BusinessEntityID of a person whose name is Ruth Ellerbrock(person type – EM)  from person table and passing it to uspGetEmployeeManagers.
	by executing uspGetEmployeeManagers, we get managerial hierarchy of the particular BusinessEntityID upto CEO.
*/
DECLARE @EmpId int
SELECT @EmpId = BusinessEntityID
FROM Person.Person
WHERE FirstName = 'Ruth'
AND LastName = 'Ellerbrock'
AND PersonType = 'EM'

EXEC uspGetEmployeeManagers @EmpId


-- 10. Display the ProductId of the product with the largest stock level. Hint: Use the Scalar-valued function [dbo]. [UfnGetStock]. (Schema(s) involved: Production)
/*
	ufnGetStock(ProductID) function takes productId and gives the stock present of that product.
	Using this function we are computing the max stocked product in Production.Product table. 
*/
SELECT TOP(1) ProductID, dbo.ufnGetStock(ProductID) AS [Max Stock]
FROM Production.Product
ORDER BY [Max Stock] DESC