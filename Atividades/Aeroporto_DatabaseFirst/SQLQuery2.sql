  IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name = 'AVIACAO')


BEGIN

	create database AVIACAO;

END
GO
	use AVIACAO;

GO


    -- CLIENTE
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'CLIENTE')
BEGIN
    CREATE TABLE [dbo].[CLIENTE] (
        [ID_CLIENTE] INT IDENTITY (1,1) NOT NULL,
        [NOME] NTEXT NULL,
        [CONTATO] NTEXT NULL,
        [GENERO] NTEXT NULL,
        [DATA_NASCIMENTO] DATETIME NULL
        CONSTRAINT [PK_dbo.CLIENTE] PRIMARY KEY CLUSTERED([ID_CLIENTE] ASC)
    );
END
GO
-- OK

    -- AEROPORTO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'AEROPORTO')
BEGIN
    CREATE TABLE [dbo].[AEROPORTO] (
        [ID_AEROPORTO] INT IDENTITY (1,1) NOT NULL,
        [LOCALIZACAO] NTEXT NULL
        CONSTRAINT [PK_dbo.AEROPORTO] PRIMARY KEY CLUSTERED([ID_AEROPORTO] ASC)
    );
END
GO
-- OK

    -- AERONAVE
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'TIPO_AERONAVE')
BEGIN
    CREATE TABLE [dbo].[TIPO_AERONAVE] (
        [ID_TIPO_AERONAVE] INT IDENTITY (1,1) NOT NULL,
        [DESCRICAO] NTEXT NULL
        CONSTRAINT [PK_dbo.TIPO_AERONAVE] PRIMARY KEY CLUSTERED([ID_TIPO_AERONAVE] ASC)
    );
END
GO
-- OK 

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'AERONAVE')
BEGIN
    CREATE TABLE [dbo].[AERONAVE] (
        [ID_AERONAVE] INT IDENTITY (1,1) NOT NULL,
        [QTD_POLTRONAS] INT NULL,
        [ID_TIPO_AERONAVE] INT NULL,
        CONSTRAINT [PK_dbo.AERONAVE] PRIMARY KEY CLUSTERED([ID_AERONAVE] ASC),
        CONSTRAINT [FK_dbo.AERONAVE_dbo.TIPOAERONAVE_IDTIPOAERONAVE]
			FOREIGN KEY ([ID_TIPO_AERONAVE])
			REFERENCES [dbo].[TIPO_AERONAVE] ([ID_TIPO_AERONAVE])
			ON DELETE CASCADE
    );
END
GO

    -- VOO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'VOO')
BEGIN
    CREATE TABLE [dbo].[VOO] (
        [ID_VOO] INT IDENTITY (1,1) NOT NULL,
        [HORARIO_SAIDA] DATETIME NULL,
        [HORARIO_DESTINO] DATETIME NULL,
        [ID_AEROPORTO_SAIDA] INT NULL,
        [ID_AEROPORTO_DESTINO] INT NULL,
        [ID_AERONAVE] INT NULL,
        CONSTRAINT [PK_dbo.VOO] PRIMARY KEY CLUSTERED([ID_VOO] ASC),
        CONSTRAINT [FK_dbo.VOO_dbo.AEROPORTOSAIDA_IDAEROPORTO]
			FOREIGN KEY ([ID_AEROPORTO_SAIDA])
			REFERENCES [dbo].[AEROPORTO] ([ID_AEROPORTO])
			ON DELETE CASCADE,
        CONSTRAINT [FK_dbo.VOO_dbo.AEROPORTODESTINO_IDAEROPORTO]
			FOREIGN KEY ([ID_AEROPORTO_DESTINO])
			REFERENCES [dbo].[AEROPORTO] ([ID_AEROPORTO])
			ON DELETE CASCADE,
        CONSTRAINT [FK_dbo.VOO_dbo.AERONAVE_IDAERONAVE]
			FOREIGN KEY ([ID_AERONAVE])
			REFERENCES [dbo].[AERONAVE] ([ID_AERONAVE])
			ON DELETE CASCADE
    );
END
GO

    -- ESCALA
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'ESCALA')
BEGIN
    CREATE TABLE [dbo].[ESCALA] (
        [ID_ESCALA] INT IDENTITY (1,1) NOT NULL,
        [HORARIO_SAIDA] DATETIME NULL,
        [ID_VOO] INT NULL,
        [ID_AEROPORTO_SAIDA] INT NULL,
        CONSTRAINT [PK_dbo.ESCALA] PRIMARY KEY CLUSTERED([ID_ESCALA] ASC),
        CONSTRAINT [FK_dbo.ESCALA_dbo.VOO_IDVOO]
			FOREIGN KEY ([ID_VOO])
			REFERENCES [dbo].[VOO] ([ID_VOO])
			ON DELETE CASCADE,
        CONSTRAINT [FK_dbo.ESCALA_dbo.AEROPORTO_IDAEROPORTO]
			FOREIGN KEY ([ID_AEROPORTO_SAIDA])
			REFERENCES [dbo].[AEROPORTO] ([ID_AEROPORTO])
			ON DELETE CASCADE
    );
END
GO


    -- HORARIO E COMPRA
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'HORARIO')
BEGIN
    CREATE TABLE [dbo].[HORARIO] (
        [ID_HORARIO] INT IDENTITY (1,1) NOT NULL,
        [DISPONIBILIDADE] BOOL DEFAULT TRUE,
        [LADO_POLTRONA] NTEXT NULL,
        [LOCALIZACAO_POLTRONA] NTEXT NULL,
        [ID_VOO] INT NULL,
        CONSTRAINT [PK_dbo.HORARIO] PRIMARY KEY CLUSTERED([ID_HORARIO] ASC),
        CONSTRAINT [FK_dbo.HORARIO_dbo.VOO_IDVOO]
			FOREIGN KEY ([ID_VOO])
			REFERENCES [dbo].[VOO] ([ID_VOO])
			ON DELETE CASCADE
    );
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'COMPRA')
BEGIN
    CREATE TABLE [dbo].[COMPRA] (
        [ID_COMPRA] INT IDENTITY (1,1) NOT NULL,
        [ID_HORARIO] INT NULL,
        [ID_CLIENTE] INT NULL,
        CONSTRAINT [PK_dbo.COMPRA] PRIMARY KEY CLUSTERED([ID_COMPRA] ASC),

        CONSTRAINT [FK_dbo.COMPRA_dbo.HORARIO_IDHORARIO]
			FOREIGN KEY ([ID_HORARIO])
			REFERENCES [dbo].[HORARIO] ([ID_HORARIO])
			ON DELETE CASCADE,
        CONSTRAINT [FK_dbo.COMPRA_dbo.CLIENTE_IDCLIENTE]
			FOREIGN KEY ([ID_CLIENTE])
			REFERENCES [dbo].[CLIENTE] ([ID_CLIENTE])
			ON DELETE CASCADE
    );
END
GO