<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicial
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
        Me.FicheirosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabelasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutocarrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PessoasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HabilitaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FicheirosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(674, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FicheirosToolStripMenuItem
        '
        Me.FicheirosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TabelasToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.FicheirosToolStripMenuItem.Name = "FicheirosToolStripMenuItem"
        Me.FicheirosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.FicheirosToolStripMenuItem.Text = "Ficheiros"
        '
        'TabelasToolStripMenuItem
        '
        Me.TabelasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutocarrosToolStripMenuItem, Me.PessoasToolStripMenuItem, Me.HabilitaçãoToolStripMenuItem})
        Me.TabelasToolStripMenuItem.Name = "TabelasToolStripMenuItem"
        Me.TabelasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TabelasToolStripMenuItem.Text = "Tabelas"
        '
        'AutocarrosToolStripMenuItem
        '
        Me.AutocarrosToolStripMenuItem.Name = "AutocarrosToolStripMenuItem"
        Me.AutocarrosToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AutocarrosToolStripMenuItem.Text = "Autocarros"
        '
        'PessoasToolStripMenuItem
        '
        Me.PessoasToolStripMenuItem.Name = "PessoasToolStripMenuItem"
        Me.PessoasToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.PessoasToolStripMenuItem.Text = "Pessoas"
        '
        'HabilitaçãoToolStripMenuItem
        '
        Me.HabilitaçãoToolStripMenuItem.Name = "HabilitaçãoToolStripMenuItem"
        Me.HabilitaçãoToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.HabilitaçãoToolStripMenuItem.Text = "Habilitação"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'Inicial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 271)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Inicial"
        Me.Text = "inicial"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FicheirosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabelasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutocarrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PessoasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HabilitaçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
