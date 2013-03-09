<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutocarrosMarca
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgMarcaCarro = New System.Windows.Forms.DataGridView()
        CType(Me.dgMarcaCarro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgMarcaCarro
        '
        Me.dgMarcaCarro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMarcaCarro.Location = New System.Drawing.Point(12, 41)
        Me.dgMarcaCarro.Name = "dgMarcaCarro"
        Me.dgMarcaCarro.Size = New System.Drawing.Size(745, 310)
        Me.dgMarcaCarro.TabIndex = 77
        '
        'AutocarrosMarca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 363)
        Me.Controls.Add(Me.dgMarcaCarro)
        Me.Controls.Add(Me.Button1)
        Me.Name = "AutocarrosMarca"
        Me.Text = "Autocarros por Marca"
        CType(Me.dgMarcaCarro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgMarcaCarro As System.Windows.Forms.DataGridView
End Class
