Public Class LISTA
    Private linha As DataGridViewRow

    Public ReadOnly Property Escolha As DataGridViewRow
        Get
            Escolha = linha
        End Get
    End Property

    Private Sub LISTA_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        linha = Nothing
    End Sub

    'Abre o resgisto da linha registada
    Private Sub DataGridView1_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        linha = New DataGridViewRow
        linha = Me.DataGridView1.CurrentRow
        Me.Close()
    End Sub
End Class