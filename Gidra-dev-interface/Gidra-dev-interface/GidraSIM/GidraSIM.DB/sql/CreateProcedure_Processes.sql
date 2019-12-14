USE SimSaprNew
GO

CREATE PROCEDURE Processes.Processes_Create
@ProcessNameId INT,
@TotalTime DATETIME2,
@TotalPrice MONEY
AS
BEGIN
    INSERT Processes.Processes([ProcessNameId], [TotalTime], [TotalPrice])
    VALUES(@ProcessNameId, @TotalTime, @TotalPrice)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Processes.Processes_Update
@Id HIERARCHYID,
@TotalTime DATETIME2,
@TotalPrice MONEY
AS
BEGIN
    UPDATE Processes.Processes
    SET [TotalTime]=@TotalTime, [TotalPrice]=@TotalPrice
    WHERE ProcessId=@Id
END
GO

CREATE PROCEDURE Processes.Processes_Delete
@Id HIERARCHYID
AS
BEGIN
    DELETE Processes.Processes WHERE ProcessId=@Id
END
GO

CREATE PROCEDURE Processes.Processes_GetAll
AS
BEGIN
    SELECT * FROM Processes.Processes
END
GO

CREATE PROCEDURE Processes.Processes_Get
@Id HIERARCHYID
AS
BEGIN
     SELECT [ProcessId], [TotalTime], [TotalPrice], pn.Name as Process
    FROM Processes.Processes p JOIN Dictionaries.ProcessNames AS pn ON pn.ProcessNameId=p.ProcessNameId
    WHERE ProcessId=@Id
END
GO






CREATE PROCEDURE Processes.Procedures_Create
@ProcedureNameId INT,
@FunctionExpression NVARCHAR,
@TotalTime DATETIME2,
@TotalPrice MONEY
AS
BEGIN
    INSERT Processes.Procedures([ProcedureNameId], [FunctionExpression], [TotalTime], [TotalPrice])
    VALUES(@ProcedureNameId, @FunctionExpression, @TotalTime, @TotalPrice)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Processes.Procedures_Update
@Id HIERARCHYID,
@FunctionExpression NVARCHAR,
@TotalTime DATETIME2,
@TotalPrice MONEY
AS
BEGIN
    UPDATE Processes.Procedures
    SET [FunctionExpression]=@FunctionExpression, [TotalTime]=@TotalTime, [TotalPrice]=@TotalPrice
    WHERE ProcedureId=@Id
END
GO

CREATE PROCEDURE Processes.Procedures_Delete
@Id HIERARCHYID
AS
BEGIN
    DELETE Processes.Procedures WHERE ProcedureId=@Id
END
GO

CREATE PROCEDURE Processes.Procedures_GetAll
AS
BEGIN
    SELECT * FROM Processes.Procedures
END
GO

CREATE PROCEDURE Processes.Procedures_Get
@Id HIERARCHYID
AS
BEGIN
    SELECT [ProcedureId], [TotalTime], [TotalPrice], pn.Name as 'Procedure'
    FROM Processes.Procedures p JOIN Dictionaries.ProcedureNames AS pn ON pn.ProcedureNameId=p.ProcedureNameId
    WHERE ProcedureId=@Id
END
GO

CREATE PROCEDURE Processes.Procedures_GetByProcessId
@Id HIERARCHYID
AS
BEGIN
     SELECT [ProcedureId], [TotalTime], [TotalPrice], pn.Name as 'Procedure'
    FROM Processes.Procedures p JOIN Dictionaries.ProcedureNames AS pn ON pn.ProcedureNameId=p.ProcedureNameId
    WHERE ProcessId=@Id
END
GO


CREATE PROCEDURE Processes.ProceduresResources_Create
@ResourceId INT,
@ProcedureId HIERARCHYID
AS
BEGIN
    INSERT Processes.ProceduresResources([ResourceId], [ProcedureId])
    VALUES(@ResourceId, @ProcedureId)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Processes.ProceduresResources_Delete
@Id INT
AS
BEGIN
    DELETE Processes.ProceduresResources WHERE ProcedureResourceId=@Id
END
GO

CREATE PROCEDURE Processes.ProceduresResources_GetByProcedureId
@Id HIERARCHYID
AS
BEGIN
    SELECT * 
    FROM Processes.ProceduresResources
    WHERE ProcedureId=@Id
END
GO