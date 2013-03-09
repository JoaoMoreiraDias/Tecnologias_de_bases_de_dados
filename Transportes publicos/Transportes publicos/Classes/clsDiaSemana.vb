Public Class clsDiaSemana
    Private myCnn As SqlClient.SqlConnection
    Private myDiaSemanaId As String

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public ReadOnly Property diaSemanaId As String
        Get
            diaSemanaId = myDiaSemanaId
        End Get
    End Property

    'executa a stored procedure DiaSemana_ins, adiciona um dia da semana
    Public Sub addDiaSemana(ByVal dia As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DiaSemana_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@diaSemanaId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = dia
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

    'executa a stored procedure DiaSemana_del, apaga um dia da semana
    Public Sub delDiaSemana(ByVal dia As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DiaSemana_del"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@diaSemanaId"
            .DbType = DbType.String
            .Value = dia
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

    'executa a stored procedure editDiaSemana, edita o dia da semana
    Public Sub editDiaSemana(ByVal dia)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DiaSemana_edit"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@diaSemanaId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = dia
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