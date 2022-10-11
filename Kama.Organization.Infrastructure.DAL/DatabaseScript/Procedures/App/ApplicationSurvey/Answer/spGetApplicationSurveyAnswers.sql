USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyAnswers'))
	DROP PROCEDURE app.spGetApplicationSurveyAnswers
GO

CREATE PROCEDURE app.spGetApplicationSurveyAnswers
	@AUserID uniqueidentifier,
	@ADate SMALLDATETIME,
	@APageSize INT,
	@APageIndex INT
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;
	
	DECLARE 
		@UserID uniqueidentifier = @AUserID,
		@Date SMALLDATETIME = @ADate,
		@PageSize INT = COALESCE(@APageSize,20),
		@PageIndex INT = COALESCE(@APageIndex, 0)

	IF @PageIndex = 0 
	BEGIN
		SET @pagesize = 10000000
		SET @PageIndex = 1
	END

	
	;WITH MainSelect AS (
	SELECT
		Count(*) OVER() Total,
		[ID]
       ,[QuestionID]
       ,[Type]
	   ,Date
	FROM app.[ApplicationSurveyAnswer]
	WHERE (@UserID IS NULL OR UserID = @UserID)
		AND(@Date IS NULL OR Date > @Date)
	)

	SELECT * FROM MainSelect		 
	ORDER BY Date
	OFFSET ((@PageIndex - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;

END