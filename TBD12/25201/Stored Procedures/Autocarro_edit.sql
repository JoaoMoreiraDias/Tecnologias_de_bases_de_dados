CREATE PROCEDURE [dbo].[Autocarro_edit]
	@autocarroMatricula nvarchar(20),
	@autocarroMarca nvarchar(30),
	@autocarroTipo bigint,
	@autocarroModelo bigint
AS
BEGIN
	BEGIN
	if not ISNULL(@autocarroMarca,'')=''
	  update Autocarro set A_M_id = @autocarroMarca where A_matricula = @autocarroMatricula
	if not ISNULL (@autocarroTipo,'')=''
		update Autocarro set A_T_id = @autocarroTipo where A_matricula = @autocarroMatricula
	if not ISNULL (@autocarroModelo,'')=''
		update Autocarro set A_MOD_id = @autocarroModelo where A_matricula = @autocarroMatricula

END
END