CREATE PROCEDURE [dbo].[Linha_edit]
	@linhaId nvarchar(30) 
AS
BEGIN
	if not ISNULL(@linhaId,'')=''
	  update Linha set LIN_id = @linhaId where LIN_id = @linhaId
END