IF OBJECT_ID('dbo.WatermarkTable', 'U') IS NULL 
BEGIN
	 create table WatermarkTable
	(

		TableName varchar(255) NOT NULL,
		WatermarkValue datetime2 NOT NULL,
		CONSTRAINT PK_MyTable PRIMARY KEY CLUSTERED (TableName)
	);


END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_write_watermark'))
   exec('CREATE PROCEDURE [dbo].[sp_write_watermark] AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[sp_write_watermark] @LastModifiedtime datetime2, @TableName varchar(255)
AS
BEGIN

	UPDATE WatermarkTable
	SET [WatermarkValue] = @LastModifiedtime 
	WHERE [TableName] = @TableName
	
	IF @@ROWCOUNT=0 
	BEGIN
		insert into WatermarkTable(TableName, WatermarkValue) 
		values(@TableName, @LastModifiedtime);
	END

END


GO

