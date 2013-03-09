CREATE PROCEDURE [dbo].[Marca_SEL1]
@nome nvarchar(30)
AS
BEGIN
	select Marca.M_nome from Marca where Marca.M_nome=@nome
END