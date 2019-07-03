﻿CREATE TABLE [dbo].[Student] (
    [Id]             INT                IDENTITY (1, 1) NOT NULL,
    [FirstName]      VARCHAR (100)      NOT NULL,
    [LastName]       VARCHAR (100)      NOT NULL,
    [DateOfBirth]    DATETIMEOFFSET (7) NULL,
    [PlaceOfBirth]   VARCHAR (25)       NULL,
    [Gender]         BIT                NULL,
    [Address]        VARCHAR (100)      NULL,
    [Phone]          VARCHAR (20)       NULL,
    [Email]          VARCHAR (50)       NOT NULL,
    [Username]       VARCHAR (25)       NOT NULL,
    [Password]       VARCHAR (50)       NOT NULL,
    [IsSite]         BIT                NOT NULL,
    [SecretQuestion] VARCHAR (100)      NULL,
    [SecretAnswer]   VARCHAR (100)      NULL,
    [HiringLocation] VARCHAR (100)      NULL,
    [IsDelete]       BIT                NOT NULL,
    [CreateDate]     DATETIMEOFFSET (7) NOT NULL,
    [UpdateDate]     DATETIMEOFFSET (7) NOT NULL,
    [DeleteDate]     DATETIMEOFFSET (7) NOT NULL,
    [Village_Id]     INT                NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Student_Village] FOREIGN KEY ([Village_Id]) REFERENCES [dbo].[Village] ([Id])
);

