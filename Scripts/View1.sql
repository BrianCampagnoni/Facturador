USE [FacturadorDB]
GO

/****** Object:  View [dbo].[View1]    Script Date: 6/9/2022 15:23:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[View1] as

select FC.Estado, 
FD.Monto
from Factura_Cabecera FC
left join Factura_Detalle FD on FC.FC_ID = FD.Fact_ID
group by FC.Estado,	FD.Monto
GO


