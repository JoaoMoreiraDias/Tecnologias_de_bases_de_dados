Public Class clsLinha
    Private myCnn As SqlClient.SqlConnection
    Private mylinId As String

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public ReadOnly Property linId As String
        Get
            linId = mylinId
        End Get
    End Property

    Public Sub addLinha(ByVal nome As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Linha_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@linhaId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = nome
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

    Public Sub delLinha(ByVal nome As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Linha_del"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@linhaId"
            .DbType = DbType.String
            .Value = nome
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

    Public Sub editLinha(ByVal nome)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Linha_edit"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@linhaId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = nome
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
End Class