CREATE PROCEDURE [dbo].[Pessoa_SEL1]
@id bigint
AS
BEGIN
	select Pessoa.PESS_nome from Pessoa where Pessoa.PESS_id=@id
END