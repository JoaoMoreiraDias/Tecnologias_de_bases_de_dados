CREATE PROCEDURE [dbo].[diaSemana_ins]
	@diaSemanaId nvarchar(30) 
AS
BEGIN
  insert into DiaSemana(DS_dia) values(@diaSemanaId)
END