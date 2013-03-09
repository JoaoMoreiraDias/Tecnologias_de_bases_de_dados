Public Class INICIAL

  Private Sub SAIRToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SAIRToolStripMenuItem.Click
    Me.Close()
  End Sub

  Private Sub TiposDeTerceirosToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TiposDeTerceirosToolStripMenuItem1.Click
    TERCT.Show()
  End Sub

  Private Sub AcercaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AcercaToolStripMenuItem.Click
    AcercaDe.ShowDialog()
  End Sub

  Private Sub DocumentosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DocumentosToolStripMenuItem.Click
    DOCDOClin.Show()
  End Sub

End Class