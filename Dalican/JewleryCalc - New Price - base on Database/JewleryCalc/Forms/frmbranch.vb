Imports Microsoft.Office.Interop

Public Class frmbranch

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtBranchname.Text = "" Then Exit Sub

        Dim lv As ListViewItem = lvlbranch.Items.Add(0)

        lv.SubItems.Add(txtbranchcode.Text)

        lv.SubItems.Add(txtBranchname.Text)
        txtBranchname.Clear()
        txtbranchcode.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        For Each lv As ListViewItem In lvlbranch.Items
            Dim bnj As New Category
            With bnj
                .branchcode = lv.SubItems(1).Text
                .branchname = lv.SubItems(2).Text
                .SaveBRANCH()
            End With
            lvlbranch.Items.Clear()
        Next

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMD.ShowDialog()

        txtPath.Text = ofdIMD.FileName
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If txtPath.Text = "" Then Exit Sub
        If txtIDBranch.Text = "" Then Exit Sub

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(txtPath.Text)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        'If Not TemplateIntegrityCheck(checkHeaders) Then
        '    AddTimelyLogs("IMPORT MASTER DATA", "Template was tampered", , False, "IMD Template has been modify", )
        '    MsgBox("Template was tampered", MsgBoxStyle.Critical, "Please Contact Warehouse")
        '    GoTo unloadObj
        'End If
        pbStatus.Maximum = MaxEntries

        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim mySql As String = String.Format("SELECT * FROM {0}", "TBLCLASS")
            Dim ds As DataSet = LoadSQL(mySql, "TBLCLASS")

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("KaratID") = oSheet.Cells(cnt, 1).Value
                .Item("Class") = oSheet.Cells(cnt, 2).Value
                .Item("Price") = oSheet.Cells(cnt, 3).Value
                .Item("Branch_ID") = txtIDBranch.Text
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            pbStatus.Value = cnt
            Application.DoEvents()
            lblStatus.Text = String.Format("{0}%", (pbStatus.Value / pbStatus.Maximum * 100).ToString("F2"))
        Next
        Me.Enabled = True

        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Item Loaded", MsgBoxStyle.Information)
    End Sub

End Class