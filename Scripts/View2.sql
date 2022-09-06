USE [FacturadorDB]
GO

/****** Object:  View [dbo].[View2]    Script Date: 6/9/2022 15:24:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[View2] as

select FC.FC_ID, 
FC.FechaAlta,
C.RazonSocial,
C.CUIT
from Factura_Cabecera FC
left join Cliente C on FC.Cli_ID= C.Cli_ID
group by FC.FC_ID,	FC.FechaAlta, C.RazonSocial, C.CUIT
GO


