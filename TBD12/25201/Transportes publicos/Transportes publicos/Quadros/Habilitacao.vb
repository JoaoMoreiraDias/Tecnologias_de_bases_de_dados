Public Class Habilitacao

    Private WithEvents myTipo As clsTipo
    Private WithEvents myPessoa As clsPessoa

    Public Sub Habilitacao_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myTipo = New clsTipo(dbCNNstr)
        myPessoa = New clsPessoa(dbCNNstr)
    End Sub

    '
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tbl As New DataTable
        LISTA.DataGridView1.DataSource = myTipo.listaTipo
        LISTA.ShowDialog()
        If Not LISTA.Escolha Is Nothing Then
            myTipo.getTipo(LISTA.Escolha.Cells("T_id").Value)
            Me.dgTipoPessoa.DataSource = myPessoa.pessoaSelTipo(LISTA.Escolha.Cells("T_id").Value)
        End If
    End Sub
End Class