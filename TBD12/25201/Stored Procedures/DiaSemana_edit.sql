CREATE PROCEDURE [dbo].[DiaSemana_edit]
	@diaSemanaId nvarchar(30) 
AS
BEGIN
	if not ISNULL(@diaSemanaId,'')=''
	  update DiaSemana set DS_dia = @diaSemanaId where DS_dia = @diaSemanaId
END