DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'SaleContactInfo') AND [c].[name] = N'Skype');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [SaleContactInfo] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [SaleContactInfo] ALTER COLUMN [Skype] nvarchar(64) NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'SaleContactInfo') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [SaleContactInfo] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [SaleContactInfo] ALTER COLUMN [Email] nvarchar(64) NULL;

GO

ALTER TABLE [SaleContactInfo] ADD [CellPhone] nvarchar(64) NULL;

GO

CREATE TABLE [CustomerContactInfo] (
    [Id] int NOT NULL IDENTITY,
    [CreateDateTime] datetime2 NULL,
    [CreateUserName] nvarchar(16) NULL,
    [Email] nvarchar(32) NULL,
    [Free] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Name] nvarchar(32) NULL,
    CONSTRAINT [PK_CustomerContactInfo] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180712021652_AddCustomerModel', N'2.0.1-rtm-125');

GO

