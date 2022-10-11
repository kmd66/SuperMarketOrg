
--drop table app.ticketsubject

--drop table app.TicketSequence

--drop table app.ticket

--drop table app.ticketsubjectuser


IF OBJECT_ID('[app].[TicketSubject]', 'U') IS NULL
BEGIN 
	EXEC ('
	CREATE TABLE [app].[TicketSubject](
		[ID] [uniqueidentifier] NOT NULL,
		[ApplicationID] [uniqueidentifier] NOT NULL,
		[Name] [nvarchar](200) NOT NULL,
		[Enable] [bit] NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [app].[TicketSubject]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
	REFERENCES [org].[Application] ([ID])
	')
END



IF OBJECT_ID('[app].[TicketSequence]', 'U') IS NULL
BEGIN 
	EXEC ('
	CREATE TABLE [app].[TicketSequence](
	[ID] [uniqueidentifier] NOT NULL,
	[TicketID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](4000) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[PositionID] [uniqueidentifier] NULL,
	[ReadDate] [smalldatetime] NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [app].[TicketSequence]  WITH CHECK ADD FOREIGN KEY([TicketID])
	REFERENCES [app].[Ticket] ([ID])

	ALTER TABLE [app].[TicketSequence]  WITH CHECK ADD FOREIGN KEY([UserID])
	REFERENCES [org].[User] ([ID])

	ALTER TABLE [app].[TicketSequence]  WITH CHECK ADD  CONSTRAINT [FK_TicketSequencePosition] FOREIGN KEY([PositionID])
	REFERENCES [org].[Position] ([ID])

	ALTER TABLE [app].[TicketSequence] CHECK CONSTRAINT [FK_TicketSequencePosition]
	')
END

IF OBJECT_ID('[app].[Ticket]', 'U') IS NULL
BEGIN 
	EXEC ('CREATE TABLE [app].[Ticket](
	[ID] [uniqueidentifier] NOT NULL,
	[ApplicationID] [uniqueidentifier] NOT NULL,
	[SubjectID] [uniqueidentifier] NOT NULL,
	[State] [tinyint] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[CreatorPositionID] [uniqueidentifier] NOT NULL,
	[OwnerID] [uniqueidentifier] NULL,
	[CreationDate] [smalldatetime] NOT NULL,
	[TrackingCode] [nvarchar](50) NULL,
	[Score] [tinyint] NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	ALTER TABLE [app].[Ticket]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
	REFERENCES [org].[Application] ([ID])

	ALTER TABLE [app].[Ticket]  WITH CHECK ADD FOREIGN KEY([SubjectID])
	REFERENCES [app].[TicketSubject] ([ID])
	')
END

IF OBJECT_ID('[app].[TicketSubjectUser]', 'U') IS NULL
BEGIN 
	EXEC ('
	CREATE TABLE [app].[TicketSubjectUser](
	[ID] [uniqueidentifier] NOT NULL,
	[TicketSubjectID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL
	PRIMARY KEY CLUSTERED 
	(
	[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [app].[TicketSubjectUser]  WITH CHECK ADD FOREIGN KEY([TicketSubjectID])
	REFERENCES [app].[TicketSubject] ([ID])

	ALTER TABLE [app].[TicketSubjectUser]  WITH CHECK ADD FOREIGN KEY([UserID])
	REFERENCES [org].[User] ([ID])
	')
END


