CREATE PROCEDURE [dbo].[Marca_ins]
	@marcaId nvarchar(30) 
AS
BEGIN
  insert into Marca(M_nome) values(@marcaId)
END