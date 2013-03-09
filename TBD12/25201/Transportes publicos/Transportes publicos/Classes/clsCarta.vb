Public Class clsCarta

    Private myCnn As SqlClient.SqlConnection
    Private myCartaTipoId As Long
    Private myCartaDataEmissao As String
    Private myCartaDataValidade As String

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public Property cartaTipoId As Long
        Get
            cartaTipoId = myCartaTipoId
        End Get
        Set(value As Long)
            myCartaTipoId = value
        End Set
    End Property

    Public Property cartaDataEmissao As String
        Get
            cartaDataEmissao = myCartaDataEmissao
        End Get
        Set(value As String)
            myCartaDataEmissao = value
        End Set
    End Property

    Public Property cartaDataValidade As String
        Get
            cartaDataValidade = myCartaDataValidade
        End Get
        Set(value As String)
            myCartaDataValidade = value
        End Set
    End Property

    Public Sub New(ByVal dbConStr As String)
        myCnn = New SqlClient.SqlConnection(dbConStr)
    End Sub

    'Escreve o quadro das cartas
    Public Function pessCarta(ByVal pessId As Long) As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Carta_SEL1"
            .CommandType = CommandType.StoredProcedure
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@pessId"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = pessId
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            pessCarta = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            pessCarta = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function

    'Public Sub getMarca(ByVal nome As String)
    '    Dim cmd As New SqlClient.SqlCommand
    '    With cmd
    '        .Connection = myCnn
    '        .CommandType = CommandType.StoredProcedure
    '        .CommandText = "Marca_SEL1"
    '    End With

    '    Dim prm As SqlClient.SqlParameter

    '    prm = New SqlClient.SqlParameter
    '    With prm
    '        .ParameterName = "@nome"
    '        .DbType = DbType.String
    '        .Direction = ParameterDirection.Input
    '        .Value = nome
    '    End With
    '    cmd.Parameters.Add(prm)

    '    Try
    '        If myCnn.State = ConnectionState.Closed Then myCnn.Open()
    '        Dim tbl As New DataTable
    '        tbl.Load(cmd.ExecuteReader)
    '        If tbl.Rows.Count > 0 Then
    '            With tbl.Rows(0)
    '                Me.myMarca = .Item("M_nome")
    '            End With
    '            RaiseEvent Action(-1)
    '        Else
    '            Me.myMarca = vbNull
    '            RaiseEvent Action(2)
    '        End If
    '    Catch ex As Exception
    '        RaiseEvent Errors(ex.Message)
    '    End Try
    'End Sub
End Class
