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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[News] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Title] nvarchar(150) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Updated] datetime2 NOT NULL DEFAULT (GETDATE()),
        CONSTRAINT [PK_News] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Permission] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Type] varchar(10) NOT NULL,
        [Name] varchar(30) NOT NULL,
        [DisplayName] varchar(100) NOT NULL,
        [Order] int NOT NULL,
        CONSTRAINT [PK_Permission] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Role] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] varchar(30) NOT NULL,
        [DisplayName] varchar(100) NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[RolePermission] (
        [RoleId] uniqueidentifier NOT NULL,
        [PermissionId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_RolePermission] PRIMARY KEY ([RoleId], [PermissionId]),
        CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[User] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [RoleId] uniqueidentifier NOT NULL,
        [IdentificationNumber] bigint NOT NULL,
        [Username] nvarchar(100) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Email] varchar(150) NOT NULL,
        [FirstName] varchar(50) NOT NULL,
        [LastName] varchar(50) NOT NULL,
        [Direction] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Age] smallint NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Title') AND [object_id] = OBJECT_ID(N'[dbo].[News]'))
        SET IDENTITY_INSERT [dbo].[News] ON;
    EXEC(N'INSERT INTO [dbo].[News] ([Id], [Description], [Title])
    VALUES (''f0660d32-93f8-438b-80db-8df975641bc8'', N''Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años'', N''Solo hay 4 mujeres en los CEO de las 100 empresas más grandes''),
    (''cb7d7cd3-0510-4203-9176-2f6b3b937519'', N''El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones'', N''Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia''),
    (''5aad402e-a2f3-4103-83e1-097e4219a4f8'', N''Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma'', N''Google y Facebook firman asociación con empresa de pago en línea''),
    (''0c42bc5e-9c6d-45c9-8bf6-ae3983da4dd4'', N''Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros'', N''Bitcóin: hackers tienen nuevo método para robar criptomonedas''),
    (''6c58d694-e913-4b81-a74b-26d3795d48a1'', N''Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC'', N''''''Startup'''' Habi recauda 100 millones de dólares en ronda de inversión''),
    (''f9b55d06-c802-4e39-b371-dbbf097ca9cb'', N''Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados'', N''E3: los mejores anuncios que dejó el evento en su edición virtual'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Title') AND [object_id] = OBJECT_ID(N'[dbo].[News]'))
        SET IDENTITY_INSERT [dbo].[News] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayName', N'Name', N'Order', N'Type') AND [object_id] = OBJECT_ID(N'[dbo].[Permission]'))
        SET IDENTITY_INSERT [dbo].[Permission] ON;
    EXEC(N'INSERT INTO [dbo].[Permission] ([Id], [DisplayName], [Name], [Order], [Type])
    VALUES (''73eadeb6-bc84-4d98-ab6e-04f85e057db7'', ''Crear Usuario'', ''AddUser'', 4, ''CanUsers''),
    (''cb5095c0-02cd-4b10-8666-09eaafeda595'', ''Detalle del Usuario'', ''GetUserById'', 3, ''CanUsers''),
    (''f6176536-ac08-4607-b003-11caa3cc5e31'', ''Listar Usuarios'', ''GetUsers'', 2, ''CanUsers''),
    (''d3683aa7-defb-48ea-8459-b17a34a0c363'', ''Todos'', ''ALL'', 1, ''CanUsers''),
    (''71fea3d3-2d23-4971-97c1-23cec13242ba'', ''Listar Permisos por Rol'', ''GetPermissionsByRole'', 5, ''CanRoles''),
    (''6a2493a7-27f7-414f-9e8c-47077feafa82'', ''Listar Permisos'', ''GetPermissions'', 4, ''CanRoles''),
    (''bfaa9995-bfa4-4c5b-b4dc-754be406cb18'', ''Detalle del Rol'', ''GetRoleById'', 3, ''CanRoles''),
    (''69778186-75fd-445d-9993-b9f9b35d78bc'', ''Listar Roles'', ''GetRoles'', 2, ''CanRoles''),
    (''a984910b-6ecc-43e0-82d5-e9c9b0c78d03'', ''Eliminar Usuario'', ''RemoveUser'', 6, ''CanUsers''),
    (''942d6f21-a7f7-43cd-9588-23657911fea2'', ''Editar Usuario'', ''EditUser'', 5, ''CanUsers''),
    (''6d05ba82-9e0c-46ea-9e90-b268bca31885'', ''Detalle de Noticias'', ''GetNewsById'', 3, ''CanNews''),
    (''f79b85e6-0911-43e1-b68f-49fa74a52518'', ''Listar Noticias'', ''GetNews'', 2, ''CanNews''),
    (''4f39c31e-ca99-4782-b585-ae847185a292'', ''Todos'', ''ALL'', 1, ''CanNews''),
    (''e5472dd9-f0c1-4233-be69-cb59425a8407'', ''Todos'', ''ALL'', 1, ''CanRoles'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayName', N'Name', N'Order', N'Type') AND [object_id] = OBJECT_ID(N'[dbo].[Permission]'))
        SET IDENTITY_INSERT [dbo].[Permission] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayName', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] ON;
    EXEC(N'INSERT INTO [dbo].[Role] ([Id], [DisplayName], [Name])
    VALUES (''3cb57f96-7092-4842-a3a4-5e8302f6618d'', ''Editor'', ''EditorUser''),
    (''590cb67a-5177-4bda-86e4-e5b80ac333c9'', ''Visitante'', ''VisitorUser''),
    (''c651f92d-d9a1-45e8-9d04-3bb184da7a96'', ''Administrador'', ''AdminUser''),
    (''f7b2beba-7445-463d-8978-0b3b3940390c'', ''Asistente'', ''AssistantUser'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DisplayName', N'Name') AND [object_id] = OBJECT_ID(N'[dbo].[Role]'))
        SET IDENTITY_INSERT [dbo].[Role] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[dbo].[RolePermission]'))
        SET IDENTITY_INSERT [dbo].[RolePermission] ON;
    EXEC(N'INSERT INTO [dbo].[RolePermission] ([PermissionId], [RoleId])
    VALUES (''4f39c31e-ca99-4782-b585-ae847185a292'', ''c651f92d-d9a1-45e8-9d04-3bb184da7a96''),
    (''4f39c31e-ca99-4782-b585-ae847185a292'', ''590cb67a-5177-4bda-86e4-e5b80ac333c9''),
    (''4f39c31e-ca99-4782-b585-ae847185a292'', ''f7b2beba-7445-463d-8978-0b3b3940390c''),
    (''4f39c31e-ca99-4782-b585-ae847185a292'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d''),
    (''e5472dd9-f0c1-4233-be69-cb59425a8407'', ''c651f92d-d9a1-45e8-9d04-3bb184da7a96''),
    (''69778186-75fd-445d-9993-b9f9b35d78bc'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d''),
    (''69778186-75fd-445d-9993-b9f9b35d78bc'', ''f7b2beba-7445-463d-8978-0b3b3940390c''),
    (''bfaa9995-bfa4-4c5b-b4dc-754be406cb18'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d''),
    (''bfaa9995-bfa4-4c5b-b4dc-754be406cb18'', ''f7b2beba-7445-463d-8978-0b3b3940390c''),
    (''d3683aa7-defb-48ea-8459-b17a34a0c363'', ''c651f92d-d9a1-45e8-9d04-3bb184da7a96''),
    (''f6176536-ac08-4607-b003-11caa3cc5e31'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d''),
    (''f6176536-ac08-4607-b003-11caa3cc5e31'', ''f7b2beba-7445-463d-8978-0b3b3940390c''),
    (''cb5095c0-02cd-4b10-8666-09eaafeda595'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d''),
    (''cb5095c0-02cd-4b10-8666-09eaafeda595'', ''f7b2beba-7445-463d-8978-0b3b3940390c''),
    (''942d6f21-a7f7-43cd-9588-23657911fea2'', ''3cb57f96-7092-4842-a3a4-5e8302f6618d'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PermissionId', N'RoleId') AND [object_id] = OBJECT_ID(N'[dbo].[RolePermission]'))
        SET IDENTITY_INSERT [dbo].[RolePermission] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Permission_Type_Name] ON [dbo].[Permission] ([Type], [Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_Role_Name] ON [dbo].[Role] ([Name]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE INDEX [IX_RolePermission_PermissionId] ON [dbo].[RolePermission] ([PermissionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_User_IdentificationNumber_Username_Email] ON [dbo].[User] ([IdentificationNumber], [Username], [Email]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    CREATE INDEX [IX_User_RoleId] ON [dbo].[User] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210625012434_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210625012434_InitialCreate', N'5.0.7');
END;
GO

COMMIT;
GO

