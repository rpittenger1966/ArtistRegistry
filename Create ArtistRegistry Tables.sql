use [ArtistRegistry]
go

IF OBJECT_ID('dbo.GalleryExhibitionPrize', 'U') IS NOT NULL
  DROP TABLE [dbo].[GalleryExhibitionPrize];

IF OBJECT_ID('dbo.Prize', 'U') IS NOT NULL
  DROP TABLE [dbo].[Prize];

IF OBJECT_ID('dbo.ArtPiece', 'U') IS NOT NULL
  DROP TABLE [dbo].[ArtPiece];

IF OBJECT_ID('dbo.GalleryExhibitionArtist', 'U') IS NOT NULL
  DROP TABLE [dbo].[GalleryExhibitionArtist];

IF OBJECT_ID('dbo.GalleryExhibition', 'U') IS NOT NULL
  DROP TABLE [dbo].[GalleryExhibition];

IF OBJECT_ID('dbo.FestivalEventArtist', 'U') IS NOT NULL
  DROP TABLE [dbo].[FestivalEventArtist];

IF OBJECT_ID('dbo.FestivalEvent', 'U') IS NOT NULL
  DROP TABLE [dbo].[FestivalEvent];

IF OBJECT_ID('dbo.Festival', 'U') IS NOT NULL
  DROP TABLE [dbo].[Festival];

IF OBJECT_ID('dbo.Gallery', 'U') IS NOT NULL
  DROP TABLE [dbo].[Gallery];

IF OBJECT_ID('dbo.Juror', 'U') IS NOT NULL
  DROP TABLE [dbo].[Juror];

IF OBJECT_ID('dbo.Artist', 'U') IS NOT NULL
  DROP TABLE [dbo].[Artist];

IF OBJECT_ID('dbo.Contact', 'U') IS NOT NULL
  DROP TABLE [dbo].[Contact];


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[ContactId] int identity(1,1) NOT NULL,
	[FirstName] [varchar](80) NOT NULL,
	[LastName] [varchar](40) NOT NULL,
	[Gender] [varchar](2) NULL,
	[BirthYear] int NULL,
	[Generation] varchar(10) NULL,
	[Address1] [varchar](30) NULL,
	[Address2] [varchar](30) NULL,
	[City] [varchar](40) NULL,
	[State] [varchar](5) NULL,
	[PostalCode] [varchar](10) NULL,
	[Country] [varchar](50) NOT NULL,
	[Phone] [varchar](15) NULL,

	[Email] [varchar](100) NULL,
	[WebSite] [varchar](100) NULL,
	[Facebook] [varchar](100) NULL,
	[Instagram] [varchar](100) NULL,
	[DeviantArt] [varchar](100) NULL,
	[YouTube] [varchar](100) NULL,
	[OhioArtistRegistry] [varchar](200) NULL,

	[InitialSource] varchar(50) NULL,
	[StatusId] int NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([ContactId])
);

CREATE TABLE [dbo].[Artist] (
	[ContactId] int NOT NULL,

	CONSTRAINT PK_Artist PRIMARY KEY CLUSTERED ([ContactId])
);

ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])

CREATE TABLE [dbo].[Juror] (
	[ContactId] int NOT NULL,

	CONSTRAINT PK_Juror PRIMARY KEY CLUSTERED ([ContactId])
);

ALTER TABLE [dbo].[Juror]  WITH CHECK ADD  CONSTRAINT [FK_Juror_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])


CREATE TABLE [dbo].[Gallery] (
	[GalleryId] int identity(1,1) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PostalCode] [varchar](10) NULL,
	[Country] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NULL,
	[EmailAddress] [varchar](50) NULL,

	[WebSite] [varchar](100) NULL,
	[Facebook] [varchar](100) NULL,
	[Instagram] [varchar](100) NULL,
	[DeviantArt] [varchar](100) NULL,
	[YouTube] [varchar](100) NULL,

	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
	CONSTRAINT PK_Gallery PRIMARY KEY CLUSTERED ([GalleryId])
);


CREATE TABLE [dbo].[Festival] (
	[FestivalId] int identity(1,1) NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,

	[WebSite] [varchar](100) NULL,
	[Facebook] [varchar](100) NULL,
	[Instagram] [varchar](100) NULL,
	[DeviantArt] [varchar](100) NULL,
	[YouTube] [varchar](100) NULL,

	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
	CONSTRAINT PK_Festival PRIMARY KEY CLUSTERED ([FestivalId])
);

CREATE TABLE [dbo].[FestivalEvent] (
	[FestivalEventId] int identity(1,1) NOT NULL,
	[FestivalId] int NOT NULL,

	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[EntryDeadline] [datetime] NULL,
	[EntryStatus] int NULL,

	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
	CONSTRAINT PK_FestivalEvent PRIMARY KEY CLUSTERED ([FestivalEventId])
);

ALTER TABLE [dbo].[Festival]  WITH CHECK ADD  CONSTRAINT [FK_Festival_FestivalId] FOREIGN KEY([FestivalId])
	REFERENCES [dbo].[Festival] ([FestivalId])


CREATE TABLE [dbo].[FestivalEventArtist] (
	[FestivalEventId] int NOT NULL,
	[ContactId] int NOT NULL,
	CONSTRAINT PK_FestivalEventArtist PRIMARY KEY CLUSTERED ([FestivalEventId],[ContactId])
);


ALTER TABLE [dbo].[FestivalEventArtist]  WITH CHECK ADD  CONSTRAINT [FK_FestivalEventArtist_FestivalEventId] FOREIGN KEY([FestivalEventId])
	REFERENCES [dbo].[FestivalEvent] ([FestivalEventId])

ALTER TABLE [dbo].[FestivalEventArtist]  WITH CHECK ADD  CONSTRAINT [FK_FestivalEventArtist_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])


CREATE TABLE [dbo].[GalleryExhibition] (
	[GalleryExhibitionId] int identity(1,1) NOT NULL,
	[GalleryId] int NOT NULL,
	[Name] varchar(50) NOT NULL,
	[ArtCallUrl] varchar(100) NOT NULL,
	[ProspectusUrl] varchar(100) NOT NULL,
	[Notes] varchar(max) NOT NULL,

	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[EntryDeadline] [datetime] NULL,
	[EntryStatus] int NULL,

	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
	CONSTRAINT PK_GalleryExhibition PRIMARY KEY CLUSTERED ([GalleryExhibitionId])
);


ALTER TABLE [dbo].[GalleryExhibition]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibition_GalleryId] FOREIGN KEY([GalleryId])
	REFERENCES [dbo].[Gallery] ([GalleryId])


CREATE TABLE [dbo].[GalleryExhibitionArtist] (
	[GalleryExhibitionId] int NOT NULL,
	[ContactId] int NOT NULL,

	CONSTRAINT PK_GalleryExhibitionArtist PRIMARY KEY CLUSTERED ([GalleryExhibitionId],[ContactId])
);

ALTER TABLE [dbo].[GalleryExhibitionArtist]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionArtist_GalleryExhibitionId] FOREIGN KEY([GalleryExhibitionId])
	REFERENCES [dbo].[GalleryExhibition] ([GalleryExhibitionId])

ALTER TABLE [dbo].[GalleryExhibitionArtist]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionArtist_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])



CREATE TABLE [dbo].[Prize] (
	[PrizeId] int NOT NULL,
	[Name] varchar(20) NOT NULL,
	CONSTRAINT PK_Prize PRIMARY KEY CLUSTERED ([PrizeId])
);

CREATE TABLE [dbo].[ArtPiece] (
	[ArtPieceId] int identity(1,1) NOT NULL,
	[ContactId] int NOT NULL,
	[Title] varchar(100) NULL,
	[Medium] varchar(30) NULL,
	[Size] varchar(30) NULL,
	[Category] varchar(30) NULL,
	[Price] int NULL,

	[CreateDate] [datetime] NOT NULL,
	[ModifyDate] [datetime] NULL,
	CONSTRAINT PK_ArtPiece PRIMARY KEY CLUSTERED ([ArtPieceId])
);

ALTER TABLE [dbo].[ArtPiece]  WITH CHECK ADD  CONSTRAINT [FK_ArtPiece_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])


CREATE TABLE [dbo].[GalleryExhibitionPrize] (
	[GalleryExhibitionPrizeId] int identity(1,1) NOT NULL,
	[GalleryExhibitionId] int NOT NULL,
	[PrizeId] int NOT NULL,
	[ContactId] int NOT NULL,
	[ArtPieceId] int NOT NULL,
	CONSTRAINT PK_GalleryExhibitionPrize PRIMARY KEY CLUSTERED ([GalleryExhibitionPrizeId])
);

ALTER TABLE [dbo].[GalleryExhibitionPrize]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionPrize_GalleryExhibitionId] FOREIGN KEY([GalleryExhibitionId])
	REFERENCES [dbo].[GalleryExhibition] ([GalleryExhibitionId])

ALTER TABLE [dbo].[GalleryExhibitionPrize]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionPrize_PrizeId] FOREIGN KEY([PrizeId])
	REFERENCES [dbo].[Prize] ([PrizeId])

ALTER TABLE [dbo].[GalleryExhibitionPrize]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionPrize_ContactId] FOREIGN KEY([ContactId])
	REFERENCES [dbo].[Contact] ([ContactId])

ALTER TABLE [dbo].[GalleryExhibitionPrize]  WITH CHECK ADD  CONSTRAINT [FK_GalleryExhibitionPrize_ArtPieceId] FOREIGN KEY([ArtPieceId])
	REFERENCES [dbo].[ArtPiece] ([ArtPieceId])




INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (0,'Best of Show');
INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (1,'First Place');
INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (2,'Second Place');
INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (3,'Third Place');
INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (4,'Honorable Mention');
INSERT INTO [dbo].[Prize] ([PrizeId],[Name]) VALUES (5,'Peoples Choice');



INSERT INTO [dbo].[Gallery]
           ([Name]
           ,[City]
           ,[State]
           ,[Country]
           ,[CreateDate])
     VALUES
           ('Gallery Veronique'
           ,'Harpers Point'
           ,'OH'
           ,'US'
           ,GETDATE());


INSERT INTO [dbo].[Gallery]
           ([Name]
           ,[City]
           ,[State]
           ,[Country]
           ,[CreateDate])
     VALUES
           ('Pop Revolution Gallery'
           ,'Mason'
           ,'OH'
           ,'US'
           ,GETDATE());


INSERT INTO [dbo].[Gallery]
           ([Name]
           ,[City]
           ,[State]
           ,[Country]
           ,[CreateDate])
     VALUES
           ('Randolph Arts'
           ,'Elkins'
           ,'WV'
           ,'US'
           ,GETDATE());



INSERT INTO [dbo].[Contact]
           ([FirstName]
           ,[LastName]
           ,[Gender]
           ,[BirthYear]
           ,[Generation]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Email]
           ,[WebSite]
           ,[Facebook]
           ,[Instagram]
           ,[DeviantArt]
           ,[YouTube]
           ,[OhioArtistREgistry]
           ,[InitialSource]
           ,[StatusId]
           ,[CreateDate]
           ,[ModifyDate])
     VALUES
           ('Bob Pittenger'
           ,'Pittenger'
           ,'M'
           ,1966
           ,'GenX'
           ,'7376 Middleton Way'
           ,''
           ,'Mason'
           ,'OH'
           ,'45040'
           ,'US'
           ,'513-755-7624'
           ,'pittenger@pointstar.com'
           ,'https://artbybob.art'
           ,null
           ,null
           ,'https://www.deviantart.com/boboilpainting'
           ,NULL
           ,'https://oovar.ohioartscouncil.org/name/bob-pittenger/'
           ,''
           ,1
           ,getdate()
           ,null);



INSERT INTO [dbo].[Artist]
           ([ContactId])
     VALUES
           (1);


