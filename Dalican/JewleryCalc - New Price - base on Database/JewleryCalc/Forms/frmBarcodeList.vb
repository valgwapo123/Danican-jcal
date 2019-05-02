Public Class frmBarcodeList
    Dim idx As Integer = 0

    Private Sub frmBarcodeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCategory.Text = "Brand New"

        loadbarcode_list()
    End Sub


    Private Sub save()
        Dim msg As DialogResult = MsgBox("Do you want to save this?", MsgBoxStyle.YesNo, "Question")
        If msg = vbNo Then Exit Sub

        For Each lv As ListViewItem In lvaddbardcode.Items
            Dim bnj As New BNJewelry
            With bnj
                .Barcode = lv.SubItems(1).Text
                .Category = lv.SubItems(2).Text
                .IsSpecial = IIf(lv.SubItems(3).Text = "Special", True, False)

                .savebarcode()
            End With
        Next

        MsgBox("Successfully saved.")
        clearfields()
    End Sub

    Private Sub Updatebarcode()
        If lvaddbardcode.Items.Count = 0 Then Exit Sub

        Dim msg As DialogResult = MsgBox("Do you want to save this?", MsgBoxStyle.YesNo, "Question")
        If msg = vbNo Then Exit Sub


        For Each lv As ListViewItem In lvaddbardcode.Items
            Dim bnj As New BNJewelry
            With bnj
                .ID = lv.Tag
                .Barcode = lv.SubItems(1).Text
                .Category = lv.SubItems(2).Text
                .IsSpecial = IIf(lv.SubItems(3).Text = "Special", True, False)

                .Updatebarcode()
            End With
        Next
        MsgBox("Successfully updated.")
        clearfields()
    End Sub


    Private Sub clearfields()
        txtBarcode.Clear()
        txtCategory.Text = "Brand New"
        chkIsSpecial.Checked = False
        lvaddbardcode.Items.Clear()
        btnSave.Text = "&Save"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lvaddbardcode.Items.Count = 0 Then Exit Sub

        If btnSave.Text = "&Save" Then
            save()
            loadbarcode_list()
            Exit Sub
        End If

        If btnSave.Text = "&Update" Then
            Updatebarcode()
            loadbarcode_list()
            Exit Sub
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtBarcode.Text = "" Then Exit Sub

        If btnAdd.Text = "+" Then
            Dim lv As ListViewItem = lvaddbardcode.Items.Add(0)
            lv.SubItems.Add(txtBarcode.Text)
            lv.SubItems.Add(txtCategory.Text)
            lv.SubItems.Add(IIf(chkIsSpecial.Checked, "Special", "Not Special"))
            btnAdd.Text = "+"
            txtBarcode.Text = ""
            chkIsSpecial.Checked = False
            Exit Sub
        End If

        If btnAdd.Text = "++" Then
            lvaddbardcode.SelectedItems(0).SubItems(0).Text = idx
            lvaddbardcode.SelectedItems(0).SubItems(1).Text = txtBarcode.Text
            lvaddbardcode.SelectedItems(0).SubItems(2).Text = txtCategory.Text
            lvaddbardcode.SelectedItems(0).SubItems(3).Text = IIf(chkIsSpecial.Checked, "Special", "Not Special")

        End If

        txtBarcode.Text = ""
        chkIsSpecial.Checked = False
        btnAdd.Text = "+"
    End Sub

    Private Sub lvaddbardcode_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvaddbardcode.DoubleClick
        If lvaddbardcode.SelectedItems.Count = 0 Then Exit Sub

        idx = lvaddbardcode.SelectedItems(0).SubItems(0).Text
        txtBarcode.Text = lvaddbardcode.SelectedItems(0).SubItems(1).Text
        txtCategory.Text = lvaddbardcode.SelectedItems(0).SubItems(2).Text
        If lvaddbardcode.SelectedItems(0).SubItems(3).Text = "Special" Then chkIsSpecial.Checked = True

        btnAdd.Text = "++"
    End Sub


    Private Sub loadbarcode_list(Optional ByVal str As String = "select * from tblbarcode order by id asc")
        Dim ds As DataSet = LoadSQL(str, "tblbarcode")

        If ds.Tables(0).Rows.Count = 0 Then lvList.Items.Clear() : Exit Sub

        lvList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim bnj As New BNJewelry
            bnj.load_Barcodes(dr.Item("id"))

            additem(bnj)
        Next

    End Sub

    Private Sub additem(ByVal bn As BNJewelry)
        With bn
            Dim lv As ListViewItem = lvList.Items.Add(.ID)
            lv.SubItems.Add(.Barcode)
            lv.SubItems.Add(.Category)
            lv.SubItems.Add(IIf(.IsSpecial, "Special", "Not Special"))

            lv.Tag = .ID
        End With
    End Sub

    Private Sub lvList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 0 Then Exit Sub
        selectbarcode()
    End Sub

    Private Sub selectbarcode()

        lvaddbardcode.Items.Clear()
        Dim i As Integer = lvList.FocusedItem.Tag
        Dim bn As New BNJewelry
        bn.load_Barcodes(i)
        With bn
            Dim lv As ListViewItem = lvaddbardcode.Items.Add(.ID)
            lv.SubItems.Add(.Barcode)
            lv.SubItems.Add(.Category)
            lv.SubItems.Add(IIf(.IsSpecial, "Special", "Not Special"))

            lv.Tag = .ID
        End With

        TabControl1.SelectedTab = TabPage1
        btnSave.Text = "&Update"
    End Sub

    Private Sub lvList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvList.KeyPress

    End Sub

    Private Sub lvList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        selectbarcode()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text <> "" Then
            Dim mysql As String = "select * from tblbarcode where Lower(barcode) like Lower('%" & txtSearch.Text & "%')"
            loadbarcode_list(mysql)
        Else
            loadbarcode_list()
        End If
      
    End Sub
End Class