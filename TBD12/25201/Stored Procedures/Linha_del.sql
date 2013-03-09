CREATE PROCEDURE [dbo].[Linha_del]
	@linhaId nvarchar(30) 
AS
BEGIN
  delete from Linha where LIN_id=@linhaId
END