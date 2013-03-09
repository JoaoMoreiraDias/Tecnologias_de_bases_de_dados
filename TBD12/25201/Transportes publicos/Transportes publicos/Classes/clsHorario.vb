Public Class clsHorario
    Private myCnn As SqlClient.SqlConnection
    Private myHorario As String
    Private myHorarioId As Long

    Public Event Action(ByVal estado As Integer)
    Public Event Errors(ByVal mensagem As Object)

    Public ReadOnly Property horarioId As String
        Get
            horarioId = myHorarioId
        End Get
    End Property

    Public Sub addHorario(ByVal horario As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Horario_ins"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@horarioId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = horario
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

    Public Sub delHorario(ByVal horario As String)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Horario_del"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@horarioId"
            .DbType = DbType.String
            .Value = horario
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

    Public Sub editHorario(ByVal horario)
        Dim cmd As New SqlClient.SqlCommand
        With cmd
            .Connection = myCnn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "Horario_edit"
        End With

        Dim parametro As SqlClient.SqlParameter
        parametro = New SqlClient.SqlParameter
        With parametro
            .ParameterName = "@horarioId"
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Value = horario
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