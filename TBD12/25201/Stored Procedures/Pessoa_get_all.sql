CREATE PROCEDURE [dbo].[Pessoa_get_all] 
as
BEGIN
	SELECT Pessoa.PESS_id, Pessoa.PESS_nome, Pessoa.PESS_morada, Pessoa.PESS_dataNascimento, Pessoa.PESS_telefone from Pessoa order by Pessoa.PESS_id
END
