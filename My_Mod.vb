Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports DevComponents.DotNetBar
Module My_Mod
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public DR As MySql.Data.MySqlClient.MySqlDataReader
    Public SQL As String
    Public conn As New MySql.Data.MySqlClient.MySqlConnection
    Public cn As New Connection
    'Tabel User
    '--------------------------------
    Public tambah_user_baru As Boolean
    Public oTambah_User As New Tambah_User
    Public user_baru As Boolean
    Public oUser As New user

    'Tabel Order
    '-------------------------------
    Public cldorder As New Order()
    Public TotalTab As Boolean
    Public x As Integer
    Public menu_order As Boolean
    '--------------------------------
    'Tabel Order
    '-------------------------------
    Public order__baru As Boolean
    Public oFunc_Order As New Func_Order
    '-------------------------------
    'Tabel Order_Detail
    '-------------------------------
    Public order_detail_baru As Boolean
    Public oFunc_Order_Detail As New Func_Order_Detail
    Public menu_order_detail As New Boolean
    Public cldorder_detail As New Order_Detail()
    '-------------------------------
    'Tabel Room
    '-------------------------------
    Public room_baru As Boolean
    Public oRoom As New room
    '-------------------------------
    Public login_valid As Boolean
    '-------------------------------
    Public nobukti As Double
    Public R As Random = New Random

    Public Sub DBConnect()
        cn.Host = "localhost"
        cn.User = "root"
        cn.Password = ""
        cn.DatabaseName = "karoke"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
    Public Function getNomorBukti()
        Dim res As Double
        res = R.Next(1000000, 9999999)
        Return res
    End Function

    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function

    Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)

    End Sub

End Module
