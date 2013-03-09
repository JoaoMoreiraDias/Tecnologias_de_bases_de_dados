Public Class TERCT
  Private WithEvents myTERCT As clsTERCT
  Private novoREG As Boolean

  Private Sub TERCT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    myTERCT = New clsTERCT(dbCNNstr)
    Call prepForm(0)
  End Sub

  Sub prepForm(ByVal status As Integer)
    Select Case status
      Case 0
        btnNOVO.Enabled = True
        btnBUSCA.Enabled = True
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = False
        btnCANCELAR.Enabled = False
        Me.txtTTCOD.ReadOnly = True
        Me.txtTTDESCR.ReadOnly = False

      Case 1
        btnNOVO.Enabled = False
        btnBUSCA.Enabled = False
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = True
        btnCANCELAR.Enabled = True
        Me.txtTTCOD.ReadOnly = False
        Me.txtTTDESCR.ReadOnly = False

      Case 3
        btnNOVO.Enabled = True
        btnBUSCA.Enabled = True
        btnEDITAR.Enabled = True
        btnELIMINAR.Enabled = True
        btnGRAVAR.Enabled = False
        btnCANCELAR.Enabled = False
        Me.txtTTCOD.ReadOnly = True
        Me.txtTTDESCR.ReadOnly = False
    End Select
  End Sub

  Private Sub clsTERCTErrors(ByVal msg As String) Handles myTERCT.Errors
    MsgBox(msg, MsgBoxStyle.Exclamation, "Terc T")
  End Sub

  Private Sub clsTERCTAction(ByVal status As Short) Handles myTERCT.Action
    Select Case status
      Case -1
        Call mostraDados()
        Call prepForm(3)
      Case 2
        Call prepForm(1)
        novoREG = True
        txtTTDESCR.Focus()
      Case 5
        MsgBox("Registo com chave duplicada", MsgBoxStyle.Exclamation, "Terc T")
        txtTTCOD.Focus()
      Case 6
        MsgBox("Registo Eliminado", MsgBoxStyle.Information, "Terc T")
        Call newTERCT()
        Call prepForm(0)
        txtTTCOD.Focus()
      Case 7
        MsgBox("Registo actualizado.", MsgBoxStyle.Information, "Terc T")
        Call prepForm(3)
        txtTTCOD.Focus()
      Case 8
        MsgBox("Registo inserido", MsgBoxStyle.Information, "Terc T")
        Call prepForm(3)
        txtTTCOD.Focus()
    End Select
  End Sub

  Private Sub mostraDados()
    txtTTCOD.Text = myTERCT.COD
    txtTTDESCR.Text = myTERCT.DESCR
  End Sub

  Private Sub newTERCT()
    Me.txtTTCOD.Text = ""
    Me.txtTTDESCR.Text = ""
    Me.txtTTCOD.Focus()
    novoREG = True
  End Sub

  Private Sub btnBUSCA_Click(sender As System.Object, e As System.EventArgs) Handles btnBUSCA.Click
    Dim tbl As New DataTable
    LISTA.DataGridView1.DataSource = myTERCT.listTERCT
    LISTA.ShowDialog()
    If Not LISTA.Escolha Is Nothing Then
      myTERCT.getTERCT(LISTA.Escolha.Cells("TT_COD").Value)
    End If
  End Sub

  Private Sub btnNOVO_Click(sender As System.Object, e As System.EventArgs) Handles btnNOVO.Click
    Call newTERCT()
    Call prepForm(1)
  End Sub

  Private Sub btnEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles btnEDITAR.Click
    novoREG = False
    Call prepForm(1)
    Me.txtTTDESCR.Focus()
  End Sub

  Private Sub btnELIMINAR_Click(sender As System.Object, e As System.EventArgs) Handles btnELIMINAR.Click
    If MsgBox("Pretende eliminar o registo?", MsgBoxStyle.YesNo, "TERC T") = MsgBoxResult.Yes Then
      myTERCT.delTERCT(Me.txtTTCOD.Text)
      Call newTERCT()
      Call prepForm(0)
    End If
  End Sub

  Private Sub btnCANCELAR_Click(sender As System.Object, e As System.EventArgs) Handles btnCANCELAR.Click
    Call newTERCT()
    Call prepForm(0)
  End Sub

  Private Sub btnGRAVAR_Click(sender As System.Object, e As System.EventArgs) Handles btnGRAVAR.Click
    If novoREG Then
      myTERCT.addTERCT(Me.txtTTCOD.Text, Me.txtTTDESCR.Text)
    Else
      myTERCT.updTERCT(Me.txtTTCOD.Text, Me.txtTTDESCR.Text)
    End If
  End Sub
End Class