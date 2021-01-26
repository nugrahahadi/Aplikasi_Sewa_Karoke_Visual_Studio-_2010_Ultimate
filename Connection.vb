Public Class Connection
    Private _host As String = "localhost"
    Private _user As String
    Private _password As String
    Private _dbname As String
    Private _connected As Boolean = False
    Public Property Host()
        Get
            Return _host
        End Get
        Set(ByVal value)
            _host = value
        End Set
    End Property
    Public Property User()
        Get
            Return _user
        End Get
        Set(ByVal value)
            _user = value
        End Set
    End Property
    Public Property Password()
        Get
            Return _password
        End Get
        Set(ByVal value)
            _password = value
        End Set
    End Property
    Public Property DatabaseName()
        Get
            Return _dbname
        End Get
        Set(ByVal value)
            _dbname = value
        End Set
    End Property

    Public ReadOnly Property Connected()
        Get
            Return _connected
        End Get
    End Property

    Public Sub Connect()
        conn.ConnectionString = "server=" & _host & ";" & _
        "user id=" & _user & ";" & _
        "password=" & _password & ";" & _
        "database=" & _dbname
        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If (conn.State = ConnectionState.Open) Then
                _connected = True
            Else
                _connected = False
            End If
        End Try

    End Sub

    Public Sub Disconnect()
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
            _connected = False
        End If
    End Sub

End Class
