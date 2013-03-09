Public Class Inicial

    Private Sub AutocarrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutocarrosToolStripMenuItem.Click
        AutocarrosMarca.ShowDialog()
    End Sub

    Private Sub HabilitaçãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HabilitaçãoToolStripMenuItem.Click
        Habilitacao.ShowDialog()
    End Sub

    Private Sub PessoasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PessoasToolStripMenuItem.Click
        Jornada.ShowDialog()
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class