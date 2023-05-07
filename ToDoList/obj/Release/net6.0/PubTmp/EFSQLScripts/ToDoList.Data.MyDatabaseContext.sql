IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425173756_MyMygration1')
BEGIN
    CREATE TABLE [DoneModelasCollection] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [ToDoDate] datetime2 NOT NULL,
        [DoneTime] datetime2 NOT NULL,
        [IP] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DoneModelasCollection] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425173756_MyMygration1')
BEGIN
    CREATE TABLE [ToDoModelCollection] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [ToDoDate] datetime2 NOT NULL,
        [IP] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ToDoModelCollection] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425173756_MyMygration1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230425173756_MyMygration1', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425182949_MyMygration3')
BEGIN
    ALTER TABLE [DoneModelasCollection] DROP CONSTRAINT [PK_DoneModelasCollection];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425182949_MyMygration3')
BEGIN
    EXEC sp_rename N'[DoneModelasCollection]', N'DoneModelCollection';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425182949_MyMygration3')
BEGIN
    ALTER TABLE [DoneModelCollection] ADD CONSTRAINT [PK_DoneModelCollection] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425182949_MyMygration3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230425182949_MyMygration3', N'7.0.5');
END;
GO

COMMIT;
GO

