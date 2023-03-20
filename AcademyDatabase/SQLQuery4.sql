CREATE DATABASE Trainees

CREATE TABLE [dbo].[Trainees] (
    [TraineeID] CHAR (5) NOT NULL,
    [Name]      VARCHAR (20) NULL,
    [Course]    VARCHAR (20) NULL,
    [Location]  VARCHAR (20) NULL,
    CONSTRAINT [PK_Trainees] PRIMARY KEY CLUSTERED ([TraineeID] ASC)
);