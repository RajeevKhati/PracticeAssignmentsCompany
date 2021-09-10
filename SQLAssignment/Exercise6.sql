--Write a trigger for the Product table to ensure the list price can never be raised more than 15 Percent in a single change. Modify the above trigger to execute its check code only if the ListPrice column is   updated (Use AdventureWorks Database).


/*
	In Production.Product table you can't raise a listPrice more than 15% of the current price in single change, doing so fires a after update trigger which shows the corresponding error message and also later ROLLBACK TRANSACTION as it prevents the row to be changed when listPrice crosses 15% mark.
*/

CREATE TRIGGER [Production].[tr_Product_forUpdate] ON [Production].[Product]
AFTER UPDATE
AS
BEGIN
	DECLARE @oldPrice money
	DECLARE @newPrice money
	SELECT @oldPrice = ListPrice
	FROM deleted
	SELECT @newPrice = ListPrice
	FROM inserted
	DECLARE @errorMessage varchar(255);
    SET @errorMessage = 'The new price '+
                        CONVERT(varchar(50), @newPrice) +
                        ' cannot be more than 15 Percent of the current price '+
                        CONVERT(varchar(50), @oldPrice);

    IF (@newPrice > (@oldPrice * 0.15))
	BEGIN
        RAISERROR(@errorMessage,1,1)
		ROLLBACK TRANSACTION
    END
END
GO

--ProductID - 515 has ListPrice - 147.14
SELECT ProductID, ListPrice FROM Production.Product
WHERE ProductID = 515

--Trying to update the ListPrice more than the 15% of current price, this query will show error.
UPDATE Production.Product
SET ListPrice = 510
WHERE ProductID = 515