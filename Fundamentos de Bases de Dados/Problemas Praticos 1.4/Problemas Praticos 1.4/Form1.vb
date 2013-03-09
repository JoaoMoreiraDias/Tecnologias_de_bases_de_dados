Public Class Form1
    Public Function power(ByVal x As Integer, ByVal n As Integer) As Integer

        If x = 0 Then
            Return 0
        ElseIf n = 0 Then
            Return 1
        ElseIf n > 0 Then
            Return (x * power(x, n - 1))
        Else
            Return ((1 / x) * power(x, n + 1))
    End Function
End Class
