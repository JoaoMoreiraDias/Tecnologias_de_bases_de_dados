CREATE PROCEDURE [dbo].[Tipo_get_all] 
as
BEGIN
	SELECT Tipo.T_id, Tipo.T_nome, Tipo.T_lugares_em_pe, Tipo.T_lugares_sentados from Tipo order by Tipo.T_nome
END
