USE [FacturadorDB]
GO

/****** Object:  StoredProcedure [dbo].[FacturasPorClientesMasVendido]    Script Date: 6/9/2022 15:23:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[FacturasPorClientesMasVendido]
(
	@FechaDesde date,
	@FechaHasta date,
	@IdCliente int
)
as
begin

if (@IdCliente is not null and @IdCliente != 0)

	select FC.Cli_ID, 
	FC.Estado, 
	FC.FechaAlta, 
	FC.FC_ID,
	A.ART_ID as ID_Articulo,
	A.Descripcion
	from Factura_Cabecera FC
	left join Factura_Detalle FD on FD.Fact_Id = FC.FC_ID
	left join Articulo A on FD.Art_ID = A.ART_ID
	where FC.Cli_ID = @IdCliente --1001
	and fc.FechaAlta >= @FechaDesde --'2022-09-02' 
	and fc.FechaAlta <= @FechaHasta --'2022-09-09'

else
	select FC.Cli_ID, 
	FC.Estado, 
	FC.FechaAlta, 
	FC.FC_ID,
	A.ART_ID as ID_Articulo,
	A.Descripcion
	from Factura_Cabecera FC
	left join Factura_Detalle FD on FD.Fact_Id = FC.FC_ID
	left join Articulo A on FD.Art_ID = A.ART_ID
	where fc.FechaAlta >= @FechaDesde --'2022-09-02' 
	and fc.FechaAlta <= @FechaHasta --'2022-09-09'

end
GO


