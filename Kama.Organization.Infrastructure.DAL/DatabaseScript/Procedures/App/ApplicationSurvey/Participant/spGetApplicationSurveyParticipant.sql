USE [Kama.Sm.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyParticipant'))
	DROP PROCEDURE app.spGetApplicationSurveyParticipant
GO

CREATE PROCEDURE app.spGetApplicationSurveyParticipant
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
		surpart.ID,
		surpart.SurveyID,
		surpart.UserID,
		us.FirstName + ' ' + us.LastName UserFullName,
		surpart.[Date],
		sur.[Name] SurveyName
	FROM app.ApplicationSurveyParticipant  surpart
	INNER JOIN app.ApplicationSurveyAnswer suranswer ON suranswer.ParticipantID = surpart.ID
	INNER JOIN app.ApplicationSurveyQuestion surquestion ON surquestion.ID = suranswer.QuestionID
		INNER JOIN app.ApplicationSurveyGroup surgroup ON surgroup.ID = surquestion.GroupID
		INNER JOIN app.ApplicationSurvey sur ON sur.ID = surgroup.ApplicationSurveyID
		LEFT JOIN org.[User] us  ON us.ID = surpart.UserID
	WHERE surpart.ID = @ID

	RETURN @@ROWCOUNT
END