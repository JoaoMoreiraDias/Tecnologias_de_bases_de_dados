Public Class DOCDOClin
  Private WithEvents myDOC As clsDOC
  Private WithEvents myDOClin As clsDOClin

  Private novoDOC As Boolean
  Private locDID As Long
  Private locDNUM As Long
  Private locDD As Date
  Private locDREC As Object
  Private locDRREC As Object

  Private novoDOClin As Boolean
  Private locDLID As Long

  Private daTERC As New SqlClient.SqlDataAdapter
  Private daDOCT As New SqlClient.SqlDataAdapter
  Private daDOC As New SqlClient.SqlDataAdapter
  Private daDOClin As New SqlClient.SqlDataAdapter
  Private daPROD As New SqlClient.SqlDataAdapter

  Private dsMain As New DataSet

  Private myPROD As clsPROD
  Private myDOCT As clsDOCT

  Private Sub DOCDOClin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    myDOC = New clsDOC(dbCNNstr)
    myDOClin = New clsDOClin(dbCNNstr)
    myPROD = New clsPROD(dbCNNstr)
    myDOCT = New clsDOCT(dbCNNstr)

    Call prepForm(0)
    novoDOClin = True

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

      cmd = New SqlClient.SqlCommand ' *** PROD ***
      With cmd
        .Connection = cnn
        .CommandText = "PROD_SELALL"
        .CommandType = CommandType.StoredProcedure
      End With
      daPROD.SelectCommand = cmd
      daPROD.Fill(dsMain, "PROD")

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

      With Me.cmbPROD
        .DataSource = dsMain.Tables("PROD")
        .DisplayMember = "P_REF"
        .ValueMember = "P_REF"
      End With

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
      Case 1 'edit
        btnNOVO.Enabled = False
        btnBUSCA.Enabled = False
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = True
        btnCANCELAR.Enabled = True
        Me.cmbDDTCOD.Enabled = False
      Case 2 'novo
        btnNOVO.Enabled = False
        btnBUSCA.Enabled = False
        btnEDITAR.Enabled = False
        btnELIMINAR.Enabled = False
        btnGRAVAR.Enabled = True
        btnCANCELAR.Enabled = True
        Me.cmbDDTCOD.Enabled = True
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
        Me.dgDOClin.DataSource = myDOClin.listDOClinDOC(myDOC.DID)
      Case 2
        Call prepForm(1)
        novoDOC = True
        Me.cmbDDTCOD.Focus()
        Me.dgDOClin.DataSource = Nothing
      Case 5
        MsgBox("Registo com chave duplicada", MsgBoxStyle.Exclamation, "DOC")
        Me.cmbDDTCOD.Focus()
      Case 6
        MsgBox("Registo Eliminado", MsgBoxStyle.Information, "DOC")
        Call newDOC()
        Call prepForm(0)
        Me.cmbDDTCOD.Focus()
      Case 7
        MsgBox("Registo actualizado.", MsgBoxStyle.Information, "DOC")
        Call prepForm(3)
        Me.cmbDDTCOD.Focus()
      Case 8
        MsgBox("Registo inserido", MsgBoxStyle.Information, "DOC")
        Call prepForm(3)
        Me.cmbDDTCOD.Focus()
    End Select
  End Sub

  Public Sub DOClinAction(ByVal status As Short) Handles myDOClin.Action
    Select Case status
      Case 6
        MsgBox("Registo Eliminado", MsgBoxStyle.Information, "Doclin")
      Case 8
        MsgBox("Registo Inserido", MsgBoxStyle.Information, "Doclin")
      Case 30
        MsgBox("A quantidade existente é insuficiente", MsgBoxStyle.Information, "Doclin")
        Me.txtQT.Focus()
    End Select
  End Sub

  Private Sub mostraDados()
    Me.txtDID.Text = myDOC.DID
    Me.cmbDDTCOD.Text = myDOC.DDTCOD
    Me.txtDNUM.Text = myDOC.DNUM
    Me.cmbDTCOD.Text = myDOC.DTCOD
    Me.dtpDD.Text = myDOC.DD

    If myDOC.DDREC = "0:0:0" Then
      Me.txtDDREC.Text = ""
    Else
      Me.txtDDREC.Text = myDOC.DDREC
    End If
    If myDOC.DDRREC = "0:0:0" Then
      Me.txtDDRREC.Text = ""
    Else
      Me.txtDDRREC.Text = myDOC.DDRREC
    End If

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
    Me.txtDDREC.Text = ""
    Me.txtDDRREC.Text = ""
    Me.txtDVALQT.Text = ""
    Me.txtDVALIVA.Text = ""
    Me.txtDVALTOT.Text = ""

    Me.cmbDDTCOD.Focus()
    novoDOC = True
  End Sub

  Private Sub btnNOVO_Click(sender As System.Object, e As System.EventArgs) Handles btnNOVO.Click
    Call newDOC()
    Call prepForm(2)
    Me.dgDOClin.DataSource = Nothing
  End Sub

  Private Sub btnBUSCA_Click(sender As System.Object, e As System.EventArgs) Handles btnBUSCA.Click
    Dim tbl As New DataTable
    LISTA.DataGridView1.DataSource = myDOC.listDOCP
    LISTA.ShowDialog()
    If Not LISTA.Escolha Is Nothing Then
      myDOC.getDOC(LISTA.Escolha.Cells("D_ID").Value)
      Me.dgDOClin.DataSource = myDOClin.listDOClinDOC(LISTA.Escolha.Cells("D_ID").Value)
    End If
  End Sub

  Private Sub btnGRAVAR_Click(sender As System.Object, e As System.EventArgs) Handles btnGRAVAR.Click

    'If Me.txtDDREC.Text <> "" Then
    '  If Not IsDate(Me.txtDDREC.Text) Then
    '    MsgBox("Valor de DATA inadequado", MsgBoxStyle.Exclamation, "DOC")
    '    Me.txtDDREC.Focus()
    '  End If
    'ElseIf Me.txtDDRREC.Text <> "" Then
    '  If Not IsDate(Me.txtDDRREC.Text) Then
    '    MsgBox("Valor de DATA inadequado", MsgBoxStyle.Exclamation, "DOC")
    '    Me.txtDDRREC.Focus()
    '  End If
    'Else
    If novoDOC Then 'insert
      locDID = 0
      locDNUM = 0
      locDD = Me.dtpDD.Value
      If Me.txtDDREC.Text = "" Then
        locDREC = Nothing
      Else
        locDREC = Me.txtDDREC.Text
      End If
      If Me.txtDDRREC.Text = "" Then
        locDRREC = Nothing
      Else
        locDRREC = Me.txtDDRREC.Text
      End If
      myDOC.addDOC(locDID, Me.cmbDDTCOD.Text, locDNUM, Me.cmbDTCOD.SelectedValue, locDD, locDREC, locDRREC)
      myDOC.getDOC(locDID)
    Else 'update
      If Me.txtDDREC.Text = "" Then
        locDREC = Nothing
      Else
        locDREC = Me.txtDDREC.Text
      End If
      If Me.txtDDRREC.Text = "" Then
        locDRREC = Nothing
      Else
        locDRREC = Me.txtDDRREC.Text
      End If
      myDOC.updDOC(Me.txtDID.Text, Me.cmbDTCOD.SelectedValue, Me.dtpDD.Value, locDREC, locDRREC)
      myDOC.getDOC(Me.txtDID.Text)

    End If
    'End If
  End Sub

  Private Sub btnELIMINAR_Click(sender As System.Object, e As System.EventArgs) Handles btnELIMINAR.Click
    If MsgBox("Pretende eliminar o registo?", MsgBoxStyle.YesNo, "DOC") = MsgBoxResult.Yes Then
      myDOC.delDOC(Me.txtDID.Text)
      Call newDOC()
      Call prepForm(0)
      Me.dgDOClin.DataSource = Nothing
    End If
  End Sub

  Private Sub btnEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles btnEDITAR.Click
    novoDOC = False
    Call prepForm(1)
    Me.txtDDREC.Focus()
  End Sub

  Private Sub btnCANCELAR_Click(sender As System.Object, e As System.EventArgs) Handles btnCANCELAR.Click
    Call newDOC()
    Call prepForm(0)
  End Sub

  Private Sub btnCLRlin_Click(sender As System.Object, e As System.EventArgs) Handles btnCLRlin.Click
    Me.cmbPROD.Text = ""
    Me.txtPDESCR.Text = ""
    Me.txtQT.Text = ""
    Me.txtVAL.Text = ""
    Me.txtIVATX.Text = ""
    Me.cmbPROD.Focus()
  End Sub

  Private Sub cmbPROD_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbPROD.SelectedIndexChanged
    Call PRODATUALIZA()
  End Sub

  Private Sub PRODATUALIZA()
    myDOCT.getDOCTU(Me.cmbDDTCOD.Text)
    myPROD.getPROD(Me.cmbPROD.Text)

    Me.txtPDESCR.Text = myPROD.DESCR
    Me.txtQT.Text = myPROD.QT
    If myDOCT.VUSO = 1 Then
      Me.txtVAL.Text = myPROD.CST
    ElseIf myDOCT.VUSO = 2 Then
      Me.txtVAL.Text = myPROD.PRC
    End If
    Me.txtIVATX.Text = myPROD.IVATX
  End Sub
 
  Private Sub cmbDDTCOD_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDDTCOD.SelectedIndexChanged
    Call PRODATUALIZA()
  End Sub

  Private Sub btnADDlin_Click(sender As System.Object, e As System.EventArgs) Handles btnADDlin.Click
    If novoDOClin Then
      myDOClin.addDOCLIN(locDLID, Me.txtDID.Text, Me.cmbPROD.Text, Me.txtPDESCR.Text, Me.txtQT.Text, Me.txtVAL.Text, Me.txtIVATX.Text)
    Else
      myDOClin.updDOCLIN(locDLID, Me.cmbPROD.Text, Me.txtPDESCR.Text, Me.txtQT.Text, Me.txtVAL.Text, Me.txtIVATX.Text)
      novoDOClin = True
    End If
    myDOC.getDOC(Me.txtDID.Text)
    Me.dgDOClin.DataSource = myDOClin.listDOClinDOC(Me.txtDID.Text)
  End Sub

  Private Sub btnREMOVE_Click(sender As System.Object, e As System.EventArgs) Handles btnREMOVE.Click
    If MsgBox("Pretende eliminar o registo " & Me.dgDOClin.CurrentRow.Cells(0).Value & "?", MsgBoxStyle.YesNo, "DOClin") = MsgBoxResult.Yes Then
      myDOClin.delDOCLIN(Me.dgDOClin.CurrentRow.Cells(0).Value)
      myDOC.getDOC(Me.txtDID.Text)
      Me.dgDOClin.DataSource = myDOClin.listDOClinDOC(Me.txtDID.Text)
    End If
  End Sub

  Private Sub btnUPDlin_Click(sender As System.Object, e As System.EventArgs) Handles btnUPDlin.Click
    novoDOClin = False
    'DL_ID, DL_D_ID, DL_P_REF, DL_DESCR, DL_QT, DL_VAL, DL_VALQT, DL_IVATX, DL_VALIVA, DL_VALTOT
    Me.locDLID = Me.dgDOClin.CurrentRow.Cells(0).Value
    Me.cmbPROD.Text = Me.dgDOClin.CurrentRow.Cells(2).Value
    Me.txtPDESCR.Text = Me.dgDOClin.CurrentRow.Cells(3).Value
    Me.txtQT.Text = Me.dgDOClin.CurrentRow.Cells(4).Value
    Me.txtVAL.Text = Me.dgDOClin.CurrentRow.Cells(5).Value
    Me.txtIVATX.Text = Me.dgDOClin.CurrentRow.Cells(7).Value
  End Sub
End Class

