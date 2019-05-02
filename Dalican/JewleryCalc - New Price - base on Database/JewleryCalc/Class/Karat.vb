
Public Class Karat
    Private MainTable As String = "tblkarat"
    Private SubTable As String = "tblclass"


#Region "Properties"

    Private _KaratID As Integer
    Public Property KaratID() As Integer
        Get
            Return _KaratID
        End Get
        Set(ByVal value As Integer)
            _KaratID = value
        End Set
    End Property

    Private _Karat As String
    Public Property Karat() As String
        Get
            Return _Karat
        End Get
        Set(ByVal value As String)
            _Karat = value
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


    Private _tmpClass As ColClass
    Public Property TmpClass() As ColClass
        Get
            Return _tmpClass
        End Get
        Set(ByVal value As ColClass)
            _tmpClass = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadKarat(ByVal Category As String, ByVal Karat As String)
        Dim mySql As String = String.Format("SELECT * FROM " & MainTable & " WHERE CATEGORY = '{0}' AND KARAT ='{1}'", Category, Karat)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count = 0 Then
            MsgBox("Failed to load Karat", MsgBoxStyle.Critical)

            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            _KaratID = .Item("KaratID")
            _Category = .Item("Category")
            _Karat = .Item("Karat")
        End With

        ' Load class
        mySql = String.Format("SELECT * FROM {0} WHERE KaratID = {1} ORDER BY ClassID", SubTable, _KaratID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _tmpClass = New ColClass
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("Class"))
            Dim tmpSpecs As New Classes
            tmpSpecs.LoadClass_row(dr)

            'Load Class
            _tmpClass.Add(tmpSpecs)
        Next
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
        With dr
            _KaratID = .Item("KaratID")
            _Category = .Item("Category")
            _Karat = .Item("Karat")
        End With
        ' Load Item Specification
        mySql = String.Format("SELECT * FROM {0} WHERE KaratID = {1} ORDER BY SpecsID", SubTable, _KaratID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _tmpClass = New ColClass
        For Each dr1 As DataRow In ds.Tables(SubTable).Rows
            Console.WriteLine(dr1.Item("Class"))
            Dim tmpClasses As New Classes
            tmpClasses.LoadClass_row(dr1)

            'Load Class
            _tmpClass.Add(tmpClasses)
        Next
    End Sub


    Friend Function ParseCategory(ByVal itemcode As String, ByVal BarcodeParse As String, ByVal itmGroup As String, Optional ByVal cls As String = "")

        Dim category

        category = itemcode.Substring(0, 3)

        Dim bnjAllBarcodes As New BNJewelry
        bnjAllBarcodes.loadAllBarcode()

        'Wedding 
        Dim wdSpecial As New BNJewelry
        wdSpecial.loadWedding_NotSpecial()

        'Proposal 
        Dim ProposalRing_Special As New BNJewelry
        ProposalRing_Special.loadPROPOSALring_NotSpecial()


        If itmGroup = "BRAND NEW JWL" Then
            For Each Str As String In bnjAllBarcodes.load_all_barcode
                If BarcodeParse.Contains(Str) Then
                    category = "Brand New"
                    Return category
                End If
            Next
        End If
        If itmGroup = "PROPOSAL RING" Then
            'Return Proposal
            For Each Str As String In ProposalRing_Special.load_all_barcode
                If BarcodeParse.Contains(Str) Then
                    category = ProposalRing_Special.Category
                    Return category
                End If
            Next
        End If

        If itmGroup = "WEDDING RING" Then
            'Return Wedding
            For Each Str As String In wdSpecial.load_all_barcode
                If BarcodeParse.Contains(Str) Then
                    category = wdSpecial.Category
                    Return category
                End If
            Next
        End If

        If BarcodeParse.Contains("BN") Then
            category = "Brand New"
            Return category
        ElseIf BarcodeParse.Contains("JPN") Then
            category = "Brand New"
            Return category
        End If

        If category.ToString.Contains("G") Then
            category = "Auction"
        ElseIf category.ToString.Contains("NC") Then
            category = "Auction"
        ElseIf category.ToString.Contains("NA") Then
            category = "Auction"
        ElseIf category.ToString.Contains("NB") Then
            category = "Auction"
        ElseIf category.ToString.Contains("T") Then
            category = "Titus"
        Else
            category = "Brand New"
        End If

        Console.WriteLine(category)
        Return category
    End Function

    Friend Function ParseKarat(ByVal Description As String)
        Dim Karat As String

        Dim isValidDesc As String = Description.Substring(Math.Max(0, Description.Length - 1))
        If isValidDesc <> "G" And isValidDesc <> "g" Then
            If Not IsNumeric(isValidDesc) Then
                Return 0.0
            End If
        End If

        Description = CleanDescription(Description)

        If Description.Contains("kt") Then
            Karat = Description.Substring(0, Description.IndexOf("kt")).Trim(" ")
            Karat = Karat.Substring(Karat.Length - 2)
            Karat = Karat.Replace(" ", "")
        ElseIf Description.Contains("KT") Then
            Karat = Description.Substring(0, Description.IndexOf("KT")).Trim(" ")
            Karat = Karat.Substring(Karat.Length - 2)
            Karat = Karat.Replace(" ", "")
        Else
            Return 0.0
        End If

        Console.WriteLine(Karat)
        Return Karat
    End Function

    Friend Function ParseClass(ByVal itmCode As String)
        Dim cls As String
        cls = itmCode.Substring(0, 3)
        cls = cls.Substring(cls.Length - 1)

        Console.WriteLine(cls)
        Return cls
    End Function

    Friend Function ParseGrams(ByVal Description As String)
        Dim Gram As String
        Dim isValidDesc As String = Description.Substring(Math.Max(0, Description.Length - 1))
        If isValidDesc <> "G" And isValidDesc <> "g" Then
            If Not IsNumeric(isValidDesc) Then
                Return 0.0
            End If
        End If

        If Not CheckIfNoGrams(Description) Then
            Description = Description & "G"
        End If


        Description = CleanDescription(Description)

        If Not Description.Contains("KT") Then
            If Not Description.Contains("kt") Then
                Return 0.0
            End If
        End If

        Dim tmpDesc As String = Description
        tmpDesc = tmpDesc.Substring(tmpDesc.Length - 1)
        If tmpDesc = "G" Or tmpDesc = "g" Then

            If Description.Contains("-") Then
                Gram = Description.Substring(Description.LastIndexOf("-"c)).Trim("-").Trim("G").Trim("g")
                Return Gram
            Else
                If Description.Contains("G") Then
                    Description = Description.Replace(" G", "")
                Else
                    Description = Description.Replace(" g", "")
                End If

                Gram = Description.Substring(Description.LastIndexOf(" "c)).Trim("G").Trim("g").Trim(" ")
                Gram = Gram.Replace("-", " ")

                Return Gram
            End If

        Else
            Gram = Description.Substring(0, Description.LastIndexOf("G"))

            Gram = Gram.Substring(Gram.LastIndexOf(" "c)).Trim("G").Trim("g").Trim(" ")
            Gram = Gram.Replace("-", " ")

        End If

        Return 0.0
    End Function

    Private Function CleanDescription(ByVal desc As String)
        Dim tmpDesc As String
        tmpDesc = desc.Replace("-", " ")

        Return tmpDesc
    End Function

    Private Function CheckIfNoGrams(ByVal desc As String) As Boolean
        Dim tmpdesc As String

        tmpdesc = CleanDescription(desc).Substring(desc.Length - 5)
        If Not tmpdesc.Contains("G") And Not tmpdesc.Contains("g") Then
            Return False
        End If

        Return True
    End Function
    'Public Sub Save_ItemClass()
    '    Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE ItemClass = '{0}'", _itemClassName)
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    'If ds.Tables(0).Rows.Count = 1 Then
    '    '    MsgBox("Class already existed", MsgBoxStyle.Critical)
    '    '    Exit Sub
    '    'End If

    '    Dim dsNewRow As DataRow
    '    dsNewRow = ds.Tables(0).NewRow
    '    With dsNewRow
    '        .Item("ItemClass") = _itemClassName
    '        .Item("ItemCategory") = _category
    '        .Item("Description") = _desc
    '        .Item("isRenew") = IIf(_isRenew, 1, 0)
    '        .Item("onHold") = IIf(_onHold, 1, 0)
    '        .Item("Print_Layout") = _printLayout
    '        .Item("Renewal_Cnt") = _Count
    '        .Item("Created_At") = Now

    '        .Item("Scheme_ID") = _interestScheme.SchemeID

    '    End With
    '    ds.Tables(0).Rows.Add(dsNewRow)
    '    database.SaveEntry(ds)


    '    mySql = "SELECT * FROM tblItem ORDER BY ItemID DESC ROWS 1"
    '    ds = LoadSQL(mySql, MainTable)
    '    _itemID = ds.Tables(MainTable).Rows(0).Item("ItemID")

    '    For Each ItemSpec As ItemSpecs In ItemSpecifications
    '        ItemSpec.ItemID = _itemID
    '        ItemSpec.SaveSpecs()
    '    Next
    'End Sub

    

    'Public Sub Update()
    '    Dim mySql As String = String.Format("SELECT * FROM {0} WHERE ItemID = {1}", MainTable, _itemID)
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    If ds.Tables(0).Rows.Count <> 1 Then
    '        MsgBox("Unable to update record", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    With ds.Tables(MainTable).Rows(0)
    '        '.Item("ItemClass") = _itemClassName
    '        .Item("ItemCategory") = _category
    '        .Item("Description") = _desc
    '        .Item("isRenew") = If(_isRenew, 1, 0)
    '        .Item("onHold") = If(_onHold, 1, 0)
    '        .Item("Print_Layout") = _printLayout
    '        .Item("Renewal_Cnt") = _Count
    '        .Item("Updated_At") = Now

    '        .Item("Scheme_ID") = _interestScheme.SchemeID

    '    End With
    '    database.SaveEntry(ds, False)
    'End Sub

    'Public Function LASTITEMID() As Single
    '    Dim mySql As String = "SELECT * FROM TBLItem ORDER BY ItemID DESC"
    '    Dim ds As DataSet = LoadSQL(mySql)

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        Return 0
    '    End If
    '    Return ds.Tables(0).Rows(0).Item("ItemID")
    'End Function


#End Region

End Class
