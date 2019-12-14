CREATE DATABASE SimSaprNew
GO
ALTER DATABASE SimSaprNew SET COMPATIBILITY_LEVEL = 100
GO

USE SimSaprNew
GO

CREATE SCHEMA Dictionaries
GO

-- Словарь для имен процессов (по факту - некие базовые процессы + можно добавить и свои)
CREATE TABLE Dictionaries.ProcessNames
(
    ProcessNameId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(MAX) NOT NULL CHECK(LEN(Name)>0)
);

-- Словарь для имен процедур (по факту - некие базовые процедуры + можно добавить и свои)
CREATE TABLE Dictionaries.ProcedureNames
(
    ProcedureNameId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(MAX) NOT NULL CHECK(LEN(Name)>0)
);

-- Словарь для типов ресурсов (при необходимости - можно и расширить)
CREATE TABLE Dictionaries.ResourceTypes
(
    ResourceTypeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL CHECK(Name in('Технический','Программный','Человеческий', 'Информационный'))
);

-- Словарь для общих имен ресурсов с привязкой к типу (например, Монитор, Принтер, Компас, Автокад и тд)
CREATE TABLE Dictionaries.ResourceNames
(
    ResourceNameId INT PRIMARY KEY IDENTITY(1,1),
	ResourceTypeId INT REFERENCES Dictionaries.ResourceTypes(ResourceTypeId) NOT NULL,
    Name NVARCHAR(255) NOT NULL CHECK(LEN(Name)>0)
);

-- Словарь для названий параметров ресурсов с привязкой к конкретному ресурсу (например, для монитора - частота кадров, диагональ, разрешение и тд)
CREATE TABLE Dictionaries.ResourceParameterNames
(
    ResourceParameterNameId INT PRIMARY KEY IDENTITY(1,1),
	ResourceNameId INT REFERENCES Dictionaries.ResourceNames(ResourceNameId) NOT NULL,
    Name NVARCHAR(255) NOT NULL CHECK(LEN(Name)>0)
);
GO

USE SimSaprNew
GO


CREATE SCHEMA Processes
GO

CREATE TABLE Processes.Processes
(
    ProcessId HIERARCHYID PRIMARY KEY CLUSTERED,
	ProcessNameId INT REFERENCES Dictionaries.ProcessNames(ProcessNameId) NOT NULL,
    TotalTime DATETIME2(0) NOT NULL DEFAULT '01/01/0001 00:00:00',
    TotalPrice MONEY NOT NULL CHECK(TotalPrice>0)
);

-- Таблица для сохранения конкретных процедур с уже реальными значениями ресурсов и их параметров
CREATE TABLE Processes.Procedures
(
    ProcedureId HIERARCHYID PRIMARY KEY CLUSTERED,
    ProcessId HIERARCHYID REFERENCES Processes.Processes(ProcessId) NULL DEFAULT NULL,
	ProcedureNameId INT REFERENCES Dictionaries.ProcedureNames(ProcedureNameId) NOT NULL,
	-- выражение функции для расчета времени
	FunctionExpression NVARCHAR(max) NOT NULL CHECK(LEN(FunctionExpression)>0),
    TotalTime DATETIME2(0) NOT NULL DEFAULT '01/01/0001 00:00:00',
    TotalPrice MONEY NOT NULL CHECK(TotalPrice>0)
);

USE SimSaprNew
GO

CREATE SCHEMA Resources
GO

-- Таблица для хранения реальных ресурсов (например, Монитор Самсунг, Принтер HP)
CREATE TABLE Resources.Resources
(
    ResourceId INT PRIMARY KEY IDENTITY(1,1),
	ResourceNameId INT REFERENCES Dictionaries.ResourceNames(ResourceNameId) NOT NULL,
    Name NVARCHAR(255) NOT NULL CHECK(LEN(Name)>0),
	Price MONEY NOT NULL CHECK(Price>0)
);

-- Таблица для хранения реальных значений параметров конкретного ресурса (диагональ 22 дюйма, скорость печати 1000 стр/мин)
CREATE TABLE Resources.ResourceParameters
(
    ResourceParameterId INT PRIMARY KEY IDENTITY(1,1),
	ResourceParameterNameId INT REFERENCES Dictionaries.ResourceParameterNames(ResourceParameterNameId) NOT NULL,
	ResourceId INT REFERENCES Resources.Resources(ResourceId) NOT NULL,
    Value float NULL
);

-- Таблица связи many-to-many для хранения ссылок на реальные процедуры и ресурсы, котоыре в них используются
CREATE TABLE Processes.ProceduresResources
(
    ProcedureResourceId INT PRIMARY KEY IDENTITY(1,1),
	ResourceId INT REFERENCES Resources.Resources(ResourceId) NOT NULL,
    ProcedureId HIERARCHYID REFERENCES Processes.Procedures(ProcedureId) NOT NULL,
);
GO