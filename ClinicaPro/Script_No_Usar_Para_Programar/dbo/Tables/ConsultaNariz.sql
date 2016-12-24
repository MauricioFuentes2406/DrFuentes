CREATE TABLE [dbo].[ConsultaNariz] (
    [IdConsulta]       INT NOT NULL,
    [Rinorrea]         BIT NOT NULL,
    [Epitaxis]         BIT NOT NULL,
    [Sinusitis]        BIT NOT NULL,
    [ResfrioFrecuente] BIT NOT NULL,
    CONSTRAINT [PK_ConsultaNariz] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaNariz_ConsultaExploracionFisica] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[ConsultaExploracionFisica] ([IdConsulta])
);

