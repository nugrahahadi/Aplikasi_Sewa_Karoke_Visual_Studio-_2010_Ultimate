Public Class Tambah_Userrr

    Private Sub Reload()
        txtNamaLengkap.Clear()
        txtPassword.Clear()
        txtUsername.Clear()
    End Sub
    Private Sub GetData()
        oTambah_User.getAllData(DataGridView)
    End Sub
    
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        oTambah_User.username = txtUsername.Text
        oTambah_User.password = txtPassword.Text
        oTambah_User.nama_lengkap = txtNamaLengkap.Text
        oTambah_User.Simpan()
        MessageBox.Show("User Berhasil Disimpan")
        GetData()
    End Sub

    Private Sub btnDel_Click(sender As System.Object, e As System.EventArgs) Handles btnDel.Click

    End Sub

    Private Sub btnreload_Click(sender As System.Object, e As System.EventArgs) Handles btnreload.Click
        Reload()
        GetData()
    End Sub

    Private Sub Tambah_Userrr_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()

    End Sub
End Class
