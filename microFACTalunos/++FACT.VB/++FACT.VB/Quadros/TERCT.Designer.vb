<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TERCT
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
    Dim Z_CodigoLabel As System.Windows.Forms.Label
    Dim Z_NomeLabel As System.Windows.Forms.Label
    Me.txtTTDESCR = New System.Windows.Forms.TextBox()
    Me.txtTTCOD = New System.Windows.Forms.TextBox()
    Me.btnBUSCA = New System.Windows.Forms.Button()
    Me.btnNOVO = New System.Windows.Forms.Button()
    Me.btnEDITAR = New System.Windows.Forms.Button()
    Me.btnELIMINAR = New System.Windows.Forms.Button()
    Me.btnCANCELAR = New System.Windows.Forms.Button()
    Me.btnGRAVAR = New System.Windows.Forms.Button()
    Z_CodigoLabel = New System.Windows.Forms.Label()
    Z_NomeLabel = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Z_CodigoLabel
    '
    Z_CodigoLabel.AutoSize = True
    Z_CodigoLabel.Location = New System.Drawing.Point(78, 66)
    Z_CodigoLabel.Name = "Z_CodigoLabel"
    Z_CodigoLabel.Size = New System.Drawing.Size(43, 13)
    Z_CodigoLabel.TabIndex = 14
    Z_CodigoLabel.Text = "Codigo:"
    '
    'Z_NomeLabel
    '
    Z_NomeLabel.AutoSize = True
    Z_NomeLabel.Location = New System.Drawing.Point(64, 97)
    Z_NomeLabel.Name = "Z_NomeLabel"
    Z_NomeLabel.Size = New System.Drawing.Size(57, 13)
    Z_NomeLabel.TabIndex = 16
    Z_NomeLabel.Text = "Descritivo:"
    '
    'txtTTDESCR
    '
    Me.txtTTDESCR.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTTDESCR.Location = New System.Drawing.Point(127, 97)
    Me.txtTTDESCR.Name = "txtTTDESCR"
    Me.txtTTDESCR.Size = New System.Drawing.Size(371, 24)
    Me.txtTTDESCR.TabIndex = 17
    '
    'txtTTCOD
    '
    Me.txtTTCOD.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtTTCOD.Location = New System.Drawing.Point(127, 66)
    Me.txtTTCOD.Name = "txtTTCOD"
    Me.txtTTCOD.Size = New System.Drawing.Size(100, 24)
    Me.txtTTCOD.TabIndex = 15
    '
    'btnBUSCA
    '
    Me.btnBUSCA.Location = New System.Drawing.Point(12, 1)
    Me.btnBUSCA.Name = "btnBUSCA"
    Me.btnBUSCA.Size = New System.Drawing.Size(44, 23)
    Me.btnBUSCA.TabIndex = 18
    Me.btnBUSCA.Text = "busca"
    Me.btnBUSCA.UseVisualStyleBackColor = True
    '
    'btnNOVO
    '
    Me.btnNOVO.Location = New System.Drawing.Point(62, 1)
    Me.btnNOVO.Name = "btnNOVO"
    Me.btnNOVO.Size = New System.Drawing.Size(40, 23)
    Me.btnNOVO.TabIndex = 19
    Me.btnNOVO.Text = "novo"
    Me.btnNOVO.UseVisualStyleBackColor = True
    '
    'btnEDITAR
    '
    Me.btnEDITAR.Location = New System.Drawing.Point(108, 1)
    Me.btnEDITAR.Name = "btnEDITAR"
    Me.btnEDITAR.Size = New System.Drawing.Size(44, 23)
    Me.btnEDITAR.TabIndex = 20
    Me.btnEDITAR.Text = "editar"
    Me.btnEDITAR.UseVisualStyleBackColor = True
    '
    'btnELIMINAR
    '
    Me.btnELIMINAR.Location = New System.Drawing.Point(158, 1)
    Me.btnELIMINAR.Name = "btnELIMINAR"
    Me.btnELIMINAR.Size = New System.Drawing.Size(50, 23)
    Me.btnELIMINAR.TabIndex = 21
    Me.btnELIMINAR.Text = "eliminar"
    Me.btnELIMINAR.UseVisualStyleBackColor = True
    '
    'btnCANCELAR
    '
    Me.btnCANCELAR.Location = New System.Drawing.Point(214, 1)
    Me.btnCANCELAR.Name = "btnCANCELAR"
    Me.btnCANCELAR.Size = New System.Drawing.Size(60, 23)
    Me.btnCANCELAR.TabIndex = 22
    Me.btnCANCELAR.Text = "cancelar"
    Me.btnCANCELAR.UseVisualStyleBackColor = True
    '
    'btnGRAVAR
    '
    Me.btnGRAVAR.Location = New System.Drawing.Point(280, 1)
    Me.btnGRAVAR.Name = "btnGRAVAR"
    Me.btnGRAVAR.Size = New System.Drawing.Size(51, 23)
    Me.btnGRAVAR.TabIndex = 23
    Me.btnGRAVAR.Text = "gravar"
    Me.btnGRAVAR.UseVisualStyleBackColor = True
    '
    'TERCT
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(566, 187)
    Me.Controls.Add(Me.btnGRAVAR)
    Me.Controls.Add(Me.btnCANCELAR)
    Me.Controls.Add(Me.btnELIMINAR)
    Me.Controls.Add(Me.btnEDITAR)
    Me.Controls.Add(Me.btnNOVO)
    Me.Controls.Add(Me.btnBUSCA)
    Me.Controls.Add(Me.txtTTDESCR)
    Me.Controls.Add(Z_CodigoLabel)
    Me.Controls.Add(Z_NomeLabel)
    Me.Controls.Add(Me.txtTTCOD)
    Me.Name = "TERCT"
    Me.Text = "TERCT"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtTTDESCR As System.Windows.Forms.TextBox
  Friend WithEvents txtTTCOD As System.Windows.Forms.TextBox
  Friend WithEvents btnBUSCA As System.Windows.Forms.Button
  Friend WithEvents btnNOVO As System.Windows.Forms.Button
  Friend WithEvents btnEDITAR As System.Windows.Forms.Button
  Friend WithEvents btnELIMINAR As System.Windows.Forms.Button
  Friend WithEvents btnCANCELAR As System.Windows.Forms.Button
  Friend WithEvents btnGRAVAR As System.Windows.Forms.Button
End Class
