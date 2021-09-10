-- Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. Alter the above Store Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)

/*
	spGetNameWithFilter is a stored procedure which takes a filter(varchar) as a parameter and it applies the filter to the Firstname, and shows the desired results.
	If no parameter is passed then it takes character 'a' as default parameter and shows those names which have letter 'a' in their Firstname.
*/
CREATE PROCEDURE [dbo].[spGetNameWithFilter]
@filter nvarchar(50)
AS
BEGIN
	SELECT FirstName, ISNULL(MiddleName, '-') AS MiddleName, LastName
	FROM Person.Person
	WHERE FirstName LIKE '%' + @filter + '%'
END
GO

ALTER PROCEDURE [dbo].[spGetNameWithFilter]
@filter nvarchar(50) = 'a'
AS
BEGIN
	SELECT FirstName, ISNULL(MiddleName, '-') AS MiddleName, LastName
	FROM Person.Person
	WHERE FirstName LIKE '%' + @filter + '%'
END
GO


EXECUTE spGetNameWithFilter 'ama'