Public Class Order_Detail
    Dim siji As Integer
    Dim loro As Integer
    Dim hasil As Integer
    Public Property stringpass As String
    Public Property waktu As String
    Private Sub ClearEntry()
        txtHarga.Clear()
        txtKodeRoom.Clear()
        cboNamaRoom.Text = ""
        txtNomorbukti.Clear()
        txtSubtotal.Clear()
    End Sub

    Private Sub Reload()
        oFunc_Order_Detail.getAllDataDetail(DataGridView1)
    End Sub

    Private Sub SimpanOrderDetail()
        oFunc_Order_Detail.harga = txtHarga.Text
        oFunc_Order_Detail.kode_room = txtKodeRoom.Text
        oFunc_Order_Detail.nomor_bukti = txtNomorbukti.Text
        oFunc_Order_Detail.room = cboNamaRoom.Text
        oFunc_Order_Detail.subtotal = txtSubtotal.Text
        order_detail_baru = True
        oFunc_Order_Detail.SimpanDetail()

        ClearEntry()
    End Sub


    Private Sub Order_Detail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtNomorbukti.Text = stringpass
    End Sub

    Private Sub txtKodeRoom_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtKodeRoom.KeyDown
        If (e.KeyCode = Keys.Enter And txtKodeRoom.Text <> "") Then
            oRoom.Cariroom(txtKodeRoom.Text)
            If (room_baru = True) Then
                cboNamaRoom.Visible = False
            Else
                cboNamaRoom.Text = oRoom.nama_room
                txtHarga.Text = oRoom.harga

            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        SimpanOrderDetail()
        txtKodeRoom.Focus()
        Reload()
        MessageBox.Show("Data Berhasil Disimpan")
    End Sub

    Private Sub btnHitung_Click(sender As System.Object, e As System.EventArgs) Handles btnHitung.Click
        siji = CDec(txtHarga.Text)
        loro = CDec(waktu)
        hasil = siji * loro
        txtSubtotal.Text = hasil
    End Sub
End Class
