CREATE PROCEDURE [dbo].[Tipo_SEL1]
@id bigint
AS
BEGIN
	select Tipo.T_nome from Tipo where Tipo.T_id=@id
END