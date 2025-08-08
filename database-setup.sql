-- Script para configuración de la base de datos API
-- Ejecutar en SQL Server LocalDB

-- Crear base de datos
CREATE DATABASE API;
GO

-- Usar la base de datos
USE API;
GO

-- Crear tabla Usuario
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Identificacion NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL
);
GO

-- Insertar datos de prueba
INSERT INTO Usuario (Identificacion, Password, Nombre) VALUES 
('123456789', 'password123', 'Juan Pérez'),
('987654321', 'admin123', 'María González'),
('555666777', 'user123', 'Carlos Rodríguez');
GO
