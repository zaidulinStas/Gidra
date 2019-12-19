USE SimSaprNew
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Create
@Name NVARCHAR(MAX)
AS
BEGIN
    INSERT Dictionaries.ProcessNames([Name])
    VALUES(@Name)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Update
@Id INT,
@Name NVARCHAR(MAX) = NULL
AS
BEGIN
    UPDATE Dictionaries.ProcessNames
    SET [Name]=ISNULL(@Name, [Name])
    WHERE ProcessNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.ProcessNames WHERE ProcessNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ProcessNames_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.ProcessNames
END
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Get
@Id INT
AS
BEGIN
    SELECT [ProcessNameId], [Name]
    FROM Dictionaries.ProcessNames
    WHERE ProcessNameId=@Id
END
GO






CREATE PROCEDURE Dictionaries.BaseProcedures_Create
@Name NVARCHAR(MAX),
@DefaultFunctionExpression NVARCHAR(MAX)
AS
BEGIN
    INSERT Dictionaries.BaseProcedures([Name], [DefaultFunctionExpression])
    VALUES(@Name, @DefaultFunctionExpression)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedures_Update
@Id INT,
@Name NVARCHAR(MAX) = NULL,
@DefaultFunctionExpression NVARCHAR(MAX) = NULL
AS
BEGIN
    UPDATE Dictionaries.BaseProcedures
    SET [Name]=ISNULL(@Name, [Name]), [DefaultFunctionExpression]=ISNULL(@DefaultFunctionExpression, [DefaultFunctionExpression])
	WHERE BaseProcedureId=@Id
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedures_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.BaseProcedures WHERE BaseProcedureId=@Id
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedures_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.BaseProcedures
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedures_Get
@Id INT
AS
BEGIN
    SELECT [BaseProcedureId], [Name], [DefaultFunctionExpression]
    FROM Dictionaries.BaseProcedures
    WHERE BaseProcedureId=@Id
END
GO



CREATE PROCEDURE Dictionaries.ResourceTypes_Create
@Name NVARCHAR(255)
AS
BEGIN
    INSERT Dictionaries.ResourceTypes([Name])
    VALUES(@Name)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ResourceTypes_Update
@Id INT,
@Name NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE Dictionaries.ResourceTypes
    SET [Name]=ISNULL(@Name, [Name])
    WHERE ResourceTypeId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceTypes_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.ResourceTypes WHERE ResourceTypeId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceTypes_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.ResourceTypes
END
GO

CREATE PROCEDURE Dictionaries.ResourceTypes_Get
@Id INT
AS
BEGIN
    SELECT [ResourceTypeId], [Name]
    FROM Dictionaries.ResourceTypes
    WHERE ResourceTypeId=@Id
END
GO




CREATE PROCEDURE Dictionaries.ResourceNames_Create
@Name NVARCHAR(255),
@TypeId INT
AS
BEGIN
    INSERT Dictionaries.ResourceNames([Name], [ResourceTypeId])
    VALUES(@Name, @TypeId)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ResourceNames_Update
@Id INT,
@Name NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE Dictionaries.ResourceNames
    SET [Name]=ISNULL(@Name, [Name])
    WHERE ResourceNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceNames_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.ResourceNames WHERE ResourceNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceNames_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.ResourceNames
END
GO

CREATE PROCEDURE Dictionaries.ResourceNames_Get
@Id INT
AS
BEGIN
    SELECT [ResourceNameId], rn.[ResourceTypeId], rn.[Name], rt.[Name] as 'Type'
    FROM Dictionaries.ResourceNames rn JOIN Dictionaries.ResourceTypes AS rt ON rt.ResourceTypeId=rn.ResourceTypeId
    WHERE ResourceNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceNames_GetByResourceTypeId
@Id INT
AS
BEGIN
    SELECT *
    FROM Dictionaries.ResourceNames
    WHERE ResourceTypeId=@Id
END
GO







CREATE PROCEDURE Dictionaries.ResourceParameterNames_Create
@Name NVARCHAR(255),
@ResourceNameId INT
AS
BEGIN
    INSERT Dictionaries.ResourceParameterNames([Name], [ResourceNameId])
    VALUES(@Name, @ResourceNameId)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_Update
@Id INT,
@Name NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE Dictionaries.ResourceParameterNames
     SET [Name]=ISNULL(@Name, [Name])
    WHERE ResourceParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.ResourceParameterNames WHERE ResourceParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.ResourceParameterNames
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_Get
@Id INT
AS
BEGIN
    SELECT [ResourceParameterNameId], rpn.[ResourceNameId], rpn.[Name], rn.Name as 'Resource'
    FROM Dictionaries.ResourceParameterNames rpn JOIN Dictionaries.ResourceNames AS rn ON rn.ResourceNameId=rpn.ResourceNameId
    WHERE ResourceParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_GetByResourceId
@Id INT
AS
BEGIN
    SELECT *
    FROM Dictionaries.ResourceParameterNames
    WHERE ResourceNameId=@Id
END
GO







CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_Create
@Name NVARCHAR(255),
@BaseProcedureId INT
AS
BEGIN
    INSERT Dictionaries.BaseProcedureParameterNames([Name], [BaseProcedureId])
    VALUES(@Name, @BaseProcedureId)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_Update
@Id INT,
@Name NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE Dictionaries.BaseProcedureParameterNames
    SET [Name]=ISNULL(@Name, [Name])
    WHERE BaseProcedureParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.BaseProcedureParameterNames WHERE BaseProcedureParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.BaseProcedureParameterNames
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_Get
@Id INT
AS
BEGIN
    SELECT [BaseProcedureParameterNameId], bppn.[BaseProcedureId], bppn.[Name], bp.Name as 'Procedure'
    FROM Dictionaries.BaseProcedureParameterNames bppn JOIN Dictionaries.BaseProcedures AS bp ON bp.BaseProcedureId=bppn.BaseProcedureId
    WHERE BaseProcedureParameterNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.BaseProcedureParameterNames_GetByProcedureId
@Id INT
AS
BEGIN
    SELECT *
    FROM Dictionaries.BaseProcedureParameterNames
    WHERE BaseProcedureId=@Id
END
GO