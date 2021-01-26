Public Class room
    Dim strsql As String
    Dim info As String
    Private _id_paket As Integer
    Private _kode_room As String
    Private _nama_room As String
    Private _harga As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property id_paket()
        Get
            Return _id_paket
        End Get
        Set(ByVal value)
            _id_paket = value
        End Set
    End Property
    Public Property kode_room()
        Get
            Return _kode_room
        End Get
        Set(ByVal value)
            _kode_room = value
        End Set
    End Property
    Public Property nama_room()
        Get
            Return _nama_room
        End Get
        Set(ByVal value)
            _nama_room = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (room_baru = True) Then
            strsql = "Insert into room(id_paket,kode_room,nama_room,harga) values ('" & _id_paket & "','" & _kode_room & "','" & _nama_room & "','" & _harga & "')"
            info = "INSERT"
        Else
            strsql = "update room set id_paket='" & _id_paket & "', kode_room='" & _kode_room & "', nama_room='" & _nama_room & "', harga='" & _harga & "' where kode_room='" & _kode_room & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub Cariroom(ByVal s As String)
        DBConnect()
        strsql = "SELECT * FROM room WHERE kode_room = '" & s & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            room_baru = False
            DR.Read()
            kode_room = Convert.ToString((DR("kode_room")))
            nama_room = Convert.ToString((DR("nama_room")))
            harga = Convert.ToString((DR("harga")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            room_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal s As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM room WHERE ='" & s & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM room"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
