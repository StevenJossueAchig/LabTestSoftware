---------------------------------------------------------
						SQL SERVER
---------------------------------------------------------
-- Crear la base de datos
CREATE DATABASE dbproductos;
GO

-- Usar la base de datos creada
USE dbproductos;
GO

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(10) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Nombres VARCHAR(50) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Mail VARCHAR(50) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Direccion VARCHAR(40) NOT NULL,
    Estado BIT
);
GO

-- Insertar algunos datos en la tabla Cliente
INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) VALUES
('0123456789', 'Perez', 'Juan', '1985-04-12', 'juan.perez@example.com', '0987654321', 'Calle Falsa 123', 1),
('9876543210', 'Lopez', 'Ana', '1990-07-22', 'ana.lopez@example.com', '0912345678', 'Avenida Siempre Viva 456', 0),
('1234567890', 'Gomez', 'Carlos', '1975-01-30', 'carlos.gomez@example.com', '0998765432', 'Boulevard Central 789', NULL);
GO

-- Verificar los datos insertados
SELECT * FROM Cliente;
GO



---------------------------------------------------------
						POSTGRESQL
---------------------------------------------------------
-- Crear la base de datos
CREATE DATABASE dbproductos;

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Codigo SERIAL PRIMARY KEY,
    Cedula VARCHAR(10) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Nombres VARCHAR(50) NOT NULL,
    FechaNacimiento TIMESTAMP NOT NULL,
    Mail VARCHAR(50) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Direccion VARCHAR(40) NOT NULL,
    Estado BOOLEAN NOT NULL
);

INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) VALUES
('1701234567', 'Perez Lopez', 'Juan Carlos', '1985-04-12 00:00:00', 'juan.perez@hotmail.com', '0991234567', 'Calle Amazonas 123', TRUE),
('1712345678', 'Lopez Martinez', 'Ana Maria', '1990-07-22 00:00:00', 'ana.lopez@gmail.com', '0992345678', 'Avenida 6 de Diciembre 456', FALSE),
('1703456789', 'Gomez Sanchez', 'Carlos Andres', '1975-01-30 00:00:00', 'carlos.gomez@yahoo.com', '0993456789', 'Calle Republica 789', TRUE),
('1714567890', 'Fernandez Garcia', 'Lucia Isabel', '1982-08-15 00:00:00', 'lucia.fernandez@hotmail.com', '0994567890', 'Calle Shyris 101', TRUE),
('1705678901', 'Rodriguez Castillo', 'Miguel Angel', '1987-07-10 00:00:00', 'miguel.rodriguez@gmail.com', '0995678901', 'Calle Colon 202', FALSE),
('1716789012', 'Vargas Ramos', 'Laura Beatriz', '1992-11-14 00:00:00', 'laura.vargas@yahoo.com', '0996789012', 'Calle Naciones Unidas 303', TRUE),
('1707890123', 'Guzman Diaz', 'David Alejandro', '1979-09-25 00:00:00', 'david.guzman@hotmail.com', '0997890123', 'Calle Eloy Alfaro 404', TRUE),
('1718901234', 'Reyes Ortiz', 'Sofia Valeria', '1980-04-03 00:00:00', 'sofia.reyes@gmail.com', '0998901234', 'Calle Guayaquil 505', FALSE),
('1709012345', 'Morales Paredes', 'Luis Eduardo', '1994-06-22 00:00:00', 'luis.morales@yahoo.com', '0999012345', 'Calle Venezuela 606', TRUE),
('1710123456', 'Ramos Herrera', 'Elena Patricia', '1983-01-11 00:00:00', 'elena.ramos@hotmail.com', '0990123456', 'Calle Sucre 707', TRUE),
('1701234568', 'Jimenez Velasco', 'Jorge Alberto', '1986-10-30 00:00:00', 'jorge.jimenez@gmail.com', '0991234568', 'Calle Esmeraldas 808', FALSE),
('1712345679', 'Torres Guzman', 'Maria Gabriela', '1998-03-18 00:00:00', 'maria.torres@yahoo.com', '0992345679', 'Calle Manabi 909', TRUE),
('1703456780', 'Vargas Zambrano', 'Raul Santiago', '1991-07-29 00:00:00', 'raul.vargas@hotmail.com', '0993456780', 'Calle Pichincha 010', TRUE),
('1714567891', 'Mendoza Leon', 'Carlos Fernando', '1988-02-27 00:00:00', 'carlos.mendoza@gmail.com', '0994567891', 'Calle Quito 111', FALSE),
('1705678902', 'Salazar Chavez', 'Ana Teresa', '1976-08-13 00:00:00', 'ana.salazar@yahoo.com', '0995678902', 'Calle Bolivar 212', TRUE),
('1716789013', 'Castillo Andrade', 'Andres Vicente', '1984-12-24 00:00:00', 'andres.castillo@hotmail.com', '0996789013', 'Calle Mejia 313', TRUE),
('1707890124', 'Cruz Ortega', 'Patricia Lucia', '1999-09-15 00:00:00', 'patricia.cruz@gmail.com', '0997890124', 'Calle Rocafuerte 414', FALSE),
('1718901235', 'Vera Flores', 'Diego Hernan', '1981-05-09 00:00:00', 'diego.vera@yahoo.com', '0998901235', 'Calle Espejo 515', TRUE),
('1709012346', 'Navarro Suarez', 'Jose Manuel', '1978-02-19 00:00:00', 'jose.navarro@hotmail.com', '0999012346', 'Calle Chile 616', TRUE),
('1710123457', 'Cedeño Estrella', 'Isabel Cristina', '1993-11-06 00:00:00', 'isabel.cedeno@gmail.com', '0990123457', 'Calle Olmedo 717', FALSE);


-- Verificar los datos insertados
SELECT * FROM Cliente;


---------------------------------------------------------
                        MySQL
---------------------------------------------------------
-- Crear la base de datos
CREATE DATABASE dbproductos;
USE dbproductos;

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Codigo INT AUTO_INCREMENT PRIMARY KEY,
    Cedula VARCHAR(10) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Nombres VARCHAR(50) NOT NULL,
    FechaNacimiento DATETIME NOT NULL,
    Mail VARCHAR(50) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Direccion VARCHAR(40) NOT NULL,
    Estado BOOLEAN NOT NULL
);

INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) VALUES
('1701234567', 'Perez Lopez', 'Juan Carlos', '1985-04-12 00:00:00', 'juan.perez@hotmail.com', '0991234567', 'Calle Amazonas 123', TRUE),
('1712345678', 'Lopez Martinez', 'Ana Maria', '1990-07-22 00:00:00', 'ana.lopez@gmail.com', '0992345678', 'Avenida 6 de Diciembre 456', FALSE),
('1703456789', 'Gomez Sanchez', 'Carlos Andres', '1975-01-30 00:00:00', 'carlos.gomez@yahoo.com', '0993456789', 'Calle Republica 789', TRUE),
('1714567890', 'Fernandez Garcia', 'Lucia Isabel', '1982-08-15 00:00:00', 'lucia.fernandez@hotmail.com', '0994567890', 'Calle Shyris 101', TRUE),
('1705678901', 'Rodriguez Castillo', 'Miguel Angel', '1987-07-10 00:00:00', 'miguel.rodriguez@gmail.com', '0995678901', 'Calle Colon 202', FALSE),
('1716789012', 'Vargas Ramos', 'Laura Beatriz', '1992-11-14 00:00:00', 'laura.vargas@yahoo.com', '0996789012', 'Calle Naciones Unidas 303', TRUE),
('1707890123', 'Guzman Diaz', 'David Alejandro', '1979-09-25 00:00:00', 'david.guzman@hotmail.com', '0997890123', 'Calle Eloy Alfaro 404', TRUE),
('1718901234', 'Reyes Ortiz', 'Sofia Valeria', '1980-04-03 00:00:00', 'sofia.reyes@gmail.com', '0998901234', 'Calle Guayaquil 505', FALSE),
('1709012345', 'Morales Paredes', 'Luis Eduardo', '1994-06-22 00:00:00', 'luis.morales@yahoo.com', '0999012345', 'Calle Venezuela 606', TRUE),
('1710123456', 'Ramos Herrera', 'Elena Patricia', '1983-01-11 00:00:00', 'elena.ramos@hotmail.com', '0990123456', 'Calle Sucre 707', TRUE),
('1701234568', 'Jimenez Velasco', 'Jorge Alberto', '1986-10-30 00:00:00', 'jorge.jimenez@gmail.com', '0991234568', 'Calle Esmeraldas 808', FALSE),
('1712345679', 'Torres Guzman', 'Maria Gabriela', '1998-03-18 00:00:00', 'maria.torres@yahoo.com', '0992345679', 'Calle Manabi 909', TRUE),
('1703456780', 'Vargas Zambrano', 'Raul Santiago', '1991-07-29 00:00:00', 'raul.vargas@hotmail.com', '0993456780', 'Calle Pichincha 010', TRUE),
('1714567891', 'Mendoza Leon', 'Carlos Fernando', '1988-02-27 00:00:00', 'carlos.mendoza@gmail.com', '0994567891', 'Calle Quito 111', FALSE),
('1705678902', 'Salazar Chavez', 'Ana Teresa', '1976-08-13 00:00:00', 'ana.salazar@yahoo.com', '0995678902', 'Calle Bolivar 212', TRUE),
('1716789013', 'Castillo Andrade', 'Andres Vicente', '1984-12-24 00:00:00', 'andres.castillo@hotmail.com', '0996789013', 'Calle Mejia 313', TRUE),
('1707890124', 'Cruz Ortega', 'Patricia Lucia', '1999-09-15 00:00:00', 'patricia.cruz@gmail.com', '0997890124', 'Calle Rocafuerte 414', FALSE),
('1718901235', 'Vera Flores', 'Diego Hernan', '1981-05-09 00:00:00', 'diego.vera@yahoo.com', '0998901235', 'Calle Espejo 515', TRUE),
('1709012346', 'Navarro Suarez', 'Jose Manuel', '1978-02-19 00:00:00', 'jose.navarro@hotmail.com', '0999012346', 'Calle Chile 616', TRUE),
('1710123457', 'Cedeño Estrella', 'Isabel Cristina', '1993-11-06 00:00:00', 'isabel.cedeno@gmail.com', '0990123457', 'Calle Olmedo 717', FALSE);

-- Verificar los datos insertados
SELECT * FROM Cliente;
