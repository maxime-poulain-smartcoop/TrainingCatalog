CREATE TABLE [dbo].[TrainingDetail]
(
	[Id]          INT            NOT NULL PRIMARY KEY IDENTITY(1,1),
    [TrainingId]  INT            NOT NULL,
    [Title]       VARCHAR(100)   NOT NULL,
    [Goal]        NVARCHAR(1024) NULL,
    [Methodology] NVARCHAR(1024) NULL,
    [Language]    VARCHAR(2)     NOT NULL,

    CONSTRAINT [FK_TrainingDescription_Training] FOREIGN KEY ([TrainingId]) REFERENCES [Training]([Id])

)

GO
CREATE UNIQUE INDEX [IX_TrainingDescription_TrainingId] ON [dbo].[TrainingDetail] ([TrainingId])
