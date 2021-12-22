/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/
-- Seed/update Training Types
:r .\PostDeploy\SeedTrainingType.sql

-- Seed/update  TargetAudiences
:r .\PostDeploy\SeedTargetAudience.sql

-- Seed/update  Audience types
:r .\PostDeploy\SeedAudienceType.sql
