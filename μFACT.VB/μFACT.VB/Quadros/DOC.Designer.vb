<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DOC
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
    Me.btnGRAVAR = New System.Windows.Forms.Button()
    Me.btnCANCELAR = New System.Windows.Forms.Button()
    Me.btnELIMINAR = New System.Windows.Forms.Button()
    Me.btnEDITAR = New System.Windows.Forms.Button()
    Me.btnNOVO = New System.Windows.Forms.Button()
    Me.btnBUSCA = New System.Windows.Forms.Button()
    Me.txtDID = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtDNUM = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.dtpDD = New System.Windows.Forms.DateTimePicker()
    Me.dtpDDREC = New System.Windows.Forms.DateTimePicker()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.txtDVALQT = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.txtDVALIVA = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.txtDVALTOT = New System.Windows.Forms.TextBox()
    Me.cmbDTCOD = New System.Windows.Forms.ComboBox()
    Me.cmbDDTCOD = New System.Windows.Forms.ComboBox()
    Me.dgDOClin = New System.Windows.Forms.DataGridView()
    Me.txtDDRREC = New System.Windows.Forms.TextBox()
    CType(Me.dgDOClin, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnGRAVAR
    '
    Me.btnGRAVAR.Location = New System.Drawing.Point(280, 3)
    Me.btnGRAVAR.Name = "btnGRAVAR"
    Me.btnGRAVAR.Size = New System.Drawing.Size(51, 23)
    Me.btnGRAVAR.TabIndex = 29
    Me.btnGRAVAR.Text = "gravar"
    Me.btnGRAVAR.UseVisualStyleBackColor = True
    '
    'btnCANCELAR
    '
    Me.btnCANCELAR.Location = New System.Drawing.Point(214, 3)
    Me.btnCANCELAR.Name = "btnCANCELAR"
    Me.btnCANCELAR.Size = New System.Drawing.Size(60, 23)
    Me.btnCANCELAR.TabIndex = 28
    Me.btnCANCELAR.Text = "cancelar"
    Me.btnCANCELAR.UseVisualStyleBackColor = True
    '
    'btnELIMINAR
    '
    Me.btnELIMINAR.Location = New System.Drawing.Point(158, 3)
    Me.btnELIMINAR.Name = "btnELIMINAR"
    Me.btnELIMINAR.Size = New System.Drawing.Size(50, 23)
    Me.btnELIMINAR.TabIndex = 27
    Me.btnELIMINAR.Text = "eliminar"
    Me.btnELIMINAR.UseVisualStyleBackColor = True
    '
    'btnEDITAR
    '
    Me.btnEDITAR.Location = New System.Drawing.Point(108, 3)
    Me.btnEDITAR.Name = "btnEDITAR"
    Me.btnEDITAR.Size = New System.Drawing.Size(44, 23)
    Me.btnEDITAR.TabIndex = 26
    Me.btnEDITAR.Text = "editar"
    Me.btnEDITAR.UseVisualStyleBackColor = True
    '
    'btnNOVO
    '
    Me.btnNOVO.Location = New System.Drawing.Point(62, 3)
    Me.btnNOVO.Name = "btnNOVO"
    Me.btnNOVO.Size = New System.Drawing.Size(40, 23)
    Me.btnNOVO.TabIndex = 25
    Me.btnNOVO.Text = "novo"
    Me.btnNOVO.UseVisualStyleBackColor = True
    '
    'btnBUSCA
    '
    Me.btnBUSCA.Location = New System.Drawing.Point(12, 3)
    Me.btnBUSCA.Name = "btnBUSCA"
    Me.btnBUSCA.Size = New System.Drawing.Size(44, 23)
    Me.btnBUSCA.TabIndex = 24
    Me.btnBUSCA.Text = "busca"
    Me.btnBUSCA.UseVisualStyleBackColor = True
    '
    'txtDID
    '
    Me.txtDID.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.txtDID.Location = New System.Drawing.Point(635, 6)
    Me.txtDID.Name = "txtDID"
    Me.txtDID.ReadOnly = True
    Me.txtDID.Size = New System.Drawing.Size(52, 20)
    Me.txtDID.TabIndex = 30
    Me.txtDID.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(585, 11)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(44, 13)
    Me.Label1.TabIndex = 31
    Me.Label1.Text = "Doc_ID"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 59)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(54, 13)
    Me.Label2.TabIndex = 33
    Me.Label2.Text = "Tipo Doc:"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(191, 59)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 13)
    Me.Label3.TabIndex = 35
    Me.Label3.Text = "Num:"
    '
    'txtDNUM
    '
    Me.txtDNUM.Location = New System.Drawing.Point(226, 56)
    Me.txtDNUM.Name = "txtDNUM"
    Me.txtDNUM.ReadOnly = True
    Me.txtDNUM.Size = New System.Drawing.Size(48, 20)
    Me.txtDNUM.TabIndex = 34
    Me.txtDNUM.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(17, 85)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(49, 13)
    Me.Label4.TabIndex = 37
    Me.Label4.Text = "Terceiro:"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(28, 111)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(33, 13)
    Me.Label5.TabIndex = 39
    Me.Label5.Text = "Data:"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'dtpDD
    '
    Me.dtpDD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpDD.Location = New System.Drawing.Point(72, 111)
    Me.dtpDD.Name = "dtpDD"
    Me.dtpDD.Size = New System.Drawing.Size(105, 20)
    Me.dtpDD.TabIndex = 40
    Me.dtpDD.Value = New Date(2012, 11, 21, 23, 5, 35, 0)
    '
    'dtpDDREC
    '
    Me.dtpDDREC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpDDREC.Location = New System.Drawing.Point(338, 111)
    Me.dtpDDREC.Name = "dtpDDREC"
    Me.dtpDDREC.Size = New System.Drawing.Size(105, 20)
    Me.dtpDDREC.TabIndex = 42
    Me.dtpDDREC.Value = New Date(2012, 11, 21, 23, 5, 54, 0)
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(191, 111)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(141, 13)
    Me.Label6.TabIndex = 41
    Me.Label6.Text = "Data esperada recebimento:"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(462, 111)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(114, 13)
    Me.Label7.TabIndex = 43
    Me.Label7.Text = "Data real recebimento:"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(12, 140)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(90, 13)
    Me.Label8.TabIndex = 46
    Me.Label8.Text = "Valor Mercadoria:"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtDVALQT
    '
    Me.txtDVALQT.Location = New System.Drawing.Point(108, 137)
    Me.txtDVALQT.Name = "txtDVALQT"
    Me.txtDVALQT.ReadOnly = True
    Me.txtDVALQT.Size = New System.Drawing.Size(105, 20)
    Me.txtDVALQT.TabIndex = 45
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(277, 140)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(52, 13)
    Me.Label9.TabIndex = 48
    Me.Label9.Text = "Valor Iva:"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtDVALIVA
    '
    Me.txtDVALIVA.Location = New System.Drawing.Point(338, 140)
    Me.txtDVALIVA.Name = "txtDVALIVA"
    Me.txtDVALIVA.ReadOnly = True
    Me.txtDVALIVA.Size = New System.Drawing.Size(105, 20)
    Me.txtDVALIVA.TabIndex = 47
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(521, 140)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(61, 13)
    Me.Label10.TabIndex = 50
    Me.Label10.Text = "Valor Total:"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'txtDVALTOT
    '
    Me.txtDVALTOT.Location = New System.Drawing.Point(582, 140)
    Me.txtDVALTOT.Name = "txtDVALTOT"
    Me.txtDVALTOT.ReadOnly = True
    Me.txtDVALTOT.Size = New System.Drawing.Size(105, 20)
    Me.txtDVALTOT.TabIndex = 49
    '
    'cmbDTCOD
    '
    Me.cmbDTCOD.FormattingEnabled = True
    Me.cmbDTCOD.Location = New System.Drawing.Point(72, 84)
    Me.cmbDTCOD.Name = "cmbDTCOD"
    Me.cmbDTCOD.Size = New System.Drawing.Size(201, 21)
    Me.cmbDTCOD.TabIndex = 36
    '
    'cmbDDTCOD
    '
    Me.cmbDDTCOD.FormattingEnabled = True
    Me.cmbDDTCOD.Location = New System.Drawing.Point(72, 55)
    Me.cmbDDTCOD.Name = "cmbDDTCOD"
    Me.cmbDDTCOD.Size = New System.Drawing.Size(112, 21)
    Me.cmbDDTCOD.TabIndex = 32
    '
    'dgDOClin
    '
    Me.dgDOClin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgDOClin.Location = New System.Drawing.Point(15, 188)
    Me.dgDOClin.Name = "dgDOClin"
    Me.dgDOClin.Size = New System.Drawing.Size(672, 238)
    Me.dgDOClin.TabIndex = 51
    '
    'txtDDRREC
    '
    Me.txtDDRREC.Location = New System.Drawing.Point(583, 111)
    Me.txtDDRREC.Name = "txtDDRREC"
    Me.txtDDRREC.Size = New System.Drawing.Size(104, 20)
    Me.txtDDRREC.TabIndex = 44
    '
    'DOC
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Info
    Me.ClientSize = New System.Drawing.Size(705, 458)
    Me.Controls.Add(Me.txtDDRREC)
    Me.Controls.Add(Me.dgDOClin)
    Me.Controls.Add(Me.cmbDDTCOD)
    Me.Controls.Add(Me.cmbDTCOD)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.txtDVALTOT)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.txtDVALIVA)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.txtDVALQT)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.dtpDDREC)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.dtpDD)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtDNUM)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtDID)
    Me.Controls.Add(Me.btnGRAVAR)
    Me.Controls.Add(Me.btnCANCELAR)
    Me.Controls.Add(Me.btnELIMINAR)
    Me.Controls.Add(Me.btnEDITAR)
    Me.Controls.Add(Me.btnNOVO)
    Me.Controls.Add(Me.btnBUSCA)
    Me.Name = "DOC"
    Me.Text = "DOC"
    CType(Me.dgDOClin, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnGRAVAR As System.Windows.Forms.Button
  Friend WithEvents btnCANCELAR As System.Windows.Forms.Button
  Friend WithEvents btnELIMINAR As System.Windows.Forms.Button
  Friend WithEvents btnEDITAR As System.Windows.Forms.Button
  Friend WithEvents btnNOVO As System.Windows.Forms.Button
  Friend WithEvents btnBUSCA As System.Windows.Forms.Button
  Friend WithEvents txtDID As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtDNUM As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents dtpDD As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpDDREC As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtDVALQT As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtDVALIVA As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtDVALTOT As System.Windows.Forms.TextBox
  Friend WithEvents cmbDTCOD As System.Windows.Forms.ComboBox
  Friend WithEvents cmbDDTCOD As System.Windows.Forms.ComboBox
  Friend WithEvents dgDOClin As System.Windows.Forms.DataGridView
  Friend WithEvents txtDDRREC As System.Windows.Forms.TextBox
End Class
