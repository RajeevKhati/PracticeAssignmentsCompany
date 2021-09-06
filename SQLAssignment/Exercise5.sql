-- Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. Alter the above Store Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)

/*
	spGetNameWithFilter is a stored procedure which takes a filter(varchar) as a parameter and it applies the filter to the Firstname, and shows the desired results.
	If no parameter is passed then it takes character 'a' as default parameter and shows those names which have letter 'a' in their Firstname.
*/

EXECUTE spGetNameWithFilter 'ama'