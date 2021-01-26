Public Class Order
    Private Sub ClearEntry()
        txtNamaPelanggan.Clear()
        txtNomorBukti.Clear()
    End Sub

    Private Sub Tampil_Order()
        txtNomorBukti = oFunc_Order.nomor_bukti
        txtDate.Text = oFunc_Order.tanggal
    End Sub

    Private Sub Simpan_Order()
        oFunc_Order.waktu = cboWaktu.Text
        oFunc_Order.tanggal = txtDate.Text
        oFunc_Order.nomor_bukti = txtNomorBukti.Text
        oFunc_Order.nama_pelanggan = txtNamaPelanggan.Text
        order__baru = True
        oFunc_Order.Simpan()
    End Sub

    Private Sub GetData()
        oFunc_Order.getAllData(DataGridView)

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtNamaPelanggan.Text = "" Or cboWaktu.Text = "" Or txtDate.Text = "" Then
            MsgBox("Silahkan isi data secara lengkap.", MsgBoxStyle.Exclamation, "Peringatan")
        Else
            txtNomorBukti.Text = getNomorBukti()
            Simpan_Order()
            MsgBox("Order berhasil disimpan.", MsgBoxStyle.Information, "Peringatan")
            cboWaktu.Visible = False
            txtNamaPelanggan.Clear()
            cboWaktu.Visible = True
            Order_Detail.stringpass = txtNomorBukti.Text
            Order_Detail.waktu = cboWaktu.Text
            txtNomorBukti.Clear()

            Order_Detail.Show()
            GetData()

        End If


    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs)
        ClearEntry()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If btnDelete.Text = "Hapus" Then
            MsgBox("Inputkan Nomor Bukti yang akan dihapus", MsgBoxStyle.Information, "Peringatan")
            btnDelete.Text = "Confirm"
            txtNamaPelanggan.ReadOnly = True
            txtDate.Visible = False
            cboWaktu.Visible = False
            txtNomorBukti.ReadOnly = False
            txtNamaPelanggan.Visible = False
            txtNamaPelanggan.Clear()
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            btnSave.Visible = False
            btnEdit.Visible = False
        ElseIf btnDelete.Text = "Confirm" And txtNomorBukti.Text = "" Then
            MsgBox("Lah gk jadi hapus", MsgBoxStyle.Information, "Peringatan")
            btnDelete.Text = "Hapus"
            txtNamaPelanggan.ReadOnly = False
            cboWaktu.Visible = True
            txtNamaPelanggan.Visible = True
            txtDate.Visible = True
            txtNomorBukti.ReadOnly = True
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            btnSave.Visible = True
            btnEdit.Visible = True
        Else
            oFunc_Order.nomor_bukti = txtNomorBukti.Text
            oFunc_Order.Hapus()
            MsgBox("Order berhasil dihapus.", MsgBoxStyle.Information, "Peringatan")
            btnDelete.Text = "Hapus"
            txtNamaPelanggan.ReadOnly = False
            cboWaktu.Visible = True
            txtNamaPelanggan.Visible = True
            txtDate.Visible = True
            txtNomorBukti.ReadOnly = True
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            btnSave.Visible = True
            btnEdit.Visible = True
            txtNomorBukti.Clear()
            GetData()
        End If

    End Sub
    Private Sub Cari()

    End Sub

    Private Sub Order_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub Order_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Label6.Text = DateTime.Now.ToString()
        GetData()

    End Sub

    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub btnCari_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            MsgBox("Inputkan nomor bukti lalu tekan enter.", MsgBoxStyle.Information, "Peringatan")
            btnEdit.Text = "Confirm"
            btnDelete.Visible = False
            btnSave.Visible = False
            txtNomorBukti.ReadOnly = False
        ElseIf btnEdit.Text = "Confirm" And txtNomorBukti.Text = "" Then
            MsgBox("Lah gk jadi ngedit", MsgBoxStyle.Information, "Peringatan")
            btnEdit.Text = "Edit"
            btnDelete.Visible = True
            btnSave.Visible = True
            cboWaktu.Visible = True
            txtNomorBukti.ReadOnly = True
            txtNamaPelanggan.Clear()
        Else
            MsgBox("Orderan berhasil diubah.", MsgBoxStyle.Information, "Peringatan")
            Simpan_Order()
            btnEdit.Text = "Edit"
            btnDelete.Visible = True
            btnSave.Visible = True
            txtNomorBukti.ReadOnly = True
            txtNamaPelanggan.Clear()
            txtNomorBukti.Clear()
            oFunc_Order.waktu = cboWaktu.Text
            oFunc_Order.tanggal = txtDate.Text
            oFunc_Order.nomor_bukti = txtNomorBukti.Text
            oFunc_Order.nama_pelanggan = txtNamaPelanggan.Text
            order__baru = False
            oFunc_Order.Simpan()
            GetData()
        End If
    End Sub

    Private Sub txtNomorBukti_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNomorBukti.KeyDown
        If (e.KeyCode = Keys.Enter And txtNomorBukti.Text <> "") Then
            oFunc_Order.Cariorder_(txtNomorBukti.Text)
            If (order__baru = True) Then
                txtNomorBukti.Clear()
            Else
                txtNamaPelanggan.Text = oFunc_Order.nama_pelanggan
                txtDate.Text = oFunc_Order.tanggal
                cboWaktu.SelectedItem = oFunc_Order.waktu
            End If
        End If
    End Sub
End Class
