USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spSetAnnouncementOrders'))
	DROP PROCEDURE app.spSetAnnouncementOrders
GO

CREATE PROCEDURE app.spSetAnnouncementOrders
	@AOrders NVARCHAR(MAX),
	@ALog NVARCHAR(MAX),
	@AResult NVARCHAR(MAX) OUTPUT
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE   
		@Orders NVARCHAR(MAX) = @AOrders,
		@Log NVARCHAR(MAX) = LTRIM(RTRIM(@ALog)),
		@Result NVARCHAR(MAX)

	BEGIN TRY
		BEGIN TRAN
			update announcement 
			set announcement.[Order] = orders.[Order]
			from openjson(@Orders)
			with (
				ID UNIQUEIDENTIFIER,
				[Order] INT
			) orders
			inner join app.announcement announcement on orders.ID = announcement.ID 

			EXEC pbl.spAddLog @Log

		COMMIT
	END TRY
	BEGIN CATCH
		;THROW
	END CATCH
	
	RETURN @@ROWCOUNT
END