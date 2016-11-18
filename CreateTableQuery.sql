CREATE TABLE [dbo].[Setting]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Key] VARCHAR(50) NOT NULL,
	[Value] VARCHAR(500) NULL,
	CONSTRAINT [PK_SETTING] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[PetType]
(
	[PetTypeID]  INT  NOT NULL  PRIMARY KEY IDENTITY,
	[PetTypeDescription]  varchar (50) Null

);

CREATE TABLE [dbo].[sTATUS]
(
	[StatusID]  INT  NOT NULL  PRIMARY KEY IDENTITY,
	[Description]  varchar (50) Null

);

EXEC
SP_RENAME 'sTATUS', 'Status'
GO


CREATE TABLE [dbo].[UserProfile]
(
	[UserId] INT NOT NULL IDENTITY (1,1),
	[UserName] NVARCHAR(MAX) NULL,
	[EmailId] NVARCHAR(MAX) NULL,
	[Details] NVARCHAR(MAX) NULL
);

CREATE TABLE [dbo].[Pet]
(
	[PetID]  INT  NOT NULL  PRIMARY KEY IDENTITY,
	[PetName]  varchar (100) NOT Null,
	[PetAgeYears] int  NOT Null,
	[PetAgeMonth] int  NOT Null,
	[StatusID]  int  NOT NULL,
	[LastSeenOn]  date  Null,
	[LastSeenWhere]  varchar(50) Null,
	[Notes] varchar(500) Null,
	[UserID]  int NOT NULL,
	CONSTRAINT [FK_Pet_Status] FOREIGN KEY ([StatusID])
	REFERENCES [Status]([StatusID]),
	CONSTRAINT [FK_Pet_User] FOREIGN KEY ([UserID])
	REFERENCES [UserProfile] ([UserId])		
);


CREATE TABLE [dbo].[PetPhoto]
(
	[PhotoID] INT NOT NULL IDENTITY (1,1),
	[PetID] INT NOT NULL,
	[Photo] varchar(500) DEFAULT '/content/pets/no-image.png',
	[Notes] Varchar(500) Null,
	CONSTRAINT [PK_PetPhoto] PRIMARY KEY ([PhotoID]),
	CONSTRAINT [FK_PetPhoto_Pet] FOREIGN KEY ([PetID])
	REFERENCES [Pet] ([PetID])
);

CREATE TABLE [dbo].[Message]
(
	[MessageID] INT NOT NULL,
	[UserID] INT NOT NULL,
	[MessageDate] DATETIME NOT NULL,
	[From] VARCHAR(150) NOT NULL,
	[Email] VARCHAR(150) NOT NULL,
	[Subject] VARCHAR(150) NULL,
	[Message] VARCHAR(1500) NOT NULL,
	CONSTRAINT [PK_Message] PRIMARY KEY ([MessageID]),
	CONSTRAINT [FK_Message_USer] FOREIGN KEY ([UserId])
	REFERENCES [UserProfile] ([UserId])
);

