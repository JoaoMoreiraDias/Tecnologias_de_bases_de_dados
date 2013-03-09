Public Class LISTA
    Private linha As DataGridViewRow
    Private WithEvents myIndiv As clsIndiv

    Public ReadOnly Property Escolha As DataGridViewRow
        Get
            Escolha = linha
        End Get
    End Property

    Private Sub LISTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        linha = Nothing
    End Sub

    'Este event DoubleCLick abre o resgisto relativo a linha seleciona
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        linha = New DataGridViewRow
        linha = Me.DataGridView1.CurrentRow
        Me.Close()
    End Sub
End Class