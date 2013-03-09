Public Class AutocarrosMarca
    Private WithEvents myMarca As clsMarca
    Private WithEvents myAutocarro As clsAutocarro

    Public Sub AutocarrosMarca_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myMarca = New clsMarca(dbCNNstr)
        myAutocarro = New clsAutocarro(dbCNNstr)
    End Sub

    'busca a lista de marcas de autocarro
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tbl As New DataTable
        LISTA.DataGridView1.DataSource = myMarca.listaMarca
        LISTA.ShowDialog()
        If Not LISTA.Escolha Is Nothing Then
            myMarca.getMarca(LISTA.Escolha.Cells("M_nome").Value)
            Me.dgMarcaCarro.DataSource = myAutocarro.autocarroSelMarca(LISTA.Escolha.Cells("M_nome").Value)
        End If
    End Sub
End Class