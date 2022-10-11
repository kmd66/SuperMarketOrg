USE [Kama.Mefa.Organization]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS(SELECT 1 FROM SYS.objects WHERE [object_id] = OBJECT_ID ('[dbo].[fnTicketNumber]'))
DROP FUNCTION [dbo].fnTicketNumber
GO

CREATE  FUNCTION [dbo].fnTicketNumber()
RETURNS NVARCHAR(50)
AS
BEGIN

DECLARE
	@TrackingCode NVARCHAR(50)

SET @TrackingCode = (SELECT
				 REVERSE(SUBSTRING([dbo].[fnGetShamsiDate](GETDATE()),3,2)
				 + SUBSTRING([dbo].[fnGetShamsiDate](GETDATE()),6,2)
				 + SUBSTRING([dbo].[fnGetShamsiDate](GETDATE()),9,2))
				 + RIGHT('000' + RTRIM(CAST((SELECT
				COUNT(*) + 1
				 FROM app.Ticket ticket
				 WHERE (DATEPART(YEAR, ticket.CreationDate) = DATEPART(YEAR, GETDATE())
				 AND DATEPART(MONTH, ticket.CreationDate) = DATEPART(MONTH, GETDATE())
				 AND DATEPART(DAY, ticket.CreationDate) = DATEPART(DAY, GETDATE())))
				 AS VARCHAR(10))), 3)
				 + '99')

RETURN @TrackingCode
END