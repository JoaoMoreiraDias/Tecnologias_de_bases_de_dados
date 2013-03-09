
Public Class Form1

    Private Sub Form1_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = 0
        TextBox5.Text = 10000 'N
        TextBox3.Text = 0
        TextBox4.Text = 1000 'M
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox2.Items.Clear()
        Dim casa(51) As String

        For I = 0 To 51
            casa(I) = ""
        Next
        ' casa = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        Dim B As Integer
        Dim M As Integer
        Dim N As Integer
        Dim Rand As Integer
        Rand = TextBox1.Text
        B = TextBox3.Text
        M = TextBox4.Text
        Dim x As Integer
        For N = 1 To TextBox5.Text
            Rand = ((Rand * B) + 1) Mod M
            ListBox1.Items.Add(Rand)
            x = Math.Ceiling(Rand / 20)
            ' Dim temp As String = casa(x)
            casa(x) = casa(x) + "*"
        Next
        Dim pos As Integer
        For pos = 1 To UBound(casa)
            ListBox2.Items.Add(casa(pos))
        Next
    End Sub
End Class
