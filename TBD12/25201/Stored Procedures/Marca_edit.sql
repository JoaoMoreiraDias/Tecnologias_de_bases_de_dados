CREATE PROCEDURE [dbo].[Marca_edit]
	@marcaId nvarchar(30) 
AS
BEGIN
	if not ISNULL(@marcaId,'')=''
	  update Marca set M_nome = @marcaId where M_nome = @marcaId
END