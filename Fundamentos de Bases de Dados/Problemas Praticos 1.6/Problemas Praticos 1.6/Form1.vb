Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x0 As Double, x1 As Double, a As Double
        If IsNumeric(Trim(TextBox1.Text)) = False Then
            MsgBox("Valor invalido!", vbOKOnly, "ERRO!")
        Else
            a = Val(Trim(TextBox1.Text))
            x0 = 1
            x1 = 0
            Do While True = True
                x1 = (1 / 2) * (x0 + a / x0)
                If x0 = x1 Then Exit Do
                x0 = x1
            Loop
            TextBox1.Text = x0
        End If
    End Sub
End Class