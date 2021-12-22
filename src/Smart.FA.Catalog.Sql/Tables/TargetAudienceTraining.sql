CREATE TABLE [dbo].[TargetAudienceTraining]
(
	[TrainingId]       INT NOT NULL,
    [TargetAudienceId] INT NOT NULL,

    CONSTRAINT [PK_TargetAudienceTraining]                 PRIMARY KEY ([TrainingId],[TargetAudienceId]),
    CONSTRAINT [FK_TargetAudienceTraining_Training]        FOREIGN KEY ([TrainingId])       REFERENCES [Training]([Id]),
    CONSTRAINT [FK_TargetAudienceTraining_TargetAudieneId] FOREIGN KEY ([TargetAudienceId]) REFERENCES [TargetAudience]([Id]),
)

GO

CREATE INDEX [IX_TargetAudienceTraining_TrainingId] ON [dbo].[TargetAudienceTraining] ([TrainingId])

GO
CREATE INDEX [IX_TargetAudienceTraining_TargetAudienceId] ON [dbo].[TargetAudienceTraining] ([TargetAudienceId])
