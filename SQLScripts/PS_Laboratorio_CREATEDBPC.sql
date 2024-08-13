---------------------------------------------------------
						SQL SERVER
---------------------------------------------------------

-- Usar la base de datos
USE [dbproductos];
GO

-- Procedimiento almacenado para seleccionar todos los clientes
CREATE PROCEDURE [dbo].[cliente_SelectAll]
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    BEGIN TRANSACTION
    SELECT [Codigo], [Cedula], [Apellidos], [Nombres], [FechaNacimiento], [Mail], [Telefono], [Direccion], [Estado]
    FROM [dbo].[ClienteSql];
    COMMIT TRANSACTION;
END;
GO

-- Procedimiento almacenado para eliminar un cliente por ID
CREATE PROCEDURE [dbo].[cliente_Delete]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRAN
    DELETE FROM [dbo].[ClienteSql]
    WHERE Codigo = @Codigo;
    COMMIT
END;
GO

-- Procedimiento almacenado para insertar un nuevo cliente
CREATE PROCEDURE [dbo].[cliente_Insert]
    @Cedula VARCHAR(10),
    @Apellidos VARCHAR(50),
    @Nombres VARCHAR(50),
    @FechaNacimiento DATETIME,
    @Mail VARCHAR(50),
    @Telefono VARCHAR(10),
    @Direccion VARCHAR(40),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRAN
    INSERT INTO [dbo].[ClienteSql] (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado)
    VALUES (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado);
    COMMIT
END;
GO

-- Procedimiento almacenado para seleccionar un cliente por ID
CREATE PROCEDURE [dbo].[cliente_SelectById]
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRAN
    SELECT [Codigo], [Cedula], [Apellidos], [Nombres], [FechaNacimiento], [Mail], [Telefono], [Direccion], [Estado]
    FROM [dbo].[ClienteSql]
    WHERE Codigo = @Codigo;
    COMMIT
END;
GO

-- Procedimiento almacenado para actualizar un cliente
CREATE PROCEDURE [dbo].[cliente_Update]
    @Codigo INT,
    @Cedula VARCHAR(10),
    @Apellidos VARCHAR(50),
    @Nombres VARCHAR(50),
    @FechaNacimiento DATETIME,
    @Mail VARCHAR(50),
    @Telefono VARCHAR(10),
    @Direccion VARCHAR(40),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRAN
    UPDATE [dbo].[ClienteSql]
    SET Cedula = @Cedula,
        Apellidos = @Apellidos,
        Nombres = @Nombres,
        FechaNacimiento = @FechaNacimiento,
        Mail = @Mail,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Estado = @Estado
    WHERE Codigo = @Codigo;
    COMMIT
END;
GO


---------------------------------------------------------
						POSTGRESQL
---------------------------------------------------------
-- Procedimiento almacenado para seleccionar todos los clientes
CREATE OR REPLACE PROCEDURE cliente_SelectAll()
LANGUAGE plpgsql
AS $$
BEGIN
    PERFORM SETOF RECORD
    FROM (
        SELECT Codigo, Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado
        FROM ClienteSql
    ) AS result;
END;
$$;

-- Procedimiento almacenado para eliminar un cliente por ID
CREATE OR REPLACE PROCEDURE cliente_Delete(Codigo INT)
LANGUAGE plpgsql
AS $$
BEGIN
    DELETE FROM ClienteSql
    WHERE Codigo = cliente_Delete.Codigo;
END;
$$;

-- Procedimiento almacenado para insertar un nuevo cliente
CREATE OR REPLACE PROCEDURE cliente_Insert(
    Cedula VARCHAR(10),
    Apellidos VARCHAR(50),
    Nombres VARCHAR(50),
    FechaNacimiento TIMESTAMP,
    Mail VARCHAR(50),
    Telefono VARCHAR(10),
    Direccion VARCHAR(40),
    Estado BOOLEAN
)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO ClienteSql (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado)
    VALUES (cliente_Insert.Cedula, cliente_Insert.Apellidos, cliente_Insert.Nombres, cliente_Insert.FechaNacimiento, cliente_Insert.Mail, cliente_Insert.Telefono, cliente_Insert.Direccion, cliente_Insert.Estado);
END;
$$;

-- Procedimiento almacenado para seleccionar un cliente por ID
CREATE OR REPLACE PROCEDURE cliente_SelectById(Codigo INT)
LANGUAGE plpgsql
AS $$
BEGIN
    PERFORM SETOF RECORD
    FROM (
        SELECT Codigo, Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado
        FROM ClienteSql
        WHERE Codigo = cliente_SelectById.Codigo
    ) AS result;
END;
$$;

-- Procedimiento almacenado para actualizar un cliente
CREATE OR REPLACE PROCEDURE cliente_Update(
    Codigo INT,
    Cedula VARCHAR(10),
    Apellidos VARCHAR(50),
    Nombres VARCHAR(50),
    FechaNacimiento TIMESTAMP,
    Mail VARCHAR(50),
    Telefono VARCHAR(10),
    Direccion VARCHAR(40),
    Estado BOOLEAN
)
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE ClienteSql
    SET Cedula = cliente_Update.Cedula,
        Apellidos = cliente_Update.Apellidos,
        Nombres = cliente_Update.Nombres,
        FechaNacimiento = cliente_Update.FechaNacimiento,
        Mail = cliente_Update.Mail,
        Telefono = cliente_Update.Telefono,
        Direccion = cliente_Update.Direccion,
        Estado = cliente_Update.Estado
    WHERE Codigo = cliente_Update.Codigo;
END;
$$;
