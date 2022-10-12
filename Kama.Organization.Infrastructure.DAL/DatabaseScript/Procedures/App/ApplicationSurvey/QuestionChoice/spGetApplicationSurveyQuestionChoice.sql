USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyQuestionChoice'))
	DROP PROCEDURE app.spGetApplicationSurveyQuestionChoice
GO

CREATE PROCEDURE app.spGetApplicationSurveyQuestionChoice
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
		surchoice.ID,
		surchoice.QuestionID,
		surchoice.[Name],
		surquestion.[Name] QuestionName
	FROM app.ApplicationSurveyQuestionChoice AS surchoice
		INNER JOIN app.ApplicationSurveyQuestion surquestion ON surquestion.ID = surchoice.QuestionID
	WHERE surchoice.ID = @ID
		AND surchoice.RemoverPositionID IS NOT NULL
		AND surchoice.RemoveDate IS NOT NULL

	RETURN @@ROWCOUNT
END