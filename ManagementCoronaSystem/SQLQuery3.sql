﻿CREATE TABLE [dbo].[Clients] (
    [id]                   VARCHAR (9)    NOT NULL,
    [firstName]            VARCHAR (100)  NOT NULL,
    [lastName]             VARCHAR (100)  NOT NULL,
    [address]              VARCHAR (MAX)  NULL,
    [phoneNumber]          VARCHAR (MAX)  NULL,
    [cellPhoneNumber]      VARCHAR (MAX)  NULL,
    [email]                VARCHAR (150)  NOT NULL,
    [birthDate]            DATE NOT NULL,
    [firstShot]            DATE   NOT NULL,
    [secondShot]           DATE NOT NULL,
    [thirdShot]            DATE  NOT NULL,
    [fourthShot]           DATE  NOT NULL,
    [vaccine1Manufacturer] NVARCHAR (MAX) NOT NULL,
    [vaccine2Manufacturer] NVARCHAR (MAX) NOT NULL,
    [vaccine3Manufacturer] NVARCHAR (MAX) NOT NULL,
    [vaccine4Manufacturer] NVARCHAR (MAX) NOT NULL,
    [positiveDate]         DATE NOT NULL,
    [coronaRecovery]       DATE NOT NULL,
    [created_at]           DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);