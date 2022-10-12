USE [Kama.Sm.Organization]
GO

IF OBJECT_ID('pbl.GetContextData') IS NOT NULL
	DROP FUNCTION pbl.GetContextData
GO

CREATE FUNCTION pbl.GetContextData (@AKey VARCHAR(50))
RETURNS NVARCHAR(256)
AS
BEGIN
	DECLARE @contextKey NVARCHAR(128) = N'Kama_App_DB_ContextInfo'
	      , @Key VARCHAR(50) = @AKey
		  , @JsonValue NVARCHAR(MAX)
		  , @Value NVARCHAR(256)


	SET @JsonValue = CAST(SESSION_CONTEXT(@contextKey) AS NVARCHAR(MAX))

	SET @Value = (SELECT TOP(1) [Value] FROM OPENJSON(@JsonValue) WHERE [Key] = @Key)

	SET @JsonValue = NULL

	RETURN @Value

END
GO

