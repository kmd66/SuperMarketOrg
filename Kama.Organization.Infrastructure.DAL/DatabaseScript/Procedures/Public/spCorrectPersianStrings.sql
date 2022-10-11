USE [Kama.Bonyad.Organization]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spCorrectPersianStrings') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.spCorrectPersianStrings
GO

CREATE PROCEDURE dbo.spCorrectPersianStrings

AS
BEGIN

	DECLARE 
		@Schema NVARCHAR(MAX),  
		@Table NVARCHAR(MAX), 
		@Column NVARCHAR(MAX)

	DECLARE Table_Cursor CURSOR
	FOR
	--پیدا کردن تمام فیلدهای متنی تمام جداول دیتابیس جاری
	SELECT 
		sh.name,  -- schema
		t.name,   -- table
		c.name    -- column
	FROM sys.objects t,sys.syscolumns c, sys.schemas sh
	WHERE  t.object_id = C.id  
		AND t.schema_id = sh.schema_id
		AND t.type = 'U' /* User Table */
        AND (C.xtype = 99 /* ntext */
			OR C.xtype = 35   /* text */
			OR C.xtype = 231  /* nvarchar */
			OR C.xtype = 167  /* varchar */
			OR C.xtype = 175  /* char */
			OR C.xtype = 239  /* nchar */)
	Order by t.name, sh.name, c.name		

	OPEN Table_Cursor FETCH NEXT FROM Table_Cursor 
	INTO @Schema, 
		@Table, 
		@Column
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		EXEC ('Update [' + @Schema + '].[' + @Table + '] Set [' + @Column + '] = REPLACE(REPLACE(CAST([' + @Column +	'] as nvarchar(max)), NCHAR(1610), NCHAR(1740)), NCHAR(1603), NCHAR(1705))')
	FETCH NEXT FROM Table_Cursor 
	INTO @Schema, 
		@Table, 
		@Column
	END CLOSE Table_Cursor 
	DEALLOCATE Table_Cursor


END