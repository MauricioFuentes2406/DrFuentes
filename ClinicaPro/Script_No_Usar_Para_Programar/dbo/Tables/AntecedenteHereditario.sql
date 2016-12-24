﻿CREATE TABLE [dbo].[AntecedenteHereditario] (
    [IdConsulta]         INT               NOT NULL,
    [DM]                 TINYINT           NOT NULL,
    [HTA]                TINYINT           NOT NULL,
    [Asma]               TINYINT           NOT NULL,
    [Cardiopatía]        TINYINT           NOT NULL,
    [EnfermedadPulmonar] TINYINT           NOT NULL,
    [Hepatopapia]        TINYINT           NOT NULL,
    [Neuropatia]         TINYINT           NOT NULL,
    [Cancer]             TINYINT           NOT NULL,
    [AfeccionTiroide]    TINYINT           NOT NULL,
    [AVC]                TINYINT           NOT NULL,
    [otro]               NCHAR (90) SPARSE NULL,
    CONSTRAINT [PK_AntecedenteHereditario] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_AntecedenteHereditario_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar] FOREIGN KEY ([HTA]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar1] FOREIGN KEY ([Asma]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar2] FOREIGN KEY ([DM]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar3] FOREIGN KEY ([Cardiopatía]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar4] FOREIGN KEY ([EnfermedadPulmonar]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar5] FOREIGN KEY ([Hepatopapia]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar6] FOREIGN KEY ([Neuropatia]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar7] FOREIGN KEY ([Cancer]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar8] FOREIGN KEY ([AfeccionTiroide]) REFERENCES [dbo].[Familiar] ([IdFamiliar]),
    CONSTRAINT [FK_AntecedenteHereditario_Familiar9] FOREIGN KEY ([AVC]) REFERENCES [dbo].[Familiar] ([IdFamiliar])
);

