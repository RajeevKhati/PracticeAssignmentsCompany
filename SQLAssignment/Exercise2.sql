-- Write separate queries using a join, a subquery, a CTE, and then an EXISTS to list all AdventureWorks customers who have not placed an order.

/*
***Sales.SalesOrderHeader Table***
This table contains the orderIds of customers, whenever a customer places an order, an entry will be generated in this table.

***Sales.Customer Table***
This table contains details regarding customers who ordered from adventureWorks.
*/

-- Using a join
/*
	Here we left joined Customer and SalesOrderHeader table, lets call it newTable.
	This newTable will contain all the CustomerIds from Customer table as we left joined the table, but the customers who have not placed an order will contain null values in those columns of newTable which is part of SalesOrderHeader table. (i.e.SOH.CustomerID will be NULL for customers who haven't placed order)
	so to filter these customers we added a where clause which will filter all the customers who have not placed an order.
*/
SELECT C.CustomerID
FROM Sales.Customer AS C
LEFT JOIN Sales.SalesOrderHeader AS SOH
ON C.CustomerID = SOH.CustomerID
WHERE SOH.CustomerID IS NULL

-- Using a subquery
/*
	Customer ids which are not present in SalesOrderHeader table, is the proof that they didn't yet placed an order.
*/
SELECT C.CustomerID
FROM Sales.Customer AS C
WHERE C.CustomerID NOT IN
(
	SELECT SOH.CustomerID
	FROM Sales.SalesOrderHeader AS SOH
	WHERE SOH.CustomerID = C.CustomerID
)

-- Using CTE
/*
	Here we made a CTE by left joining Customers and SalesOrderHeader table.
	In this new joined table wherever the SalesOrderHeader's CustomerId is null that means the customer have not placed an order.
*/
WITH AllCusts
AS
(
	SELECT C.CustomerID AS Customers, SOH.CustomerID AS CustomersWhoOrdered
	FROM Sales.Customer AS C
	LEFT JOIN Sales.SalesOrderHeader AS SOH
	ON C.CustomerID = SOH.CustomerID
)

SELECT Customers
FROM AllCusts
WHERE CustomersWhoOrdered IS NULL


--Using EXISTS
/*
	This query filters all the Customer ids from customer table which doesn't exist in salesOrderHeader table, which will in turn give us customers who have not placed an order.
*/
SELECT C.CustomerID
FROM Sales.Customer AS C
WHERE NOT EXISTS
(
	SELECT SOH.CustomerID
	FROM Sales.SalesOrderHeader AS SOH
	WHERE SOH.CustomerID = C.CustomerID
)