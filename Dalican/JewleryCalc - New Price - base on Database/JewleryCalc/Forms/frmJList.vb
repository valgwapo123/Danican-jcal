Public Class frmJList

    Dim tmpcat As Category
    Dim selectedSchemeDetails As Price
    Private fromOtherForm As Boolean = False
    Private frmOrig As FormName

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub frmJList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadClass()
        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub LoadClass()
        Dim mySql As String = "SELECT * FROM tblKarat ORDER BY tblKarat.CATEGORY  "
        Dim ds As DataSet = LoadSQL(mySql)

        lvList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvList.Items.Add(dr("KaratID"))
            lv.SubItems.Add(dr("Category"))
            lv.SubItems.Add(dr("Karat"))
        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchItem()
    End Sub

    Private Sub searchItem()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text

        Dim mySql As String = "SELECT * FROM " & "tblkarat" & " WHERE "
        mySql &= String.Format("UPPER (Category) LIKE UPPER('%{0}%')", secured_str)

        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count

        lvList.Items.Clear()

        If MaxRow <= 0 Then
            Console.WriteLine("No Item List Found")
            MsgBox("Query not found", MsgBoxStyle.Information)
            txtSearch.SelectAll()
            lvList.Items.Clear()
            Exit Sub
        End If

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Item")
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = lvList.Items.Add(dr("KaratID"))
            lv.SubItems.Add(dr("Category"))
            lv.SubItems.Add(dr("Karat"))
        Next
    End Sub

    Private Sub lvList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvList.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmJList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        LoadClass()
        txtSearch.Text = ""
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvList.SelectedItems.Count <= 0 Then Exit Sub

        Dim catid As Integer
        catid = lvList.FocusedItem.Text
        Console.WriteLine("Cat ID: " & catid)

        tmpcat = New Category

        tmpcat.LoadCat(catid, frmJelCal.branchid)
        frmConsole.catID = catid

        lvList.Items.Clear()
        For Each pr As Price In tmpcat.Classdetails
            With pr

                Dim row As ListViewItem

                row = New ListViewItem(.ID)
                row.SubItems.Add(.CLassificaton)
                row.SubItems.Add(.Price)

                frmConsole.lvList.Items.Add(row)

            End With
        Next

        frmConsole.LoadCategory(tmpcat)
        frmConsole.Show()
        Me.Close()
    End Sub

End Class