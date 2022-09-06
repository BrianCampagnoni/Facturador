use FacturadorDB

--insert clientes

insert into Cliente (RazonSocial, CUIT, Direccion,Deshabilitado)
values ('Brian', '10101010', 'DirASD123', 0)

insert into Cliente (RazonSocial, CUIT, Direccion,Deshabilitado)
values ('MARIAN', '10000', 'DirMarian123', 0)

insert into Cliente (RazonSocial, CUIT, Direccion,Deshabilitado)
values ('Pato', '3333', 'DirPato123', 1)

-- insert factura cabecera

insert into Factura_Cabecera (FechaAlta,Estado, Cli_ID)
values (GETDATE(),'Aceptado', 1001)

insert into Factura_Cabecera (FechaAlta,Estado, Cli_ID)
values (GETDATE(),'Aceptado', 1000)

insert into Factura_Cabecera (FechaAlta,Estado, Cli_ID)
values (GETDATE(),'Aceptado', 1002)

insert into Factura_Cabecera (FechaAlta,Estado, Cli_ID)
values ('2022-09-05','Rechazado', 1001)

insert into Factura_Cabecera (FechaAlta,Estado, Cli_ID)
values ('2022-09-10','Esperando', 1001)

--insert articulos

insert into Articulo (NombreArticulo, Marca, Descripcion)
values ('Bici','Bike Pro', 'Bicicleta Profesional')

insert into Articulo (NombreArticulo, Marca, Descripcion)
values ('Auto','Auto Pro', 'Auto Profesional')

insert into Articulo (NombreArticulo, Marca, Descripcion)
values ('Moto','Moto Pro', 'Moto Profesional')
-- insert Factura Detalle

insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 2, 100, 2*100, 2001, 20)

insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 3, 200, 3*200, 2002, 30)

insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 4, 300, 4*300, 2003, 40)


insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 2, 100, 2*100, 2000, 20)

insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 3, 200, 3*200, 2004, 30)

insert into Factura_Detalle(FechaAlta, Cant, Precio, Monto, Fact_ID, Art_ID)
values(GETDATE(), 4, 300, 4*300, 2005, 40)


select * from Cliente
select * from Factura_Cabecera
--where Cli_ID = 1001
select * from Articulo
select * from Factura_Detalle

exec FacturasPorClientesMasVendido
	@FechaDesde = '2022-09-02',
	@FechaHasta = '2022-09-09',
	@IdCliente = 0

exec FacturasCabeceraDetallePorClientes
	@FechaDesde = '2022-09-02',
	@FechaHasta = '2022-09-09',
	@IdCliente = 0


select * from View1

select * from View2