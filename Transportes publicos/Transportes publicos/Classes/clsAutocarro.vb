Public Class clsAutocarro
    Private myCnn As SqlClient.SqlConnection
    Private myAutocarroId As String

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public Sub New(ByVal dbConStr As String)
        myCnn = New SqlClient.SqlConnection(dbConStr)
    End Sub

    Public ReadOnly Property autocarroId As Long
        Get
            autocarroId = myAutocarroId
        End Get
    End Property

    'executa a stored procedure Autocarro_ins, para inserir um autocarro novo
    Public Sub addAutocarro(ByVal matricula As String, ByVal marca As String, ByVal tipo As Long, ByVal modelo As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Autocarro_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroMatricula"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = matricula
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroMarca"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = marca
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroTipo"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = tipo
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroModelo"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = modelo
        End With
        cmd.Parameters.Add(parametro)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            cmd.ExecuteNonQuery()
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

    'executa a stored procedure Autocaro_del, apaga um autocarro pela matricula
    Public Sub delAutocarro(ByVal matricula As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Autocarro_del"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroMatricula"
            .DbType = DbType.String
            .Value = matricula
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

    'executa a stored procedure Autocarro_ins, para editar o autocarro
    Public Sub editMarca(ByVal matricula As String, ByVal marca As String, ByVal tipo As Long, ByVal modelo As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Autocarro_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroMatricula"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = matricula
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroMarca"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = marca
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroTipo"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = tipo
        End With
        cmd.Parameters.Add(parametro)

        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@autocarroModelo"
            .DbType = DbType.Int64
            .Direction = ParameterDirection.Input
            .Value = modelo
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

    'executa a stored procedure Autocarro_SELMARCA
    Public Function autocarroSelMarca(ByVal marca As String) As DataTable
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandText = "Autocarro_SELMARCA"
            .CommandType = CommandType.StoredProcedure
        End With

        Dim prm As SqlClient.SqlParameter
        prm = New SqlClient.SqlParameter

        With prm
            .Direction = ParameterDirection.Input
            .DbType = DbType.String
            .ParameterName = "@autocarro_Marca"
            .Value = marca
        End With
        cmd.Parameters.Add(prm)

        Try
            If myCnn.State = ConnectionState.Closed Then myCnn.Open()
            Dim tbl As New DataTable
            tbl.Load(cmd.ExecuteReader)
            autocarroSelMarca = tbl
            myCnn.Close()
        Catch ex As Exception
            If myCnn.State = ConnectionState.Open Then myCnn.Close()
            autocarroSelMarca = Nothing
            RaiseEvent Errors(ex.Message)
        End Try
    End Function
End Class
