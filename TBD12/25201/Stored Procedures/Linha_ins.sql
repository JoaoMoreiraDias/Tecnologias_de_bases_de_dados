CREATE PROCEDURE [dbo].[Linha_ins]
	@linhaId nvarchar(30) 
AS
BEGIN
  insert into Linha(LIN_id) values(@linhaId)
END