USE [FoodSupplementsSystem]
GO

-- =============================================
-- Author:		<ATo,Alexander Toplijski>
-- Create date: <22.02.2017>
-- Description:	<for the Web Forms project db,>
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.usp_GetRatingCountAndAvgBySupplementId'))
   EXEC('CREATE PROCEDURE [dbo].[usp_GetRatingCountAndAvgBySupplementId] @SupplementId int AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE [dbo].[usp_GetRatingCountAndAvgBySupplementId]
	@SupplementId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	    
	DECLARE @RatingsCount int;
	SET @RatingsCount = (
		SELECT Count([Value]) AS VotesCount
		FROM [Ratings] 
		WHERE SupplementId = @SupplementId);

	IF ( @RatingsCount <= 0 )
		BEGIN
			 SELECT 0 AS VotesCount, 
				0 AS VotesAverageValue 
		END
	ELSE
		BEGIN
			 SELECT Count([Value]) AS VotesCount, 
					AVG([Value]) AS VotesAverageValue 
			FROM [Ratings] 
			WHERE SupplementId = @SupplementId 
		END
END
GO



