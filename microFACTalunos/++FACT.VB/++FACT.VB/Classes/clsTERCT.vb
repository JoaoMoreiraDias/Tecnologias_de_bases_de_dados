Public Class clsTERCT
  Private myCnn As SqlClient.SqlConnection
  Private myTT_COD As String
  Private myTT_DESCR As String

  Public Event Action(ByVal status As Integer)
  Public Event Errors(ByVal errMessages As Object)

  Public Property COD() As String
    Get
      COD = myTT_COD
    End Get
    Set(ByVal value As String)
      myTT_COD = value
    End Set
  End Property
 
  Public Property DESCR As String
    Get
      DESCR = myTT_DESCR
    End Get
    Set(value As String)
      myTT_DESCR = value
    End Set
  End Property

  Public Sub New(ByVal dbConStr As String)
    myCnn = New SqlClient.SqlConnection(dbConStr)
  End Sub

  Public Function listTERCT() As DataTable
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandText = "TERCT_SELALL"
      .CommandType = CommandType.StoredProcedure
    End With

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      listTERCT = tbl
      myCnn.Close()
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      listTERCT = Nothing
      RaiseEvent Errors(ex.Message)
    End Try
  End Function

  Public Sub addTERCT(ByVal TTCOD As String, ByVal TTDESCR As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "TERCT_INS"
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTCOD"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = TTCOD
    End With
    cmd.Parameters.Add(prm)

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTDESCR"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = TTDESCR
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()
      RaiseEvent Action(8)
      myCnn.Close()
    Catch ex As SqlClient.SqlException 'podem apanhar-se os erros de SQL e depois os outros!
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      If Left(ex.Message, 35) = "Violation of PRIMARY KEY constraint" Then
        RaiseEvent Action(5)
      Else
        RaiseEvent Errors(ex.Message)
      End If
    Catch ex2 As Exception
      '------
    End Try
    If myCnn.State = ConnectionState.Open Then myCnn.Close()
  End Sub

  Public Sub delTERCT(ByVal TTCOD As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "TERCT_DEL"
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTCOD"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = TTCOD
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

  Public Sub updTERCT(ByVal TTCOD As String, ByVal TTDESCR As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "TERCT_UPD"
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTCOD"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = TTCOD
    End With
    cmd.Parameters.Add(prm)

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTDESCR"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = TTDESCR
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()
      myCnn.Close()
      RaiseEvent Action(7)
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub

  Public Sub getTERCT(ByVal TTCOD As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "TERCT_SEL1"
    End With

    Dim prm As SqlClient.SqlParameter

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@TTCOD"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = TTCOD
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      If tbl.Rows.Count > 0 Then
        Me.myTT_COD = tbl.Rows(0)("TT_COD")
        Me.myTT_DESCR = tbl.Rows(0)("TT_DESCR")
        RaiseEvent Action(-1)
      Else
        Me.myTT_COD = vbNull
        Me.myTT_DESCR = vbNull
        RaiseEvent Action(2)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub

End Class
