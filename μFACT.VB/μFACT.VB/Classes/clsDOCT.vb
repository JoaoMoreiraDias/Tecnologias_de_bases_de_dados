Public Class clsDOCT
  Private myCnn As SqlClient.SqlConnection
  Private myDT_COD As String
  Private myDT_DTCOD As String
  Private myDT_VUSO As Integer

  Public Event Action(ByVal status As Integer)
  Public Event Errors(ByVal errMessages As Object)

  Public Property COD() As String
    Get
      COD = myDT_COD
    End Get
    Set(ByVal value As String)
      myDT_COD = value
    End Set
  End Property

  Public Property DTCOD As Long
    Get
      DTCOD = myDT_DTCOD
    End Get
    Set(ByVal value As Long)
      myDT_DTCOD = value
    End Set
  End Property

  Public Property VUSO As Integer
    Get
      VUSO = myDT_VUSO
    End Get
    Set(ByVal value As Integer)
      myDT_VUSO = value
    End Set
  End Property

  Public Sub New(ByVal dbConStr As String)
    myCnn = New SqlClient.SqlConnection(dbConStr)
  End Sub

  Public Sub getDOCTU(ByVal DTCOD As String)
    Dim cmd As New SqlClient.SqlCommand
    With cmd
      .Connection = myCnn
      .CommandType = CommandType.StoredProcedure
      .CommandText = "DOCT_SEL1U"
    End With

    Dim prm As SqlClient.SqlParameter

    prm = New SqlClient.SqlParameter
    With prm
      .ParameterName = "@DTCOD"
      .DbType = DbType.String
      .Direction = ParameterDirection.Input
      .Value = DTCOD
    End With
    cmd.Parameters.Add(prm)

    Try
      If myCnn.State = ConnectionState.Closed Then myCnn.Open()
      Dim tbl As New DataTable
      tbl.Load(cmd.ExecuteReader)
      If tbl.Rows.Count > 0 Then
        Me.myDT_DTCOD = tbl.Rows(0)("DT_COD")
        Me.myDT_VUSO = tbl.Rows(0)("DT_VUSO")
        RaiseEvent Action(-1)
      Else
        Me.myDT_DTCOD = vbNull
        Me.myDT_VUSO = vbNull
        RaiseEvent Action(2)
      End If
    Catch ex As Exception
      RaiseEvent Errors(ex.Message)
    End Try
  End Sub
End Class
