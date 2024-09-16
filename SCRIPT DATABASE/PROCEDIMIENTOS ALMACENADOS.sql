-- @ 2023 César Martínez. All Copyright.
-- CREADOR DEL CÓDIGO SQL -> CÉSAR OVIDIO MARTÍNEZ CHICAS.

/* PROCEDIMIENTOS ALMACENADOS */
USE SISTEMA_BANCARIO
GO

/* 1. PROCEDIMIENTOS ALMACENADOS DE TIPOS DE CLIENTES DEL BANCO */
CREATE PROCEDURE USP_ListadoTipoPersonas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TP_PERSONA,
        FECHA_REGISTRO,
        TIPO_PERSONA

    FROM TIPO_CLIENTE 
    
    WHERE ESTADO = 1 AND (
            TIPO_PERSONA LIKE '%' + @cTexto + '%'
		  )
	ORDER BY ID_TP_PERSONA DESC
END;
GO
-- EXEC USP_ListadoTipoPersonas

CREATE PROCEDURE USP_ListadoTipoPersonasCaidas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TP_PERSONA,
        FECHA_REGISTRO,
        TIPO_PERSONA

    FROM TIPO_CLIENTE
    
    WHERE ESTADO = 0 AND (
            TIPO_PERSONA LIKE '%' + @cTexto + '%'
		  )
	ORDER BY ID_TP_PERSONA DESC
END;
GO
-- EXEC USP_ListadoTipoPersonasCaidas

CREATE PROCEDURE USP_GuardarTipoCliente
@nOpcion        INT = 0,
@nId_Tp_Persona INT = 0,
@cTipo_Persona  VARCHAR(20) = ''
AS
BEGIN
    DECLARE @xCodigo INT = 0
    DECLARE @fFecha AS DATETIME
    SET @fFecha = CONVERT(DATETIME, GETDATE())

    IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
        INSERT INTO TIPO_CLIENTE (
            TIPO_PERSONA,
			ESTADO
        )
        VALUES (
            @cTipo_persona,
			1
        );
    END;
    ELSE -- Actualizar registro
    BEGIN
        UPDATE TIPO_CLIENTE
        SET
            TIPO_PERSONA      = @cTipo_Persona
        WHERE 
		    ID_TP_PERSONA     = @nId_Tp_Persona;
    END;
END
GO

CREATE PROCEDURE USP_EliminarTipoCliente
@nID_TP_PERSONA INT = 0
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 0
    WHERE ID_TP_PERSONA = @nID_TP_PERSONA
END
GO

CREATE PROCEDURE USP_LevantarTipoCliente
@nID_TP_PERSONA INT = 0
AS
BEGIN
    -- Actualizar la tabla nativa a 0
    UPDATE TIPO_CLIENTE
    SET ESTADO = 1
    WHERE ID_TP_PERSONA = @nID_TP_PERSONA
END;
GO
-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 2. PROCEDIMIENTOS ALMACENADOS CLIENTES DEL BANCO */
CREATE PROCEDURE USP_ListadoClientes
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        C.ID_CLIENTE,
		C.FECHA_REGISTRO,
		T.TIPO_PERSONA,
        C.NOM_CLIENTE,
        C.APE_PATE_CLIENTE,
        C.APE_MATE_CLIENTE,
        C.DIRECCION_CLIENTE,
        C.TEL_CEL_CLIENTE,
        C.TEL_FIJO_CLIENTE,
        C.DNI,
        C.NOM_CARGO_CLIENTE,
        C.SUELDO,
		C.ESTADO,
        T.ID_TP_PERSONA

    FROM CLIENTE C
    INNER JOIN TIPO_CLIENTE T ON C.ID_TP_PERSONA = T.ID_TP_PERSONA
    WHERE C.ESTADO = 1 
	AND (	    
        C.NOM_CLIENTE             LIKE '%' + @cTexto + '%' OR
		C.APE_PATE_CLIENTE        LIKE '%' + @cTexto + '%' OR
		C.APE_MATE_CLIENTE        LIKE '%' + @cTexto + '%' OR
        C.DIRECCION_CLIENTE       LIKE '%' + @cTexto + '%' OR
		C.TEL_CEL_CLIENTE         LIKE '%' + @cTexto + '%' OR
		C.TEL_FIJO_CLIENTE        LIKE '%' + @cTexto + '%' OR 
        C.DNI                     LIKE '%' + @cTexto + '%' OR
		C.NOM_CARGO_CLIENTE       LIKE '%' + @cTexto + '%' OR
		CAST(C.SUELDO AS VARCHAR) LIKE '%' + @cTexto + '%' OR 
        T.TIPO_PERSONA            LIKE '%' + @cTexto + '%'
		)
	ORDER BY C.ID_CLIENTE DESC
END;
GO
-- EXEC USP_ListadoClientes

CREATE PROCEDURE USP_ListadoClientesCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        C.ID_CLIENTE,
		C.FECHA_REGISTRO,
		T.TIPO_PERSONA,
        C.NOM_CLIENTE,
        C.APE_PATE_CLIENTE,
        C.APE_MATE_CLIENTE,
        C.DIRECCION_CLIENTE,
        C.TEL_CEL_CLIENTE,
        C.TEL_FIJO_CLIENTE,
        C.DNI,
        C.NOM_CARGO_CLIENTE,
        C.SUELDO,
		C.ESTADO,
        T.ID_TP_PERSONA

    FROM CLIENTE C
    INNER JOIN TIPO_CLIENTE T ON C.ID_TP_PERSONA = T.ID_TP_PERSONA
    WHERE C.ESTADO = 0 
	AND (	    
        C.NOM_CLIENTE             LIKE '%' + @cTexto + '%' OR
		C.APE_PATE_CLIENTE        LIKE '%' + @cTexto + '%' OR
		C.APE_MATE_CLIENTE        LIKE '%' + @cTexto + '%' OR
        C.DIRECCION_CLIENTE       LIKE '%' + @cTexto + '%' OR
		C.TEL_CEL_CLIENTE         LIKE '%' + @cTexto + '%' OR
		C.TEL_FIJO_CLIENTE        LIKE '%' + @cTexto + '%' OR 
        C.DNI                     LIKE '%' + @cTexto + '%' OR
		C.NOM_CARGO_CLIENTE       LIKE '%' + @cTexto + '%' OR
		CAST(C.SUELDO AS VARCHAR) LIKE '%' + @cTexto + '%' OR 
        T.TIPO_PERSONA            LIKE '%' + @cTexto + '%'
		)
	ORDER BY C.ID_CLIENTE DESC
END;
GO
-- EXEC USP_ListadoClientesCaidos

CREATE PROCEDURE USP_GuardarCliente
@nOpcion int=0,
@nId_cliente    INT = 0,
@nId_Tp_Persona INT = 0,
@cNom_Cliente   VARCHAR(20) = '',
@cApe_Pate_cli  VARCHAR(15) = '',
@cApe_Mate_cli  VARCHAR(15) = '',
@cDireccion_cli VARCHAR(50) = '',
@cTel_Movil_cli VARCHAR(9)  = '',
@cTel_Fijo_cli  VARCHAR(9)  = '',
@cDNI_cli       VARCHAR(10) = '',
@cNom_Cargo_cli VARCHAR(40) = '',
@nSueldo_cli    INT = 0 
as
if @nOpcion=1 -- Nuevo Registro
begin
	insert into CLIENTE(
            ID_TP_PERSONA,
            NOM_CLIENTE,
            APE_PATE_CLIENTE,
            APE_MATE_CLIENTE,
            DIRECCION_CLIENTE,
            TEL_CEL_CLIENTE,
            TEL_FIJO_CLIENTE,
            DNI,
            NOM_CARGO_CLIENTE,
            SUELDO,
			ESTADO
			)  
      values(
	        @nId_Tp_Persona,
            @cNom_Cliente,
            @cApe_Pate_cli,
            @cApe_Mate_cli,
            @cDireccion_cli,
            @cTel_Movil_cli,
            @cTel_Fijo_cli,
            @cDNI_cli,
            @cNom_Cargo_cli,
            @nSueldo_cli,
			1
		  )
end;
else -- Actualizar registro
begin
	 update CLIENTE set 
            ID_TP_PERSONA     = @nId_Tp_Persona,
            NOM_CLIENTE       = @cNom_Cliente,
            APE_PATE_CLIENTE  = @cApe_Pate_cli,
            APE_MATE_CLIENTE  = @cApe_Mate_cli,
            DIRECCION_CLIENTE = @cDireccion_cli,
            TEL_CEL_CLIENTE   = @cTel_Movil_cli,
            TEL_FIJO_CLIENTE  = @cTel_Fijo_cli,
            DNI               = @cDNI_cli,
            NOM_CARGO_CLIENTE = @cNom_Cargo_cli,
            SUELDO            = @nSueldo_cli
      WHERE 
		    ID_CLIENTE        = @nId_cliente;
end;
GO

CREATE PROCEDURE USP_EliminarCliente
@nID_CLIENTE INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE CLIENTE
    SET ESTADO = 0
    WHERE ID_CLIENTE = @nID_CLIENTE;

END;
GO

CREATE PROCEDURE USP_LevantarCliente
@nID_CLIENTE INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 1
    UPDATE CLIENTE
    SET ESTADO = 1
    WHERE ID_CLIENTE = @nID_CLIENTE;
END
GO

-------------------------------------------------------------------
-- PANEL DE DESICIÓN CLIENTE
-------------------------------------------------------------------

CREATE PROC USP_ListadoTipoCliente      
AS 
  SELECT ID_TP_PERSONA, TIPO_PERSONA 
  FROM TIPO_CLIENTE
  WHERE ESTADO = 1 ORDER BY ID_TP_PERSONA DESC
GO
-- EXEC USP_ListadoTipoCliente

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 3. PROCEDIMIENTOS ALMACENADOS DE TIPOS DE TARJETAS DE CREDITO */
CREATE PROCEDURE USP_ListadoTipoCredito
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT 
	       ID_TP_TARJETA, 
	       FECHA_REGISTRO, 
		   NOM_TARJETA, 
		   LIMITE
    FROM   
	       TIPO_TARJETA_CREDITO
    WHERE  ESTADO = 1
    AND (
           NOM_TARJETA LIKE '%' + @cTexto + '%'
        OR LIMITE      LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_TP_TARJETA DESC
END;
GO
-- EXEC USP_ListadoTipoCredito


CREATE PROCEDURE USP_ListadoTipoCreditosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT 
	       ID_TP_TARJETA, 
	       FECHA_REGISTRO, 
		   NOM_TARJETA, 
		   LIMITE
    FROM   
	       TIPO_TARJETA_CREDITO
    WHERE  ESTADO = 0
    AND (
           NOM_TARJETA LIKE '%' + @cTexto + '%'
        OR LIMITE      LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_TP_TARJETA DESC
END
GO
-- EXEC USP_ListadoTipoCreditosCaidos

CREATE PROCEDURE USP_GuardarTipoCredito
@nOpcion                INT = 0,
@nID_TP_TARJETA         INT = 0,
@cNOM_TARJETA           VARCHAR(10),
@cLIMITE                INT = 0
AS
IF @nOpcion=1 -- Nuevo Registro
BEGIN
	INSERT INTO TIPO_TARJETA_CREDITO(
				NOM_TARJETA,
				LIMITE,
				ESTADO
        )
        VALUES (
                @cNOM_TARJETA,
                @cLIMITE,
			    1
               )
END
ELSE -- Actualizar registro
BEGIN
	 update TIPO_TARJETA_CREDITO  SET
            NOM_TARJETA           = @cNOM_TARJETA,
            LIMITE                = @cLIMITE

        WHERE 
		    ID_TP_TARJETA = @nID_TP_TARJETA
END
GO

CREATE PROCEDURE USP_EliminarTipoCredito
@nID_TP_TARJETA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_TARJETA_CREDITO
    SET ESTADO = 0
    WHERE ID_TP_TARJETA = @nID_TP_TARJETA;
END;
GO

CREATE PROCEDURE USP_LenvantarTipoCredito
@nID_TP_TARJETA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_TARJETA_CREDITO
    SET ESTADO = 1
    WHERE ID_TP_TARJETA = @nID_TP_TARJETA;
END
GO
-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 4. PROCEDIMIENTOS ALMACENADOS DE TARJETAS DE CREDITO */

CREATE PROCEDURE USP_ListadoTarjetasCredito
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        A.ID_TARJETA_CREDITO,
		A.FECHA_REGISTRO,
        A.ID_CLIENTE,
        C.NOM_CLIENTE,
        C.APE_PATE_CLIENTE,
        C.APE_MATE_CLIENTE,
        A.ID_CUENTA,
		T.NOM_TARJETA,
        B.CODIGO_CUENTA,
        A.ID_TP_TARJETA,
        A.CODIGO_TARJETA,
        A.SALDO_DISPONIBLE
    FROM TARJETA_CREDITO A
    INNER JOIN CLIENTE C ON A.ID_CLIENTE = C.ID_CLIENTE
    INNER JOIN TIPO_TARJETA_CREDITO T ON A.ID_TP_TARJETA = T.ID_TP_TARJETA
    INNER JOIN CUENTA B ON A.ID_CUENTA = B.ID_CUENTA
    WHERE A.ESTADO = 1
    AND (
           A.SALDO_DISPONIBLE LIKE '%' + @cTexto + '%'
        OR C.NOM_CLIENTE      LIKE '%' + @cTexto + '%'
        OR C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%'
        OR C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%'
        OR C.ID_CLIENTE       LIKE '%' + @cTexto + '%'
        OR T.ID_TP_TARJETA    LIKE '%' + @cTexto + '%'
        OR B.ID_CUENTA        LIKE '%' + @cTexto + '%'
        OR B.CODIGO_CUENTA    LIKE '%' + @cTexto + '%'
        )
	ORDER BY A.ID_TARJETA_CREDITO DESC
END
GO
-- EXEC USP_ListadoTarjetasCredito

CREATE PROCEDURE USP_ListadoTarjetasCreditoCaidas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        A.ID_TARJETA_CREDITO,
		A.FECHA_REGISTRO,
        A.ID_CLIENTE,
        C.NOM_CLIENTE,
        C.APE_PATE_CLIENTE,
        C.APE_MATE_CLIENTE,
        A.ID_CUENTA,
		T.NOM_TARJETA,
        B.CODIGO_CUENTA,
        A.ID_TP_TARJETA,
        A.CODIGO_TARJETA,
        A.SALDO_DISPONIBLE
    FROM TARJETA_CREDITO A
    INNER JOIN CLIENTE C ON A.ID_CLIENTE = C.ID_CLIENTE
    INNER JOIN TIPO_TARJETA_CREDITO T ON A.ID_TP_TARJETA = T.ID_TP_TARJETA
    INNER JOIN CUENTA B ON A.ID_CUENTA = B.ID_CUENTA
    WHERE A.ESTADO = 0
    AND (
           A.SALDO_DISPONIBLE LIKE '%' + @cTexto + '%'
        OR C.NOM_CLIENTE      LIKE '%' + @cTexto + '%'
        OR C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%'
        OR C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%'
        OR C.ID_CLIENTE       LIKE '%' + @cTexto + '%'
        OR T.ID_TP_TARJETA    LIKE '%' + @cTexto + '%'
        OR B.ID_CUENTA        LIKE '%' + @cTexto + '%'
        OR B.CODIGO_CUENTA    LIKE '%' + @cTexto + '%'
        )
	ORDER BY A.ID_TARJETA_CREDITO DESC
END
GO
-- EXEC USP_ListadoTarjetasCreditoCaidas

CREATE PROCEDURE USP_GuardarTarjetaCredito
@nOpcion                INT = 0,
@nID_TARJETA_CREDITO    INT = 0,
@nID_CLIENTE            INT = 0,
@cID_CUENTA             INT = 0,
@cID_TP_TARJETA         INT = 0,
@cSALDO_DISPONIBLE      DECIMAL = 0.00
AS
BEGIN
    IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
        DECLARE @nSALDO_DISPONIBLE INT
        SELECT @nSALDO_DISPONIBLE = LIMITE FROM TIPO_TARJETA_CREDITO WHERE ID_TP_TARJETA = @cID_TP_TARJETA

        INSERT INTO TARJETA_CREDITO(
            ID_CLIENTE,
            ID_CUENTA,
            ID_TP_TARJETA,
            SALDO_DISPONIBLE,
            ESTADO
        )
        VALUES (
            @nID_CLIENTE,
            @cID_CUENTA,
            @cID_TP_TARJETA,
            @nSALDO_DISPONIBLE, -- Utiliza el límite obtenido
            1
        )
    END;
    ELSE -- Actualizar registro
    BEGIN
        UPDATE TARJETA_CREDITO
        SET
            ID_CLIENTE       = @nID_CLIENTE,
            ID_CUENTA        = @cID_CUENTA,
            ID_TP_TARJETA    = @cID_TP_TARJETA,
            SALDO_DISPONIBLE = @cSALDO_DISPONIBLE
        WHERE
            ID_TARJETA_CREDITO = @nID_TARJETA_CREDITO
    END;
END;
GO

CREATE PROCEDURE USP_EliminarTarjetaCredito
@nID_TARJETA_CREDITO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TARJETA_CREDITO
    SET ESTADO = 0
    WHERE ID_TARJETA_CREDITO = @nID_TARJETA_CREDITO;
END
GO

CREATE PROCEDURE USP_LevantarTarjetaCredito
@nID_TARJETA_CREDITO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TARJETA_CREDITO
    SET ESTADO = 1
    WHERE ID_TARJETA_CREDITO = @nID_TARJETA_CREDITO;
END
GO
-------------------------------------------------------------------
-- PANELES DE DESICIÓN TARJETAS DE CREDITO
-------------------------------------------------------------------

CREATE PROCEDURE USP_ListadoTarjetaCreditoCliente        
AS 
  SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE 
  FROM     CLIENTE
  WHERE    ESTADO = 1
  ORDER BY ID_CLIENTE DESC
GO
-- EXEC USP_ListadoTarjetaCreditoCliente

CREATE PROCEDURE USP_ListadoTarjetasCreditoCuenta
AS
BEGIN
    SELECT A.ID_CUENTA, A.CODIGO_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE
    FROM CUENTA A
    INNER JOIN CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE 
	WHERE A.ESTADO = 1
    ORDER BY A.ID_CUENTA DESC
END
GO
-- EXEC USP_ListadoTarjetasCreditoCuenta

CREATE PROC USP_ListadoTipoTarjetasCredito       
AS 
  SELECT ID_TP_TARJETA, NOM_TARJETA 
  FROM TIPO_TARJETA_CREDITO
  WHERE ESTADO = 1
  ORDER BY ID_TP_TARJETA DESC
GO
-- EXEC USP_ListadoTipoTarjetasCredito

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 5. PROCEDIMIENTOS ALMACENADOS DE TIPO DE CUENTAS */

CREATE PROCEDURE USP_ListadoTipoCuentas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TIPO_CUENTA,
		FECHA_REGISTRO,
		NOM_CUENTA

    FROM TIPO_CUENTA

    WHERE ESTADO = 1 AND
	      NOM_CUENTA   LIKE '%' + @cTexto + '%'
    ORDER BY ID_TIPO_CUENTA DESC
END;
GO
-- EXEC USP_ListadoTipoCuentas

CREATE PROCEDURE USP_ListadoTipoCuentasCaidas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TIPO_CUENTA,
		FECHA_REGISTRO,
		NOM_CUENTA

    FROM TIPO_CUENTA

    WHERE ESTADO = 0 AND
	      NOM_CUENTA   LIKE '%' + @cTexto + '%'
    ORDER BY ID_TIPO_CUENTA DESC
END
GO
-- EXEC USP_ListadoTipoCuentasCaidas

CREATE PROCEDURE USP_GuardarTipoCuenta
@nOpcion                INT = 0,
@cID_TIPO_CUENTA        INT = 0,
@cNOM_CUENTA            VARCHAR (12)
AS
IF @nOpcion=1 -- Nuevo Registro
BEGIN
	INSERT INTO TIPO_CUENTA(
            NOM_CUENTA,
			ESTADO
        )
        VALUES (
            @cNOM_CUENTA,
			1
        )
END
ELSE -- Actualizar registro
BEGIN
	 UPDATE TIPO_CUENTA  SET
            NOM_CUENTA     = @cNOM_CUENTA

        WHERE 
		    ID_TIPO_CUENTA = @cID_TIPO_CUENTA
END
GO

CREATE PROCEDURE USP_EliminarTipoCuenta
@nID_TIPO_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_CUENTA
    SET    ESTADO = 0
    WHERE  ID_TIPO_CUENTA = @nID_TIPO_CUENTA
END
GO

CREATE PROCEDURE USP_LevantarTipoCuenta
@nID_TIPO_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 1
    UPDATE TIPO_CUENTA
    SET    ESTADO = 1
    WHERE  ID_TIPO_CUENTA = @nID_TIPO_CUENTA
END
GO

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 6. PROCEDIMIENTOS ALMACENADOS DE CUENTAS BANCARIAS */

CREATE PROCEDURE USP_ListadoCuentas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        A.ID_CUENTA,
		A.FECHA_REGISTRO,
        A.CODIGO_CUENTA,
		A.SALDO_ACTUAL,
        C.ID_TIPO_CUENTA,
		C.NOM_CUENTA,
        T.ID_CLIENTE,
		T.NOM_CLIENTE,
		T.APE_PATE_CLIENTE,
		T.APE_MATE_CLIENTE

    FROM CUENTA A
    INNER JOIN TIPO_CUENTA C ON A.ID_TIPO_CUENTA = C.ID_TIPO_CUENTA
    INNER JOIN CLIENTE     T ON A.ID_CLIENTE     = T.ID_CLIENTE
    WHERE A.ESTADO = 1
    AND (
           A.ID_CUENTA        LIKE '%' + @cTexto + '%'
		OR A.CODIGO_CUENTA    LIKE '%' + @cTexto + '%'
		OR A.SALDO_ACTUAL     LIKE '%' + @cTexto + '%'
        OR T.NOM_CLIENTE      LIKE '%' + @cTexto + '%'
        OR T.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%'
        )
	ORDER BY A.ID_CUENTA DESC 
END
GO
-- EXEC USP_ListadoCuentas

CREATE PROCEDURE USP_ListadoCuentasCaidas
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        A.ID_CUENTA,
		A.FECHA_REGISTRO,
        A.CODIGO_CUENTA,
		A.SALDO_ACTUAL,
        C.ID_TIPO_CUENTA,
		C.NOM_CUENTA,
        T.ID_CLIENTE,
		T.NOM_CLIENTE,
		T.APE_PATE_CLIENTE,
		T.APE_MATE_CLIENTE

    FROM CUENTA A
    INNER JOIN TIPO_CUENTA C ON A.ID_TIPO_CUENTA = C.ID_TIPO_CUENTA
    INNER JOIN CLIENTE     T ON A.ID_CLIENTE     = T.ID_CLIENTE
    WHERE A.ESTADO = 0
    AND (
           A.ID_CUENTA        LIKE '%' + @cTexto + '%'
		OR A.CODIGO_CUENTA    LIKE '%' + @cTexto + '%'
		OR A.SALDO_ACTUAL     LIKE '%' + @cTexto + '%'
        OR T.NOM_CLIENTE      LIKE '%' + @cTexto + '%'
        OR T.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%'
        )
	ORDER BY A.ID_CUENTA DESC
END
GO
-- EXEC USP_ListadoCuentasCaidas


CREATE PROCEDURE USP_GuardarCuenta
@nOpcion                INT = 0,
@cID_CUENTA             INT = 0,
@cID_TIPO_CUENTA        INT = 0,
@cID_CLIENTE            INT = 0,
@cSALDO_ACTUAL          INT = 0

AS
BEGIN
  -- Verificar si el cliente tiene ID_TP_CLIENTE = 1
  DECLARE @ID_TP_CLIENTE INT
  SELECT @ID_TP_CLIENTE = ID_TP_PERSONA FROM CLIENTE WHERE ID_CLIENTE = @cID_CLIENTE

  IF @ID_TP_CLIENTE = 1
  BEGIN
    -- SI EL CLIENTE ES FISICO SOLO SE PERMITIRAN CUENTAS DE AHORRO
    IF @cID_TIPO_CUENTA = 2
    BEGIN
      IF @nOpcion = 1 -- Nuevo Registro
      BEGIN
        INSERT INTO CUENTA(
          ID_TIPO_CUENTA,
          ID_CLIENTE,
          SALDO_ACTUAL,
          ESTADO
        )
        VALUES 
        (
          @cID_TIPO_CUENTA,
          @cID_CLIENTE,
          @cSALDO_ACTUAL,
          1
        )
      END
      ELSE -- Actualizar registro
      BEGIN
        UPDATE CUENTA SET
          ID_CLIENTE        = @cID_CLIENTE,
          ID_TIPO_CUENTA    = @cID_TIPO_CUENTA,
          SALDO_ACTUAL      = @cSALDO_ACTUAL
        WHERE 
          ID_CUENTA         = @cID_CUENTA
      END
    END
    ELSE
    BEGIN
      -- CUANDO EL CIENTE SEA FISICO Y LA CUENTA SELECCIONADA SEA DE TIPO CORRIENTE:
      RAISERROR ('POLITICAS DEL BANCO: NO SE PERMITEN CREAR CUENTAS CORRIENTES PARA CLIENTES FISICOS.', 16, 1)
    END
  END
  ELSE
  BEGIN
    -- SI EL CLIENTE ES JURIDICO SE PERMITIRA CREAR CUENTAS TANTO DE AHORRO COMO CORRIENTES
    IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
      INSERT INTO CUENTA(
        ID_TIPO_CUENTA,
        ID_CLIENTE,
        SALDO_ACTUAL,
        ESTADO
      )
      VALUES 
      (
        @cID_TIPO_CUENTA,
        @cID_CLIENTE,
        @cSALDO_ACTUAL,
        1
      )
    END
    ELSE -- Actualizar registro
    BEGIN
      UPDATE CUENTA SET
        ID_CLIENTE        = @cID_CLIENTE,
        ID_TIPO_CUENTA    = @cID_TIPO_CUENTA,
        SALDO_ACTUAL      = @cSALDO_ACTUAL
      WHERE 
        ID_CUENTA         = @cID_CUENTA
    END
  END
END
GO


CREATE PROCEDURE USP_EliminarCuenta
@nID_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE CUENTA
    SET ESTADO = 0
    WHERE ID_CUENTA = @nID_CUENTA;
END;
GO

CREATE PROCEDURE USP_LevantarCuenta
@nID_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE CUENTA
    SET ESTADO = 1
    WHERE ID_CUENTA = @nID_CUENTA;
END
GO
-------------------------------------------------------------------
-- PANELES DE DESICIÓN DE CUENTA
-------------------------------------------------------------------

CREATE PROCEDURE USP_ListadoCuentaCliente
AS
BEGIN
    SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE 
    FROM     CLIENTE
	WHERE    ESTADO = 1
    ORDER BY ID_CLIENTE DESC
END
GO
-- EXEC USP_ListadoCuentaCliente

CREATE PROCEDURE USP_ListadoTipoCuenta
AS 
  SELECT   ID_TIPO_CUENTA, NOM_CUENTA 
  FROM     TIPO_CUENTA
  WHERE    ESTADO = 1
  ORDER BY ID_TIPO_CUENTA DESC
GO
-- EXEC USP_ListadoTipoCuenta

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 7. PROCEDIMIENTOS ALMACENADOS DE LOS TIPOS DE PRESTAMOS BANCARIOS */

CREATE PROCEDURE USP_ListadoTipoPrestamo
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TP_PRESTAMO,
		FECHA_REGISTRO,
		NOM_PRESTAMO

    FROM TIPO_PRESTAMO 
   WHERE ESTADO = 1
    AND (
           ID_TP_PRESTAMO     LIKE '%' + @cTexto + '%'
		OR NOM_PRESTAMO       LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_TP_PRESTAMO DESC
END
GO
-- EXEC USP_ListadoTipoPrestamo

CREATE PROCEDURE USP_ListadoTipoPrestamosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_TP_PRESTAMO,
		FECHA_REGISTRO,
		NOM_PRESTAMO

    FROM TIPO_PRESTAMO 
   WHERE ESTADO = 0
    AND (
           ID_TP_PRESTAMO     LIKE '%' + @cTexto + '%'
		OR NOM_PRESTAMO       LIKE '%' + @cTexto + '%'
       )
	ORDER BY ID_TP_PRESTAMO DESC
END
GO
-- EXEC USP_ListadoTipoPrestamoCaidos

CREATE PROCEDURE USP_GuardarTipoPrestamo
@nOpcion                INT = 0,
@cID_TP_PRESTAMO        INT = 0,
@cNOM_PRESTAMO          VARCHAR(15)

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO TIPO_PRESTAMO(
				ID_TP_PRESTAMO,
				NOM_PRESTAMO,
				ESTADO
			    )
			VALUES 
			   (
				@cID_TP_PRESTAMO,
				@cNOM_PRESTAMO,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE TIPO_PRESTAMO     SET
				NOM_PRESTAMO      = @cNOM_PRESTAMO
			WHERE 
				ID_TP_PRESTAMO    = @cID_TP_PRESTAMO
	END
GO
-- EXEC USP_GuardarTipoPrestamo


CREATE PROCEDURE USP_EliminarTipoPrestamo
@nID_TP_PRESTAMO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_PRESTAMO
    SET    ESTADO = 0
    WHERE  ID_TP_PRESTAMO = @nID_TP_PRESTAMO;
END;
GO
-- EXEC USP_EliminarTipoPrestamo

CREATE PROCEDURE USP_LevantarTipoPrestamo
@nID_TP_PRESTAMO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_PRESTAMO
    SET    ESTADO = 1
    WHERE  ID_TP_PRESTAMO = @nID_TP_PRESTAMO;
END
GO
-- EXEC USP_LevantarTipoPrestamo

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 8. PROCEDIMIENTOS ALMACENADOS DE LOS TIPOS DE PAGOS DE PRESTAMOS BANCARIOS */

CREATE PROCEDURE USP_ListadoTipoPago_Prestamo
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_DIM_TP_PAGO,
		FECHA_REGISTRO,
		TIPO_COBRO

    FROM TIPO_PAGO 
   WHERE ESTADO = 1
    AND (
           ID_DIM_TP_PAGO     LIKE '%' + @cTexto + '%'
		OR TIPO_COBRO         LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_DIM_TP_PAGO DESC
END
GO
-- EXEC USP_ListadoTipoPago_Prestamo

CREATE PROCEDURE USP_ListadoTipoPago_PrestamoCaido
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_DIM_TP_PAGO,
		FECHA_REGISTRO,
		TIPO_COBRO

    FROM TIPO_PAGO 
   WHERE ESTADO = 0
    AND (
           ID_DIM_TP_PAGO     LIKE '%' + @cTexto + '%'
		OR TIPO_COBRO         LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_DIM_TP_PAGO DESC
END
GO
-- EXEC USP_ListadoTipoPago_PrestamoCaido

CREATE PROCEDURE USP_GuardarTipoPago_Prestamo
@nOpcion                INT = 0,
@cID_DIM_TP_PAGO        INT = 0,
@cTIPO_COBRO            VARCHAR(15)

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO TIPO_PAGO(
				TIPO_COBRO,
				ESTADO
			    )
			VALUES 
			   (
				@cTIPO_COBRO,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE TIPO_PAGO
		      SET
				TIPO_COBRO      = @cTIPO_COBRO
			WHERE 
				ID_DIM_TP_PAGO  = @cID_DIM_TP_PAGO
	END
GO
-- EXEC USP_GuardarTipoPago_Prestamo

CREATE PROCEDURE USP_EliminarTipoPago_Prestamo
@nID_DIM_TP_PAGO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_PAGO
    SET    ESTADO = 0
    WHERE  ID_DIM_TP_PAGO = @nID_DIM_TP_PAGO;
END;
GO
-- EXEC USP_EliminarTipoPrestamo

CREATE PROCEDURE USP_LevantarTipoPago_Prestamo
@nID_DIM_TP_PAGO INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE TIPO_PAGO
    SET    ESTADO = 1
    WHERE  ID_DIM_TP_PAGO = @nID_DIM_TP_PAGO;
END
GO
-- EXEC USP_LevantarTipoPago_Prestamo

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 9. PROCEDIMIENTOS ALMACENADOS DE PRESTAMOS */

CREATE PROCEDURE USP_ListadoPrestamos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        O.ID_PRESTAMO,
        O.FECHA_REGISTRO,
		M.NOM_CUENTA,
		E.CODIGO_CUENTA,
		Y.NOM_TARJETA,
		S.CODIGO_TARJETA,
		O.ID_CLIENTE,
		O.ID_CUENTA,
		O.ID_TARJETA_CREDITO,
		O.ID_TP_PRESTAMO,
		O.ID_DIM_TP_PAGO,
		O.MONTO_PRESTADO,
		O.MTCN_PRESTAMO,
		A.NOM_PRESTAMO,
		R.TIPO_COBRO,
		C.NOM_CLIENTE,
		C.APE_PATE_CLIENTE,
		C.APE_MATE_CLIENTE

    FROM PRESTAMO O
    INNER JOIN CLIENTE         C ON O.ID_CLIENTE         = C.ID_CLIENTE
    INNER JOIN CUENTA          E ON O.ID_CUENTA          = E.ID_CUENTA
	INNER JOIN TARJETA_CREDITO S ON O.ID_TARJETA_CREDITO = S.ID_TARJETA_CREDITO
	INNER JOIN TIPO_PRESTAMO   A ON O.ID_TP_PRESTAMO     = A.ID_TP_PRESTAMO
	INNER JOIN TIPO_PAGO       R ON O.ID_DIM_TP_PAGO     = R.ID_DIM_TP_PAGO
	INNER JOIN TIPO_CUENTA     M ON M.ID_TIPO_CUENTA     = E.ID_TIPO_CUENTA
	INNER JOIN TIPO_TARJETA_CREDITO Y ON Y.ID_TP_TARJETA = S.ID_TP_TARJETA
    WHERE O.ESTADO = 1
    AND (
		   C.NOM_CLIENTE       LIKE '%' + @cTexto + '%'
        OR C.APE_PATE_CLIENTE  LIKE '%' + @cTexto + '%'
        OR C.APE_MATE_CLIENTE  LIKE '%' + @cTexto + '%'
        )
	ORDER BY O.ID_PRESTAMO DESC
END
GO
-- EXEC USP_ListadoPrestamos


CREATE PROCEDURE USP_ListadoPrestamosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        O.ID_PRESTAMO,
        O.FECHA_REGISTRO,
		M.NOM_CUENTA,
		E.CODIGO_CUENTA,
		Y.NOM_TARJETA,
		S.CODIGO_TARJETA,
		O.ID_CLIENTE,
		O.ID_CUENTA,
		O.ID_TARJETA_CREDITO,
		O.ID_TP_PRESTAMO,
		O.ID_DIM_TP_PAGO,
		O.MONTO_PRESTADO,
		O.MTCN_PRESTAMO,
		A.NOM_PRESTAMO,
		R.TIPO_COBRO,
		C.NOM_CLIENTE,
		C.APE_PATE_CLIENTE,
		C.APE_MATE_CLIENTE

    FROM PRESTAMO O
    INNER JOIN CLIENTE         C ON O.ID_CLIENTE         = C.ID_CLIENTE
    INNER JOIN CUENTA          E ON O.ID_CUENTA          = E.ID_CUENTA
	INNER JOIN TARJETA_CREDITO S ON O.ID_TARJETA_CREDITO = S.ID_TARJETA_CREDITO
	INNER JOIN TIPO_PRESTAMO   A ON O.ID_TP_PRESTAMO     = A.ID_TP_PRESTAMO
	INNER JOIN TIPO_PAGO       R ON O.ID_DIM_TP_PAGO     = R.ID_DIM_TP_PAGO
	INNER JOIN TIPO_CUENTA     M ON M.ID_TIPO_CUENTA     = E.ID_TIPO_CUENTA
	INNER JOIN TIPO_TARJETA_CREDITO Y ON Y.ID_TP_TARJETA = S.ID_TP_TARJETA
    WHERE O.ESTADO = 0
    AND (
		   C.NOM_CLIENTE       LIKE '%' + @cTexto + '%'
        OR C.APE_PATE_CLIENTE  LIKE '%' + @cTexto + '%'
        OR C.APE_MATE_CLIENTE  LIKE '%' + @cTexto + '%'
        )
	ORDER BY O.ID_PRESTAMO DESC
END
GO
-- EXEC USP_ListadoPrestamosCaidos

CREATE PROCEDURE USP_GuardarPrestamo
@nOpcion                INT = 0,
@cID_PRESTAMO           INT = 0,
@cID_CLIENTE            INT = 0,
@cID_CUENTA             INT = 0,
@cID_TARJETA_CREDITO    INT = 0,
@cID_TP_PRESTAMO        INT = 0,
@cID_DIM_TP_PAGO        INT = 0,
@cMONTO_PRESTADO        INT = 0

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO PRESTAMO(
				ID_CLIENTE,
				ID_CUENTA,
				ID_TARJETA_CREDITO,
				ID_TP_PRESTAMO,
				ID_DIM_TP_PAGO,
				MONTO_PRESTADO,
				ESTADO
			    )
			VALUES 
			   (
				@cID_CLIENTE,
				@cID_CUENTA,
				@cID_TARJETA_CREDITO,
				@cID_TP_PRESTAMO,
				@cID_DIM_TP_PAGO,
				@cMONTO_PRESTADO,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE PRESTAMO         SET
				ID_CLIENTE         = @cID_CLIENTE,
				ID_CUENTA          = @cID_CUENTA,
				ID_TARJETA_CREDITO = @cID_TARJETA_CREDITO,
				ID_TP_PRESTAMO     = @cID_TP_PRESTAMO,
				MONTO_PRESTADO     = @cMONTO_PRESTADO
			WHERE 
				ID_PRESTAMO        = @cID_PRESTAMO
	END
GO

CREATE PROCEDURE USP_EliminarPrestamo
@nID_PRESTAMO INT = 0
AS
BEGIN
   
    UPDATE PRESTAMO
    SET    ESTADO = 0
    WHERE  ID_PRESTAMO = @nID_PRESTAMO;
END
GO

CREATE PROCEDURE USP_LevantarPrestamo
@nID_PRESTAMO INT = 0
AS
BEGIN
    
    UPDATE PRESTAMO
    SET    ESTADO = 1
    WHERE  ID_PRESTAMO = @nID_PRESTAMO;
END
GO

-------------------------------------------------------------------
-- PANELES DE DESICIÓN DE PRESTAMOS
-------------------------------------------------------------------

CREATE PROCEDURE USP_ListadoPrestamo_Cliente
AS
BEGIN
    SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE 
    FROM     CLIENTE
	WHERE    ESTADO = 1
    ORDER BY ID_CLIENTE DESC
END
GO
-- EXEC USP_ListadoPrestamo_Cliente

CREATE PROCEDURE USP_ListadoPrestamo_Cuenta
AS 
  SELECT   B.ID_CUENTA, B.CODIGO_CUENTA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE
  FROM     CUENTA B, CLIENTE C 
  WHERE    C.ID_CLIENTE = B.ID_CLIENTE AND B.ESTADO = 1 AND C.ESTADO = 1
  ORDER BY B.ID_CUENTA DESC
GO
-- EXEC USP_ListadoPrestamo_Cuenta

CREATE PROCEDURE USP_ListadoPrestamo_TarjetaCredito
AS 
  SELECT   A.ID_TARJETA_CREDITO, A.CODIGO_TARJETA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE
  FROM     TARJETA_CREDITO A, CLIENTE C 
  WHERE    A.ID_CLIENTE = C.ID_CLIENTE AND A.ESTADO = 1 AND C.ESTADO = 1
  ORDER BY A.ID_TARJETA_CREDITO DESC
GO
-- EXEC USP_ListadoPrestamo_TarjetaCredito

CREATE PROCEDURE USP_ListadoPrestamo_TipoPrestamo
AS 
  SELECT   ID_TP_PRESTAMO, NOM_PRESTAMO
  FROM     TIPO_PRESTAMO 
  WHERE    ESTADO = 1
  ORDER BY ID_TP_PRESTAMO DESC
GO
-- EXEC USP_ListadoPrestamo_TipoPrestamo

CREATE PROCEDURE USP_ListadoPrestamo_TipoPago
AS 
  SELECT   ID_DIM_TP_PAGO, TIPO_COBRO
  FROM     TIPO_PAGO
  WHERE    ESTADO = 1
  ORDER BY ID_DIM_TP_PAGO DESC
GO
-- EXEC USP_ListadoPrestamo_TipoPago

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 10. PROCEDIMIENTOS ALMACENADOS DE CARGOS DE EMPLEADOS BANCARIOS */

CREATE PROCEDURE USP_ListadoCargoEmpleado
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_CARGO_EM,
		FECHA_REGISTRO,
		NOM_CARGO

    FROM CARGO_EMPLEADO 
   WHERE ESTADO = 1
    AND (
         NOM_CARGO     LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_CARGO_EM DESC
END
GO
-- EXEC USP_ListadoCargoEmpleado


CREATE PROCEDURE USP_ListadoCargoEmpleadosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
        ID_CARGO_EM,
		FECHA_REGISTRO,
		NOM_CARGO

    FROM CARGO_EMPLEADO 
   WHERE ESTADO = 0
    AND (
         NOM_CARGO     LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_CARGO_EM DESC
END
GO
-- EXEC USP_ListadoCargoEmpleadosCaidos

CREATE PROCEDURE USP_GuardarCargoEmpleado
@nOpcion                INT = 0,
@cID_CARGO_EM           INT = 0,
@cNOM_CARGO             VARCHAR(35)

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO CARGO_EMPLEADO(
				NOM_CARGO,
				ESTADO
			    )
			VALUES 
			   (
				@cNOM_CARGO,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE CARGO_EMPLEADO     SET
				NOM_CARGO      = @cNOM_CARGO
			WHERE 
				ID_CARGO_EM    = @cID_CARGO_EM
	END
GO
-- EXEC USP_GuardarCargoEmpleado


CREATE PROCEDURE USP_EliminarCargoEmpleado
@nID_CARGO_EM        INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE CARGO_EMPLEADO
    SET    ESTADO = 0
    WHERE  ID_CARGO_EM    = @nID_CARGO_EM;
END
GO
-- EXEC USP_EliminarCargoEmpleado

CREATE PROCEDURE USP_LevantarCargoEmpleado
@nID_CARGO_EM        INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE CARGO_EMPLEADO
    SET    ESTADO = 1
    WHERE  ID_CARGO_EM    = @nID_CARGO_EM;
END
GO
-- EXEC USP_LevantarCargoEmpleado

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 11. PROCEDIMIENTOS ALMACENADOS DE USUARIOS DE EMPLEADOS BANCARIOS */

CREATE PROCEDURE USP_ListadoUsuarios
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
	    ID_USER,
        FECHA_REGISTRO,
		USUARIO,
		CONTRASEÑA,
		ADMIN,
		PRESTAMOS,
		CUENTAS,
		TARJETAS

    FROM USUARIO_EM 
   WHERE ESTADO = 1
    AND (
           USUARIO      LIKE '%' + @cTexto + '%'
		OR CONTRASEÑA   LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_USER DESC
END
GO
-- EXEC USP_ListadoUsuarios

CREATE PROCEDURE USP_ListadoUsuariosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
	    ID_USER,
        FECHA_REGISTRO,
		USUARIO,
		CONTRASEÑA,
		ADMIN,
		PRESTAMOS,
		CUENTAS,
		TARJETAS

    FROM USUARIO_EM 
   WHERE ESTADO = 0
    AND (
           USUARIO      LIKE '%' + @cTexto + '%'
		OR CONTRASEÑA   LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_USER DESC
END
GO
-- EXEC USP_ListadoUsuariosCaidos

CREATE PROCEDURE USP_GuardarUsuarios
@nOpcion                INT = 0,
@cID_USER               INT = 0,
@cUSUARIO               VARCHAR(15),
@cCONTRASEÑA            VARCHAR(15),
@cADMIN                 BIT,
@cPRESTAMOS             BIT,
@cCUENTAS               BIT,
@cTARJETAS              BIT

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO 
		        USUARIO_EM(
				USUARIO,
				CONTRASEÑA,
				ADMIN,
				PRESTAMOS,
				CUENTAS,
				TARJETAS,
				ESTADO
			    )
			VALUES 
			   (
				@cUSUARIO,
				@cCONTRASEÑA,
				@cADMIN,
				@cPRESTAMOS,
				@cCUENTAS,
				@cTARJETAS,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE USUARIO_EM     SET
				USUARIO      = @cUSUARIO,
				CONTRASEÑA   = @cCONTRASEÑA,
				ADMIN        = @cADMIN,
				PRESTAMOS    = @cPRESTAMOS,
				CUENTAS      = @cCUENTAS,
				TARJETAS     = @cTARJETAS
			WHERE 
				ID_USER      = @cID_USER
	END
GO
-- EXEC USP_GuardarUsuarios


CREATE PROCEDURE USP_EliminarUsuarios
@nID_USER INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE USUARIO_EM
    SET    ESTADO = 0
    WHERE  ID_USER        = @nID_USER;
END;
GO
-- EXEC USP_EliminarUsuarios

CREATE PROCEDURE USP_LevantarUsuarios
@nID_USER INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE USUARIO_EM
    SET    ESTADO = 1
    WHERE  ID_USER        = @nID_USER;
END
GO
-- EXEC USP_LevantarUsuarios

-------------------------------------------------------------------
-- PARA EL LOGEO DEL SISTEMA -- ¡PRECAUTION! ... NO TOCAR!!!!
-------------------------------------------------------------------
CREATE PROCEDURE USP_LoginUS
    @USUARIO VARCHAR(50),
    @CONTRASEÑA VARCHAR(50) -- Suponiendo que la contraseña está almacenada como texto en la base de datos
AS
BEGIN
    SELECT *
    FROM  V_EMPLEADO
    WHERE USUARIO = @USUARIO AND CONTRASEÑA = @CONTRASEÑA
	      AND ESTADO_US = 1 -- Debes aplicar hash a la contraseña antes de almacenarla y compararla
END
GO
-- EXEC USP_LoginUS

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 12. PROCEDIMIENTO ALMACENADO DE SUCURSALES DEL BANCO */

CREATE PROCEDURE USP_ListadoSucursales
@cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
	    ID_SUCURSAL,
        FECHA_REGISTRO,
		DIRECCION

    FROM SUCURSAL 
   WHERE ESTADO = 1
    AND (
         DIRECCION      LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_SUCURSAL DESC
END
GO
-- EXEC USP_ListadoSucursales

CREATE PROCEDURE USP_ListadoSucursalesCaidas
@cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
	    ID_SUCURSAL,
        FECHA_REGISTRO,
		DIRECCION

    FROM SUCURSAL 
    WHERE ESTADO = 0
    AND (
         DIRECCION      LIKE '%' + @cTexto + '%'
        )
	ORDER BY ID_SUCURSAL DESC
END
GO
-- EXEC USP_ListadoSucursalesCaidas

CREATE PROC USP_GuardarSucursales
@nOpcion                INT = 0,
@cID_SUCURSAL           INT = 0,
@cDIRECCION             VARCHAR(80)

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO 
		        SUCURSAL(
				DIRECCION,
				ESTADO
			    )
			VALUES 
			   (
				@cDIRECCION,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE SUCURSAL     SET
				DIRECCION    = @cDIRECCION
			WHERE 
				ID_SUCURSAL  = @cID_SUCURSAL
	END
GO
-- EXEC USP_GuardarSucursales

CREATE PROCEDURE USP_EliminarSucursales
@nID_SUCURSAL INT = 0
AS
BEGIN
    -- Actualizar el estado de la sucursal a 0
    UPDATE SUCURSAL
    SET    ESTADO = 0
    WHERE  ID_SUCURSAL     = @nID_SUCURSAL
END;
GO
-- EXEC USP_EliminarSucursales


CREATE PROCEDURE USP_LevantarSucursales
@nID_SUCURSAL INT = 0
AS
BEGIN
    -- Actualizar el estado de la sucursal a 0
    UPDATE SUCURSAL
    SET    ESTADO = 1
    WHERE  ID_SUCURSAL     = @nID_SUCURSAL
END
GO
-- EXEC USP_LevantarSucursales
-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 13. PROCEDIMIENTOS ALMACENADOS DE EMPLEADOS BANCARIOS */
CREATE PROCEDURE USP_ListadoEmpleado
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
    Z.ID_EM,
	Z.ID_CARGO_EM,
	Z.ID_USER,
	I.ID_SUCURSAL,
	Z.FECHA_REGISTRO,
	Z.NOM_EMPLEADO,
	Z.APE_PATE,
	Z.APE_MATE,
	Z.DIRECCION,
	Z.DNI_EM,
	Z.SUELDO,
	O.NOM_CARGO,
	V.USUARIO,
	I.DIRECCION

    FROM EMPLEADO Z
    INNER JOIN CARGO_EMPLEADO  O ON O.ID_CARGO_EM  = Z.ID_CARGO_EM
    INNER JOIN USUARIO_EM      V ON V.ID_USER      = Z.ID_USER
	INNER JOIN SUCURSAL        I ON I.ID_SUCURSAL  = Z.ID_SUCURSAL
    WHERE Z.ESTADO = 1
    AND (
		  Z.NOM_EMPLEADO      LIKE '%' + @cTexto + '%' OR
		  Z.APE_PATE          LIKE '%' + @cTexto + '%' OR
		  Z.APE_MATE          LIKE '%' + @cTexto + '%' 
        )
	ORDER BY Z.ID_EM DESC
END
GO
-- EXEC USP_ListadoEmpleado

CREATE PROCEDURE USP_ListadoEmpleadosCaidos
    @cTexto VARCHAR(150) = ''
AS
BEGIN
    SELECT
    Z.ID_EM,
	Z.ID_CARGO_EM,
	Z.ID_USER,
	I.ID_SUCURSAL,
	Z.FECHA_REGISTRO,
	Z.NOM_EMPLEADO,
	Z.APE_PATE,
	Z.APE_MATE,
	Z.DIRECCION,
	Z.DNI_EM,
	Z.SUELDO,
	O.NOM_CARGO,
	V.USUARIO,
	I.DIRECCION

    FROM EMPLEADO Z
    INNER JOIN CARGO_EMPLEADO  O ON O.ID_CARGO_EM  = Z.ID_CARGO_EM
    INNER JOIN USUARIO_EM      V ON V.ID_USER      = Z.ID_USER
	INNER JOIN SUCURSAL        I ON I.ID_SUCURSAL    = Z.ID_SUCURSAL
    WHERE Z.ESTADO = 0
    AND (
		  Z.NOM_EMPLEADO      LIKE '%' + @cTexto + '%' OR
		  Z.APE_PATE          LIKE '%' + @cTexto + '%' OR
		  Z.APE_MATE          LIKE '%' + @cTexto + '%' 
        )
    ORDER BY Z.ID_EM DESC
END
GO
-- EXEC USP_ListadoEmpleadosCaidos

CREATE PROCEDURE USP_GuardarEmpleado
@nOpcion                INT = 0,
@cID_EM                 INT = 0,
@cID_CARGO_EM           INT = 0,
@cID_USER               INT = 0,
@cID_SUCURSAL           INT = 0,
@cNOM_EMPLEADO          VARCHAR(20),
@cAPE_PATE              VARCHAR(12),
@cAPE_MATE              VARCHAR(12),
@cDIRECCION             VARCHAR(25),
@cDNI_EM                VARCHAR(10),
@cSUELDO                INT = 0

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO EMPLEADO(
				ID_CARGO_EM,
				ID_USER,
				ID_SUCURSAL,
				NOM_EMPLEADO,
				APE_PATE,
				APE_MATE,
				DIRECCION,
				DNI_EM,
				SUELDO,
				ESTADO
			    )
			VALUES 
			   (
				@cID_CARGO_EM,
				@cID_USER,
				@cID_SUCURSAL,
				@cNOM_EMPLEADO,
				@cAPE_PATE,
				@cAPE_MATE,
				@cDIRECCION,
				@cDNI_EM,
				@cSUELDO,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE EMPLEADO         SET
				ID_CARGO_EM  = @cID_CARGO_EM,
				ID_USER      = @cID_USER,
				ID_SUCURSAL  = @cID_SUCURSAL,
				NOM_EMPLEADO = @cNOM_EMPLEADO,
				APE_PATE     = @cAPE_PATE,
				APE_MATE     = @cAPE_MATE,
				DIRECCION    = @cDIRECCION,
				DNI_EM       = @cDNI_EM,
				SUELDO       = @cSUELDO
			WHERE 
				ID_EM        = @cID_EM
	END
GO


CREATE PROCEDURE USP_EliminarEmpleado
@nID_EM INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE EMPLEADO
    SET    ESTADO = 0
    WHERE  ID_EM  = @nID_EM;

	UPDATE V_EMPLEADO
	SET    ESTADO_US = 0
	WHERE  ID_EM     = @nID_EM
END
GO

CREATE PROCEDURE USP_LevantarEmpleado
@nID_EM INT = 0
AS
BEGIN
    -- Actualizar el estado del CLIENTE a 0
    UPDATE EMPLEADO
    SET    ESTADO = 1
    WHERE  ID_EM  = @nID_EM;

	UPDATE V_EMPLEADO
	SET    ESTADO_US = 1
	WHERE  ID_EM     = @nID_EM
END
GO

-------------------------------------------------------------------
-- PANELES DE DESICIÓN EMPLEADO
-------------------------------------------------------------------
CREATE PROCEDURE USP_ListadoEmpleado_Cargo
AS
BEGIN
    SELECT   ID_CARGO_EM, NOM_CARGO 
    FROM     CARGO_EMPLEADO
	WHERE    ESTADO = 1
    ORDER BY ID_CARGO_EM DESC
END
GO
-- EXEC USP_ListadoEmpleado_Cargo

CREATE PROCEDURE USP_ListadoEmpleado_Usuario
AS 
  SELECT   ID_USER, USUARIO
  FROM     USUARIO_EM
  WHERE    ESTADO = 1
  ORDER BY ID_USER DESC
GO
-- EXEC USP_ListadoEmpleado_Usuario

CREATE PROC USP_ListadoEmpleado_Sucursal
AS
  SELECT   ID_SUCURSAL, DIRECCION
  FROM     SUCURSAL
  WHERE    ESTADO = 1
  ORDER BY ID_SUCURSAL DESC
GO
-- EXEC USP_ListadoEmpleado_Sucursal

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 14. PROCEDIMIENTOS ALMACENADOS DE ABONOS BANCARIOS */
CREATE PROCEDURE USP_ListadoMovimientoAbono
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_ABONO,
	B.ID_CUENTA,
	C.ID_PRESTAMO,
	D.ID_CLIENTE,
	E.ID_EM,
	F.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	D.NOM_CLIENTE,
	D.APE_PATE_CLIENTE,
	D.APE_MATE_CLIENTE,
	F.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	E.NOM_EMPLEADO,
	E.APE_PATE,
	E.APE_MATE,
	C.MONTO_PRESTADO

  FROM MOVIMIENTO_ABONO A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
    INNER JOIN PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO
	INNER JOIN CLIENTE  D ON D.ID_CLIENTE  = A.ID_CLIENTE
	INNER JOIN EMPLEADO E ON E.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA G   ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE H  ON H.ID_TP_PERSONA = D.ID_TP_PERSONA
	INNER JOIN TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO
	INNER JOIN TIPO_PAGO J     ON J.ID_DIM_TP_PAGO = C.ID_DIM_TP_PAGO
	INNER JOIN CARGO_EMPLEADO K ON K.ID_CARGO_EM = E.ID_CARGO_EM
  WHERE A.ESTADO = 1
    AND (
		  D.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  D.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  D.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_ABONO DESC
END
GO
-- EXEC USP_ListadoMovimientoAbono


CREATE PROCEDURE USP_ListadoMovimientoAbonoCaido
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_ABONO,
	B.ID_CUENTA,
	C.ID_PRESTAMO,
	D.ID_CLIENTE,
	E.ID_EM,
	F.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	D.NOM_CLIENTE,
	D.APE_PATE_CLIENTE,
	D.APE_MATE_CLIENTE,
	F.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	E.NOM_EMPLEADO,
	E.APE_PATE,
	E.APE_MATE,
	C.MONTO_PRESTADO

  FROM MOVIMIENTO_ABONO A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
    INNER JOIN PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO
	INNER JOIN CLIENTE  D ON D.ID_CLIENTE  = B.ID_CLIENTE
	INNER JOIN EMPLEADO E ON E.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA G   ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE H  ON H.ID_TP_PERSONA = D.ID_TP_PERSONA
	INNER JOIN TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO
	INNER JOIN TIPO_PAGO J     ON J.ID_DIM_TP_PAGO = C.ID_DIM_TP_PAGO
	INNER JOIN CARGO_EMPLEADO K ON K.ID_CARGO_EM = E.ID_CARGO_EM
  WHERE A.ESTADO = 0
    AND (
		  D.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  D.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  D.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_ABONO DESC
END
GO
-- EXEC USP_ListadoMovimientoAbonoCaido


CREATE PROCEDURE USP_ListadoMovimientoAbonoPri
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_ABONO,
	B.ID_CUENTA,
	C.ID_PRESTAMO,
	D.ID_CLIENTE,
	E.ID_EM,
	F.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	D.NOM_CLIENTE,
	D.APE_PATE_CLIENTE,
	D.APE_MATE_CLIENTE,
	F.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	E.NOM_EMPLEADO,
	E.APE_PATE,
	E.APE_MATE,
	C.MONTO_PRESTADO

  FROM MOVIMIENTO_ABONO A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
    INNER JOIN PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO
	INNER JOIN CLIENTE  D ON D.ID_CLIENTE  = C.ID_CLIENTE
	INNER JOIN EMPLEADO E ON E.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA G   ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE H  ON H.ID_TP_PERSONA  = D.ID_TP_PERSONA
	INNER JOIN TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO
	INNER JOIN TIPO_PAGO J     ON J.ID_DIM_TP_PAGO = C.ID_DIM_TP_PAGO
	INNER JOIN CARGO_EMPLEADO K ON K.ID_CARGO_EM   = E.ID_CARGO_EM
  WHERE A.ESTADO = 1
    AND (
		  D.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  D.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  D.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_ABONO DESC
END
GO
-- EXEC USP_ListadoMovimientoAbonoPri


CREATE PROCEDURE USP_GuardarMovimientoAbono
@nOpcion                INT = 0,
@cID_MV_ABONO           INT = 0,
@cID_CUENTA             INT = 0,
@cID_PRESTAMO           INT = 0,
@cID_CLIENTE            INT = 0,
@cID_EM                 INT = 0,
@cID_SUCURSAL           INT = 0,
@cMONTO_SALIDA          DECIMAL = 0.00

AS
  IF @nOpcion = 1 -- Nuevo Registro
    BEGIN
		INSERT INTO MOVIMIENTO_ABONO(
				ID_CUENTA,
				ID_PRESTAMO,
				ID_CLIENTE,
				ID_EM,
				ID_SUCURSAL,
				MONTO_SALIDA,
				ESTADO
			    )
			VALUES 
			   (
				@cID_CUENTA,
				@cID_PRESTAMO,
				@cID_CLIENTE,
				@cID_EM,
				@cID_SUCURSAL,
				@cMONTO_SALIDA,
				1
			   )
	END
	ELSE -- Actualizar registro
	BEGIN
		 UPDATE MOVIMIENTO_ABONO SET
				ID_CUENTA    = @cID_CUENTA,
				ID_PRESTAMO  = @cID_PRESTAMO,
				ID_CLIENTE   = @cID_CLIENTE,
				ID_EM        = @cID_EM,
				ID_SUCURSAL  = @cID_SUCURSAL,
				MONTO_SALIDA = @cMONTO_SALIDA
			WHERE 
				ID_MV_ABONO  = @cID_MV_ABONO
	END
GO
-- EXEC USP_GuardarMovimientoAbono

CREATE PROCEDURE USP_EliminarMovimientoAbono
@nID_MV_ABONO INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO ABONO a 0
    UPDATE MOVIMIENTO_ABONO
    SET    ESTADO = 0
    WHERE  ID_MV_ABONO  = @nID_MV_ABONO
END;
GO
-- EXEC USP_EliminarMovimientoAbono

CREATE PROCEDURE USP_LevantarMovimientoAbono
@nID_MV_ABONO INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO ABONO a 0
    UPDATE MOVIMIENTO_ABONO
    SET    ESTADO = 1
    WHERE  ID_MV_ABONO  = @nID_MV_ABONO
END
GO
-- EXEC USP_LevantarMovimientoAbono

-------------------------------------------------------------------
-- PANELES DE DESICIÓN DE MOVIMIENTOS DE ABONO
-------------------------------------------------------------------
CREATE PROCEDURE USP_ListadoMovimientoAbono_Cuenta
AS
BEGIN
    SELECT   A.ID_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, A.CODIGO_CUENTA 
    FROM     CUENTA A, CLIENTE B
	WHERE    A.ID_CLIENTE = B.ID_CLIENTE AND B.ESTADO = 1 AND A.ESTADO = 1
    ORDER BY A.ID_CUENTA DESC
END
GO
-- EXEC USP_ListadoMovimientoAbono_Cuenta

CREATE PROCEDURE USP_ListadoMovimientoAbono_Prestamo
AS 
  SELECT   A.ID_PRESTAMO, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, A.MONTO_PRESTADO, A.MTCN_PRESTAMO
  FROM     PRESTAMO A, CLIENTE B
  WHERE    B.ESTADO = 1 AND A.ESTADO = 1 AND
           A.ID_CLIENTE = B.ID_CLIENTE
  ORDER BY A.ID_PRESTAMO DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Prestamo

CREATE PROC USP_ListadoMovimientoAbono_Cliente
AS
  SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE
  FROM     CLIENTE
  WHERE    ESTADO = 1
  ORDER BY ID_CLIENTE DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Cliente

CREATE PROC USP_ListadoMovimientoAbono_Empleado
AS
  SELECT   ID_EM, NOM_EMPLEADO, APE_PATE, APE_MATE
  FROM     EMPLEADO
  WHERE    ESTADO = 1
  ORDER BY ID_EM DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Empleado

CREATE PROC USP_ListadoMovimientoAbono_Sucursal
AS
  SELECT   ID_SUCURSAL, DIRECCION
  FROM     SUCURSAL
  WHERE    ESTADO = 1
  ORDER BY ID_SUCURSAL DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Sucursal

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 15. PROCEDIMIENTOS ALMACENADOS DE MOVIMIENTOS DE CUENTAS */
CREATE PROCEDURE USP_ListadoMovimientoCuentas
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_CUENTA,
	B.ID_CUENTA,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_ENTRADA,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_CUENTA A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
	INNER JOIN CLIENTE  C ON C.ID_CLIENTE  = A.ID_CLIENTE
	INNER JOIN EMPLEADO D ON D.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA
	INNER JOIN CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM
  WHERE A.ESTADO = 1
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_CUENTA DESC
END
GO
-- EXEC USP_ListadoMovimientoCuentas


CREATE PROCEDURE USP_ListadoMovimientoCuentasCaidas
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_CUENTA,
	B.ID_CUENTA,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_ENTRADA,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_CUENTA A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
	INNER JOIN CLIENTE  C ON C.ID_CLIENTE  = B.ID_CLIENTE
	INNER JOIN EMPLEADO D ON D.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA
	INNER JOIN CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM
  WHERE A.ESTADO = 0
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_CUENTA DESC
END
GO
-- EXEC USP_ListadoMovimientoCuentasCaidas

CREATE PROCEDURE USP_ListadoMovimientoCuentasPri
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_CUENTA,
	B.ID_CUENTA,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_ENTRADA,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_CUENTA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_CUENTA A
    INNER JOIN CUENTA   B ON B.ID_CUENTA   = A.ID_CUENTA
	INNER JOIN CLIENTE  C ON C.ID_CLIENTE  = B.ID_CLIENTE
	INNER JOIN EMPLEADO D ON D.ID_EM       = A.ID_EM
	INNER JOIN SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL
	INNER JOIN TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA
	INNER JOIN TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA
	INNER JOIN CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM
  WHERE A.ESTADO = 1
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_CUENTA DESC
END
GO
-- EXEC USP_ListadoMovimientoCuentasPri

CREATE PROCEDURE USP_GuardarMovimientoCuenta
@nOpcion                INT = 0,
@cID_MV_CUENTA          INT = 0,
@cID_CUENTA             INT = 0,
@cID_CLIENTE            INT = 0,
@cID_EM                 INT = 0,
@cID_SUCURSAL           INT = 0,
@cMONTO_ENTRADA         DECIMAL = 0.00,
@cMONTO_SALIDA          DECIMAL = 0.00
AS
BEGIN
  DECLARE @nTipoCuenta VARCHAR(50)
  DECLARE @nSaldoActual DECIMAL

  -- Obtener el tipo de cuenta de la tabla CUENTA
  SELECT @nTipoCuenta = TIPO_CUENTA.NOM_CUENTA
  FROM CUENTA
  INNER JOIN TIPO_CUENTA ON CUENTA.ID_TIPO_CUENTA = TIPO_CUENTA.ID_TIPO_CUENTA
  WHERE CUENTA.ID_CUENTA = @cID_CUENTA

  -- Verificar si la cuenta es de tipo "AHORRO"
  IF @nTipoCuenta = 'AHORRO'
  BEGIN
    -- Obtener el saldo actual de la cuenta
    SELECT @nSaldoActual = SALDO_ACTUAL
    FROM CUENTA
    WHERE ID_CUENTA = @cID_CUENTA

    -- Verificar si el monto de salida hará que el saldo disponible sea menor que cero
    IF (@nSaldoActual - @cMONTO_SALIDA) < 0
    BEGIN
      RAISERROR('El saldo de la cuenta de ahorro no puede ser negativo.', 16, 1)
      RETURN
    END
  END
  

  IF @nOpcion = 1 -- Nuevo Registro
  BEGIN
    INSERT INTO MOVIMIENTO_CUENTA(
      ID_CUENTA,
      ID_CLIENTE,
      ID_EM,
      ID_SUCURSAL,
      MONTO_ENTRADA,
      MONTO_SALIDA,
      ESTADO
    )
    VALUES 
    (
      @cID_CUENTA,
      @cID_CLIENTE,
      @cID_EM,
      @cID_SUCURSAL,
      @cMONTO_ENTRADA,
      @cMONTO_SALIDA,
      1
    )
  END
  ELSE -- Actualizar registro
  BEGIN
    UPDATE MOVIMIENTO_CUENTA SET
      ID_CUENTA     = @cID_CUENTA,
      ID_CLIENTE    = @cID_CLIENTE,
      ID_EM         = @cID_EM,
      ID_SUCURSAL   = @cID_SUCURSAL,
      MONTO_ENTRADA = @cMONTO_ENTRADA,
      MONTO_SALIDA  = @cMONTO_SALIDA
    WHERE 
      ID_MV_CUENTA  = @cID_MV_CUENTA
  END
END
GO
-- EXEC USP_GuardarMovimientoAbono

CREATE PROCEDURE USP_EliminarMovimientoCuenta
@nID_MV_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO ABONO a 0
    UPDATE MOVIMIENTO_CUENTA
    SET    ESTADO = 0
    WHERE  ID_MV_CUENTA  = @nID_MV_CUENTA
END
GO

CREATE PROCEDURE USP_LevantarMovimientoCuenta
@nID_MV_CUENTA INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO ABONO a 0
    UPDATE MOVIMIENTO_CUENTA
    SET    ESTADO = 1
    WHERE  ID_MV_CUENTA  = @nID_MV_CUENTA
END
GO

-------------------------------------------------------------------
-- PANELES DE DESICIÓN DE MOVIMIENTOS DE CUENTAS
-------------------------------------------------------------------
CREATE PROCEDURE USP_ListadoMovimientoCuenta_Cuenta
AS
BEGIN
    SELECT     A.ID_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, A.CODIGO_CUENTA
    FROM       CUENTA A
	INNER JOIN CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE
	WHERE    A.ESTADO = 1 AND B.ESTADO = 1
    ORDER BY A.ID_CUENTA DESC
END
GO
-- EXEC USP_ListadoMovimientoAbono_Cuenta

CREATE PROC USP_ListadoMovimientoCuenta_Cliente
AS
  SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE
  FROM     CLIENTE
  WHERE    ESTADO = 1
  ORDER BY ID_CLIENTE DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Cliente

CREATE PROC USP_ListadoMovimientoCuenta_Empleado
AS
  SELECT   ID_EM, NOM_EMPLEADO, APE_PATE, APE_MATE
  FROM     EMPLEADO
  WHERE    ESTADO = 1
  ORDER BY ID_EM DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Empleado

CREATE PROC USP_ListadoMovimientoCuenta_Sucursal
AS
  SELECT   ID_SUCURSAL, DIRECCION
  FROM     SUCURSAL
  WHERE    ESTADO = 1
  ORDER BY ID_SUCURSAL DESC
GO
-- EXEC USP_ListadoMovimientoAbono_Sucursal

-------------------------------------------------------------------
--
-------------------------------------------------------------------

/* 16. PROCEDIMIENTOS ALMACENADOS DE MOVIMIENTOS DE TARJETAS */
CREATE PROCEDURE USP_ListadoMovimientoTarjetas
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_TARJETA,
	B.ID_TARJETA_CREDITO,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_TARJETA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_TARJETA            A
    INNER JOIN TARJETA_CREDITO      B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO
	INNER JOIN TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA      = B.ID_TP_TARJETA
	INNER JOIN CLIENTE              C ON C.ID_CLIENTE         = A.ID_CLIENTE
	INNER JOIN TIPO_CLIENTE         G ON G.ID_TP_PERSONA      = C.ID_TP_PERSONA
	INNER JOIN EMPLEADO             D ON D.ID_EM              = A.ID_EM
	INNER JOIN SUCURSAL             E ON E.ID_SUCURSAL        = A.ID_SUCURSAL
	INNER JOIN CARGO_EMPLEADO       H ON H.ID_CARGO_EM        = D.ID_CARGO_EM
  WHERE A.ESTADO = 1 
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_TARJETA DESC
END
GO
-- EXEC USP_ListadoMovimientoTarjetas


CREATE PROCEDURE USP_ListadoMovimientoTarjetasCaidas
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_TARJETA,
	B.ID_TARJETA_CREDITO,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_TARJETA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_TARJETA            A
    INNER JOIN TARJETA_CREDITO      B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO
	INNER JOIN TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA      = B.ID_TP_TARJETA
	INNER JOIN CLIENTE              C ON C.ID_CLIENTE         = B.ID_CLIENTE
	INNER JOIN TIPO_CLIENTE         G ON G.ID_TP_PERSONA      = C.ID_TP_PERSONA
	INNER JOIN EMPLEADO             D ON D.ID_EM              = A.ID_EM
	INNER JOIN SUCURSAL             E ON E.ID_SUCURSAL        = A.ID_SUCURSAL
	INNER JOIN CARGO_EMPLEADO       H ON H.ID_CARGO_EM        = D.ID_CARGO_EM
  WHERE A.ESTADO = 0 
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_TARJETA DESC
END
GO
-- EXEC USP_ListadoMovimientoTarjetasCaidas

CREATE PROCEDURE USP_ListadoMovimientoTarjetasPri
@cTexto VARCHAR(150) = ''
AS
BEGIN
  SELECT
    A.ID_MV_TARJETA,
	B.ID_TARJETA_CREDITO,
	C.ID_CLIENTE,
	D.ID_EM,
	E.ID_SUCURSAL,
	A.FECHA_REGISTRO,
	A.MONTO_SALIDA,
	C.NOM_CLIENTE,
	C.APE_PATE_CLIENTE,
	C.APE_MATE_CLIENTE,
	E.DIRECCION AS SUCURSAL,
	B.CODIGO_TARJETA,
	D.NOM_EMPLEADO,
	D.APE_PATE,
	D.APE_MATE

 FROM MOVIMIENTO_TARJETA            A
    INNER JOIN TARJETA_CREDITO      B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO
	INNER JOIN TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA      = B.ID_TP_TARJETA
	INNER JOIN CLIENTE              C ON C.ID_CLIENTE         = B.ID_CLIENTE
	INNER JOIN TIPO_CLIENTE         G ON G.ID_TP_PERSONA      = C.ID_TP_PERSONA
	INNER JOIN EMPLEADO             D ON D.ID_EM              = A.ID_EM
	INNER JOIN SUCURSAL             E ON E.ID_SUCURSAL        = A.ID_SUCURSAL
	INNER JOIN CARGO_EMPLEADO       H ON H.ID_CARGO_EM        = D.ID_CARGO_EM
  WHERE A.ESTADO = 1 
    AND (
		  C.NOM_CLIENTE      LIKE '%' + @cTexto + '%' OR
		  C.APE_PATE_CLIENTE LIKE '%' + @cTexto + '%' OR
		  C.APE_MATE_CLIENTE LIKE '%' + @cTexto + '%' 
        )
	ORDER BY A.ID_MV_TARJETA DESC
END
GO
-- EXEC USP_ListadoMovimientoTarjetasPri

CREATE PROCEDURE USP_GuardarMovimientoTarjetas
@nOpcion                INT = 0,
@cID_MV_TARJETA         INT = 0,
@cID_TARJETA_CREDITO    INT = 0,
@cID_SUCURSAL           INT = 0,
@cID_CLIENTE            INT = 0,
@cID_EM                 INT = 0,
@cMONTO_SALIDA          DECIMAL = 0.00
AS
BEGIN
  DECLARE @nSaldoActual DECIMAL
  
  -- Obtener el saldo actual de la tarjeta de crédito
  SELECT @nSaldoActual = SALDO_DISPONIBLE
  FROM TARJETA_CREDITO
  WHERE ID_TARJETA_CREDITO = @cID_TARJETA_CREDITO

  -- Verificar si el monto de salida no causa un saldo negativo
  IF (@nSaldoActual - @cMONTO_SALIDA) < 0
  BEGIN
    RAISERROR('El monto de salida excede el saldo disponible en la tarjeta de crédito.', 16, 1)
    RETURN
  END

  IF @nOpcion = 1 -- Nuevo Registro
  BEGIN
    INSERT INTO MOVIMIENTO_TARJETA(
      ID_TARJETA_CREDITO,
      ID_SUCURSAL,
      ID_CLIENTE,
      ID_EM,
      MONTO_SALIDA,
      ESTADO
    )
    VALUES 
    (
      @cID_TARJETA_CREDITO,
      @cID_SUCURSAL,
      @cID_CLIENTE,
      @cID_EM,
      @cMONTO_SALIDA,
      1
    )
  END
  ELSE -- Actualizar registro
  BEGIN
    UPDATE MOVIMIENTO_TARJETA SET
      ID_TARJETA_CREDITO = @cID_TARJETA_CREDITO,
      ID_SUCURSAL        = @cID_SUCURSAL,
      ID_CLIENTE         = @cID_CLIENTE,
      ID_EM              = @cID_EM,
      MONTO_SALIDA       = @cMONTO_SALIDA
    WHERE 
      ID_MV_TARJETA      = @cID_MV_TARJETA
  END
END
GO
-- EXEC USP_GuardarMovimientoTarjetas

CREATE PROCEDURE USP_EliminarMovimientoTarjetas
@nID_MV_TARJETA INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO TARJETA a 0
    UPDATE MOVIMIENTO_TARJETA
    SET    ESTADO = 0
    WHERE  ID_MV_TARJETA  = @nID_MV_TARJETA
END
GO

CREATE PROCEDURE USP_LevantarMovimientoTarjetas
@nID_MV_TARJETA INT = 0
AS
BEGIN
    -- Actualizar el estado de MOVIMIENTO TARJETA a 0
    UPDATE MOVIMIENTO_TARJETA
    SET    ESTADO = 1
    WHERE  ID_MV_TARJETA  = @nID_MV_TARJETA
END
GO

-------------------------------------------------------------------
-- PANELES DE DESICIÓN DE MOVIMIENTOS DE TARJETAS
-------------------------------------------------------------------
CREATE PROCEDURE USP_ListadoMovimientoTarjeta_TarjetaCredito
AS
BEGIN
    SELECT A.ID_TARJETA_CREDITO, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, A.CODIGO_TARJETA
    FROM   TARJETA_CREDITO A
    INNER JOIN CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE
	WHERE A.ESTADO = 1 AND B.ESTADO = 1
    ORDER BY A.ID_TARJETA_CREDITO DESC
END
GO
-- EXEC USP_ListadoMovimientoTarjeta_TarjetaCredito

CREATE PROC USP_ListadoMovimientoTarjeta_Cliente
AS
  SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE
  FROM     CLIENTE
  WHERE    ESTADO = 1
  ORDER BY ID_CLIENTE DESC
GO
-- EXEC USP_ListadoMovimientoTarjeta_Cliente

CREATE PROC USP_ListadoMovimientoTarjeta_Empleado
AS
  SELECT   ID_EM, NOM_EMPLEADO, APE_PATE, APE_MATE
  FROM     EMPLEADO
  WHERE    ESTADO = 1
  ORDER BY ID_EM DESC
GO
-- EXEC USP_ListadoMovimientoTarjeta_Empleado

CREATE PROC USP_ListadoMovimientoTarjeta_Sucursal
AS
  SELECT   ID_SUCURSAL, DIRECCION
  FROM     SUCURSAL
  WHERE    ESTADO = 1
  ORDER BY ID_SUCURSAL DESC
GO
-- EXEC USP_ListadoMovimientoTarjeta_Sucursal

-------------------------------------------------------------------
--
-------------------------------------------------------------------
