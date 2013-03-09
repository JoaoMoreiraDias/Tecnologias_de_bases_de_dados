Public Class Form1
    Sub Quicksort(ByVal List() As Long, ByVal min As Integer, ByVal max As Integer)
        Dim med_value As Long
        Dim hi As Integer
        Dim lo As Integer
        Dim i As Integer

        ' se a lista tiver multiplos elementos, é ordenada
        If min >= max Then Exit Sub

        ' escolher um item a dividir
        i = Int((max - min + 1) * Rnd() + min)
        med_value = List(i)

        ' elemento é posicionado na frente para ser mais facil de acceder
        List(i) = List(min)

        ' items mas pequenos que este sao movidos para a metade d esquerda, o respo para a metade da direita
        lo = min
        hi = max
        Do
            ' procura de hi para baixo por um valor menor que < med_value.
            Do While List(hi) >= med_value
                hi = hi - 1
                If hi <= lo Then Exit Do
            Loop
            If hi <= lo Then
                List(lo) = med_value
                Exit Do
            End If

            'trocar os valores lo por hi
            List(lo) = List(hi)

            ' precorer de lo por um valor >= med_value.
            lo = lo + 1
            Do While List(lo) < med_value
                lo = lo + 1
                If lo >= hi Then Exit Do
            Loop
            If lo >= hi Then
                lo = hi
                List(hi) = med_value
                Exit Do
            End If

            ' trocar valores lo por hi
            List(hi) = List(lo)
        Loop

        ' Sort the two sublists
        Quicksort(List, min, lo - 1)
        Quicksort(List, lo + 1, max)
    End Sub
End Class
