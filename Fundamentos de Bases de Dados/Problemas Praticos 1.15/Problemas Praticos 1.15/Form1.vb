Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox2.Text = "C:\Documents and Settings\Administrator\Desktop\Teste.txt"
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()

        Dim FILE_NAME As String = TextBox2.Text
        Dim TextLine As String

        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            Do While objReader.Peek() <> -1
                TextLine = TextLine & objReader.ReadLine() & vbNewLine
            Loop

            TextLine = TextLine.ToUpper
            Dim Cletras() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            Dim letras() As Char = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "O", "M", "E", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "X", "Y", "Z"}

            For Each elemento As Integer In Cletras
                elemento = 0
            Next

            Dim I As Integer
            For I = 0 To TextLine.Length()
                Dim temp As Char = TextLine.Substring(I)
                For A = 0 To letras.Length
                    If letras(A).CompareTo(temp) = 0 Then
                        Cletras(A) = Cletras(A) + 1
                    End If
                Next
            Next
            For B = 0 To letras.Length
                Dim linha As String
                linha = letras(B)
                linha = linha + ": "
                linha = linha + Cletras(B)
                ListBox1.Items.Add(linha)
            Next

        Else
            MsgBox("Erro no File Path")

        End If
    End Sub


End Class

