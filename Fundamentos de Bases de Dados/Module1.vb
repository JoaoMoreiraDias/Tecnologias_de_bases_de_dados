Module Module1

    Private nome As String
    Private email As String
    Private dominio As String

    Sub Main()

        Console.WriteLine("Qual o nome do Funcionario?")
        nome = Console.ReadLine()

        Console.WriteLine("Qual o dominio?")
        dominio = Console.ReadLine()

        Console.WriteLine(criarEmail(nome, dominio))
        Console.ReadLine()

    End Sub

    Public Function criarEmail(ByVal novo_nome As String, ByVal nove_dominio As String) As String

        nome = novo_nome
        dominio = nove_dominio
        Dim letra As String
        Dim sub_nomes() As String = nome.Split(" ")

        For i = 0 To sub_nomes.GetUpperBound(0)

            If (sub_nomes(i) = "") Then

            Else
                letra = sub_nomes(i).Substring(0, 1)
                If (i = sub_nomes.GetUpperBound(0)) Then
                    letra = "." & letra.ToUpper
                    letra = letra + sub_nomes(i).Substring(1)
                    email = email & letra
                Else
                    letra = letra.ToLower()
                    email = email & letra
                End If
            End If


        Next

        email = email & "@" & dominio

        Return email

    End Function

End Module
