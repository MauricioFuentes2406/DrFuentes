CREATE TABLE [dbo].[TipoCitas] (
    [idTipoCita] INT        IDENTITY (1, 1) NOT NULL,
    [Nombre]     NCHAR (10) NULL,
    CONSTRAINT [PK_TipoCitas] PRIMARY KEY CLUSTERED ([idTipoCita] ASC)
);

