USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyAnswer'))
	DROP PROCEDURE app.spGetApplicationSurveyAnswer
GO

CREATE PROCEDURE app.spGetApplicationSurveyAnswer
	@AID UNIQUEIDENTIFIER
WITH ENCRYPTION
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @ID UNIQUEIDENTIFIER = @AID
	
	SELECT 
		suranswer.ID,
		suranswer.QuestionID,
		suranswer.[Type]
		--sur.[Name] SurveyName,
		--surchoice.[Name] ChoiceName
	FROM app.[ApplicationSurveyAnswer] suranswer
		INNER JOIN app.ApplicationSurveyQuestion surquestion ON surquestion.ID = suranswer.QuestionID
		INNER JOIN app.ApplicationSurveyGroup surgroup ON surgroup.ID = surquestion.GroupID
		--INNER JOIN app.ApplicationSurvey sur ON sur.ID = surgroup.ApplicationSurveyID
		--INNER JOIN app.ApplicationSurveyParticipant surpart ON surpart.ID = suranswer.ParticipantID
		--LEFT JOIN org.[User] us  ON us.ID = surpart.UserID
		--LEFT JOIN app.ApplicationSurveyQuestionChoice surchoice ON surchoice.ID = suranswer.ChoiceID
	WHERE suranswer.ID = @ID

	RETURN @@ROWCOUNT
END