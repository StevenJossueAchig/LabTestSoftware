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


---------------------------------------------------------
                        MySQL
---------------------------------------------------------
-- Usar la base de datos
USE dbproductos;

-- Procedimiento almacenado para seleccionar todos los clientes
DELIMITER //

CREATE PROCEDURE cliente_SelectAll()
BEGIN
    SELECT Codigo, Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado
    FROM Cliente;
END //

DELIMITER ;

-- Procedimiento almacenado para eliminar un cliente por ID
DELIMITER //

CREATE PROCEDURE cliente_Delete(IN p_Codigo INT)
BEGIN
    START TRANSACTION;
    DELETE FROM Cliente
    WHERE Codigo = p_Codigo;
    COMMIT;
END //

DELIMITER ;

-- Procedimiento almacenado para insertar un nuevo cliente
DELIMITER //

CREATE PROCEDURE cliente_Insert(
    IN p_Cedula VARCHAR(10),
    IN p_Apellidos VARCHAR(50),
    IN p_Nombres VARCHAR(50),
    IN p_FechaNacimiento DATETIME,
    IN p_Mail VARCHAR(50),
    IN p_Telefono VARCHAR(10),
    IN p_Direccion VARCHAR(40),
    IN p_Estado BOOLEAN
)
BEGIN
    START TRANSACTION;
    INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado)
    VALUES (p_Cedula, p_Apellidos, p_Nombres, p_FechaNacimiento, p_Mail, p_Telefono, p_Direccion, p_Estado);
    COMMIT;
END //

DELIMITER ;

-- Procedimiento almacenado para seleccionar un cliente por ID
DELIMITER //

CREATE PROCEDURE cliente_SelectById(IN p_Codigo INT)
BEGIN
    SELECT Codigo, Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado
    FROM Cliente
    WHERE Codigo = p_Codigo;
END //

DELIMITER ;

-- Procedimiento almacenado para actualizar un cliente
DELIMITER //

CREATE PROCEDURE cliente_Update(
    IN p_Codigo INT,
    IN p_Cedula VARCHAR(10),
    IN p_Apellidos VARCHAR(50),
    IN p_Nombres VARCHAR(50),
    IN p_FechaNacimiento DATETIME,
    IN p_Mail VARCHAR(50),
    IN p_Telefono VARCHAR(10),
    IN p_Direccion VARCHAR(40),
    IN p_Estado BOOLEAN
)
BEGIN
    START TRANSACTION;
    UPDATE Cliente
    SET Cedula = p_Cedula,
        Apellidos = p_Apellidos,
        Nombres = p_Nombres,
        FechaNacimiento = p_FechaNacimiento,
        Mail = p_Mail,
        Telefono = p_Telefono,
        Direccion = p_Direccion,
        Estado = p_Estado
    WHERE Codigo = p_Codigo;
    COMMIT;
END //

DELIMITER ;
