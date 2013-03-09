CREATE PROCEDURE [dbo].[Autocarro_ins]
	@autocarroMatricula nvarchar(20),
	@autocarroMarca nvarchar(30),
	@autocarroTipo bigint,
	@autocarroModelo bigint
AS

BEGIN
  insert into Autocarro(A_matricula, A_M_id, A_T_id, A_MOD_id) values(@autocarroMatricula, @autocarroMarca, @autocarroTipo, @autocarroModelo)
END