CREATE PROCEDURE [dbo].[Autocarro_del]
	@autocarroMatricula nvarchar(20) 
AS
BEGIN
  delete from Autocarro where Autocarro.A_matricula=@autocarroMatricula
END