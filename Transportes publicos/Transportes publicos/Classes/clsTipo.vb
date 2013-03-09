Public Class clsTipo
    Private myCnn As SqlClient.SqlConnection

    Private myTipoId As Long
    Private myTipoNome As String
    Private myTipoLugaresSentados As Integer
    Private myTipoLugaresEmPe As Integer

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public Sub New(ByVal dbConStr As String)
        myCnn = New SqlClient.SqlConnection(dbConStr)
    End Sub

    Public ReadOnly Property id As Long
        Get
            id = myTipoId
        End Get
    End Property

    Public Property tipoNome As String
        Get
            tipoNome = myTipoNome
        End Get
        Set(value As String)
            myTipoNome = value
        End Set
    End Property

    Public Property tipoLugaresSentados As Integer
        Get
            tipoLugaresSentados = myTipoLugaresSentados
        End Get
        Set(value As Integer)
            myTipoLugaresSentados = value
        End Set
    End Property

    Public Property tipoLugaresEmPe As Integer
        Get
            tipoLugaresEmPe = myTipoLugaresEmPe
        End Get
        Set(value As Integer)
            myTipoLugaresEmPe = value
        End Set
    End Property

    'executa a stored procedure Tipo_get_all, busca todos os tipos
    Public Function listaTipo() As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Tipo_get_all"
            .CommandType = CommandType.StoredProcedure
        End With

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            listaTipo = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            listaTipo = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function

    'executa a stored procedure Tipo_SEL1
    Public Sub getTipo(ByVal id As Long)

        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Tipo_SEL1"
        End With

        Dim prm As SqlClient.SqlParameter

        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@id"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = id
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            If tbl.Rows.Count > 0 Then
                With tbl.Rows(0)
                    Me.myTipoId = .Item("T_id")
                    Me.myTipoNome = .Item("T_nome")
                    Me.myTipoLugaresSentados = .Item("T_lugares_sentados")
                    Me.myTipoLugaresEmPe = .Item("T_lugares_em_pe")
                End With
                RaiseEvent Action(-1)
            Else
                Me.myTipoId = vbNull
                Me.myTipoNome = vbNull
                Me.myTipoLugaresSentados = vbNull
                Me.myTipoLugaresEmPe = vbNull
                RaiseEvent Action(2)
            End If
        Catch ex As Exception
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub
End Class
