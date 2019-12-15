USE SimSaprNew
GO


CREATE PROCEDURE Resources.Resources_Create
@ResourceNameId INT,
@Name NVARCHAR,
@Price MONEY
AS
BEGIN
    INSERT Resources.Resources([ResourceNameId], [Name], [Price])
    VALUES(@ResourceNameId, @Name, @Price)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Resources.Resources_Update
@Id INT,
@Name NVARCHAR,
@Price MONEY
AS
BEGIN
    UPDATE Resources.Resources
    SET [Name]=@Name, [Price]=@Price
    WHERE ResourceId=@Id
END
GO

CREATE PROCEDURE Resources.Resources_Delete
@Id INT
AS
BEGIN
    DELETE Resources.Resources WHERE ResourceId=@Id
END
GO

CREATE PROCEDURE Resources.Resources_GetAll
AS
BEGIN
    SELECT * FROM Resources.Resources
END
GO


CREATE PROCEDURE Resources.Resources_Get
@Id INT
AS
BEGIN
    SELECT [ResourceId], [Price], r.[Name], rn.Name as 'Resource'
    FROM Resources.Resources r JOIN Dictionaries.ResourceNames AS rn ON rn.ResourceNameId=r.ResourceNameId
    WHERE ResourceId=@Id
END
GO


CREATE PROCEDURE Resources.Resources_GetByProcedureId
@Id INT
AS
BEGIN
    SELECT [ResourceId], [Price], r.[Name], rn.Name as 'Resource'
    FROM Resources.Resources r JOIN Dictionaries.ResourceNames AS rn ON rn.ResourceNameId=r.ResourceNameId
    WHERE ResourceId IN (SELECT ResourceId 
    FROM Processes.ProceduresResources
    WHERE ProcedureId=@Id)
END
GO







CREATE PROCEDURE Resources.ResourceParameters_Create
@ResourceParameterNameId INT,
@ResourceId INT,
@Value float
AS
BEGIN
    INSERT Resources.ResourceParameters([ResourceParameterNameId], [ResourceId], [Value])
    VALUES(@ResourceParameterNameId, @ResourceId, @Value)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Resources.ResourceParameters_Update
@Id INT,
@Value float
AS
BEGIN
    UPDATE Resources.ResourceParameters
    SET [Value]=@Value
    WHERE ResourceParameterId=@Id
END
GO

CREATE PROCEDURE Resources.ResourceParameters_Delete
@Id INT
AS
BEGIN
    DELETE Resources.ResourceParameters WHERE ResourceParameterId=@Id
END
GO

CREATE PROCEDURE Resources.ResourceParameters_GetAll
AS
BEGIN
    SELECT * FROM Resources.ResourceParameters
END
GO


CREATE PROCEDURE Resources.ResourceParameters_Get
@Id INT
AS
BEGIN
    SELECT [ResourceParameterId], [ResourceId], [Value], rpn.Name as 'Parameter'
    FROM Resources.ResourceParameters rp JOIN Dictionaries.ResourceParameterNames AS rpn ON rpn.ResourceParameterNameId=rp.ResourceParameterNameId
    WHERE ResourceParameterId=@Id
END
GO

CREATE PROCEDURE Resources.ResourceParameters_GetByResourceId
@Id INT
AS
BEGIN
    SELECT [ResourceParameterId], [ResourceId], [Value], rpn.Name as 'Parameter'
    FROM Resources.ResourceParameters rp JOIN Dictionaries.ResourceParameterNames AS rpn ON rpn.ResourceParameterNameId=rp.ResourceParameterNameId
    WHERE ResourceId=@Id
END
GO