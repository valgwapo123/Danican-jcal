Public Class Price

    Private MainTable As String = "tblClass"

#Region "Properties"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _CatID As Integer
    Public Property CatID() As Integer
        Get
            Return _CatID
        End Get
        Set(ByVal value As Integer)
            _CatID = value
        End Set
    End Property

    Private _Class As String
    Public Property CLassificaton() As String
        Get
            Return _Class
        End Get
        Set(ByVal value As String)
            _Class = value
        End Set
    End Property

    Private _Price As Double
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal value As Double)
            _Price = value
        End Set
    End Property
    Private _branchid As Integer
    Public Property branchid() As Integer
        Get
            Return _branchid
        End Get
        Set(ByVal value As Integer)
            _branchid = value
        End Set
    End Property


#End Region

#Region "Procedures and Functions"
    Public Sub Load_Class_row(ByVal dr As DataRow)
        With dr
            _ID = .Item("ClassID")
            _CatID = .Item("KaratID")
            _Class = .Item("Class")
            _Price = .Item("Price")
        End With
    End Sub

    Public Sub Load_Class(ByVal id As Integer, ByVal branchid As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE CLASSID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to load class", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Load_Class_row(ds.Tables(MainTable).Rows(0))
    End Sub

    Public Sub Save_Details()
        Dim mySql As String = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("KaratID") = _CatID
            .Item("Class") = _Class
            .Item("Price") = _Price
            .Item("BRANCH_ID") = frmJelCal.branchid
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        SaveEntry(ds)
    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE {1}= {2} AND BRANCH_ID={3} ", MainTable, "CLASSID", _ID, frmJelCal.branchid)

        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count = 1 Then
            With ds.Tables(MainTable).Rows(0)
                .Item("Class") = _Class
                .Item("Price") = _Price
            End With
            SaveEntry(ds, False)
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
               .Item("KaratID") = _CatID
                .Item("Class") = _Class
                .Item("Price") = _Price
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End If
    End Sub

#End Region

End Class