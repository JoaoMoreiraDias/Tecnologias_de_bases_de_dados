Public Class Jornada

    Private daPessoa As New SqlClient.SqlDataAdapter
    Private daDOCT As New SqlClient.SqlDataAdapter
    Private daDOC As New SqlClient.SqlDataAdapter
    Private daDOClin As New SqlClient.SqlDataAdapter
    Private dsMain As New DataSet

    Private WithEvents myPessoa As clsPessoa
    Private WithEvents myCarta As clsCarta
    Private listaCartas As DataGridView

    Private novoREG As Boolean

    Private Sub Pessoa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myPessoa = New clsPessoa(dbCNNstr)
        myCarta = New clsCarta(dbCNNstr)
        Call prepForm(0)
    End Sub

    'Controla o uso dos botões de manutenção
    Sub prepForm(ByVal status As Integer)
        Select Case status
            Case 0
                btnNOVO.Enabled = True
                btnBUSCA.Enabled = True
                btnEDITAR.Enabled = False
                btnELIMINAR.Enabled = False
                btnGRAVAR.Enabled = False
                btnCANCELAR.Enabled = False
                Me.pessId.Enabled = False
            Case 1
                btnNOVO.Enabled = False
                btnBUSCA.Enabled = False
                btnEDITAR.Enabled = False
                btnELIMINAR.Enabled = False
                btnGRAVAR.Enabled = True
                btnCANCELAR.Enabled = True
                Me.pessId.Enabled = False
            Case 2
                btnNOVO.Enabled = False
                btnBUSCA.Enabled = False
                btnEDITAR.Enabled = False
                btnELIMINAR.Enabled = False
                btnGRAVAR.Enabled = True
                btnCANCELAR.Enabled = True
                Me.pessId.Enabled = False
            Case 3
                btnNOVO.Enabled = True
                btnBUSCA.Enabled = True
                btnEDITAR.Enabled = True
                btnELIMINAR.Enabled = True
                btnGRAVAR.Enabled = False
                btnCANCELAR.Enabled = False
                Me.pessId.Enabled = False
        End Select
    End Sub

    'Limpa os campos do formulario da pessoa
    Private Sub newPessoa()
        Me.pessNome.Text = ""
        Me.pessMorada.Text = ""
        Me.pessDataNascimento.Text = ""
        Me.cbCondutor.Checked = False
        Me.pessTelefone.Text = ""
        novoREG = True
    End Sub

    'busca
    Private Sub btnBUSCA_Click(sender As System.Object, e As System.EventArgs) Handles btnBUSCA.Click
        LISTA.DataGridView1.DataSource = myPessoa.pessLista
        LISTA.ShowDialog()
        If Not LISTA.Escolha Is Nothing Then
            myPessoa.getPessoa(LISTA.Escolha.Cells("PESS_id").Value)
            myCarta.pessCarta(LISTA.Escolha.Cells("PESS_id").Value)
            Me.pessNome.Text = myPessoa.pessNome
            Me.pessDataNascimento.Value = myPessoa.pessDataNascimento
            Me.pessMorada.Text = myPessoa.pessMorada
            Me.pessTelefone.Text = myPessoa.pessTelefone
            Me.cbCondutor.Checked = myPessoa.pessCondutor
            If (myPessoa.pessCondutor = True) Then
                Me.cbCondutor.CheckState = CheckState.Checked
                Me.cbCondutor.Visible = True
                Me.dgJORN.Visible = True
            Else
                Me.cbCondutor.CheckState = CheckState.Unchecked
                Me.dgJORN.Visible = False
            End If
            Me.pessId.Text = myPessoa.pessId
            Me.dgJORN.DataSource = myPessoa.pessoaGetJornada(LISTA.Escolha.Cells("PESS_id").Value)
        End If
    End Sub

    Private Sub clsPessoaAction(ByVal status As Short) Handles myPessoa.Action
        Select Case status
            Case -1
                Call prepForm(3)
            Case 2
                Call prepForm(1)
                novoREG = True
                'txtTTDESCR.Focus()
            Case 5
                MsgBox("Registo com chave duplicada", MsgBoxStyle.Exclamation, "Pessoa")
                'txtTTCOD.Focus()
            Case 6
                MsgBox("Registo Eliminado", MsgBoxStyle.Information, "Pessoa")
                Call newPessoa()
                Call prepForm(0)
                'txtTTCOD.Focus()
            Case 7
                MsgBox("Registo actualizado.", MsgBoxStyle.Information, "Pessoa")
                Call prepForm(3)
                'txtTTCOD.Focus()
            Case 8
                MsgBox("Registo inserido", MsgBoxStyle.Information, "Pessoa")
                Call prepForm(3)
                'txtTTCOD.Focus()
        End Select
    End Sub

    'novo
    Private Sub btnNOVO_Click(sender As System.Object, e As System.EventArgs) Handles btnNOVO.Click
        Call newPessoa()
        Call prepForm(1)
        dgJORN.DataSource = Nothing
    End Sub

    'editar
    Private Sub btnEDITAR_Click(sender As System.Object, e As System.EventArgs) Handles btnEDITAR.Click
        novoREG = False
        Call prepForm(2)
        Me.pessNome.Focus()
    End Sub

    Private Sub btnCANCELAR_Click(sender As System.Object, e As System.EventArgs) Handles btnCANCELAR.Click
        Call newPessoa()
        Call prepForm(0)
    End Sub

    'gravar
    Private Sub btnGRAVAR_Click(sender As System.Object, e As System.EventArgs) Handles btnGRAVAR.Click
        If novoREG Then
            myPessoa.addPessoa(Me.pessNome.Text, Me.pessDataNascimento.Value, Me.pessMorada.Text, Me.pessTelefone.Text, Me.cbCondutor.Checked)
        Else
            myPessoa.editPessoa(Me.pessId.Text, Me.pessNome.Text, Me.pessDataNascimento.Value, Me.pessMorada.Text, Me.pessTelefone.Text, Me.cbCondutor.Checked)
        End If
    End Sub

    'Serve para defenir quem é condutor
    Private Sub cbCondutor_Click(sender As Object, e As EventArgs) Handles cbCondutor.Click
        If (Me.cbCondutor.Checked = True) Then
            Me.cbCondutor.CheckState = CheckState.Checked
            Me.cbCondutor.Checked = True
            Me.cbCondutor.Visible = True
            Me.dgJORN.Visible = True
        Else
            Me.cbCondutor.CheckState = CheckState.Unchecked
            Me.cbCondutor.Checked = False
            Me.dgJORN.Visible = False
        End If
    End Sub

    Private Sub btnELIMINAR_Click(sender As Object, e As EventArgs) Handles btnELIMINAR.Click
        If MsgBox("Pretende eliminar o registo?", MsgBoxStyle.YesNo, "Pessoa") = MsgBoxResult.Yes Then
            myPessoa.delPessoa(Me.pessId.Text)
            Call newPessoa()
            Call prepForm(0)
            Me.dgJORN.DataSource = Nothing
        End If
    End Sub
End Class