CREATE TABLE [dbo].[UserRole]
(
	[RoleId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_UserRole_ToTable] FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId]), 
    CONSTRAINT [FK_UserRole_ToTable_1] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
