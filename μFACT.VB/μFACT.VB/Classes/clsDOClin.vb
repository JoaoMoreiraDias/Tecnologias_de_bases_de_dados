Public Class clsDOClin
  Private myCnn As SqlClient.SqlConnection
  Private myDL_ID As Long
  Private myDL_D_ID As Long
  Private myDL_P_REF As String
  Private myDL_DESCR As String
  Private myDL_QT As Decimal
  Private myDL_VAL As Decimal
  Private myDL_VALQT As Decimal
  Private myDL_IVATX As Decimal
  Private myDL_VALIVA As Decimal
  Private myDL_VALTOT As Decimal

  Public Event Action(ByVal status As Integer)
  Public Event Errors(ByVal errMessages As Object)

  Public ReadOnly Property DLID As Long
    Get
      DLID = myDL_ID
    End Get
  End Property

  Public Property DLDID As Long
    Get
      DLDID = myDL_D_ID
    End Get
    Set(value As Long)
      myDL_D_ID = value
    End Set
  End Property

  Public Property DLPREF As Long
    Get
      DLPREF = myDL_P_REF
    End Get
    Set(value As Long)
      myDL_P_REF = value
    End Set
  End Property

  Public Property DLDESCR As String
    Get
      DLDESCR = myDL_DESCR
    End Get
    Set(value As String)
      myDL_DESCR = value
    End Set
  End Property

  Public Property DLQT As Decimal
    Get
      DLQT = myDL_QT
    End Get
    Set(value As Decimal)
      myDL_QT = value
    End Set
  End Property

  Public Property DLVAL As Decimal
    Get
      DLVAL = myDL_VAL
    End Get
    Set(value As Decimal)
      myDL_VAL = value
    End Set
  End Property

  Public ReadOnly Property DLVALQT As Decimal
    Get
      DLVALQT = myDL_VALQT
    End Get
  End Property

  Public Property DLIVATX As Decimal
    Get
      DLIVATX = myDL_IVATX
    End Get
    Set(value As Decimal)
      myDL_IVATX = value
    End Set
  End Property

  Public ReadOnly Property DLVALIVA As Decimal
    Get
      DLVALIVA = myDL_VALIVA
    End Get
  End Property

  Public ReadOnly Property DLVALTOT As Decimal
    Get
      DLVALTOT = myDL_VALTOT
    End Get
  End Property

  Public Function listDOClin() As DataTable
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandText = "DOClin_SELALL"
      .CommandType = CommandType.StoredProcedure
    End With

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      listDOClin = tbl
      myCnn.Close()
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      listDOClin = Nothing
      RaiseEvent Errors(ex.Message)
    End Try
  End Function

  Public Function listDOClinDOC(ByVal DLDID As Long) As DataTable

    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandText = "DOClin_SELDOC"
      .CommandType = CommandType.StoredProcedure
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .ParameterName = "@DLDID"
      .Value = DLDID
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      listDOClinDOC = tbl
      myCnn.Close()
    Catch ex As Exception
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      listDOClinDOC = Nothing
      RaiseEvent Errors(ex.Message)
    End Try

  End Function

  Public Sub New(ByVal dbConStr As String)
    myCnn = New SqlClient.SqlConnection(dbConStr)
  End Sub

  Public Sub getDOClin(ByVal DLID As Long)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOCLIN_SEL1"
    End With

    Dim prm As SqlClient.SqlParameter

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DLID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DLID
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      If tbl.Rows.Count > 0 Then
        With tbl.Rows(0)
          Me.myDL_ID = .Item("DL_ID")
          Me.myDL_D_ID = .Item("DL_D_ID")
          Me.myDL_P_REF = .Item("DL_P_REF")
          Me.myDL_DESCR = .Item("DL_DESCR")
          Me.myDL_QT = .Item("DL_QT")
          Me.myDL_VALQT = .Item("DL_VALQT")
          Me.myDL_IVATX = .Item("DL_IVATX")
          Me.myDL_VALIVA = .Item("DL_VALIVA")
          Me.myDL_VALTOT = .Item("DL_VALTOT")
        End With
        RaiseEvent Action(-1)
      Else
        Me.myDL_ID = vbNull
        Me.myDL_P_REF = vbNull
        Me.myDL_DESCR = vbNull
        Me.myDL_QT = vbNull
        Me.myDL_VALQT = vbNull
        Me.myDL_IVATX = vbNull
        Me.myDL_VALIVA = vbNull
        Me.myDL_VALTOT = vbNull
        RaiseEvent Action(2)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub

  Public Sub addDOCLIN(ByVal DLID As Long, ByVal DLDID As Long, ByVal DLPREF As String, ByVal DLDESCR As String, ByVal DLQT As Decimal, ByVal DLVAL As Decimal, ByVal DLIVATX As Decimal)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOCLIN_INS"
    End With

    Dim prmDLID As SqlClient.SqlParameter
    prmDLID = New SqlClient.SqlParameter
    With prmDLID
      .ParameterName = "@DLID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Output
    End With
    cmd.Parameters.Add(prmDLID)

    Dim prmDLDID As SqlClient.SqlParameter
    prmDLDID = New SqlClient.SqlParameter
    With prmDLDID
      .ParameterName = "@DLDID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DLDID
    End With
    cmd.Parameters.Add(prmDLDID)

    Dim prmDLPREF As SqlClient.SqlParameter
    prmDLPREF = New SqlClient.SqlParameter
    With prmDLPREF
      .ParameterName = "@DLPREF"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DLPREF
    End With
    cmd.Parameters.Add(prmDLPREF)

    Dim prmDLDESCR As SqlClient.SqlParameter
    prmDLDESCR = New SqlClient.SqlParameter
    With prmDLDESCR
      .ParameterName = "@DLDESCR"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DLDESCR
    End With
    cmd.Parameters.Add(prmDLDESCR)

    Dim prmDLQT As SqlClient.SqlParameter
    prmDLQT = New SqlClient.SqlParameter
    With prmDLQT
      .ParameterName = "@DLQT"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLQT
    End With
    cmd.Parameters.Add(prmDLQT)

    Dim prmDLVAL As SqlClient.SqlParameter
    prmDLVAL = New SqlClient.SqlParameter
    With prmDLVAL
      .ParameterName = "@DLVAL"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLVAL
    End With
    cmd.Parameters.Add(prmDLVAL)

    Dim prmDLIVATX As SqlClient.SqlParameter
    prmDLIVATX = New SqlClient.SqlParameter
    With prmDLIVATX
      .ParameterName = "@DLIVATX"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLIVATX
    End With
    cmd.Parameters.Add(prmDLIVATX)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()

      DLID = prmDLID.Value
      DLDID = prmDLDID.Value
      DLPREF = prmDLPREF.Value
      DLDESCR = prmDLDESCR.Value
      DLQT = prmDLQT.Value
      DLVAL = prmDLVAL.Value
      DLIVATX = prmDLIVATX.Value

      RaiseEvent Action(8)
      myCnn.Close()
    Catch ex As SqlClient.SqlException
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      If Left(ex.Message, 2) = "#3" Then
        RaiseEvent Action(30)
      ElseIf Left(ex.Message, 35) = "Violation of PRIMARY KEY constraint" Then
        RaiseEvent Action(5)
      Else
        RaiseEvent Errors(ex.Message)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
    If myCnn.State = ConnectionState.Open Then myCnn.Close()
  End Sub

  Public Sub delDOCLIN(ByVal DLID As Long)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOCLIN_DEL"
    End With

    Dim prm As SqlClient.SqlParameter
    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DLID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DLID
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

  Public Sub updDOCLIN(ByVal DLID As Long, ByVal DLPREF As String, ByVal DLDESCR As String, ByVal DLQT As Decimal, ByVal DLVAL As Decimal, ByVal DLIVATX As Decimal)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOCLIN_UPD"
    End With

    Dim prmDLID As SqlClient.SqlParameter
    prmDLID = New SqlClient.SqlParameter
    With prmDLID
      .ParameterName = "@DLID"
      .DbType = DbType.Int64
      .Direction = ParameterDirection.Input
      .Value = DLID
    End With
    cmd.Parameters.Add(prmDLID)

    Dim prmDLPREF As SqlClient.SqlParameter
    prmDLPREF = New SqlClient.SqlParameter
    With prmDLPREF
      .ParameterName = "@DLPREF"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DLPREF
    End With
    cmd.Parameters.Add(prmDLPREF)

    Dim prmDLDESCR As SqlClient.SqlParameter
    prmDLDESCR = New SqlClient.SqlParameter
    With prmDLDESCR
      .ParameterName = "@DLDESCR"
      .Direction = ParameterDirection.Input
      .DbType = DbType.String
      .Value = DLDESCR
    End With
    cmd.Parameters.Add(prmDLDESCR)

    Dim prmDLQT As SqlClient.SqlParameter
    prmDLQT = New SqlClient.SqlParameter
    With prmDLQT
      .ParameterName = "@DLQT"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLQT
    End With
    cmd.Parameters.Add(prmDLQT)

    Dim prmDLVAL As SqlClient.SqlParameter
    prmDLVAL = New SqlClient.SqlParameter
    With prmDLVAL
      .ParameterName = "@DLVAL"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLVAL
    End With
    cmd.Parameters.Add(prmDLVAL)

    Dim prmDLIVATX As SqlClient.SqlParameter
    prmDLIVATX = New SqlClient.SqlParameter
    With prmDLIVATX
      .ParameterName = "@DLIVATX"
      .Direction = ParameterDirection.Input
      .DbType = DbType.Decimal
      .Value = DLIVATX
    End With
    cmd.Parameters.Add(prmDLIVATX)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      cmd.ExecuteNonQuery()
      RaiseEvent Action(7)
      myCnn.Close()
    Catch ex As SqlClient.SqlException
      If myCnn.State = ConnectionState.Open Then myCnn.Close()
      If Left(ex.Message, 2) = "#3" Then
        RaiseEvent Action(30)
      Else
        RaiseEvent Errors(ex.Message)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
    If myCnn.State = ConnectionState.Open Then myCnn.Close()
  End Sub


End Class
