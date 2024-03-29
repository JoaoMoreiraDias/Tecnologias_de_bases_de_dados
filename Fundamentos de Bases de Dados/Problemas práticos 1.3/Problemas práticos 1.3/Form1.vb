﻿Public Class Form1

    Public Function HeapSort(ByVal Keys)
        Dim Base As Long : Base = LBound(Keys)                    ' array index base
        Dim n As Long : n = UBound(Keys) - LBound(Keys) + 1       ' array size
   ReDim Index(Base To Base + n - 1) As Long                ' allocate index array
        Dim i As Long, m As Long
        For i = 0 To n - 1 : Index(Base + i) = Base + i : Next     ' fill index array
        For i = n \ 2 - 1 To 0 Step -1                           ' generate ordered heap
            Heapify(Keys, Index, i, n)
        Next
        For m = n To 2 Step -1
            Exchange(Index, 0, m - 1)                              ' move highest element to top
            Heapify(Keys, Index, 0, m - 1)
        Next
        HeapSort = Index
    End Function

    Private Sub Heapify(ByVal Keys, ByVal Index() As Long, ByVal i1 As Long, ByVal n As Long)
        ' Heap order rule: a[i] >= a[2*i+1] and a[i] >= a[2*i+2]
        Dim Base As Long : Base = LBound(Index)
        Dim nDiv2 As Long : nDiv2 = n \ 2
        Dim i As Long : i = i1
        Do While i < nDiv2
            Dim k As Long : k = 2 * i + 1
            If k + 1 < n Then
                If Keys(Index(Base + k)) < Keys(Index(Base + k + 1)) Then k = k + 1
            End If
            If Keys(Index(Base + i)) >= Keys(Index(Base + k)) Then Exit Do
            Exchange(Index, i, k)
            i = k
        Loop
    End Sub

    Private Sub Exchange(ByVal a() As Long, ByVal i As Long, ByVal j As Long)
        Dim Base As Long : Base = LBound(a)
        Dim Temp As Long : Temp = a(Base + i)
        a(Base + i) = a(Base + j)
        a(Base + j) = Temp
    End Sub


End Class
