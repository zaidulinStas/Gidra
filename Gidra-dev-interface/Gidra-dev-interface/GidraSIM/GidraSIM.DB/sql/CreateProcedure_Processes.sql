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
@Id INT,
@TotalTime DATETIME2 = NULL,
@TotalPrice MONEY = NULL
AS
BEGIN
    UPDATE Processes.Processes
    SET [TotalTime]=ISNULL(@TotalTime, [TotalTime]), [TotalPrice]=ISNULL(@TotalPrice, [TotalPrice])
    WHERE ProcessId=@Id
END
GO

CREATE PROCEDURE Processes.Processes_Delete
@Id INT
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
@Id INT
AS
BEGIN
     SELECT [ProcessId], [TotalTime], [TotalPrice], pn.Name as Process
    FROM Processes.Processes p JOIN Dictionaries.ProcessNames AS pn ON pn.ProcessNameId=p.ProcessNameId
    WHERE ProcessId=@Id
END
GO






CREATE PROCEDURE Processes.Procedures_Create
@BaseProcedureId INT,
@FunctionExpression NVARCHAR(MAX),
@Name NVARCHAR(MAX),
@TotalTime DATETIME2,
@TotalPrice MONEY
AS
BEGIN
    INSERT Processes.Procedures([BaseProcedureId], [FunctionExpression], [Name], [TotalTime], [TotalPrice])
    VALUES(@BaseProcedureId, @FunctionExpression, @Name, @TotalTime, @TotalPrice)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Processes.Procedures_Update
@Id INT,
@FunctionExpression NVARCHAR(MAX) = NULL,
@Name NVARCHAR(MAX) = NULL,
@TotalTime DATETIME2 = NULL,
@TotalPrice MONEY = NULL
AS
BEGIN
    UPDATE Processes.Procedures
    SET [FunctionExpression]=ISNULL(@FunctionExpression, [FunctionExpression]),
		[TotalTime]=ISNULL(@TotalTime, [TotalTime]), [TotalPrice]=ISNULL(@TotalPrice, [TotalPrice]),
		[Name]=ISNULL(@Name, [Name])
    WHERE ProcedureId=@Id
END
GO

CREATE PROCEDURE Processes.Procedures_Delete
@Id INT
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
@Id INT
AS
BEGIN
    SELECT [ProcedureId], [FunctionExpression], p.[Name], [TotalTime], [TotalPrice], bp.Name as 'Procedure'
    FROM Processes.Procedures p JOIN Dictionaries.BaseProcedures AS bp ON bp.BaseProcedureId=p.BaseProcedureId
    WHERE ProcedureId=@Id
END
GO

CREATE PROCEDURE Processes.Procedures_GetByProcessId
@Id INT
AS
BEGIN
    SELECT [ProcedureId], [FunctionExpression], p.[Name], [TotalTime], [TotalPrice], bp.Name as 'Procedure'
    FROM Processes.Procedures p JOIN Dictionaries.BaseProcedures AS bp ON bp.BaseProcedureId=p.BaseProcedureId
    WHERE ProcessId=@Id
END
GO


CREATE PROCEDURE Processes.ProceduresResources_Create
@ResourceId INT,
@ProcedureId INT
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
@Id INT
AS
BEGIN
    SELECT * 
    FROM Processes.ProceduresResources
    WHERE ProcedureId=@Id
END
GO




CREATE PROCEDURE Processes.ProceduresParameters_Create
@BaseProcedureParameterNameId INT,
@ProcedureId INT,
@Value float
AS
BEGIN
    INSERT Processes.ProceduresParameters([BaseProcedureParameterNameId], [ProcedureId], [Value])
    VALUES(@BaseProcedureParameterNameId, @ProcedureId, @Value)
    SELECT scope_identity()
END
GO

CREATE PROCEDURE Processes.ProceduresParameters_Update
@Id INT,
@Value float = NULL
AS
BEGIN
    UPDATE Processes.ProceduresParameters
    SET [Value]=ISNULL(@Value, [Value])
    WHERE ProcedureParameterId=@Id
END
GO

CREATE PROCEDURE Processes.ProceduresParameters_Delete
@Id INT
AS
BEGIN
    DELETE Processes.ProceduresParameters WHERE ProcedureParameterId=@Id
END
GO

CREATE PROCEDURE Processes.ProceduresParameters_GetAll
AS
BEGIN
    SELECT * FROM Processes.ProceduresParameters
END
GO


CREATE PROCEDURE Processes.ProceduresParameters_Get
@Id INT
AS
BEGIN
    SELECT [ProcedureParameterId], pp.[BaseProcedureParameterNameId], [ProcedureId], [Value], bppn.Name as 'Parameter'
    FROM Processes.ProceduresParameters pp JOIN Dictionaries.BaseProcedureParameterNames AS bppn ON bppn.BaseProcedureParameterNameId=pp.BaseProcedureParameterNameId
    WHERE ProcedureParameterId=@Id
END
GO

CREATE PROCEDURE Processes.ProceduresParameters_GetByProcessId
@Id INT
AS
BEGIN
    SELECT [ProcedureParameterId], pp.[BaseProcedureParameterNameId], [ProcedureId], [Value], bppn.Name as 'Parameter'
    FROM Processes.ProceduresParameters pp JOIN Dictionaries.BaseProcedureParameterNames AS bppn ON bppn.BaseProcedureParameterNameId=pp.BaseProcedureParameterNameId
    WHERE ProcedureId=@Id
END
GO