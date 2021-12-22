CREATE TABLE [dbo].[Training]
(
	[Id]         INT           NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Status]     INT           NOT NULL DEFAULT(1), -- 1: Draft, 2: PendingValidation, 3: Validated
    [CreatedAt]  DATETIME2(0)  NOT NULL DEFAULT(GETUTCDATE()),
    [ModifiedAt] DATETIME2(0)  NULL,
    [DeletedAt]  DATETIME2(0)  NULL,
)
