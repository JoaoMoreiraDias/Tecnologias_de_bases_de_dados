<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INICIAL
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
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.TabelasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.TiposDeTerceirosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.TiposDeTerceirosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
    Me.SAIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AcercaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TabelasToolStripMenuItem, Me.AjudaToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(497, 24)
    Me.MenuStrip1.TabIndex = 0
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'TabelasToolStripMenuItem
    '
    Me.TabelasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TiposDeTerceirosToolStripMenuItem, Me.SAIRToolStripMenuItem})
    Me.TabelasToolStripMenuItem.Name = "TabelasToolStripMenuItem"
    Me.TabelasToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
    Me.TabelasToolStripMenuItem.Text = "Ficheiros"
    '
    'TiposDeTerceirosToolStripMenuItem
    '
    Me.TiposDeTerceirosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentosToolStripMenuItem, Me.TiposDeTerceirosToolStripMenuItem1})
    Me.TiposDeTerceirosToolStripMenuItem.Name = "TiposDeTerceirosToolStripMenuItem"
    Me.TiposDeTerceirosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.TiposDeTerceirosToolStripMenuItem.Text = "Tabelas"
    '
    'DocumentosToolStripMenuItem
    '
    Me.DocumentosToolStripMenuItem.Name = "DocumentosToolStripMenuItem"
    Me.DocumentosToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
    Me.DocumentosToolStripMenuItem.Text = "Documentos"
    '
    'TiposDeTerceirosToolStripMenuItem1
    '
    Me.TiposDeTerceirosToolStripMenuItem1.Name = "TiposDeTerceirosToolStripMenuItem1"
    Me.TiposDeTerceirosToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
    Me.TiposDeTerceirosToolStripMenuItem1.Text = "Tipos de Terceiros"
    '
    'SAIRToolStripMenuItem
    '
    Me.SAIRToolStripMenuItem.Name = "SAIRToolStripMenuItem"
    Me.SAIRToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.SAIRToolStripMenuItem.Text = "SAIR"
    '
    'AjudaToolStripMenuItem
    '
    Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaToolStripMenuItem})
    Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
    Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
    Me.AjudaToolStripMenuItem.Text = "Ajuda"
    '
    'AcercaToolStripMenuItem
    '
    Me.AcercaToolStripMenuItem.Name = "AcercaToolStripMenuItem"
    Me.AcercaToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
    Me.AcercaToolStripMenuItem.Text = "Acerca..."
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.Label1.Location = New System.Drawing.Point(12, 160)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(486, 63)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "μFACT - TBD 2012"
    '
    'INICIAL
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(497, 242)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.MenuStrip1)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "INICIAL"
    Me.Text = "INICIAL"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
  Friend WithEvents TabelasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TiposDeTerceirosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SAIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TiposDeTerceirosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AjudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AcercaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DocumentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
