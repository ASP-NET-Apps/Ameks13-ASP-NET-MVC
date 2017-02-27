USE [FoodSupplementsSystem]
GO

-- =============================================
-- Author:		<ATo,Alexander Toplijski>
-- Create date: <17.02.2017>
-- Description:	<for the Web Forms project db,>
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_GetRatingByUsernameAndSupplementId'))
   EXEC('CREATE PROCEDURE [dbo].[usp_GetRatingByUsernameAndSupplementId] @Username varchar(30), @SupplementId int AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[usp_GetRatingByUsernameAndSupplementId]
	@Username varchar(30)
	,@SupplementId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    
	DECLARE @CurrentUserId nvarchar(128);
	SET @CurrentUserId = (SELECT users.Id as userId 
		FROM [dbo].[AspNetUsers] as users
		WHERE users.UserName = @Username);

	SELECT r.Id
		,r.Value as Value
		,r.AuthorId as AuthorId
		,r.SupplementId as SupplementId
		--,r.SupplementId as Username
	FROM [dbo].[Ratings] as r
	WHERE (@SupplementId= r.SupplementId) AND (@CurrentUserId = r.AuthorId)

END
GO



