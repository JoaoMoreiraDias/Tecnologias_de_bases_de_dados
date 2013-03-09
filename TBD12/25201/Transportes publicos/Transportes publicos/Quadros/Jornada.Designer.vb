<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jornada
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgJORN = New System.Windows.Forms.DataGridView()
        Me.btnGRAVAR = New System.Windows.Forms.Button()
        Me.btnCANCELAR = New System.Windows.Forms.Button()
        Me.btnELIMINAR = New System.Windows.Forms.Button()
        Me.btnEDITAR = New System.Windows.Forms.Button()
        Me.btnNOVO = New System.Windows.Forms.Button()
        Me.btnBUSCA = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCondutor = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pessNome = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pessDataNascimento = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pessMorada = New System.Windows.Forms.TextBox()
        Me.pessTelefone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pessId = New System.Windows.Forms.TextBox()
        CType(Me.dgJORN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgJORN
        '
        Me.dgJORN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgJORN.Location = New System.Drawing.Point(4, 190)
        Me.dgJORN.Name = "dgJORN"
        Me.dgJORN.Size = New System.Drawing.Size(672, 238)
        Me.dgJORN.TabIndex = 78
        Me.dgJORN.Visible = False
        '
        'btnGRAVAR
        '
        Me.btnGRAVAR.Location = New System.Drawing.Point(272, 6)
        Me.btnGRAVAR.Name = "btnGRAVAR"
        Me.btnGRAVAR.Size = New System.Drawing.Size(51, 23)
        Me.btnGRAVAR.TabIndex = 57
        Me.btnGRAVAR.Text = "gravar"
        Me.btnGRAVAR.UseVisualStyleBackColor = True
        '
        'btnCANCELAR
        '
        Me.btnCANCELAR.Location = New System.Drawing.Point(206, 6)
        Me.btnCANCELAR.Name = "btnCANCELAR"
        Me.btnCANCELAR.Size = New System.Drawing.Size(60, 23)
        Me.btnCANCELAR.TabIndex = 56
        Me.btnCANCELAR.Text = "cancelar"
        Me.btnCANCELAR.UseVisualStyleBackColor = True
        '
        'btnELIMINAR
        '
        Me.btnELIMINAR.Location = New System.Drawing.Point(150, 6)
        Me.btnELIMINAR.Name = "btnELIMINAR"
        Me.btnELIMINAR.Size = New System.Drawing.Size(50, 23)
        Me.btnELIMINAR.TabIndex = 55
        Me.btnELIMINAR.Text = "eliminar"
        Me.btnELIMINAR.UseVisualStyleBackColor = True
        '
        'btnEDITAR
        '
        Me.btnEDITAR.Location = New System.Drawing.Point(100, 6)
        Me.btnEDITAR.Name = "btnEDITAR"
        Me.btnEDITAR.Size = New System.Drawing.Size(44, 23)
        Me.btnEDITAR.TabIndex = 54
        Me.btnEDITAR.Text = "editar"
        Me.btnEDITAR.UseVisualStyleBackColor = True
        '
        'btnNOVO
        '
        Me.btnNOVO.Location = New System.Drawing.Point(54, 6)
        Me.btnNOVO.Name = "btnNOVO"
        Me.btnNOVO.Size = New System.Drawing.Size(40, 23)
        Me.btnNOVO.TabIndex = 53
        Me.btnNOVO.Text = "novo"
        Me.btnNOVO.UseVisualStyleBackColor = True
        '
        'btnBUSCA
        '
        Me.btnBUSCA.Location = New System.Drawing.Point(4, 6)
        Me.btnBUSCA.Name = "btnBUSCA"
        Me.btnBUSCA.Size = New System.Drawing.Size(44, 23)
        Me.btnBUSCA.TabIndex = 52
        Me.btnBUSCA.Text = "busca"
        Me.btnBUSCA.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Condutor:"
        '
        'cbCondutor
        '
        Me.cbCondutor.AutoSize = True
        Me.cbCondutor.Location = New System.Drawing.Point(63, 159)
        Me.cbCondutor.Name = "cbCondutor"
        Me.cbCondutor.Size = New System.Drawing.Size(15, 14)
        Me.cbCondutor.TabIndex = 80
        Me.cbCondutor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Nome:"
        '
        'pessNome
        '
        Me.pessNome.Location = New System.Drawing.Point(48, 53)
        Me.pessNome.Name = "pessNome"
        Me.pessNome.Size = New System.Drawing.Size(275, 20)
        Me.pessNome.TabIndex = 82
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Data Nascimento:"
        '
        'pessDataNascimento
        '
        Me.pessDataNascimento.Location = New System.Drawing.Point(102, 79)
        Me.pessDataNascimento.Name = "pessDataNascimento"
        Me.pessDataNascimento.Size = New System.Drawing.Size(221, 20)
        Me.pessDataNascimento.TabIndex = 84
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Morada"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Telefone"
        '
        'pessMorada
        '
        Me.pessMorada.Location = New System.Drawing.Point(53, 105)
        Me.pessMorada.Name = "pessMorada"
        Me.pessMorada.Size = New System.Drawing.Size(270, 20)
        Me.pessMorada.TabIndex = 87
        '
        'pessTelefone
        '
        Me.pessTelefone.Location = New System.Drawing.Point(59, 131)
        Me.pessTelefone.Name = "pessTelefone"
        Me.pessTelefone.Size = New System.Drawing.Size(264, 20)
        Me.pessTelefone.TabIndex = 88
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(552, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "ID"
        '
        'pessId
        '
        Me.pessId.Enabled = False
        Me.pessId.Location = New System.Drawing.Point(576, 6)
        Me.pessId.Name = "pessId"
        Me.pessId.Size = New System.Drawing.Size(100, 20)
        Me.pessId.TabIndex = 90
        '
        'Jornada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 435)
        Me.Controls.Add(Me.pessId)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pessTelefone)
        Me.Controls.Add(Me.pessMorada)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pessDataNascimento)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pessNome)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCondutor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgJORN)
        Me.Controls.Add(Me.btnGRAVAR)
        Me.Controls.Add(Me.btnCANCELAR)
        Me.Controls.Add(Me.btnELIMINAR)
        Me.Controls.Add(Me.btnEDITAR)
        Me.Controls.Add(Me.btnNOVO)
        Me.Controls.Add(Me.btnBUSCA)
        Me.Name = "Jornada"
        Me.Text = "pessoa"
        CType(Me.dgJORN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgJORN As System.Windows.Forms.DataGridView
    Friend WithEvents btnGRAVAR As System.Windows.Forms.Button
    Friend WithEvents btnCANCELAR As System.Windows.Forms.Button
    Friend WithEvents btnELIMINAR As System.Windows.Forms.Button
    Friend WithEvents btnEDITAR As System.Windows.Forms.Button
    Friend WithEvents btnNOVO As System.Windows.Forms.Button
    Friend WithEvents btnBUSCA As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbCondutor As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pessNome As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pessDataNascimento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pessMorada As System.Windows.Forms.TextBox
    Friend WithEvents pessTelefone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pessId As System.Windows.Forms.TextBox
End Class
