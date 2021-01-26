Public Class Func_Order_Detail
        Dim strsql As String
        Dim info As String
        Private _id_detail As Integer
        Private _nomor_bukti As String
        Private _kode_room As String
        Private _room As String
        Private _harga As String
        Private _subtotal As String
        Public InsertState As Boolean = False
        Public UpdateState As Boolean = False
        Public DeleteState As Boolean = False
        Public Property id_detail()
            Get
                Return _id_detail
            End Get
            Set(ByVal value)
                _id_detail = value
            End Set
        End Property
        Public Property nomor_bukti()
            Get
                Return _nomor_bukti
            End Get
            Set(ByVal value)
                _nomor_bukti = value
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
        Public Property room()
            Get
                Return _room
            End Get
            Set(ByVal value)
                _room = value
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
        Public Property subtotal()
            Get
                Return _subtotal
            End Get
            Set(ByVal value)
                _subtotal = value
            End Set
        End Property
    Public Sub SimpanDetail()
        Dim info As String
        DBConnect()
        '       If (order_detail_baru = True) Then
        strsql = "Insert into order_detail(nomor_bukti,kode_room,room,harga,subtotal) values ('" & _nomor_bukti & "','" & _kode_room & "','" & _room & "','" & _harga & "','" & _subtotal & "')"
        info = "INSERT"
        'Else
        ' strsql = "update order_detail set id_detail='" & _id_detail & "', nomor_bukti='" & _nomor_bukti & "', kode_room='" & _kode_room & "', room='" & _room & "', harga='" & _harga & "', subtotal='" & _subtotal & "' where nomor_bukti='" & _nomor_bukti & "'"
        ' info = "UPDATE"
        'End If
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
        Public Sub Cariorder_detail(ByVal s As String)
            DBConnect()
            strsql = "SELECT * FROM order_detail WHERE ='" & s & "'"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            DR = myCommand.ExecuteReader
            If (DR.HasRows = True) Then
                order_detail_baru = False
                DR.Read()
                id_detail = Convert.ToString((DR("id_detail")))
                nomor_bukti = Convert.ToString((DR("nomor_bukti")))
                kode_room = Convert.ToString((DR("kode_room")))
                room = Convert.ToString((DR("room")))
                harga = Convert.ToString((DR("harga")))
                subtotal = Convert.ToString((DR("subtotal")))
            Else
                MessageBox.Show("Data Tidak Ditemukan.")
                order_detail_baru = True
            End If
            DBDisconnect()
        End Sub
    Public Sub HapusDetail(ByVal s As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM order_detail WHERE ='" & s & "'"
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
    Public Sub getAllDataDetail(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT nomor_bukti,kode_room,room,harga,subtotal FROM order_detail"
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
