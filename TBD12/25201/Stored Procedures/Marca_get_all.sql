CREATE PROCEDURE [dbo].[Marca_get_all] 
as
BEGIN
	SELECT Marca.M_nome from Marca order by Marca.M_nome
END
