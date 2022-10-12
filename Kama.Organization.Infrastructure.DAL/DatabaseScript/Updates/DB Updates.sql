

--USE [Kama.Sm.Organization]

----ALTER TABLE org.[User]
----ALTER COLUMN NationalCode VARCHAR(18)

--IF COL_LENGTH('org.Department','RemoverID') IS NULL
--BEGIN
--	ALTER TABLE org.Department ADD RemoverID UNIQUEIDENTIFIER NULL 
--	ALTER TABLE org.Department ADD RemoverDate SMALLDATETIME NULL 
--END

--IF COL_LENGTH('org.Department','Address') IS NULL
--BEGIN
--	ALTER TABLE org.Department ADD Address NVARCHAR(1000) NULL 
--	ALTER TABLE org.Department ADD PostalCode CHAR(10) NULL 
--END

--IF OBJECT_ID (N'pbl.Place', N'U') IS NOT NULL
--BEGIN
--	ALTER SCHEMA org
--	TRANSFER pbl.Place
--END

--IF OBJECT_ID (N'pbl.ContactInfo', N'U') IS NOT NULL
--BEGIN
--	DROP TABLE pbl.ContactInfo
--END

--IF OBJECT_ID (N'app.ContactInfo', N'U') IS NULL
--BEGIN
--	Create TABLE app.ContactInfo
--	(
--		ID UNIQUEIDENTIFIER NOT NULL,
--		ParentID UNIQUEIDENTIFIER NOT NULL,
--		Name NVARCHAR(200) NOT NULL,
--		[Order] INT NOT NULL,
--		CreationDate SMALLDATETIME NOT NULL
--		CONSTRAINT PK_ContactInfo PRIMARY KEY CLUSTERED 
--		(
--			ID ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--	) ON [PRIMARY] 

--	Create TABLE app.ContactDetail
--	(
--		ID UNIQUEIDENTIFIER NOT NULL,
--		ContactInfoID UNIQUEIDENTIFIER NOT NULL,
--		Type TINYINT NOT NULL,
--		Name NVARCHAR(200) NULL,
--		Value NVARCHAR(1000) NOT NULL,
--		CreationDate SMALLDATETIME NOT NULL
--		CONSTRAINT PK_ContactDetail PRIMARY KEY CLUSTERED 
--		(
--			ID ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--	) ON [PRIMARY] 

--	ALTER TABLE [app].[ContactDetail]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetail_ContactInfo] FOREIGN KEY([ContactInfoID]) REFERENCES [app].[ContactInfo] ([ID])
--	ALTER TABLE [app].[ContactDetail] CHECK CONSTRAINT [FK_ContactDetail_ContactInfo]
--END

--IF OBJECT_ID('org.PK_PositionType', 'PK') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.PositionType ADD CONSTRAINT PK_PositionType PRIMARY KEY(ID)')
--END

--IF OBJECT_ID('org.PositionTypeRole', 'U') IS NULL
--BEGIN
--	EXEC('CREATE TABLE org.PositionTypeRole(
--			[ID] UNIQUEIDENTIFIER NOT NULL,
--			[ApplicationID] UNIQUEIDENTIFIER NOT NULL,
--			[PositionType] TINYINT NOT NULL,
--			[RoleID] UNIQUEIDENTIFIER NOT NULL,
--			[CreationDate] SMALLDATETIME NOT NULL,
--			CONSTRAINT [PK_PositionTypeRole] PRIMARY KEY CLUSTERED 
--			(
--				[ID] ASC
--			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--			) ON [PRIMARY]')
			
--	EXEC('ALTER TABLE org.[PositionTypeRole] 
--			ADD CONSTRAINT FK_RolePositionTypeRole
--			FOREIGN KEY (RoleID) REFERENCES org.[Role](ID)')
--END

--IF OBJECT_ID('org.UserSetting', 'U') IS NULL
--BEGIN
--	EXEC('CREATE TABLE org.UserSetting(
--			ID UNIQUEIDENTIFIER NOT NULL,
--			UserID UNIQUEIDENTIFIER NOT NULL,
--			Setting NVARCHAR(MAX) NOT NULL
--			CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
--			(
--				[ID] ASC
--			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--			) ON [PRIMARY]')
--	EXEC('ALTER TABLE org.UserSetting WITH CHECK ADD CONSTRAINT [FK_UserSetting_User] FOREIGN KEY([UserID]) REFERENCES [org].[User] ([ID])')
--	EXEC('ALTER TABLE org.UserSetting CHECK CONSTRAINT [FK_UserSetting_User]')
--	EXEC('ALTER TABLE org.UserSetting WITH CHECK ADD CONSTRAINT [UQ_UserSetting_UserID] UNIQUE ([UserID])')
--END

--IF OBJECT_ID('app.FAQGroup', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE app.FAQGroup(
--			[ID] [uniqueidentifier] NOT NULL,
--			[Title] [nvarchar](500) NOT NULL,
--			[CreatorID] [uniqueidentifier] NOT NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--		 CONSTRAINT [PK_FAQGroup] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.FAQ', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE app.FAQ(
--			[ID] [uniqueidentifier] NOT NULL,
--			[FAQGroupID] [uniqueidentifier] NOT NULL,
--			[Question] [nvarchar](500) NOT NULL,
--			[Answer] [nvarchar](500) NOT NULL,
--			[CreatorID] [uniqueidentifier] NOT NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--		 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
	
--	EXEC('ALTER TABLE [app].[FAQ]  WITH CHECK ADD CONSTRAINT FAQ_FAQGroup FOREIGN KEY([FAQGroupID]) REFERENCES [app].[FAQGroup] ([ID])')

--END

----IF COL_LENGTH('org.User','CellPhone') IS NOT NULL
----BEGIN
----	ALTER TABLE org.[User] ALTER COLUMN CellPhone VARCHAR(20) NULL 
----END

--IF OBJECT_ID('org.PositionDepartmentMapping', 'U') IS NULL
--BEGIN
--	CREATE TABLE [org].[PositionDepartmentMapping](
--		[ID] uniqueidentifier NOT NULL,
--		[PositionType] tinyint NOT NULL,
--		[DepartmentType] tinyint NOT NULL,
--		[MaxUsersCount] int NULL,
--		CreationDate SMALLDATETIME
--	CONSTRAINT [PK_PositionDepartmentMapping] PRIMARY KEY CLUSTERED 
--	(
--		[ID] ASC
--	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--	) ON [PRIMARY]
--END

--IF COL_LENGTH('org.Command','CreationDate') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.Command ADD CreationDate SMALLDATETIME NULL')
--	EXEC('Update org.Command SET CreationDate = GETDATE()')
--	EXEC('ALTER TABLE org.Command ALTER Column CreationDate SMALLDATETIME NULL')
--END

--IF COL_LENGTH('org.Command','FullName') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.Command ADD FullName VARCHAR(1000) NULL')
--	EXEC('Update org.Command SET FullName = Name')
--	EXEC('ALTER TABLE org.Command ALTER Column FullName VARCHAR(1000) NOT NULL')
--END

--IF COL_LENGTH('org.PositionDepartmentMapping','ApplicationID') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.PositionDepartmentMapping ADD ApplicationID UNIQUEIDENTIFIER NOT NULL')
--END

--IF NOT EXISTS (SELECT TOP 1 1 FROM org.Command WHERE Type = 10)
--BEGIN
--	EXEC('Update org.Command Set Type = 10 WHERE Type = 5')
--	EXEC('Update org.Command Set Type = 20 WHERE Type = 4')
--END

--IF OBJECT_ID('org.SecurityStamp', 'U') IS NULL
--BEGIN
--	EXEC('Create Table org.SecurityStamp
--		(
--			ID UNIQUEIDENTIFIER NOT NULL Primary KEY,
--			CellPhone VARCHAR(20) NULL,
--			Email NVARCHAR(200) NULL,
--			Stamp VARCHAR(256) 
--		)'
--	)
--END

--IF COL_LENGTH('org.User','SecurityStamp') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE org.[User] DROP COLUMN SecurityStamp')
--END 

--IF OBJECT_ID('org.Client', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [org].[Client](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](200) NOT NULL,
--			[Secret] [nvarchar](4000) NULL,
--			[Type] [tinyint] NOT NULL,
--			[Enabled] [bit] NOT NULL,
--			[RefreshTokenLifeTime] [int] NOT NULL,
--			[AllowedOrigin] [nvarchar](4000) NULL,
--		 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--		')

--	EXEC('ALTER TABLE [org].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Application] FOREIGN KEY([ApplicationID]) REFERENCES [org].[Application] ([ID])')

--	EXEC('ALTER TABLE [org].[Client] CHECK CONSTRAINT [FK_Client_Application]')

--	INSERT INTO org.Client
--	(ID, ApplicationID, [Name], [Secret], [Type], [Enabled], RefreshTokenLifeTime, AllowedOrigin)
--	VALUES
--	('2C7E20AA-D225-41FE-8DFF-4D016D0D182D', '2AC51699-9656-4060-B632-B85E4AF705BA', '', '', 1, 1, 1440, 'localhost'),
--	('325ED74C-8441-41A4-92E4-281A8603C9FD', '67E63B1D-E423-46CC-ADB2-2D6A46226141', '', '', 1, 1, 1440, 'localhost'),
--	('7F401D5A-9FB4-4993-8E2F-8268442D3665', '6448C892-F0C7-4002-B139-011CB2E57D14', '', '', 1, 1, 1440, 'localhost')

--END

--IF OBJECT_ID('org.RefreshToken', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [org].[RefreshToken](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ClientID] [uniqueidentifier] NOT NULL,
--			[IssuedDate] [datetime] NOT NULL,
--			[ExpireDate] [datetime] NOT NULL,
--			[ProtectedTicket] [nvarchar](4000) NOT NULL,
--			[UserName] [varchar](50) NULL,
--		 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--		'
--	)
--	EXEC('ALTER TABLE [org].[RefreshToken]  WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_Client] FOREIGN KEY([ClientID]) REFERENCES [org].[Client] ([ID])')
--	EXEC('ALTER TABLE [org].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_Client]')

--END

--IF COL_LENGTH('org.RefreshToken','UserName') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE org.RefreshToken DROP Column UserName')
--	EXEC('ALTER TABLE org.RefreshToken ADD UserID UNIQUEIDENTIFIER')

--	EXEC('ALTER TABLE [org].[RefreshToken] WITH CHECK ADD  CONSTRAINT [FK_RefreshToken_User] FOREIGN KEY([UserID]) REFERENCES [org].[User] ([ID])')
--	EXEC('ALTER TABLE [org].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_User]')
--END

--IF COL_LENGTH('org.RefreshToken','ClientID') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE [org].[RefreshToken] DROP CONSTRAINT [FK_RefreshToken_Client]')
--	EXEC('ALTER TABLE org.RefreshToken DROP Column ClientId')
--END
--Update org.Command Set Type = 10 WHERE Type = 5
--Update org.Command Set Type = 20 WHERE Type = 4

--IF COL_LENGTH('app.Message','Type') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE app.Message Drop Column [Type]')
--END

--IF COL_LENGTH('app.Message','SenderID') IS NOT NULL
--BEGIN
--	EXEC sp_rename 'app.Message.SenderID', 'SenderUserID', 'COLUMN';
--END

--IF COL_LENGTH('app.Announcement','AuthorizedUsers') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement ADD AuthorizedUsers BIT')
--	EXEC('Update app.Announcement SET AuthorizedUsers = 0')
--	EXEC('ALTER TABLE app.Announcement ALTER Column AuthorizedUsers BIT NOT NULL')
--END

--IF COL_LENGTH('app.Announcement','UnAuthorizedUsers') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement ADD UnAuthorizedUsers BIT')
--	EXEC('Update app.Announcement SET UnAuthorizedUsers = 0')
--	EXEC('ALTER TABLE app.Announcement ALTER Column UnAuthorizedUsers BIT NOT NULL')
--END

--IF COL_LENGTH('app.Announcement','Expanded') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement ADD Expanded BIT NULL')
--	EXEC('UPDATE app.Announcement SET Expanded = 1')
--	EXEC('ALTER TABLE app.Announcement ALTER COLUMN Expanded BIT NOT NULL')
--END

--IF COL_LENGTH('app.Announcement','ProvinceID') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement ADD ProvinceID UNIQUEIDENTIFIER NULL')
--END

--IF COL_LENGTH('app.Message','Type') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Message ADD Type TINYINT NULL')
--END

--IF COL_LENGTH('app.Announcement','PlaceID') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement DROP COLUMN PlaceID')
--END

--IF COL_LENGTH('app.Message','Priority') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Message ADD Priority TINYINT NULL')
--END

--IF OBJECT_ID('app.NotificationUser', 'U') IS NOT NULL
--BEGIN
--	EXEC('DROP TABLE app.NotificationUser')
--END

--IF OBJECT_ID('app.Notification', 'U') IS NULL
--BEGIN
--	EXEC('
--	CREATE TABLE app.[Notification](
--		ID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
--		ApplicationID UNIQUEIDENTIFIER NOT NULL CONSTRAINT fk_Notification_Application FOREIGN KEY REFERENCES org.[Application](ID),
--		SenderPositionID UNIQUEIDENTIFIER NULL,
--		Title NVARCHAR(300) NULL,
--		Content NVARCHAR(MAX) NULL,
--		[Priority] TINYINT NOT NULL,
--		[State] TINYINT NOT NULL,
--		CreationDate SMALLDATETIME NOT NULL
--	);
--	')
--END

--IF OBJECT_ID('app.NotificationPosition', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[NotificationPosition](
--			[ID] [uniqueidentifier] NOT NULL,
--			[NotificationID] [uniqueidentifier] NOT NULL,
--			[PositionID] [uniqueidentifier] NOT NULL,
--			[IsRemoved] [bit] NULL,
--		PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')

--	EXEC('ALTER TABLE [app].[NotificationPosition]  WITH CHECK ADD  CONSTRAINT [fk_NotificationPosition_Notification] FOREIGN KEY([NotificationID]) REFERENCES [app].[Notification] ([ID])')
--	EXEC('ALTER TABLE [app].[NotificationPosition] CHECK CONSTRAINT [fk_NotificationPosition_Notification]')
--	EXEC('ALTER TABLE [app].[NotificationPosition]  WITH CHECK ADD  CONSTRAINT [fk_NotificationPosition_Position] FOREIGN KEY([PositionID]) REFERENCES [org].[Position] ([ID])')
--	EXEC('ALTER TABLE [app].[NotificationPosition] CHECK CONSTRAINT [fk_NotificationPosition_Position]')

--END

--IF COL_LENGTH('app.Announcement','Priority') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.Announcement ADD Priority TINYINT')
--	EXEC('Update app.Announcement SET Priority = 2')
--	EXEC('ALTER TABLE app.Announcement ALTER Column Priority TINYINT NOT NULL')
--END

--IF OBJECT_ID('app.NotificationReceiverCondition', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE app.NotificationReceiverCondition(
--			ID UNIQUEIDENTIFIER NOT NULL,
--			NotificationID UNIQUEIDENTIFIER NOT NULL,
--			DepartmentID UNIQUEIDENTIFIER  NULL,
--			PositionType TINYINT  NULL,
--			ProvinceID UNIQUEIDENTIFIER  NULL

--			PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.NotificationReceiverCondition', 'U') IS NOT NULL
--BEGIN
--	EXEC('DROP TABLE app.NotificationReceiverCondition')
--END



--IF OBJECT_ID('app.NotificationCondition', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE app.NotificationCondition(
--			ID UNIQUEIDENTIFIER NOT NULL,
--			NotificationID UNIQUEIDENTIFIER NOT NULL,
--			DepartmentID UNIQUEIDENTIFIER  NULL,
--			PositionType TINYINT  NULL,
--			ProvinceID UNIQUEIDENTIFIER  NULL,
--			PositionID UNIQUEIDENTIFIER  NULL

--			PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurvey', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurvey](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](200) NOT NULL,
--			[Enable] [bit] NOT NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--			[RemoverPositionID] [uniqueidentifier] NULL,
--			[RemoveDate] [smalldatetime] NULL,
--		 CONSTRAINT [PK_ApplicationSurvey] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurveyAnswer', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurveyAnswer](
--			[ID] [uniqueidentifier] NOT NULL,
--			[QuestionID] [uniqueidentifier] NOT NULL,
--			[Agree] [bit] NULL,
--			[ChoiceID] [uniqueidentifier] NULL,
--			[Text] [nvarchar](1000) NULL,
--			[ParticipantID] [uniqueidentifier] NOT NULL,
--		 CONSTRAINT [PK_ApplicationSurveyAnswer] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurveyGroup', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurveyGroup](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationSurveyID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](200) NOT NULL,
--			[RemoverPositionID] [uniqueidentifier] NULL,
--			[RemoveDate] [smalldatetime] NULL,
--		 CONSTRAINT [PK_ApplicationSurveyGroup] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurveyParticipant', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurveyParticipant](
--			[ID] [uniqueidentifier] NOT NULL,
--			[SurveyID] [uniqueidentifier] NOT NULL,
--			[UserID] [uniqueidentifier] NULL,
--			[Date] [smalldatetime] NOT NULL,
--		 CONSTRAINT [PK_ApplicationSurveyParticipant] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurveyQuestion', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurveyQuestion](
--			[ID] [uniqueidentifier] NOT NULL,
--			[GroupID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](1000) NOT NULL,
--			[Type] [tinyint] NOT NULL,
--			[RemoverPositionID] [uniqueidentifier] NULL,
--			[RemoveDate] [smalldatetime] NULL,
--		 CONSTRAINT [PK_ApplicationSurveyQuestion] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('app.ApplicationSurveyQuestionChoice', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[ApplicationSurveyQuestionChoice](
--			[ID] [uniqueidentifier] NOT NULL,
--			[QuestionID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](200) NOT NULL,
--		 CONSTRAINT [PK_ApplicationSurveyQuestionChoice] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF (SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='FK_ApplicationSurveyGroup_ApplicationSurvey') IS NULL
--BEGIN
--	EXEC('
--		ALTER TABLE [app].[ApplicationSurvey]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurvey_Application] FOREIGN KEY([ApplicationID])
--		REFERENCES [org].[Application] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurvey] CHECK CONSTRAINT [FK_ApplicationSurvey_Application]
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyParticipant] FOREIGN KEY([ParticipantID])
--		REFERENCES [app].[ApplicationSurveyParticipant] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer] CHECK CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyParticipant]
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyQuestion] FOREIGN KEY([QuestionID])
--		REFERENCES [app].[ApplicationSurveyQuestion] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer] CHECK CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyQuestion]
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyQuestionChoice] FOREIGN KEY([ChoiceID])
--		REFERENCES [app].[ApplicationSurveyQuestionChoice] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyAnswer] CHECK CONSTRAINT [FK_ApplicationSurveyAnswer_ApplicationSurveyQuestionChoice]
		
--		ALTER TABLE [app].[ApplicationSurveyGroup]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyGroup_ApplicationSurvey] FOREIGN KEY([ApplicationSurveyID])
--		REFERENCES [app].[ApplicationSurvey] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyGroup] CHECK CONSTRAINT [FK_ApplicationSurveyGroup_ApplicationSurvey]
		
--		ALTER TABLE [app].[ApplicationSurveyQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyQuestion_ApplicationSurveyGroup] FOREIGN KEY([GroupID])
--		REFERENCES [app].[ApplicationSurveyGroup] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyQuestion] CHECK CONSTRAINT [FK_ApplicationSurveyQuestion_ApplicationSurveyGroup]
		
--		ALTER TABLE [app].[ApplicationSurveyQuestionChoice]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyQuestionChoice_ApplicationSurveyQuestion] FOREIGN KEY([QuestionID])
--		REFERENCES [app].[ApplicationSurveyQuestion] ([ID])
		
--		ALTER TABLE [app].[ApplicationSurveyQuestionChoice] CHECK CONSTRAINT [FK_ApplicationSurveyQuestionChoice_ApplicationSurveyQuestion]
--	')
--END

--IF COL_LENGTH('app.ApplicationSurveyQuestionChoice','RemoverPositionID') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.ApplicationSurveyQuestionChoice ADD  RemoverPositionID UNIQUEIDENTIFIER NOT NULL')
--END

--IF COL_LENGTH('app.ApplicationSurveyQuestionChoice','RemoverPositionID') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE app.ApplicationSurveyQuestionChoice ALTER COLUMN RemoverPositionID UNIQUEIDENTIFIER NULL')
--END


--IF COL_LENGTH('app.ApplicationSurveyQuestionChoice','RemoveDate') IS NULL
--BEGIN
--	EXEC('ALTER TABLE app.ApplicationSurveyQuestionChoice ADD  RemoveDate SMALLDATETIME NULL')
--END

--IF COL_LENGTH('app.ApplicationSurveyQuestionChoice','RemoveDate') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE app.ApplicationSurveyQuestionChoice ALTER COLUMN  RemoveDate SMALLDATETIME NULL')
--END


--IF OBJECT_ID('[app].[Ticket]', 'U') IS NULL
--BEGIN
--	EXEC('
--		CREATE TABLE [app].[Ticket](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--			[SubjectID] [uniqueidentifier] NOT NULL,
--			[State] [tinyint] NOT NULL,
--			[Title] [nvarchar](200) NOT NULL,
--			[Priority] [tinyint] NOT NULL,
--			[CreatorID] [uniqueidentifier] NOT NULL,
--			[OwnerID] [uniqueidentifier] NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--		PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
		

--		ALTER TABLE [app].[Ticket]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
--		REFERENCES [org].[Application] ([ID])
		

--		ALTER TABLE [app].[Ticket]  WITH CHECK ADD FOREIGN KEY([SubjectID])
--		REFERENCES [app].[TicketSubject] ([ID])
--		')
--END

--IF OBJECT_ID('[app].[TicketSequence]', 'U') IS NULL
--BEGIN
--	EXEC(' CREATE TABLE [app].[TicketSequence](
--			[ID] [uniqueidentifier] NOT NULL,
--			[TicketID] [uniqueidentifier] NOT NULL,
--			[UserID] [uniqueidentifier] NOT NULL,
--			[Content] [nvarchar](4000) NOT NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--		PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]

--		ALTER TABLE [app].[TicketSequence]  WITH CHECK ADD FOREIGN KEY([TicketID])
--		REFERENCES [app].[Ticket] ([ID])

--		ALTER TABLE [app].[TicketSequence]  WITH CHECK ADD FOREIGN KEY([UserID])
--		REFERENCES [org].[User] ([ID])
--	')
--END

--IF OBJECT_ID('[app].[TicketSubject]', 'U') IS NULL
--BEGIN
--	EXEC('CREATE TABLE [app].[TicketSubject](
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--			[Name] [nvarchar](200) NOT NULL,
--		PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]

--	')
--END

--IF OBJECT_ID('[app].[TicketSubjectUser]', 'U') IS NULL
--BEGIN
--	EXEC(' CREATE TABLE [app].[TicketSubjectUser](
--			[ID] [uniqueidentifier] NOT NULL,
--			[TicketSubjectID] [uniqueidentifier] NOT NULL,
--			[UserID] [uniqueidentifier] NOT NULL,
--		PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]

--		ALTER TABLE [app].[TicketSubjectUser]  WITH CHECK ADD FOREIGN KEY([TicketSubjectID])
--		REFERENCES [app].[TicketSubject] ([ID])

--		ALTER TABLE [app].[TicketSubjectUser]  WITH CHECK ADD FOREIGN KEY([UserID])
--		REFERENCES [org].[User] ([ID])
--	')
--END

--IF COL_LENGTH('app.Ticket','CreatorID') IS NOT NULL
--BEGIN
--	EXEC sp_RENAME 'app.Ticket.CreatorID' , 'CreatorPositionID', 'COLUMN'
--END 

--IF COL_LENGTH('app.Ticket','TrackingCode') IS NULL
--BEGIN 
--	EXEC ('ALTER TABLE app.Ticket ADD TrackingCode NVARCHAR(50) NULL')
--END
--IF COL_LENGTH('app.Message','Priority') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE app.Message DROP COLUMN Priority')
--END

--IF (OBJECT_ID (N'pbl.PasswordBlackList', N'U')) IS NULL 
--BEGIN
--	exec('
--		CREATE TABLE pbl.PasswordBlackList(
--		[ID] UNIQUEIDENTIFIER not null,
--		[Password] varchar(1000) not null,
--		[RepeatCount] int not null,
--		[CreationDate] smalldatetime not null,
--		constraint PK_PasswordBlackList primary key clustered
--		(
--				[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		) ON [PRIMARY]
--	')
--END

--IF OBJECT_ID('[org].[WebServiceUser]', 'U') IS NULL
--BEGIN
--	EXEC(
--	'
--	CREATE TABLE [org].[WebServiceUser](
--		[ID] [uniqueidentifier] NOT NULL,
--		[UserName] [nvarchar](50) NOT NULL,
--		[Password] [nvarchar](1000) NOT NULL,
--		[OrganID] [uniqueidentifier] NOT NULL,
--		[Enabled] [bit] NOT NULL,
--		[PasswordExpireDate] [smalldatetime] NOT NULL,
--		[Comment] [nvarchar](1000) NULL,
--		[CreatorID] [uniqueidentifier] NOT NULL,
--		[CreationDate] [smalldatetime] NOT NULL,
--	 CONSTRAINT [PK_WebServiceUser] PRIMARY KEY CLUSTERED 
--	(
--		[ID] ASC
--	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--	) ON [PRIMARY]
--	')
--END

--IF (OBJECT_ID (N'org.DynamicPermission', N'U')) IS NULL 
--BEGIN
--	EXEC('
--		CREATE TABLE org.DynamicPermission(
--			[ID] [uniqueidentifier] NOT NULL,
--			[ApplicationID] [uniqueidentifier] NOT NULL,
--			[ObjectID] [uniqueidentifier] NOT NULL,
--			[Order] [int] NOT NULL,
--			[CreationDate] [smalldatetime] NOT NULL,
--		 CONSTRAINT [PK_DynamicPermission] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--		) ON [PRIMARY]
--	')

--	EXEC('
--		CREATE TABLE [org].[DynamicPermissionDetail](
--			[ID] [uniqueidentifier] NOT NULL,
--			[DynamicPermissionID] [uniqueidentifier] NOT NULL,
--			[Type] [tinyint] NOT NULL,
--			[GuidValue] [uniqueidentifier] NULL,
--			[ByteValue] [tinyint] NOT NULL,
--		 CONSTRAINT [PK_DynamicPermissionDetail] PRIMARY KEY CLUSTERED 
--		(
--			[ID] ASC
--		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--		) ON [PRIMARY]
--	')

--	EXEC('ALTER TABLE [org].[DynamicPermissionDetail]  WITH CHECK ADD  CONSTRAINT [FK_DynamicPermissionDetail_DynamicPermission] FOREIGN KEY([DynamicPermissionID]) REFERENCES [org].[DynamicPermission] ([ID])')

--	EXEC('ALTER TABLE [org].[DynamicPermissionDetail] CHECK CONSTRAINT [FK_DynamicPermissionDetail_DynamicPermission]')

--END

--IF COL_LENGTH('org.SecurityStamp','CreationDate') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.SecurityStamp ADD CreationDate DateTime NULL')
--END

--IF COL_LENGTH('org.Position','LastTokenDate') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.Position ADD LastTokenDate DATETIME NULL')
--END

--IF COL_LENGTH('org.[User]','Foreigner') IS NULL
--BEGIN
--	EXEC('ALTER TABLE org.[User] ADD Foreigner BIT')
--END

--IF COL_LENGTH('org.[Position]','Node') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE org.[Position] DROP COLUMN Node')
--END

--IF COL_LENGTH('[app].[ApplicationSurveyAnswer]','UserID') IS NULL
--BEGIN 
--	EXEC ('ALTER TABLE [app].[ApplicationSurveyAnswer] ADD UserID UNIQUEIDENTIFIER NOT NULL')
--END

--select COL_LENGTH('[app].[ApplicationSurveyAnswer]','ParticipantID') IS NULL
--BEGIN 
--	EXEC ('ALTER TABLE [app].[ApplicationSurveyAnswer] ADD Date SMALLDATETIME NOT NULL')
--END

--IF COL_LENGTH('[app].[ApplicationSurveyAnswer]','Agree') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE [app].[ApplicationSurveyAnswer] DROP COLUMN Agree')
--END

--IF COL_LENGTH('[app].[ApplicationSurveyAnswer]','ParticipantID') IS NOT NULL
--BEGIN
--	EXEC('ALTER TABLE [app].[ApplicationSurveyAnswer] DROP CONSTRAINT FK_ApplicationSurveyAnswer_ApplicationSurveyParticipant')
--	EXEC('ALTER TABLE [app].[ApplicationSurveyAnswer] DROP COLUMN [ParticipantID]')
--END

IF COL_LENGTH('app.[ApplicationSurveyAnswer]','ChoiceID') IS NOT NULL
BEGIN
	EXEC('ALTER TABLE app.[ApplicationSurveyAnswer] DROP CONSTRAINT FK_ApplicationSurveyAnswer_ApplicationSurveyQuestionChoice')
	EXEC('ALTER TABLE [app].[ApplicationSurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationSurveyAnswer_User] FOREIGN KEY([UserID]) REFERENCES [org].[User] ([ID])')
	EXEC('ALTER TABLE app.[ApplicationSurveyAnswer] DROP COLUMN ChoiceID')
END

IF COL_LENGTH('app.[ApplicationSurveyAnswer]','Text') IS NOT NULL
BEGIN
	EXEC('ALTER TABLE app.[ApplicationSurveyAnswer] DROP COLUMN Text')
END

IF COL_LENGTH('app.[ApplicationSurveyAnswer]','Type') IS NULL
BEGIN
	EXEC('ALTER TABLE app.[ApplicationSurveyAnswer] ADD [Type] TINYINT  NOT NULL DEFAULT(0)')
END
