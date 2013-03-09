Public Class DOC

  Private daTERC As New SqlClient.SqlDataAdapter
  Private daDOCT As New SqlClient.SqlDataAdapter
  Private daDOC As New SqlClient.SqlDataAdapter
  Private daDOClin As New SqlClient.SqlDataAdapter
  Private dsMain As New DataSet

  Private WithEvents myDOC As clsDOC
  Private novoREG As Boolean

  Private Sub DOC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    myDOC = New clsDOC(dbCNNstr)
    Call prepForm(0)

    'carregar o dataset
    Dim cnn As SqlClient.SqlConnection = New SqlClient.SqlConnection(dbCNNstr)
    Dim cmd As SqlClient.SqlCommand

    Try
      cmd = New SqlClient.SqlCommand ' *** TERC ***
      With cmd
        .Connection = cnn
        .CommandText = "TERC_SELALL"
        .CommandType = CommandType.StoredProcedure
      End With
      daTERC.SelectCommand = cmd
      daTERC.Fill(dsMain, "TERC")

      cmd = New SqlClient.SqlCommand ' *** DOCT ***
      With cmd
        .Connection = cnn
        .CommandText = "DOCT_SELALL"
        .CommandType = CommandType.StoredProcedure
      End With
      daDOCT.SelectCommand = cmd
      daDOCT.Fill(dsMain, "DOCT")

      cmd = New SqlClient.SqlCommand ' *** DOC ***
      With cmd
        .Connection = cnn
        .CommandText = "DOC_SELALL"
        .CommandType = CommandType.StoredProcedure
      End With
      daDOC.SelectCommand = cmd
      daDOC.Fill(dsMain, "DOC")

      cmd = New SqlClient.SqlCommand ' *** DOClin ***
      With cmd
        .Connection = cnn
        .CommandText = "DOClin_SELALL"
        .CommandType = CommandType.StoredProcedure
      End With
      daDOClin.SelectCommand = cmd
      daDOClin.Fill(dsMain, "DOClin")

      ' Criar as relações
      Dim rel1 As DataRelation = dsMain.Relations.Add("DOCTDOC", dsMain.Tables("DOCT").Columns("DT_COD"), dsMain.Tables("DOC").Columns("D_DT_COD"))
      Dim rel2 As DataRelation = dsMain.Relations.Add("TERCDOC", dsMain.Tables("TERC").Columns("T_COD"), dsMain.Tables("DOC").Columns("D_T_COD"))
      Dim rel3 As DataRelation = dsMain.Relations.Add("DOCDOClin", dsMain.Tables("DOC").Columns("D_ID"), dsMain.Tables("DOClin").Columns("DL_D_ID"))

      ' Criar os bindings
      Me.txtDID.DataBindings.Add("text", dsMain, "DOC.D_ID")
      Me.txtDNUM.DataBindings.Add("text", dsMain, "DOC.D_NUM")
      Me.dtpDD.DataBindings.Add("value", dsMain, "DOC.D_D")
      Me.dtpDDREC.DataBindings.Add("value", dsMain, "DOC.D_DREC")
      Me.txtDDRREC.DataBindings.Add("text", dsMain, "DOC.D_DRREC")
      Me.txtDVALQT.DataBindings.Add("text", dsMain, "DOC.D_VALQT")
      Me.txtDVALIVA.DataBindings.Add("text", dsMain, "DOC.D_VALIVA")
      Me.txtDVALTOT.DataBindings.Add("text", dsMain, "DOC.D_VALTOT")

      With Me.cmbDDTCOD
        .DataSource = dsMain.Tables("DOCT")
        .DisplayMember = "DT_COD"
        .ValueMember = "DT_COD"
        .DataBindings.Add("SelectedValue", dsMain, "DOC.D_DT_COD")
      End With

      With Me.cmbDTCOD
        .DataSource = dsMain.Tables("TERC")
        .DisplayMember = "T_NOME"
        .ValueMember = "T_COD"
        .DataBindings.Add("SelectedValue", dsMain, "DOC.D_T_COD")
      End With

      'datagrid DOClin
      Me.dgDOClin.DataSource = dsMain
      Me.dgDOClin.DataMember = "DOC.DOCDOClin"

      ''binding navigator bnDOC
      Dim bnDOC As New BindingNavigator(True)
      Dim bsDOC As New BindingSource

      bsDOC.DataSource = dsMain
      bsDOC.DataMember = "DOC"
      bnDOC.BindingSource = bsDOC
      bnDOC.Dock = DockStyle.Bottom
      Me.Controls.Add(bnDOC)

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
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
        Me.cmbDDTCOD.Enabled = True
      Case 1
        btnNOVO.Enabled = False
        btnBUSCA.Enabled = False
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = True
        btnCANCELAR.Enabled = True
        Me.cmbDDTCOD.Enabled = True
      Case 2
        btnNOVO.Enabled = False
        btnBUSCA.Enabled = False
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = True
        btnCANCELAR.Enabled = True
        Me.cmbDDTCOD.Enabled = False
      Case 3
        btnNOVO.Enabled = True
        btnBUSCA.Enabled = True
        btnEDITAR.Enabled = True
        btnELIMINAR.Enabled = True
        btnGRAVAR.Enabled = False
        btnCANCELAR.Enabled = False
        Me.cmbDDTCOD.Enabled = True
    End Select
  End Sub

  Private Sub clsDOCErrors(ByVal msg As String) Handles myDOC.Errors
    MsgBox(msg, MsgBoxStyle.Exclamation, "DOC")
  End Sub

  Private Sub clsDOCAction(ByVal status As Short) Handles myDOC.Action
    Select Case status
      Case -1
        Call mostraDados()
        Call prepForm(3)
      Case 2
        Call prepForm(1)
        novoREG = True
        'txtTTDESCR.Focus()
      Case 5
        MsgBox("Registo com chave duplicada", MsgBoxStyle.Exclamation, "DOC")
        'txtTTCOD.Focus()
      Case 6
        MsgBox("Registo Eliminado", MsgBoxStyle.Information, "DOC")
        Call newDOC()
        Call prepForm(0)
        'txtTTCOD.Focus()
      Case 7
        MsgBox("Registo actualizado.", MsgBoxStyle.Information, "DOC")
        Call prepForm(3)
        'txtTTCOD.Focus()
      Case 8
        MsgBox("Registo inserido", MsgBoxStyle.Information, "DOC")
        Call prepForm(3)
        'txtTTCOD.Focus()
    End Select
  End Sub

  Private Sub mostraDados()
    Me.txtDID.Text = myDOC.DID
    Me.cmbDDTCOD.Text = myDOC.DDTCOD
    Me.txtDNUM.Text = myDOC.DNUM
    Me.cmbDTCOD.Text = myDOC.DTCOD
    Me.dtpDD.Text = myDOC.DD
    Me.dtpDDREC.Text = myDOC.DDREC
    Me.txtDDRREC.Text = myDOC.DDRREC
    Me.txtDVALQT.Text = myDOC.DVALQT
    Me.txtDVALIVA.Text = myDOC.DVALIVA
    Me.txtDVALTOT.Text = myDOC.DVALTOT
  End Sub

  Private Sub newDOC()
    Me.txtDID.Text = ""
    Me.cmbDDTCOD.Text = ""
    Me.txtDNUM.Text = ""
    Me.cmbDTCOD.Text = ""
    Me.dtpDD.Text = ""
    Me.dtpDDREC.Text = ""
    Me.txtDDRREC.Text = ""
    Me.txtDVALQT.Text = ""
    Me.txtDVALIVA.Text = ""
    Me.txtDVALTOT.Text = ""

    Me.cmbDDTCOD.Focus()
    novoREG = True
  End Sub

  Private Sub btnBUSCA_Click(sender As System.Object, e As System.EventArgs) Handles btnBUSCA.Click
    Dim tbl As New DataTable
    LISTA.DataGridView1.DataSource = myDOC.listDOCP
    LISTA.ShowDialog()
    If Not LISTA.Escolha Is Nothing Then
      Me.BindingContext(dsMain, "DOC").Position = LISTA.Escolha.Index
    End If
  End Sub

  Private Sub btnNOVO_Click(sender As System.Object, e As System.EventArgs) Handles btnNOVO.Click
    Call newDOC()
    Call prepForm(1)
  End Sub

  Private Sub btnEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles btnEDITAR.Click
    novoREG = False
    Call prepForm(2)
    Me.cmbDTCOD.Focus()
  End Sub

  Private Sub btnELIMINAR_Click(sender As System.Object, e As System.EventArgs) Handles btnELIMINAR.Click
    If MsgBox("Pretende eliminar o registo?", MsgBoxStyle.YesNo, "DOC") = MsgBoxResult.Yes Then
      myDOC.delDOC(Me.txtDID.Text)
      Call newDOC()
      Call prepForm(0)
    End If
  End Sub

  Private Sub btnCANCELAR_Click(sender As System.Object, e As System.EventArgs) Handles btnCANCELAR.Click
    Call newDOC()
    Call prepForm(0)
  End Sub

  'Private Sub btnGRAVAR_Click(sender As System.Object, e As System.EventArgs) Handles btnGRAVAR.Click
  '  If novoREG Then
  '    myTERCT.addTERCT(Me.txtTTCOD.Text, Me.txtTTDESCR.Text)
  '  Else
  '    myTERCT.updTERCT(Me.txtTTCOD.Text, Me.txtTTDESCR.Text)
  '  End If
  'End Sub
End Class