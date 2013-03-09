Public Class clsPROD
  Private myCnn As SqlClient.SqlConnection
  Private myP_REF As String
  Private myP_DESCR As String
  Private myP_QT As Decimal
  Private myP_CST As Decimal
  Private myP_PRC As Decimal
  Private myP_IVATX As Decimal

  Public Event Action(ByVal status As Integer)
  Public Event Errors(ByVal errMessages As Object)

  Public Property REF() As String
    Get
      REF = myP_REF
    End Get
    Set(ByVal value As String)
      myP_REF = value
    End Set
  End Property

  Public Property DESCR As String
    Get
      DESCR = myP_DESCR
    End Get
    Set(value As String)
      myP_DESCR = value
    End Set
  End Property

  Public Property QT As Decimal
    Get
      QT = myP_QT
    End Get
    Set(value As Decimal)
      myP_QT = value
    End Set
  End Property

  Public Property CST As Decimal
    Get
      CST = myP_CST
    End Get
    Set(value As Decimal)
      myP_CST = value
    End Set
  End Property

  Public Property PRC As Decimal
    Get
      PRC = myP_PRC
    End Get
    Set(value As Decimal)
      myP_PRC = value
    End Set
  End Property

  Public Property IVATX As Decimal
    Get
      IVATX = myP_IVATX
    End Get
    Set(value As Decimal)
      myP_IVATX = value
    End Set
  End Property

  Public Sub New(ByVal dbConStr As String)
    myCnn = New SqlClient.SqlConnection(dbConStr)
  End Sub

  Public Sub getPROD(ByVal PREF As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "PROD_SEL1"
    End With

    Dim prm As SqlClient.SqlParameter

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@PREF"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = PREF
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      If tbl.Rows.Count > 0 Then
        Me.myP_REF = tbl.Rows(0)("P_REF")
        Me.myP_DESCR = tbl.Rows(0)("P_DESCR")
        Me.myP_QT = tbl.Rows(0)("P_QT")
        Me.myP_CST = tbl.Rows(0)("P_CST")
        Me.myP_PRC = tbl.Rows(0)("P_PRC")
        Me.myP_IVATX = tbl.Rows(0)("P_IVATX")
        RaiseEvent Action(-1)
      Else
        Me.myP_REF = vbNull
        Me.myP_DESCR = vbNull
        Me.myP_QT = vbNull
        Me.myP_CST = vbNull
        Me.myP_PRC = vbNull
        RaiseEvent Action(2)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub
End Class
