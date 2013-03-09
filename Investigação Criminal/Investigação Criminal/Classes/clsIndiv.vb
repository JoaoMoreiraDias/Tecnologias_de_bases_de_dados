Public Class clsIndiv
    Private myCnn As SqlClient.SqlConnection
    Private myIndiv_id As Long
    Private myIndiv_nome As String
    Private myIndiv_alcunha As String
    Private myIndiv_dob As Date
    Private myIndiv_telef As Integer
    Public Event Action(ByVal status As Integer)
    Public Event Errors(ByVal errMessages As Object)

    Public Sub New(ByVal dbConStr As String)
        myCnn = New SqlClient.SqlConnection(dbConStr)
    End Sub

    Public ReadOnly Property Indiv_id As Long
        Get
            Indiv_id = myIndiv_id
        End Get
    End Property

    Public Property Indiv_nome As String
        Get
            Indiv_nome = myIndiv_nome
        End Get
        Set(ByVal value As String)
            myIndiv_nome = value
        End Set
    End Property

    Public Property Indiv_alcunha As String
        Get
            Indiv_alcunha = myIndiv_alcunha
        End Get
        Set(ByVal value As String)
            myIndiv_alcunha = value
        End Set
    End Property

    Public Property Indiv_dob As Date
        Get
            Indiv_dob = myIndiv_dob
        End Get
        Set(ByVal value As Date)
            myIndiv_dob = value
        End Set
    End Property

    Public Property Indiv_telef As Integer
        Get
            Indiv_telef = myIndiv_telef
        End Get
        Set(ByVal value As Integer)
            myIndiv_telef = value
        End Set
    End Property

    'Executa o stored procedure Individuo_get_indiv, busca o individuo por ID Unico
    Public Sub getIndiv(ByVal Indiv_id As Long)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Individuo_get_indiv"
        End With

        Dim prm As SqlClient.SqlParameter

        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@Indiv_id"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = Indiv_id
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            If tbl.Rows.Count > 0 Then
                With tbl.Rows(0)
                    Me.myIndiv_id = .Item("Indiv_id")
                    Me.myIndiv_nome = .Item("Indiv_nome")
                    Me.myIndiv_alcunha = .Item("Indiv_alcunha")
                    Me.myIndiv_dob = .Item("Indiv_dob")
                    Me.myIndiv_telef = .Item("Indiv_telef")
                End With
                RaiseEvent Action(-1)
            Else
                Me.myIndiv_id = vbNull
                Me.myIndiv_nome = vbNull
                Me.myIndiv_alcunha = vbNull
                Me.myIndiv_dob = Nothing
                Me.myIndiv_telef = vbNull
                RaiseEvent Action(2)
            End If
        Catch ex As Exception
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub

    'Executa o stored procedure Individuo_get_all, busac todos os Individuos
    Public Function listIndiv() As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Individuo_get_all"
            .CommandType = CommandType.StoredProcedure
        End With

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            listIndiv = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            listIndiv = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function

    'Executa o stored procedure Individuo_get_detencoes, busac todas as detençõens pelo ID Unico do individuo em questão
    Public Function getDeten() As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Individuo_get_detencoes"
        End With

        Dim prm As SqlClient.SqlParameter

        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@id"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = Indiv_id
        End With

        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            getDeten = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            getDeten = Nothing
            RaiseEvent Errors(ex.Message)
        End Try

    End Function

    'Executa o stored procedure INDIV_DEL, para apagar o Individuo
    Public Sub del(ByVal indID As Long)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "INDIV_DEL"
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@indivId"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = indID
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
            RaiseEvent Action(6)
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub

    'Executa o stored procedure, para adicionar um individuo novo
    Public Sub add(ByVal nome As String, ByVal alcunha As String, ByVal dob As Date, ByVal telefone As Integer)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Individuo_add"
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@nome"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = nome
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@alcunha"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = alcunha
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@dob"
            .DbType = DbType.Date
            .Direction = ParameterDirection.Input
            .Value = dob
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@telefone"
            .DbType = DbType.Int32
            .Direction = ParameterDirection.Input
            .Value = telefone
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
            RaiseEvent Action(6)
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub

    'Executa o stored procedure, para editar o Individuo
    Public Sub edit(ByVal id As Long, ByVal nome As String, ByVal alcunha As String, ByVal dob As Date, ByVal telefone As Integer)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Indiv_Edit"
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@id"
            .DbType = DbType.UInt64
            .Direction = ParameterDirection.Input
            .Value = id
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@nome"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = nome
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@alcunha"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = alcunha
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@dob"
            .DbType = DbType.Date
            .Direction = ParameterDirection.Input
            .Value = dob
        End With
        cmd.Parameters.Add(prm)
        prm = New SqlClient.SqlParameter
        With prm
            .ParameterName = "@telefone"
            .DbType = DbType.Int32
            .Direction = ParameterDirection.Input
            .Value = telefone
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
            RaiseEvent Action(6)
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub
End Class
