
--create database FacturadorDB
use FacturadorDB


--drop table Factura_Detalle
--drop table Articulo
--drop table Factura_Cabecera
--drop table cliente


create table Cliente (
	Cli_ID int primary key identity(1000,1) not null,
	RazonSocial nvarchar(255),
	CUIT nvarchar(50),
	Direccion nvarchar(255),
	Deshabilitado bit
)

create table Factura_Cabecera(
	FC_ID int Primary Key identity(2000,1) not null,
	FechaAlta datetime,
	Estado nvarchar(50),
	Cli_ID int Foreign Key References Cliente(Cli_ID) not null
)

create table Articulo(
	ART_ID int Primary Key Identity(10,10) not null,
	NombreArticulo nvarchar(100),
	Marca nvarchar(100),
	Descripcion nvarchar(255)
)


create table Factura_Detalle(
	FC_DTL_ID int Primary Key Identity(1,1) not null,
	FechaAlta datetime,
	Cant decimal,
	Precio decimal,
	Monto decimal,
	Fact_ID int Foreign Key References Factura_Cabecera(FC_ID) not null,
	Art_ID int Foreign Key References Articulo(ART_ID) not null,
)