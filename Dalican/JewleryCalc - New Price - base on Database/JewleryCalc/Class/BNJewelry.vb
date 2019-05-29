Public Class BNJewelry
    ReadOnly tbl As String = "tblbarcode"
    Dim mysql As String = String.Empty

#Region "Propertiers  and Variables"

    Private _id As Integer

    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _Barcode As String

    Public Property Barcode() As String
        Get
            Return _Barcode
        End Get
        Set(ByVal value As String)
            _Barcode = value
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

    Private _IsSpecial As Boolean

    Public Property IsSpecial() As Boolean
        Get
            Return _IsSpecial
        End Get
        Set(ByVal value As Boolean)
            _IsSpecial = value
        End Set
    End Property

    Public barcode_col As New ArrayList

    Public load_all_barcode As New ArrayList

#End Region

#Region "Functions and Procedures"

    Public Sub load_Barcodes(ByVal idx As Integer)
        mysql = "select * from " & tbl & "  where id =" & idx
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
        Next
    End Sub

    Friend Sub loadbyRow(ByVal dr As DataRow)
        With dr
            _id = .Item("Id")
            _Barcode = .Item("Barcode")
            _Category = .Item("Category")
            _IsSpecial = IIf(.Item("IsSpecial") = 1, True, False)
        End With
    End Sub

    Friend Sub loadSpecial()
        mysql = "select * from " & tbl & "  where isSpecial =1"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub loadAllBarcode()
        mysql = "select * from " & tbl & " where category <>'SP AUCTION' AND category <> 'PROPOSAL RING' and category <> 'WEDDING'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            load_all_barcode.Add(_Barcode)
        Next
    End Sub

    Public Sub savebarcode()
        mysql = "select * from " & tbl
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow
        With dsnewrow
            .Item("Barcode") = _Barcode
            .Item("Category") = _Category
            .Item("isSpecial") = IIf(_IsSpecial, 1, 0)
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Updatebarcode()
        mysql = "select * from " & tbl & " where id =" & _id
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                .Item("Barcode") = _Barcode
                .Item("Category") = _Category
                .Item("isSpecial") = IIf(_IsSpecial, 1, 0)
            End With
            database.SaveEntry(ds, False)
        Else
            Dim dsnewrow As DataRow
            dsnewrow = ds.Tables(0).NewRow
            With dsnewrow
                .Item("Barcode") = _Barcode
                .Item("Category") = _Category
                .Item("isSpecial") = IIf(_IsSpecial, 1, 0)
            End With
            ds.Tables(0).Rows.Add(dsnewrow)
            database.SaveEntry(ds)
        End If

    End Sub

    Friend Sub loadWedding_NotSpecial()
        mysql = "select * from " & tbl & " where category ='WEDDING'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            load_all_barcode.Add(_Barcode)
        Next
    End Sub

    Friend Sub loadWedding_Special()
        mysql = "select * from " & tbl & " where category ='WEDDING' and isSpecial =1"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub loadPROPOSALring_NotSpecial()
        mysql = "select * from " & tbl & " where category ='PROPOSAL RING'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            load_all_barcode.Add(_Barcode)
        Next
    End Sub

    Friend Sub loadPROPOSALring_Special()
        mysql = "select * from " & tbl & " where category ='PROPOSAL RING' and isSpecial =1"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_SP_Auction()
        mysql = "select * from " & tbl & " where category ='SP AUCTION' and isSpecial =1"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            load_all_barcode.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_BrandNewSet()
        '  mysql = "select * from " & tbl & " where BARCODE containing 'STJT10' or BARCODE containing 'STIL10' or Barcode containing 'STIL11' or Barcode containing 'STJT12' or Barcode containing 'STCO12'"
        mysql = "select * from " & tbl & " where category ='BRAND NEW SET'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_BrandNewWithStone()
        mysql = "select * from " & tbl & " where category = 'Brand New With Stone'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_wedPro()
        mysql = "select * from " & tbl & " where category = 'WEDDING'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_pro()
        mysql = "select * from " & tbl & " where category = 'PROPOSAL RING'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Sub load_SetPreOwn()
        mysql = "select * from " & tbl & " where category = 'Auction'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("barcode not found")
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyRow(dr)
            barcode_col.Add(_Barcode)
        Next
    End Sub

    Friend Function getStoneAuctionPrice(ByVal k As Integer) As Double
        mysql = "select * from " & "tblkarat" & "  where karat =" & k & " And category ='Auction - With Stone'"
        Dim ds As DataSet = LoadSQL(mysql, "tblkarat")

        Dim iKid As Integer = ds.Tables(0).Rows(0).Item("KaratID")
        mysql = "select * from " & "tblclass" & "  where karatID=" & iKid
        ds.Clear()
        ds = LoadSQL(mysql, "tblclass")

        Dim iPrice As Double = ds.Tables(0).Rows(0).Item("Price")
        If ds.Tables(0).Rows.Count > 0 Then
            Return iPrice
        End If
        Return 0.0
    End Function

    Friend Function getStoneAuctionPrice_LESSONEGRAM(ByVal k As Integer) As Double
        mysql = "select * from " & "tblkarat" & "  where karat =" & k & " And category ='AW-LESS 1G'"
        Dim ds As DataSet = LoadSQL(mysql, "tblkarat")

        Dim iKid As Integer = ds.Tables(0).Rows(0).Item("KaratID")
        mysql = "select * from " & "tblclass" & "  where karatID=" & iKid
        ds.Clear()
        ds = LoadSQL(mysql, "tblclass")

        Dim iPrice As Double = ds.Tables(0).Rows(0).Item("Price")
        If ds.Tables(0).Rows.Count > 0 Then
            Return iPrice
        End If
        Return 0.0
    End Function

    Friend Function IsBrandNewSpecial(ByVal bc As String) As Boolean
        mysql = "select * from " & tbl & " where Category='Brand New' and IsSpecial='1'"
        Dim ds As DataSet = LoadSQL(mysql, tbl)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                Dim tmpBarcode As String = dr.Item("Barcode")
                If bc.Contains(tmpBarcode) Then Return True
            Next
        End If
        Return False
    End Function

#End Region

End Class