CREATE PROCEDURE [dbo].[DiaSemana_del]
	@diaSemanaId nvarchar(30) 
AS
BEGIN
  delete from DiaSemana where DS_dia=@diaSemanaId
END