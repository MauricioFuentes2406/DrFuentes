CREATE TABLE [dbo].[ConsultaSensibilidad] (
    [IdConsulta]                  INT                NOT NULL,
    [S_Superficial]               BIT                NOT NULL,
    [S_Profunda]                  BIT                NOT NULL,
    [S_Discriminatoria]           BIT                NOT NULL,
    [S_Discriminacion_Dos_Puntos] BIT                NOT NULL,
    [Detalles]                    NCHAR (200) SPARSE NULL,
    CONSTRAINT [PK_ConsultaSensibilidad] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaSensibilidad_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

