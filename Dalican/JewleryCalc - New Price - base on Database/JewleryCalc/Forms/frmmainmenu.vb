Public Class frmmainmenu

    Private Sub frmmainmenu_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LOADBRANCH()
    End Sub
    Private Sub LOADBRANCH()
        Dim mySql As String = "SELECT * FROM TBLBRANCH"
        Dim ds As DataSet = LoadSQL(mySql)

        cmbbranch.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows

            cmbbranch.Items.Add(dr("BRANCH_NAME"))

        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If cmbbranch.Text = "" Then Exit Sub

        frmJelCal.Show()

        frmJelCal.BRANCH.Text = cmbbranch.Text
        frmJelCal.SEARCHIDBRANCH()
        frmJelCal.Focus()
        Hide()
    End Sub
End Class