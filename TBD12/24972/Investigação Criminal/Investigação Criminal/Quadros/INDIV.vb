Public Class INDIV

    Private WithEvents myIndiv As clsIndiv
    Private tabela As DataGridView
    Private novoREG As Boolean

    Public Event Action(ByVal status As Integer)
    Public Event Errors(ByVal errMessages As Object)

    Private Sub INDIV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Inicializar um Individuo da clase clsIndiv, com a database connection string passada parametro
        myIndiv = New clsIndiv(dbCNNstr)

        'Preenche a lista de individuos
        LISTA.DataGridView1.DataSource = myIndiv.listIndiv
        LISTA.ShowDialog()
        'Preenche a ficha do individuo
        If Not LISTA.Escolha Is Nothing Then
            myIndiv.getIndiv(LISTA.Escolha.Cells("Indiv_id").Value)
            Me.TextBox1.Text = myIndiv.Indiv_nome
            Me.TextBox2.Text = myIndiv.Indiv_alcunha
            Me.TextBox3.Text = myIndiv.Indiv_telef
            Me.TextBox4.Text = myIndiv.Indiv_id
            Me.DateTimePicker1.Value = myIndiv.Indiv_dob
            Me.DataGridView1.DataSource = myIndiv.getDeten
        End If
        Call prepForm(0)
    End Sub

    'Este botão volta a mostrar a lista de individuos
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Preenche a lista de individuos
        LISTA.DataGridView1.DataSource = myIndiv.listIndiv
        LISTA.ShowDialog()
        'Preenche a ficha do individuo
        If Not LISTA.Escolha Is Nothing Then
            myIndiv.getIndiv(LISTA.Escolha.Cells("Indiv_id").Value)
            Me.TextBox1.Text = myIndiv.Indiv_nome
            Me.TextBox2.Text = myIndiv.Indiv_alcunha
            Me.TextBox3.Text = myIndiv.Indiv_telef
            Me.TextBox4.Text = myIndiv.Indiv_id
            Me.DateTimePicker1.Value = myIndiv.Indiv_dob
            Me.DataGridView1.DataSource = myIndiv.getDeten
        End If
    End Sub

    'Limpa o registo
    Private Sub newIndividuo()
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.DateTimePicker1.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox1.Focus()
        novoREG = True
    End Sub

    'Gere a utilização dos botões, controlando as operaçõens de manutenção do quadro disponiveis
    Sub prepForm(ByVal status As Integer)
        Select Case status
            Case 0
                Button2.Enabled = True
                Button1.Enabled = True
                Button3.Enabled = False
                Button6.Enabled = False
                Button5.Enabled = False
                Button4.Enabled = False
            Case 1 'edit
                Button2.Enabled = False
                Button1.Enabled = False
                Button3.Enabled = False
                Button6.Enabled = False
                Button5.Enabled = True
                Button4.Enabled = True
            Case 2 'novo
                Button2.Enabled = False
                Button1.Enabled = False
                Button3.Enabled = False
                Button6.Enabled = False
                Button5.Enabled = True
                Button4.Enabled = True
            Case 3
                Button2.Enabled = True
                Button1.Enabled = True
                Button3.Enabled = True
                Button6.Enabled = True
                Button5.Enabled = False
                Button4.Enabled = False
        End Select
    End Sub

    'Faz feedback ao utilizador com uma mensagem relativa a operação realizada e interage com o prepForm
    Private Sub clsIndividAction(ByVal status As Short) Handles myIndiv.Action
        Select Case status
            Case -1
                Call prepForm(3)
            Case 2
                Call prepForm(1)
                novoREG = True
            Case 5
                MsgBox("Registo com chave duplicada", MsgBoxStyle.Exclamation, "Individuo")
            Case 6
                MsgBox("Registo Eliminado", MsgBoxStyle.Information, "Individuo")
                Call newIndividuo()
                Call prepForm(0)
            Case 7
                MsgBox("Registo actualizado.", MsgBoxStyle.Information, "Individuo")
                Call prepForm(3)
            Case 8
                MsgBox("Registo inserido", MsgBoxStyle.Information, "Individuo")
                Call prepForm(3)
        End Select
    End Sub

    'Botão Novo
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call newIndividuo()
        Call prepForm(2)
        Me.DataGridView1.DataSource = Nothing
    End Sub

    'Botão Eliminar
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MsgBox("Pretende eliminar o registo?", MsgBoxStyle.YesNo, "DOC") = MsgBoxResult.Yes Then
            myIndiv.del(Me.TextBox4.Text)
            Call newIndividuo()
            Call prepForm(0)
            Me.DataGridView1.DataSource = Nothing
        End If
    End Sub

    'Botão Editar
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        novoREG = False
        Call prepForm(1)
        Me.TextBox1.Focus()
    End Sub

    'Botão Cancelar
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call newIndividuo()
        Call prepForm(0)
    End Sub

    'Botão Gravar
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If novoREG Then
            myIndiv.add(Me.TextBox1.Text, Me.TextBox2.Text, Me.DateTimePicker1.Value, Me.TextBox3.Text)
        Else
            myIndiv.edit(Me.TextBox4.Text, Me.TextBox1.Text, Me.TextBox2.Text, Me.DateTimePicker1.Value, Me.TextBox3.Text)
        End If
    End Sub
End Class
