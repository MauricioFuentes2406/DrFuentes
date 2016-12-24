﻿CREATE TABLE [dbo].[ConsultaParesCraneales] (
    [IdConsulta]                                      INT        NOT NULL,
    [PC_I_Olfatorio]                                  BIT        NOT NULL,
    [PC_II_FondoOjo]                                  BIT        NOT NULL,
    [PC_II_AgudezaVisual]                             BIT        NOT NULL,
    [PC_II_VisionColores]                             BIT        NOT NULL,
    [PC_II_ReflejoPupilar]                            BIT        NOT NULL,
    [PC_II_Campimetria]                               BIT        NOT NULL,
    [PC_III_IV_VI_MovimientoOcular]                   BIT        NOT NULL,
    [PC_III_IV_VI_ReflejoFotoMotorDirectoyConsensual] BIT        NOT NULL,
    [PC_V_SensibilidadCara]                           BIT        NOT NULL,
    [PC_V_ReflejoCorneano]                            BIT        NOT NULL,
    [PC_V_MovimientoMandibula]                        BIT        NOT NULL,
    [PC_VII_MovibilidadMusculosCara]                  BIT        NOT NULL,
    [PC_VII_Gustos2TerciosAnterioresLengua]           BIT        NOT NULL,
    [PC_VII_CierreOjosVsResistencia]                  BIT        NOT NULL,
    [PC_VII_SoplaMuentraDientes]                      BIT        NOT NULL,
    [PC_VII_MuecasAmbosLado]                          BIT        NOT NULL,
    [PC_VIII_WebberYRinne]                            BIT        NOT NULL,
    [PC_VIII_Romberg]                                 BIT        NOT NULL,
    [PC_IX_FunciasGustativa]                          BIT        NOT NULL,
    [PC_X_ElevacionSimetrica]                         BIT        NOT NULL,
    [PC_X_Lengua]                                     BIT        NOT NULL,
    [PC_X_Paladar]                                    BIT        NOT NULL,
    [PC_X_ReflejoNauseano]                            BIT        NOT NULL,
    [PC_XI_MovimientoEsternocleidomastoideo]          BIT        NOT NULL,
    [PC_XI_TonoFuerzaMuscarlarEsterno]                BIT        NOT NULL,
    [PC_XI_MovimientoTrapecio]                        BIT        NOT NULL,
    [PC_XI_TonoFuerzaMuscarlarTrapecio]               BIT        NOT NULL,
    [OtroDetalle]                                     CHAR (200) NULL,
    CONSTRAINT [PK_ConsultaParesCraneales] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_ConsultaParesCraneales_Consulta] FOREIGN KEY ([IdConsulta]) REFERENCES [dbo].[Consulta] ([IdConsulta])
);

