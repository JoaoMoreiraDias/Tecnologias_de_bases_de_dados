Public Class clsPessoa
    Private myCnn As SqlClient.SqlConnection
    Private myPessId As Long
    Private myPessNome As String
    Private myPessDataNascimento As String
    Private myPessMorada As String
    Private myPessTelefone As String
    Private myPessCondutor As Boolean

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public Sub New(ByVal dbConStr As String)
        myCnn = New SqlClient.SqlConnection(dbConStr)
    End Sub

    Public ReadOnly Property pessId As Long
        Get
            pessId = myPessId
        End Get
    End Property

    Public Property pessNome As String
        Get
            pessNome = myPessNome
        End Get
        Set(value As String)
            myPessNome = value
        End Set
    End Property

    Public Property pessDataNascimento As String
        Get
            pessDataNascimento = myPessDataNascimento
        End Get
        Set(value As String)
            myPessDataNascimento = value
        End Set
    End Property

    Public Property pessMorada As String
        Get
            pessMorada = myPessMorada
        End Get
        Set(value As String)
            myPessMorada = value
        End Set
    End Property

    Public Property pessTelefone As String
        Get
            pessTelefone = myPessTelefone
        End Get
        Set(value As String)
            myPessTelefone = value
        End Set
    End Property

    Public Property pessCondutor As Boolean
        Get
            pessCondutor = myPessCondutor
        End Get
        Set(value As Boolean)
            myPessCondutor = value
        End Set
    End Property

    Public Function pessLista() As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Pessoa_get_all"
            .CommandType = CommandType.StoredProcedure
        End With

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            pessLista = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            pessLista = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function

    Public Sub addPessoa(ByVal nome As String, ByVal dataNascimento As String, ByVal morada As String, ByVal telefone As String, ByVal condutor As Boolean)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Pessoa_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessNome"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = nome
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessDataNascimento"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = dataNascimento
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessMorada"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = morada
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessTelefone"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = telefone
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessCondutor"
            .DbType = DbType.Byte
            .Direction = ParameterDirection.Input
            .Value = condutor
        End With
        cmd.Parameters.Add(parametro)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
            RaiseEvent Action(8)
            myCnn.Close()
        Catch ex As SqlClient.SqlException
            If Left(ex.Message, 35) = "Violação da chave primária" Then
                RaiseEvent Action(5)
            Else
                RaiseEvent Errors(ex.Message)
            End If
        Catch ex2 As Exception
        End Try
        If myCnn.State = ConnectionState.Open Then
            myCnn.Close()
        End If
    End Sub

    Public Sub delPessoa(ByVal id As Long)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Pessoa_del"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessId"
            .DbType = DbType.Int64
            .Value = id
        End With
        cmd.Parameters.Add(parametro)

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

    Public Sub editPessoa(ByVal id As Long, ByVal nome As String, ByVal dataNascimento As String, ByVal morada As String, ByVal telefone As String, ByVal condutor As Boolean)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Pessoa_edit"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessId"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = id
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessNome"
            .Direction = ParameterDirection.Input
            .DbType = DbType.String
            .Value = nome
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessDataNascimento"
            .Direction = ParameterDirection.Input
            .DbType = DbType.String
            .Value = dataNascimento
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessMorada"
            .Direction = ParameterDirection.Input
            .DbType = DbType.String
            .Value = morada
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessTelefone"
            .Direction = ParameterDirection.Input
            .DbType = DbType.String
            .Value = telefone
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@pessCondutor"
            .Direction = ParameterDirection.Input
            .DbType = DbType.Byte
            .Value = condutor
        End With
        cmd.Parameters.Add(parametro)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
            RaiseEvent Action(7)
        Catch ex As Exception
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub

    Public Function pessoaSelTipo(ByVal tipoId As Long) As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Pessoa_SELTIPO"
            .CommandType = CommandType.StoredProcedure
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter

        With prm
            .Direction = ParameterDirection.Input
            .DbType = DbType.Int64
            .ParameterName = "@PessoaTipo"
            .Value = tipoId
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            pessoaSelTipo = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            pessoaSelTipo = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function

    Public Sub getPessoa(ByVal id As Long)

        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Pessoa_SEL1"
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
                    Me.myPessId = .Item("PESS_id")
                    Me.myPessNome = .Item("PESS_nome")
                    Me.pessDataNascimento = .Item("PESS_dataNascimento")
                    Me.myPessTelefone = .Item("PESS_telefone")
                    Me.pessCondutor = .Item("PESS_condutor")
                    Me.myPessMorada = .Item("PESS_morada")
                End With
                RaiseEvent Action(-1)
            Else
                Me.myPessId = vbNull
                Me.myPessNome = vbNull
                Me.pessDataNascimento = vbNull
                Me.myPessTelefone = vbNull
                RaiseEvent Action(2)
            End If
        Catch ex As Exception
            RaiseEvent Errors(ex.Message)
        End Try
    End Sub

    Public Function pessoaGetJornada(ByVal id As Long) As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Pessoa_SEL_Jornada"
            .CommandType = CommandType.StoredProcedure
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter

        With prm
            .Direction = ParameterDirection.Input
            .DbType = DbType.Int64
            .ParameterName = "@id"
            .Value = id
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            pessoaGetJornada = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            pessoaGetJornada = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function
End Class