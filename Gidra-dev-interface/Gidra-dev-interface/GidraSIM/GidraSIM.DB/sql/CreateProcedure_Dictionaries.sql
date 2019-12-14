USE SimSaprNew
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Create
@Name NVARCHAR
AS
BEGIN
    INSERT Dictionaries.ProcessNames([Name])
    VALUES(@Name)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ProcessNames_Update
@Id INT,
@Name NVARCHAR
AS
BEGIN
    UPDATE Dictionaries.ProcessNames
    SET [Name]=@Name
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






CREATE PROCEDURE Dictionaries.ProcedureNames_Create
@Name NVARCHAR
AS
BEGIN
    INSERT Dictionaries.ProcedureNames([Name])
    VALUES(@Name)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ProcedureNames_Update
@Id INT,
@Name NVARCHAR
AS
BEGIN
    UPDATE Dictionaries.ProcedureNames
    SET [Name]=@Name
    WHERE ProcedureNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ProcedureNames_Delete
@Id INT
AS
BEGIN
    DELETE Dictionaries.ProcedureNames WHERE ProcedureNameId=@Id
END
GO

CREATE PROCEDURE Dictionaries.ProcedureNames_GetAll
AS
BEGIN
    SELECT * FROM Dictionaries.ProcedureNames
END
GO

CREATE PROCEDURE Dictionaries.ProcedureNames_Get
@Id INT
AS
BEGIN
    SELECT [ProcedureNameId], [Name]
    FROM Dictionaries.ProcedureNames
    WHERE ProcedureNameId=@Id
END
GO



CREATE PROCEDURE Dictionaries.ResourceTypes_Create
@Name NVARCHAR
AS
BEGIN
    INSERT Dictionaries.ResourceTypes([Name])
    VALUES(@Name)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ResourceTypes_Update
@Id INT,
@Name NVARCHAR
AS
BEGIN
    UPDATE Dictionaries.ResourceTypes
    SET [Name]=@Name
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
@Name NVARCHAR,
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
@Name NVARCHAR
AS
BEGIN
    UPDATE Dictionaries.ResourceNames
    SET [Name]=@Name
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
@Name NVARCHAR,
@ResourceId INT
AS
BEGIN
    INSERT Dictionaries.ResourceNames([Name], [ResourceTypeId])
    VALUES(@Name, @ResourceId)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Dictionaries.ResourceParameterNames_Update
@Id INT,
@Name NVARCHAR
AS
BEGIN
    UPDATE Dictionaries.ResourceParameterNames
    SET [Name]=@Name
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