CREATE PROCEDURE [dbo].[Pessoa_edit]
	@pessId bigint,
	@pessNome nvarchar(30), 
	@pessDataNascimento nvarchar(30),
	@pessMorada nvarchar(30),
	@pessTelefone nvarchar(30)
AS
BEGIN
	if not ISNULL(@pessNome,'')=''
	  update Pessoa set PESS_nome = @pessNome where PESS_id = @pessId
	if not ISNULL (@pessDataNascimento,'')=''
		update Pessoa set PESS_dataNascimento = @pessDataNascimento where PESS_id = @pessId
	if not ISNULL (@pessMorada,'')=''
		update Pessoa set PESS_morada = @pessMorada where PESS_id = @pessId
	if not ISNULL (@pessTelefone,'')=''
		update Pessoa set PESS_telefone = @pessTelefone where PESS_id = @pessId 
END