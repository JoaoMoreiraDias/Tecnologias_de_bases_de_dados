Public Class clsDOC
  Private myCnn As SqlClient.SqlConnection
  Private myD_ID As Long
  Private myD_DT_COD As String
  Private myD_NUM As Integer
  Private myD_T_COD As String
  Private myD_D As Date
  Private myD_VALQT As Decimal
  Private myD_VALIVA As Decimal
  Private myD_VALTOT As Decimal
  Private myD_DREC As Date
  Private myD_DRREC As Date

  Public Event Action(ByVal status As Integer)
  Public Event Errors(ByVal errMessages As Object)

  Public ReadOnly Property DID() As Long
    Get
      DID = myD_ID
    End Get
  End Property

  Public Property DDTCOD As String
    Get
      DDTCOD = myD_DT_COD
    End Get
    Set(value As String)
      myD_DT_COD = value
    End Set
  End Property

  Public Property DNUM As Integer
    Get
      DNUM = myD_NUM
    End Get
    Set(value As Integer)
      myD_NUM = value
    End Set
  End Property

  Public Property DTCOD As String
    Get
      DTCOD = myD_T_COD
    End Get
    Set(value As String)
      myD_T_COD = value
    End Set
  End Property

  Public Property DD As Date
    Get
      DD = myD_D
    End Get
    Set(value As Date)
      myD_D = value
    End Set
  End Property

  Public Property DVALQT As Decimal
    Get
      DVALQT = myD_VALQT
    End Get
    Set(value As Decimal)
      myD_VALQT = value
    End Set
  End Property

  Public Property DVALIVA As Decimal
    Get
      DVALIVA = myD_VALIVA
    End Get
    Set(value As Decimal)
      myD_VALIVA = value
    End Set
  End Property

  Public Property DVALTOT As Decimal
    Get
      DVALTOT = myD_VALTOT
    End Get
    Set(value As Decimal)
      myD_VALTOT = value
    End Set
  End Property

  Public Property DDREC As Date
    Get
      DDREC = myD_DREC
    End Get
    Set(value As Date)
      myD_DREC = value
    End Set
  End Property

  Public Property DDRREC As Date
    Get
      If IsDBNull(myD_DRREC) Then
        DDRREC = Nothing
      Else
        DDRREC = myD_DRREC
      End If
    End Get
    Set(value As Date)
      myD_DRREC = value
    End Set
  End Property

  Public Function listDOCP() As DataTable
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandText = "DOC_SELALLP"
      .CommandType = CommandType.StoredProcedure
    End With

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      listDOCP = tbl
      myCnn.Close()
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      listDOCP = Nothing
      RaiseEvent Errors(ex.Message)
    End Try
  End Function

  Public Sub New(ByVal dbConStr As String)
    myCnn = New SqlClient.SqlConnection(dbConStr)
  End Sub

  Public Sub getDOC(ByVal DID As Long)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOC_SEL1"
    End With

    Dim prm As SqlClient.SqlParameter

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DID
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      If tbl.Rows.Count > 0 Then
        With tbl.Rows(0)
          Me.myD_ID = .Item("D_ID")
          Me.myD_DT_COD = .Item("D_DT_COD")
          Me.myD_NUM = .Item("D_NUM")
          Me.myD_T_COD = .Item("D_T_COD")
          Me.myD_D = .Item("D_D")
          Me.myD_VALQT = .Item("D_VALQT")
          Me.myD_VALIVA = .Item("D_VALIVA")
          Me.myD_VALTOT = .Item("D_VALTOT")
          If IsDBNull(.Item("D_DREC")) Then
            Me.myD_DREC = Nothing
          Else
            Me.myD_DREC = .Item("D_DREC")
          End If
          If IsDBNull(.Item("D_DRREC")) Then
            Me.myD_DRREC = Nothing
          Else
            Me.myD_DRREC = .Item("D_DRREC")
          End If
        End With
        RaiseEvent Action(-1)
      Else
        Me.myD_ID = vbNull
        Me.myD_DT_COD = vbNull
        Me.myD_NUM = vbNull
        Me.myD_T_COD = vbNull
        Me.myD_D = Nothing
        Me.myD_VALQT = vbNull
        Me.myD_VALIVA = vbNull
        Me.myD_VALTOT = vbNull
        Me.myD_DREC = Nothing
        Me.myD_DRREC = Nothing
        RaiseEvent Action(2)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub

  Public Sub addDOC(ByRef DID As Long, ByVal DDTCOD As String, ByRef DNUM As Long, ByVal DTCOD As String, ByRef DD As Date, ByRef DDREC As Object, ByRef DDRREC As Object)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOC_INS"
    End With

    Dim prmDID As SqlClient.SqlParameter
    prmDID = New SqlClient.SqlParameter
    With prmDID
      .ParameterName = "@DID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Output
    End With
    cmd.Parameters.Add(prmDID)

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DDTCOD"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DDTCOD
    End With
    cmd.Parameters.Add(prm)

    Dim prmDNUM As SqlClient.SqlParameter
    prmDNUM = New SqlClient.SqlParameter
    With prmDNUM
      .ParameterName = "@DNUM"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Output
    End With
    cmd.Parameters.Add(prmDNUM)

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DTCOD"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DTCOD
    End With
    cmd.Parameters.Add(prm)

    Dim prmDD As SqlClient.SqlParameter
    prmDD = New SqlClient.SqlParameter
    With prmDD
      .ParameterName = "@DD"
      .Direction = ParameterDirection.InputOutput
      .DbType = DbType.Date
      .Value = DD
    End With
    cmd.Parameters.Add(prmDD)

    Dim prmDDREC As SqlClient.SqlParameter
    prmDDREC = New SqlClient.SqlParameter
    With prmDDREC
      .ParameterName = "@DDREC"
      .Direction = ParameterDirection.InputOutput
      .DbType = DbType.Date
      .Value = DDREC
      If DDREC = Nothing Then
        .Value = DBNull.Value
      Else
        .Value = DDREC
      End If
    End With
    cmd.Parameters.Add(prmDDREC)

    Dim prmDDRREC As SqlClient.SqlParameter
    prmDDRREC = New SqlClient.SqlParameter
    With prmDDRREC
      .ParameterName = "@DDRREC"
      .Direction = ParameterDirection.InputOutput
      .DbType = DbType.Date
      If DDRREC = Nothing Then
        .Value = DBNull.Value
      Else
        .Value = DDRREC
      End If

    End With
    cmd.Parameters.Add(prmDDRREC)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()

      DID = prmDID.Value
      DNUM = prmDNUM.Value
      DD = prmDD.Value
      DDREC = prmDDREC.Value
      DDRREC = prmDDRREC.Value

      RaiseEvent Action(8)
      myCnn.Close()
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      If Left(ex.Message, 35) = "Violation of PRIMARY KEY constraint" Then
        RaiseEvent Action(5)
      Else
        RaiseEvent Errors(ex.Message)
      End If
    End Try
    If myCnn.State = ConnectionState.Open Then myCnn.Close()
  End Sub

  Public Sub delDOC(ByVal DID As Long)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOC_DEL"
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DID
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

  Public Sub updDOC(ByVal DID As Long, ByVal DTCOD As String, ByVal DD As Date, ByVal DDREC As Object, ByVal DDRREC As Object)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOC_UPD"
    End With

    Dim prmDID As SqlClient.SqlParameter
    prmDID = New SqlClient.SqlParameter
    With prmDID
      .ParameterName = "@DID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DID
    End With
    cmd.Parameters.Add(prmDID)

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DTCOD"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DTCOD
    End With
    cmd.Parameters.Add(prm)

    Dim prmDD As SqlClient.SqlParameter
    prmDD = New SqlClient.SqlParameter
    With prmDD
      .ParameterName = "@DD"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Date
      .Value = CDate(DD)
    End With
    cmd.Parameters.Add(prmDD)

    Dim prmDDREC As SqlClient.SqlParameter
    prmDDREC = New SqlClient.SqlParameter
    With prmDDREC
      .ParameterName = "@DDREC"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Date
      .Value = DDREC
      If DDREC = Nothing Then
        .Value = DBNull.Value
      Else
        .Value = CDate(DDREC)
      End If
    End With
    cmd.Parameters.Add(prmDDREC)

    Dim prmDDRREC As SqlClient.SqlParameter
    prmDDRREC = New SqlClient.SqlParameter
    With prmDDRREC
      .ParameterName = "@DDRREC"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Date
      If DDRREC = Nothing Then
        .Value = DBNull.Value
      Else
        .Value = CDate(DDRREC)
      End If
    End With
    cmd.Parameters.Add(prmDDRREC)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()
      RaiseEvent Action(7)
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try

  End Sub

End Class
