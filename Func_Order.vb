Public Class Func_Order
        Dim strsql As String
        Dim info As String
        Private _id_order As String
        Private _nomor_bukti As String
        Private _nama_pelanggan As String
        Private _tanggal As String
        Private _waktu As String
        Public InsertState As Boolean = False
        Public UpdateState As Boolean = False
        Public DeleteState As Boolean = False
        Public Property id_order()
            Get
                Return _id_order
            End Get
            Set(ByVal value)
                _id_order = value
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
        Public Property nama_pelanggan()
            Get
                Return _nama_pelanggan
            End Get
            Set(ByVal value)
                _nama_pelanggan = value
            End Set
        End Property
        Public Property tanggal()
            Get
                Return _tanggal
            End Get
            Set(ByVal value)
                _tanggal = value
            End Set
        End Property
        Public Property waktu()
            Get
                Return _waktu
            End Get
            Set(ByVal value)
                _waktu = value
            End Set
        End Property
        Public Sub Simpan()
            Dim info As String
            DBConnect()
        If (order__baru = True) Then
            strsql = "Insert into order_(nomor_bukti,nama_pelanggan,tanggal,waktu) values ('" & _nomor_bukti & "','" & _nama_pelanggan & "','" & _tanggal & "','" & _waktu & "')"
            info = "INSERT"
        ElseIf (order__baru = False) Then
            strsql = "update order_ set nomor_bukti='" & _nomor_bukti & "', nama_pelanggan='" & _nama_pelanggan & "', tanggal='" & _tanggal & "', waktu='" & _waktu & "' where nomor_bukti='" & _nomor_bukti & "'"
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
        Public Sub Cariorder_(ByVal s As String)
            DBConnect()
        strsql = "SELECT * FROM order_ WHERE nomor_bukti='" & s & "'"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            DR = myCommand.ExecuteReader
            If (DR.HasRows = True) Then
                order__baru = False
                DR.Read()
                nomor_bukti = Convert.ToString((DR("nomor_bukti")))
                nama_pelanggan = Convert.ToString((DR("nama_pelanggan")))
                tanggal = Convert.ToString((DR("tanggal")))
                waktu = Convert.ToString((DR("waktu")))
            Else
                MessageBox.Show("Data Tidak Ditemukan.")
                order__baru = True
            End If
            DBDisconnect()
        End Sub
    Public Sub Hapus()
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM order_ WHERE nomor_bukti='" & _nomor_bukti & "'; DELETE FROM order_detail WHERE nomor_bukti='" & _nomor_bukti & "'"
        '      strsql = "DELETE p, pa FROM order_detail p JOIN order_detail pa ON pa.nomor_bukti = p.nomor_bukti WHERE p.nomor_bukti ='" & _nomor_bukti & "'"
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
            strsql = "SELECT A.nomor_bukti,A.nama_pelanggan,A.tanggal,A.waktu,B.kode_room,B.room,B.harga,B.subtotal FROM order_ A left join order_detail B on(A.nomor_bukti=B.nomor_bukti) WHERE A.nomor_bukti='" & _nomor_bukti & "'"
            '            strsql = "SELECT * FROM order_ CROSS JOIN order_detail"
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
