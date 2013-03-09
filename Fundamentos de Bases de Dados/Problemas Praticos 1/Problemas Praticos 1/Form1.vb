Public Class Form1
    Private Sub Form1_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = 0
        TextBox5.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim B As Long
        Dim M As Long
        Dim N As Long
        Dim Rand As Integer
        Rand = TextBox1.Text
        B = TextBox3.Text
        M = TextBox4.Text
        For N = 1 To TextBox5.Text
            Rand = ((Rand * B) + 1) Mod M
            ListBox1.Items.Add(Rand)
        Next
    End Sub
End Class
