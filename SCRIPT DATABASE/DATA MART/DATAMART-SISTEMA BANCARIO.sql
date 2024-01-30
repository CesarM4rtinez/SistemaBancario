CREATE DATABASE DataMart_SisBanca
GO

USE DataMart_SisBanca
GO

CREATE TABLE DIM_CLIENTE(
   ID_DIM_CLIENTE     INT IDENTITY(1,1),
   ID_CLIENTE         INT,
   NOM_CLIENTE        VARCHAR(20) NOT NULL,
   APE_PATE_CLIENTE   VARCHAR(15) NOT NULL,
   APE_MATE_CLIENTE   VARCHAR(15) NOT NULL,

   CONSTRAINT PK_CLIENTE PRIMARY KEY (ID_DIM_CLIENTE),
   CONSTRAINT UQ_NOM_CLIENTE UNIQUE  (NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE)
)
GO

CREATE TABLE DIM_TRANSACCION(
   ID_TIPO_TRANSACCION INT IDENTITY(1,1),
   TIPO_MOVIMIENTO     VARCHAR(40) NOT NULL,

   CONSTRAINT PK_TIPO_TRANSACCION PRIMARY KEY (ID_TIPO_TRANSACCION)
)
GO


CREATE TABLE DIMENSION_TIEMPO
(
   FECHAKEY      INT         NOT NULL,
   FECHA         DATE        NOT NULL,
   AÑO           SMALLINT    NOT NULL,
   TRIMESTRE     SMALLINT    NOT NULL,
   MES           SMALLINT    NOT NULL,
   SEMANA        SMALLINT    NOT NULL,
   DIA           SMALLINT    NOT NULL,
   DIASEMANA     SMALLINT    NOT NULL,
   NTRIMESTRE    VARCHAR(15) NOT NULL,
   NMES          VARCHAR(15) NOT NULL,
   NMESL         VARCHAR(15) NOT NULL,
   NSEMANA       VARCHAR(15) NOT NULL,
   NDIA          VARCHAR(15) NOT NULL,
   NDIASEMANA    VARCHAR(15) NOT NULL,

   CONSTRAINT [PK_Dimension_Tiempo_FECHAKEY] PRIMARY KEY CLUSTERED(FECHA)
)
GO

SET LANGUAGE SPANISH
GO
SET DATEFORMAT DMY
GO
DECLARE @FechaDesde as datetime, @FechaHasta as datetime
DECLARE @FechaAAAAMMDD int
DECLARE @Año as smallint, @Trimestre varchar(15), @Mes smallint
DECLARE @Semana smallint, @Dia smallint, @DiaSemana smallint
DECLARE @NTrimestre varchar(15), @NMes varchar(15)
DECLARE @NMes3l varchar(15)
DECLARE @NSemana varchar(15), @NDia varchar(15), @NDiaSemana varchar(15)
--Set inicial por si no coincide con los del servidor
BEGIN TRANSACTION
--RAngo de fechas a generar: del 01/01/2006 al 31/12/Año actual+2
SELECT @FechaDesde = CAST('2023-09-01' AS Datetime)
SELECT @FechaHasta = CAST(CAST(YEAR(GETDATE())+2 AS CHAR(4)) + '1231' AS datetime)
WHILE (@FechaDesde <= @FechaHasta) BEGIN
SELECT @FechaAAAAMMDD = YEAR(@FechaDesde)*10000+MONTH(@FechaDesde)*100+DATEPART(dd, @FechaDesde)
SELECT @Año = DATEPART(yy, @FechaDesde)
SELECT @Trimestre = DATEPART(qq, @FechaDesde)
SELECT @Mes = DATEPART(m, @FechaDesde)
SELECT @Semana = DATEPART(wk, @FechaDesde)
SELECT @Dia = RIGHT('0' + DATEPART(dd, @FechaDesde),2)
SELECT @DiaSemana = DATEPART(DW, @FechaDesde)
SELECT @NMes = DATENAME(mm, @FechaDesde)
SELECT @NMes3l = LEFT(@NMes, 3)
SELECT @NTrimestre = 'T' + CAST(@Trimestre as CHAR(1)) + '/' + RIGHT(@Año, 2)
SELECT @NSemana = 'Sem ' +CAST(@Semana AS CHAR(2)) + '/' + RIGHT(RTRIM(CAST(@Año as CHAR(4))),2)
SELECT @NDia = CAST(@Dia as CHAR(2)) + ' ' + RTRIM(@NMes)
SELECT @NDiaSemana = DATENAME(dw, @FechaDesde)
INSERT INTO DIMENSION_TIEMPO (FECHAKEY, Fecha, Año, Trimestre, Mes, Semana, Dia, DiaSemana, NTrimestre, NMes, NMesL, NSemana, NDia, NDiaSemana)
VALUES (@FechaAAAAMMDD, @FechaDesde, @Año, @Trimestre, @Mes, @Semana, @Dia, @DiaSemana, @NTrimestre, @NMes, @NMes3l, @NSemana, @NDia, @NDiaSemana)
--Incremento del bucle
SELECT @FechaDesde = DATEADD(DAY, 1, @FechaDesde)
END
COMMIT TRANSACTION


CREATE TABLE HECHOS(
   ID_TIPO_TRANSACCION  INT,
   FECHA                DATE,
   ID_DIM_CLIENTE       INT,
   ENTRADA              DECIMAL(18,2) DEFAULT 0.00,
   SALIDA               DECIMAL(18,2) DEFAULT 0.00,

   CONSTRAINT FK_HECHOS_TIPO_TSC    FOREIGN KEY (ID_TIPO_TRANSACCION) REFERENCES DIM_TRANSACCION (ID_TIPO_TRANSACCION),
   CONSTRAINT FK_HECHOS_FECHA       FOREIGN KEY (FECHA)               REFERENCES DIMENSION_TIEMPO (FECHA),
   CONSTRAINT FK_HECHOS_DIM_CLIENTE FOREIGN KEY (ID_DIM_CLIENTE)      REFERENCES DIM_CLIENTE (ID_DIM_CLIENTE)
)
GO