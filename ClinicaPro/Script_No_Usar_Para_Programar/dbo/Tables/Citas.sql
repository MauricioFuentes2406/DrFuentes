CREATE TABLE [dbo].[Citas] (
    [IdCita]     INT        NOT NULL,
    [IdCliente]  INT        NULL,
    [IdTipoCita] INT        NULL,
    [FechaCita]  DATE       NULL,
    [EstadoCita] INT        NULL,
    [Comentario] NCHAR (50) NULL,
    CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED ([IdCita] ASC),
    CONSTRAINT [FK_Citas_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([IdCliente]),
    CONSTRAINT [FK_Citas_TipoCitas] FOREIGN KEY ([IdTipoCita]) REFERENCES [dbo].[TipoCitas] ([idTipoCita])
);

