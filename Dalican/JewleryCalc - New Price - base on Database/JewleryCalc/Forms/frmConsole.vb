Public Class frmConsole
    Dim SelectedCat As Category
    Dim SelectedClass As Price
    Friend catID, BranchID

    Friend Sub LoadCategory(ByVal c As Category)
        If c.Category = Nothing Then Exit Sub

        txtCategory.Text = c.Category
        txtKarat.Text = c.Karat
        SelectedCat = c

        BtnSave.Text = "&Update"
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim secured_str As String = txtSearch.Text
        frmJList.txtSearch.Text = Me.txtSearch.Text.ToString
        frmJList.btnSearch.PerformClick()

        frmJList.SearchSelect(secured_str, FormName.Cat)
        frmJList.Show()
        lvList.Items.Clear() : txtCategory.Clear() : txtKarat.Clear()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "&Save" Then
            save()
          
        Else
            UpdatePrice()
           
        End If
    End Sub

    Private Sub save()
        If Not IsValid() Then Exit Sub

        Dim msg As DialogResult = MsgBox("Do you want to save?", MsgBoxStyle.YesNo, "Save")
        If msg = vbNo Then Exit Sub

        SelectedCat = New Category
        Dim ClassCol As New KaratCol
        With SelectedCat
            .Category = txtCategory.Text
            .Karat = txtKarat.Text
        End With

        For Each item As ListViewItem In lvList.Items
            SelectedClass = New Price
            With SelectedClass
                .CLassificaton = item.SubItems(1).Text
                .Price = item.SubItems(2).Text
            End With
            If item.Text = "" Then Exit For
            ClassCol.Add(SelectedClass)
        Next

        SelectedCat.Classdetails = ClassCol
        SelectedCat.SaveCat()

        MsgBox("Successfully saved.", MsgBoxStyle.Information)
        lvList.Items.Clear() : txtCategory.Clear() : txtKarat.Clear()
    End Sub

    Private Sub UpdatePrice()
        If Not IsValid() Then Exit Sub

        Dim msg As DialogResult = MsgBox("Do you want to Update?", MsgBoxStyle.YesNo, "Update")
        If msg = vbNo Then Exit Sub

        SelectedCat = New Category

        With SelectedCat
            .ID = catID
            .Category = txtCategory.Text
            .Karat = txtKarat.Text

        End With
        SelectedCat.Update()

        For Each item As ListViewItem In lvList.Items
            SelectedClass = New Price
            With SelectedClass
                .CatID = catID
                .ID = IIf(item.SubItems(0).Text = "", 0, item.SubItems(0).Text)
                .CLassificaton = item.SubItems(1).Text
                .Price = item.SubItems(2).Text
                .lessthan = item.SubItems(3).Text
                .greaterthan = item.SubItems(4).Text
                .Update()
            End With
           
        Next
        lvList.Items.Clear() : txtCategory.Clear() : txtKarat.Clear() : BtnSave.Text = "&Save"
        MsgBox("Successfully updated.", MsgBoxStyle.Information)
    End Sub

    Private Function IsValid() As Boolean
        If txtCategory.Text = "" Then txtCategory.Focus() : Return False
        If txtKarat.Text = "" Then txtKarat.Focus() : Return False

        If lvList.Items.Count = 0 Then lvList.Focus() : Return False
        Return True
    End Function

    Private Sub lvList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.DoubleClick
        If lvList.SelectedItems.Count = 0 Then Exit Sub

        txtClass.Text = lvList.SelectedItems(0).SubItems(1).Text
        txtPrice.Text = lvList.SelectedItems(0).SubItems(2).Text
        txtless.Text = lvList.SelectedItems(0).SubItems(3).Text
        txtgreater.Text = lvList.SelectedItems(0).SubItems(4).Text
        btnAdd.Text = "&Update"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtClass.Text = "" Then Exit Sub : If txtPrice.Text = "" Then Exit Sub

        If btnAdd.Text = "&Add" Then
            Dim lv As ListViewItem = lvList.Items.Add(0)
            lv.SubItems.Add(txtClass.Text)
            lv.SubItems.Add(txtPrice.Text)
            lv.SubItems.Add(txtless.Text)
            lv.SubItems.Add(txtgreater.Text)
        Else
            lvList.SelectedItems(0).SubItems(1).Text = txtClass.Text
            lvList.SelectedItems(0).SubItems(2).Text = txtPrice.Text
            lvList.SelectedItems(0).SubItems(3).Text = txtless.Text
            lvList.SelectedItems(0).SubItems(4).Text = txtgreater.Text
        End If
        btnAdd.Text = "&Add" : txtPrice.Clear() : txtClass.Clear() : txtgreater.Clear() : txtless.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lvList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvList.SelectedIndexChanged

    End Sub

    Private Sub frmConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class