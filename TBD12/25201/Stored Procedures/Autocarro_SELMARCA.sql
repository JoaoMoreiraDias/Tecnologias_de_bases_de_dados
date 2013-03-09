CREATE PROCEDURE [dbo].[Autocarro_SELMARCA]
	
	@autocarro_Marca bigint
	AS
BEGIN
	SELECT Autocarro.A_id, Autocarro.A_matricula, Autocarro.A_M_id, Autocarro.A_T_id, Autocarro.A_MOD_id from Autocarro 
	where Autocarro.A_M_id = @autocarro_Marca 
END