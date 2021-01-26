Public Class Ribbon

    Private Sub btnOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnOrder.Click

        If (menu_order = False) Then
            BikinMenu(cldorder, TabControl1, "Order")
            menu_order = True
        Else
            x = getTabIndex(TabControl1, "Order")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub
    Public Sub opentabcontrol()
        If (menu_order_detail = False) Then
            BikinMenu(cldorder_detail, TabControl1, "Order_detail")
            menu_order = True
        Else
            x = getTabIndex(TabControl1, "Order_detail")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub TabControl1_ControlAdded(sender As Object, e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(sender As Object, e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If


        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Order") Then
            menu_order = False

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(sender As Object, e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub

    Private Sub TabControl1_Click(sender As System.Object, e As System.EventArgs) Handles TabControl1.Click

    End Sub

    Private Sub btnAddUser_Click(sender As System.Object, e As System.EventArgs) Handles btnAddUser.Click
        Tambah_Userrr.Show()
    End Sub

    Private Sub Ribbon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
