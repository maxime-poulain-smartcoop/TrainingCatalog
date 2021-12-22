CREATE TABLE [dbo].[AudienceTypeTraining]
(
	[TrainingId]     INT NOT NULL,
    [AudienceTypeId] INT NOT NULL,

    CONSTRAINT [PK_AudienceTypeTraining]              PRIMARY KEY ([TrainingId],[AudienceTypeId]),
    CONSTRAINT [FK_AudienceTypeTraining_Training]     FOREIGN KEY ([TrainingId]) REFERENCES [Training]([Id]),
    CONSTRAINT [FK_AudienceTypeTraining_AudienceType] FOREIGN KEY ([AudienceTypeId]) REFERENCES [AudienceType]([Id]),
)

GO

CREATE INDEX [IX_AudienceTypeTraining_TrainingId] ON [dbo].[AudienceTypeTraining] ([TrainingId])

GO

CREATE INDEX [IX_AudienceTypeTraining_AudienceId] ON [dbo].[AudienceTypeTraining] ([AudienceTypeId])
