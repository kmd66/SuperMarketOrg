USE [Kama.Bonyad.Organization]
GO

IF EXISTS(SELECT 1 FROM sys.procedures WHERE [object_id] = OBJECT_ID('app.spGetApplicationSurveyGroupByList'))
	DROP PROCEDURE app.spGetApplicationSurveyGroupByList
GO

CREATE PROCEDURE app.spGetApplicationSurveyGroupByList
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		[QuestionID],
		[Type],
		Count(*) [Count]
	FROM app.[ApplicationSurveyAnswer] 
	GROUP BY 
		QuestionID,
		[Type]

END