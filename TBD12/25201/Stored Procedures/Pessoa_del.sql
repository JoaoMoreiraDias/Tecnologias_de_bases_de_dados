CREATE PROCEDURE [dbo].[Pessoa_del]
	@pessId Bigint 
AS
BEGIN
  delete from Pessoa where PESS_id=@pessId
END