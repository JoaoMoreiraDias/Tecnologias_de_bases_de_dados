CREATE PROCEDURE [dbo].[Pessoa_SELTIPO]
	
	@PessoaTipo bigint
	AS
BEGIN
	SELECT     Pessoa.*
FROM         Tipo INNER JOIN
                      Carta ON Tipo.T_id = Carta.D_T_id INNER JOIN
                      Pessoa ON Carta.D_PESS_id = Pessoa.PESS_id
                      where Tipo.T_id=@PessoaTipo
END