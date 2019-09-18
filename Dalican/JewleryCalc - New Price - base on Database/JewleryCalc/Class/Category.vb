Public Class Category

    Private MainTable As String = "tblKarat"
    Private SubTable As String = "tblClass"
    Private BRANCTABLE As String = "tblbranch"

    Private isLoaded As Boolean = False
   
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
    Private _branchid As Integer
    Public Property branchid() As Integer
        Get
            Return _branchid
        End Get
        Set(ByVal value As Integer)
            _branchid = value
        End Set
    End Property

    Private _branchname As String
    Public Property branchname() As String
        Get
            Return _branchname
        End Get
        Set(ByVal value As String)
            _branchname = value
        End Set
    End Property
    Private _branchcode As String
    Public Property branchcode() As String
        Get
            Return _branchcode
        End Get
        Set(ByVal value As String)
            _branchcode = value
        End Set
    End Property

    Private _Category As String
    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property

    Private _Karat As Integer
    Public Property Karat() As Integer
        Get
            Return _Karat
        End Get
        Set(ByVal value As Integer)
            _Karat = value
        End Set
    End Property


    Private _Classdetails As KaratCol
    Public Property Classdetails() As KaratCol
        Get
            Return _Classdetails
        End Get
        Set(ByVal value As KaratCol)
            _Classdetails = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadCat(ByVal id As Integer ,ByVal branchid As Integer )
        If isLoaded Then Exit Sub

        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE KaratID = '{1}'", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <= 0 Then
            MsgBox("Unable to load category", MsgBoxStyle.Critical)
            Exit Sub
        End If

        LoadScheme_row(ds.Tables(MainTable).Rows(0))

        mySql = String.Format("SELECT * FROM {0} INNER JOIN TBLBRANCH ON TBLCLASS.BRANCH_ID = TBLBRANCH.BRANCH_ID  WHERE TBLCLASS.KaratID = {1} AND TBLBRANCH.BRANCH_ID={2}  ORDER BY KaratID", SubTable, _ID, branchid)


        ds.Clear()
        ds = LoadSQL(mySql, SubTable)


        _Classdetails = New KaratCol
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Dim tmpDetails As New Price
            tmpDetails.Load_Class_row(dr)

            _Classdetails.Add(tmpDetails)
        Next

        isLoaded = True
    End Sub

    Public Sub LoadScheme_row(ByVal dr As DataRow)
        With dr
            _ID = .Item("KaratID")
            _Category = .Item("Category")
            _Karat = .Item("Karat")
        End With
    End Sub


    Public Sub SaveCat()
        Dim mySql As String = String.Format("SELECT * FROM {0}", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("Category") = _Category
            .Item("karat") = _Karat
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        SaveEntry(ds)

        mySql = String.Format("SELECT * FROM {0} ORDER BY KaratID DESC ROWS 1", MainTable)
        ds = LoadSQL(mySql, MainTable)
        _ID = ds.Tables(0).Rows(0).Item("KaratID")

        For Each ClDetails As Price In _Classdetails
            ClDetails.CatID = _ID
            ClDetails.Save_Details()
        Next
    End Sub

    Public Sub SaveBRANCH()

        Dim mySql As String = String.Format("SELECT * FROM {0}", BRANCTABLE)
        Dim ds As DataSet = LoadSQL(mySql, BRANCTABLE)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(BRANCTABLE).NewRow
        With dsNewRow
            .Item("BRANCH_CODE") = _branchcode
            .Item("BRANCH_NAME") = _branchname

        End With
        ds.Tables(BRANCTABLE).Rows.Add(dsNewRow)
        SaveEntry(ds)


    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE KaratID = {1}", MainTable, _ID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <= 0 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("Category") = _Category
            .Item("karat") = _Karat
        End With

        SaveEntry(ds, False)

    End Sub
#End Region

End Class
