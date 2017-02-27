USE [FoodSupplementsSystem]
GO

-- =============================================
-- Author:		<ATo,Alexander Toplijski>
-- Create date: <17.02.2017>
-- Description:	<for the Web Forms project db,>
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_GetSupplementRatingBySupplementId'))
   EXEC('CREATE PROCEDURE [dbo].[usp_GetSupplementRatingBySupplementId] @SupplementId int AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[usp_GetSupplementRatingBySupplementId]
	@SupplementId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    
	SELECT Id
		,Value as Value
		,AuthorId as AuthorId
		,SupplementId as SupplementId
	FROM [dbo].[Ratings] as r
	WHERE (@SupplementId= r.SupplementId)

END
GO



