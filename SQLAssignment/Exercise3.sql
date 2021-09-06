-- Show the most recent five orders that were purchased from account numbers that have spent more than $70,000 with AdventureWorks.

-- This query selects the top 5 recent orders of account numbers who have spent more than $70000
-- 'Order By OrderDate Desc' helps to get the most recent orders
SELECT TOP(5) AccountNumber, TotalDue, OrderDate, SalesOrderID
FROM Sales.SalesOrderHeader
WHERE AccountNumber IN (
--This query filters the account numbers who have spent more than $70000
	SELECT AccountNumber
	FROM Sales.SalesOrderHeader
	GROUP BY AccountNumber
	HAVING SUM(TotalDue)>70000
)
ORDER BY OrderDate DESC
