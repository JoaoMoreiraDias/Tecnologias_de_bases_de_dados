CREATE PROCEDURE [dbo].[Marca_del]
	@marcaId nvarchar(30) 
AS
BEGIN
  delete from Marca where M_nome=@marcaId
END