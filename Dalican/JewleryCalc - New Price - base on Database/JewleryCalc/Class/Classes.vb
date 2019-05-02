Public Class Classes
    Private MainTable As String = "tblclass"

#Region "Properties"
    Private _ClassID As Integer
    Public Property ClassID() As Integer
        Get
            Return _ClassID
        End Get
        Set(ByVal value As Integer)
            _ClassID = value
        End Set
    End Property

    Private _KaratID As Integer
    Public Property KaratID() As Integer
        Get
            Return _KaratID
        End Get
        Set(ByVal value As Integer)
            _KaratID = value
        End Set
    End Property

    Private _Classes As String
    Public Property Classes() As String
        Get
            Return _Classes
        End Get
        Set(ByVal value As String)
            _Classes = value
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

#End Region

#Region "Functions and Procedures"

    Public Sub LoadClass_row(ByVal dr As DataRow)
        With dr
            _ClassID = .Item("ClassID")
            _KaratID = .Item("KaratID")
            _Classes = .Item("Class")
            _Price = .Item("Price")
        End With
    End Sub

    Friend Sub LoadClass(ByVal id As Integer, ByVal className As String)
        Dim mySql As String = "SELECT * FROM " & MainTable & "  WHERE KARATID = " & id & " AND CLASS ='" & className & "'"
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadClass_row(dr)
        Next

    End Sub


    'Public Sub SaveSpecs()
    '    Dim mySql As String = "SELECT * FROM " & MainTable
    '    '& " ROWS 1"
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    Dim dsNewRow As DataRow
    '    dsNewRow = ds.Tables(0).NewRow
    '    With dsNewRow
    '        .Item("ItemID") = _itemID
    '        .Item("SpecsName") = _specName
    '        .Item("SpecType") = _specType
    '        .Item("UOM") = _UoM
    '        .Item("onHold") = If(_onHold, 1, 0)
    '        .Item("SpecLayout") = _specLayout
    '        .Item("ShortCode") = _shortCode
    '        .Item("isRequired") = If(_isRequired, 1, 0)
    '        .Item("Created_At") = Now
    '    End With
    '    ds.Tables(0).Rows.Add(dsNewRow)
    '    database.SaveEntry(ds)
    'End Sub
#End Region



    'Public Sub UpdateSpecs()
    '    Dim mySql As String = "SELECT * FROM " & MainTable & " WHERE SpecsID = " & _specID
    '    Dim ds As DataSet
    '    ds = LoadSQL(mySql, MainTable)
    '    If ds.Tables(0).Rows.Count >= 1 Then
    '        With ds.Tables(0).Rows(0)
    '            .Item("SpecsName") = _specName
    '            .Item("SpecType") = _specType
    '            .Item("UoM") = _UoM
    '            .Item("onHold") = If(_onHold, 1, 0)
    '            .Item("SpecLayout") = _specLayout
    '            .Item("ShortCode") = _shortCode
    '            .Item("isRequired") = If(_isRequired, 1, 0)
    '            .Item("Updated_At") = Now
    '        End With
    '        database.SaveEntry(ds, False)
    '    Else
    '        Dim dsNewRow As DataRow
    '        dsNewRow = ds.Tables(0).NewRow
    '        With dsNewRow
    '            .Item("ItemID") = _itemID
    '            .Item("SpecsName") = _specName
    '            .Item("SpecType") = _specType
    '            .Item("UOM") = _UoM
    '            .Item("onHold") = If(_onHold, 1, 0)
    '            .Item("SpecLayout") = _specLayout
    '            .Item("ShortCode") = _shortCode
    '            .Item("isRequired") = If(_isRequired, 1, 0)
    '            .Item("Created_At") = Now
    '        End With
    '        ds.Tables(0).Rows.Add(dsNewRow)
    '        database.SaveEntry(ds)
    '    End If

    'End Sub

End Class