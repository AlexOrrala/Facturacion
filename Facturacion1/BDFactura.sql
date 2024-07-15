
CREATE DATABASE [facturacion]
GO

USE [facturacion]
GO

CREATE TABLE [dbo].[FACTURA](
	[ID_Factura] [int] NOT NULL PRIMARY KEY,
	[Nombre_cliente] [varchar](100) NOT NULL,
	[fecha] [date] NOT NULL,
	[baseimponible12] [decimal](10, 2) NULL,
	[baseImponible0] [decimal](10, 2) NULL,
	[iva12] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL,
); 
GO

CREATE TABLE [dbo].[PRODUCTOS](
	[ID_facturaP] [int] NOT NULL,
	[ID_producto] [int] NOT NULL,
	[Nombreproducto] [varchar](100) NOT NULL,
	[Preciounitario] [decimal](10, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[iva12] [bit] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
	PRIMARY KEY (ID_FacturaP,ID_producto),
	FOREIGN KEY (ID_facturaP) REFERENCES FACTURA(ID_Factura)

);
GO
