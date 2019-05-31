Imports Microsoft.Office.Interop
Public Class frmJelCal
    Dim GRFile_ht As New Hashtable

    Dim fileName As String
    Friend branchid As String
    Dim isDone As Boolean = False
    Dim tmpSavePath As String
    Dim tmpKarats As Double = 0.0
    Dim tmpgrams As Double = 0.0
    Dim tmpcls As String
    Dim OLD As String

    Dim SalePrice As Double = 0.0

    Dim isOld As Boolean = False

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdJeltmp.ShowDialog()

        fileName = ofdJeltmp.FileName

        If fileName = "" Then Exit Sub
        lblPath.Text = fileName

    End Sub


    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If lblPath.Text = "File not yet" Then Exit Sub
        SEARCHIDBRANCH()
        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim lineNum As Integer = 0

        'SAVE
        Dim oXL1 As New Excel.Application
        Dim oWB1 As Excel.Workbook
        Dim oSheet1 As Excel.Worksheet
        oWB1 = oXL.Workbooks.Open(Application.StartupPath & "/tmp/IMD Template.xlsx")
        oSheet1 = oWB1.Worksheets(1)

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        pbstatus.Maximum = MaxEntries - 1
        Dim tmpJapan_B_C_class As String = ""

        'brand new special

        Dim bnj_special As New BNJewelry
        bnj_special.loadSpecial()

        Dim bnj_allBarcode As New BNJewelry
        bnj_allBarcode.loadAllBarcode()

        'Wedding Not Special
        Dim wdNotSpecial As New BNJewelry
        wdNotSpecial.loadWedding_NotSpecial()

        'Wedding Special
        Dim wdSpecial As New BNJewelry
        wdSpecial.loadWedding_Special()

        'Proposal not Special
        Dim ProposalRing_NotSpecial As New BNJewelry
        ProposalRing_NotSpecial.loadPROPOSALring_NotSpecial()

        'Proposal Special
        Dim ProposalSpecial As New BNJewelry
        ProposalSpecial.loadPROPOSALring_Special()


        'Special Auction
        Dim SP_UACTION As New BNJewelry
        SP_UACTION.load_SP_Auction()

        'SET BrandNEW
        Dim SET_BRANDNEW As New BNJewelry
        SET_BRANDNEW.load_BrandNewSet()

        'Special Auction
        Dim withSTone As New BNJewelry
        withSTone.load_BrandNewWithStone()

        'Wedding and Proposal
        Dim wed_pro As New BNJewelry
        wed_pro.load_wedPro()

        Dim pro_ As New BNJewelry
        pro_.load_pro()

        'pre own auction
        Dim SETPreOwn_ As New BNJewelry
        SETPreOwn_.load_SetPreOwn()

        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim JewTmp As New Karat
            Dim tmpClass As New Classes
            With JewTmp
                OLD = oSheet.Cells(cnt, 11).value

                If OLD <> "YES" Then
                    isOld = True
                End If

                Dim TmpBarCode As String = oSheet.Cells(cnt, 10).value
                Console.WriteLine("Description:" & oSheet.Cells(cnt, 3).value)
                tmpKarats = .ParseKarat(oSheet.Cells(cnt, 3).value)
                tmpgrams = .ParseGrams(oSheet.Cells(cnt, 3).value)
                Dim karatclass As String = oSheet.Cells(cnt, 13).value
                Dim isBrandnew As Boolean = False
                Dim isWedding As Boolean = False
                Dim isProposal As Boolean = False
                Dim isSP_Auction As Boolean = False

                'With stone Auction
                If TmpBarCode.Contains("SNO") Then
                    If tmpgrams < 1 Then
                        Dim spAuction As New BNJewelry
                        Dim spPrice As Double = spAuction.getStoneAuctionPrice_LESSONEGRAM(tmpKarats)
                        SalePrice = (spPrice * tmpgrams) * 2
                        GoTo SalePriceHere
                    Else
                        Dim spAuction As New BNJewelry
                        Dim spPrice As Double = spAuction.getStoneAuctionPrice(tmpKarats)
                        SalePrice = (spPrice * tmpgrams) * 2
                        GoTo SalePriceHere
                    End If

                End If
                'brand new with stone
                For Each Str As String In withSTone.barcode_col
                    If TmpBarCode.Contains(Str) Then
                        If tmpgrams < 1 Then
                            If tmpKarats = 18 Then

                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New With Stone less 1G' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                                SalePrice = (a * tmpgrams) * 2
                                GoTo SalePriceHere

                            End If

                        Else
                            If tmpKarats = 18 Then

                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New With Stone'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))


                                SalePrice = (a * tmpgrams) * 2
                                GoTo SalePriceHere
                            End If

                            End If
                    End If
                Next

                For Each Str As String In SETPreOwn_.barcode_col
                    If TmpBarCode.Contains(Str) Then
                        If tmpKarats = 21 Or tmpKarats = 20 Then

                            Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Auction Set'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                            Dim ds As DataSet = LoadSQL(mySql)
                            Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                            SalePrice = (a * tmpgrams) * 2
                            GoTo SalePriceHere


                        Else

                            Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Auction Set'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                            Dim ds As DataSet = LoadSQL(mySql)
                            Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                            SalePrice = (a * tmpgrams) * 2

                            GoTo SalePriceHere
                        End If
                    End If
                Next

                'wedding proposal

            
                'Proposal package



                For Each Str As String In pro_.barcode_col
                    Dim isBrandnewSpecial As New BNJewelry
                    If isBrandnewSpecial.IsBrandNewSpecial(TmpBarCode) Then Exit For
                    If TmpBarCode.Contains(Str) Then
                        '    If chkProWedGensan.Checked Then
                        '        SalePrice = (2800 * tmpgrams) * 2

                        '    Else

                        '        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='PROPOSAL RING' OR TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='WEDDING'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        '        Dim ds As DataSet = LoadSQL(mySql)
                        '        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        '        SalePrice = (a * tmpgrams) * 2
                        '    End If
                        '    GoTo SalePriceHere
                    End If


                Next
                If karatclass = "P" Then

                    GoTo auctionprewon

                End If
                If TmpBarCode.Contains("BN") Then
                    tmpcls = "N"
                    GoTo Gohere
                ElseIf TmpBarCode.Contains("SPCO") Then
                    GoTo brandnewspecial

                ElseIf TmpBarCode.Contains("JPN") Then
                    tmpcls = "N"
                    GoTo Gohere
                ElseIf TmpBarCode.Contains("STJT") Then
                    tmpcls = "N"
                    GoTo bradnewset
                    '=================================================WEDDING AND PROPOSAL ================================================='
                ElseIf TmpBarCode.Contains("WJT") Or TmpBarCode.Contains("WHM") Or TmpBarCode.Contains("WSP") Then
                    tmpcls = "A"


                    If chkProWedGensan.Checked Then

                        If TmpBarCode.Contains("WHM") Then

                            If chkProWedGensan.Checked Then
                                SalePrice = (2750 * tmpgrams) * 2

                            Else
                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='PROPOSAL RING' and TBLCLASS.BRANCH_ID=  " & branchid & " OR TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='WEDDING'  and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                                SalePrice = (a * tmpgrams) * 2
                            End If


                        End If
                        If TmpBarCode.Contains("WSP") Then

                            If chkProWedGensan.Checked Then
                                SalePrice = (2500 * tmpgrams) * 2

                            Else
                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='PROPOSAL RING' and TBLCLASS.BRANCH_ID=  " & branchid & " OR TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='WEDDING'  and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                                SalePrice = (a * tmpgrams) * 2
                            End If


                        End If
                        If TmpBarCode.Contains("WJT") Then

                            If chkProWedGensan.Checked Then
                                SalePrice = (2500 * tmpgrams) * 2

                            Else
                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='PROPOSAL RING' and TBLCLASS.BRANCH_ID=  " & branchid & " OR TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='WEDDING'  and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                                SalePrice = (a * tmpgrams) * 2
                            End If


                        End If



                    End If


                End If

                'tmpKarats = 18
                'Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='PROPOSAL RING' and TBLCLASS.BRANCH_ID=  " & branchid & " OR TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='WEDDING'  and TBLCLASS.BRANCH_ID=  " & branchid & ""
                'Dim ds As DataSet = LoadSQL(mySql)
                'Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))

                'SalePrice = (a * tmpgrams) * 2


                'End If
                'GoTo SalePriceHere





                Select Case oSheet.Cells(cnt, 12).value
                    Case "BRAND NEW JWL"
                        tmpcls = "N"
                        GoTo brandnewnotspecial
                    Case "WEDDING RING"
                        tmpcls = "A"
                        GoTo Gohere
                    Case "PROPOSAL RING"
                        tmpcls = "A"
                        GoTo Gohere
                    Case "BRAND NEW SET"
                        tmpcls = "N"
                        GoTo bradnewset
                End Select




                For Each Str As String In SP_UACTION.load_all_barcode
                    If TmpBarCode.Contains(Str) Then
                        isSP_Auction = True
                        Exit For
                    End If
                Next

                If isSP_Auction Then
                    tmpcls = "A"
                    GoTo Gohere
                End If

                'If isBrandnew Then
                '    tmpcls = "N"
                '    GoTo Gohere
                'Else
                tmpcls = .ParseClass(oSheet.Cells(cnt, 2).value)
                'End If



                If isOld Then
                    If tmpcls = "B" Then
                        tmpcls = "A"
                    ElseIf tmpcls = "C" Then
                        tmpcls = "B"
                    End If
                End If
brandnewnotspecial:
                '====================================================BRAND NEW======================================'

                If tmpgrams < 1 Then
                    If tmpKarats = 18 Then
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLCLASS.CLASS='" & karatclass & "' AND TBLKARAT.CATEGORY='Brand New - Less 1G' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                    Else
                        tmpKarats = 21
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLCLASS.CLASS='" & karatclass & "' AND TBLKARAT.CATEGORY='Brand New - Less 1G' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2

                    End If
                    GoTo SalePriceHere

                Else
                    If tmpKarats = 18 Then
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLCLASS.CLASS='" & karatclass & "'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                        GoTo SalePriceHere
                    Else
                        tmpKarats = 21
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLCLASS.CLASS='" & karatclass & "' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                        GoTo SalePriceHere
                    End If

                End If

                '========================================================'AUCTION PREOWN
auctionprewon:

                If tmpgrams < 1 Then
                    If tmpKarats = 18 Then
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  AND TBLKARAT.CATEGORY='Auction - Less 1G' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                    Else
                        tmpKarats = 21
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "   AND TBLKARAT.CATEGORY='Auction - Less 1G' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2

                    End If
                    GoTo SalePriceHere

                Else
                    If tmpKarats = 18 Then
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & " AND TBLKARAT.CATEGORY='Auction' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                        GoTo SalePriceHere
                    Else
                        tmpKarats = 21
                        Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & " AND TBLKARAT.CATEGORY='Auction'  and TBLCLASS.BRANCH_ID=  " & branchid & ""
                        Dim ds As DataSet = LoadSQL(mySql)
                        Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                        SalePrice = (a * tmpgrams) * 2
                        GoTo SalePriceHere
                    End If

                End If

Gohere:

                Dim recCnt2 As Single = 0
                If tmpKarats = 0.0 Then
                    MsgBox("Description '" & oSheet.Cells(cnt, 3).value & "' is not valid, unable to parse.", MsgBoxStyle.Critical, "Error")

                    With oSheet
                        oSheet1.Cells(cnt, 1) = oSheet.Cells(cnt, 2).value
                        oSheet1.Cells(cnt, 2) = oSheet.Cells(cnt, 3).value
                        oSheet1.Cells(cnt, 3) = "UNKNOWN"
                        oSheet1.Cells(cnt, 4) = "UNKNOWN"
                        oSheet1.Cells(cnt, 5) = "UNKNOWN"
                        oSheet1.Cells(cnt, 6) = "UNKNOWN"
                        oSheet1.Cells(cnt, 7) = "UNKNOWN"
                        oSheet1.Cells(cnt, 8) = "UNKNOWN"
                        oSheet1.Cells(cnt, 9) = "UNKNOWN"
                        oSheet1.Cells(cnt, 10) = "UNKNOWN"
                        oSheet1.Cells(cnt, 11) = "UNKNOWN"
                        oSheet1.Cells(cnt, 12) = "UNKNOWN"
                        oSheet1.Cells(cnt, 13) = "UNKNOWN"
                        oSheet1.Cells(cnt, 14) = "UNKNOWN"
                    End With
                Else
                    Dim isSetBrandNew As Boolean = False
                    'Auction settings 

                    If isSP_Auction = True Then

                        If tmpKarats = 18 Then
                            If tmpgrams < 1 Then
                                Dim tmp_LessOneGramPrice As Double = getLess1GramPrice(tmpKarats, tmpcls)
                                SalePrice = (tmp_LessOneGramPrice * tmpgrams) * 2
                            Else
                                'Auction SPECIAL 18
                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Auction Special'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))


                                SalePrice = (a * tmpgrams) * 2
                            End If
                        ElseIf tmpKarats = 20 OrElse tmpKarats = 21 Then
                            If tmpgrams < 1 Then
                                Dim tmp_LessOneGramPrice As Double = getLess1GramPrice(tmpKarats, tmpcls)
                                SalePrice = (tmp_LessOneGramPrice * tmpgrams) * 2
                            Else


                                'AUction Special QUERY 20 and 21 karat
                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Auction Special'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                Dim ds As DataSet = LoadSQL(mySql)
                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))


                                SalePrice = (a * tmpgrams) * 2
                            End If
                        Else
                            If tmpgrams < 1 Then
                                Dim tmp_LessOneGramPrice As Double = getLess1GramPrice(tmpKarats, tmpcls)
                                SalePrice = (tmp_LessOneGramPrice * tmpgrams) * 2
                            Else
                                SalePrice = (2780 * tmpgrams) * 2
                            End If
                        End If
                    Else

                        If tmpgrams < 1 Then


                            Dim categories = .ParseCategory(oSheet.Cells(cnt, 2).value, oSheet.Cells(cnt, 10).value, oSheet.Cells(cnt, 12).value)

                            Select Case categories
                                Case "Auction"
                                    Dim tmp_LessOneGramPrice As Double = getLess1GramPrice(tmpKarats, tmpcls)
                                    SalePrice = (tmp_LessOneGramPrice * tmpgrams) * 2
                                Case "Brand New"
                                    For Each Str As String In SET_BRANDNEW.barcode_col
                                        If TmpBarCode.Contains(Str) Then
                                            isSetBrandNew = True

                                            Exit For
                                        End If
                                    Next

                                    Dim isSpecial As Boolean = False
                                    For Each Str As String In bnj_special.barcode_col
                                        If TmpBarCode.Contains(Str) Then
                                            isSpecial = True
                                            Exit For
                                        End If
                                    Next

                                    If isSetBrandNew Then

                                        '==========================================================================BRAND NEW SET=========================================================================================================
bradnewset:


                                        If tmpgrams < 1 Then

                                            If tmpKarats = 18 Then
                                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set Less 1G'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                                Dim ds As DataSet = LoadSQL(mySql)
                                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                                SalePrice = (a * tmpgrams) * 2
                                            Else
                                                tmpKarats = 21
                                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set Less 1G'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                                Dim ds As DataSet = LoadSQL(mySql)
                                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                                SalePrice = (a * tmpgrams) * 2
                                            End If

                                        Else
                                            If tmpKarats = 18 Then
                                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                                Dim ds As DataSet = LoadSQL(mySql)
                                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                                SalePrice = (a * tmpgrams) * 2
                                            Else
                                                tmpKarats = 21
                                                Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set' and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                                Dim ds As DataSet = LoadSQL(mySql)
                                                Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                                SalePrice = (a * tmpgrams) * 2
                                            End If
                                        End If

                                    End If

                                    '==========================================================================BRAND NEW SET=========================================================================================================
                            End Select

                        Else

                            For Each Str As String In SET_BRANDNEW.barcode_col
                                If TmpBarCode.Contains(Str) Then
                                    isSetBrandNew = True

                                    Exit For
                                End If
                            Next

                            If isSetBrandNew Then
                                If tmpKarats = 18 Then
                                    Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                    Dim ds As DataSet = LoadSQL(mySql)
                                    Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                    SalePrice = (a * tmpgrams) * 2


                                Else
                                    tmpKarats = 21
                                    Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Set'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                    Dim ds As DataSet = LoadSQL(mySql)
                                    Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                    SalePrice = (a * tmpgrams) * 2
                                    MessageBox.Show("isSetBrandNew")
                                End If

                                GoTo SalePriceHere
                            End If

                            .LoadKarat(.ParseCategory(oSheet.Cells(cnt, 2).value, oSheet.Cells(cnt, 10).value, oSheet.Cells(cnt, 12).value), tmpKarats)
                            tmpClass.LoadClass(.KaratID, tmpcls)

                            Dim isSpecial As Boolean = False
                            For Each Str As String In bnj_special.barcode_col
                                If TmpBarCode.Contains(Str) Then
                                    isSpecial = True
                                    Exit For
                                End If
                            Next

                            If isSpecial Then

brandnewspecial:

                                If tmpKarats = 18 Then

                                    Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Special'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                    Dim ds As DataSet = LoadSQL(mySql)
                                    Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))


                                    SalePrice = (a * tmpgrams) * 2
                                Else
                                    tmpKarats = 21
                                    Dim mySql As String = "SELECT * FROM TBLKARAT INNER JOIN TBLCLASS ON TBLCLASS.KARATID=TBLKARAT.KARATID  WHERE TBLKARAT.KARAT = " & tmpKarats & "  and TBLKARAT.CATEGORY='Brand New Special'and TBLCLASS.BRANCH_ID=  " & branchid & ""
                                    Dim ds As DataSet = LoadSQL(mySql)
                                    Dim a As Double = CDbl(ds.Tables(0).Rows(0).Item("PRICE"))
                                    SalePrice = (a * tmpgrams) * 2
                                    MessageBox.Show("isSetBrandNew")
                                End If

                            End If


                        End If

                    End If
SalePriceHere:
                    Console.WriteLine(SalePrice)

                    With oSheet
                        oSheet1.Cells(cnt, 1) = oSheet.Cells(cnt, 2).value
                        oSheet1.Cells(cnt, 2) = oSheet.Cells(cnt, 3).value
                        oSheet1.Cells(cnt, 3) = ""
                        oSheet1.Cells(cnt, 4) = oSheet.Cells(cnt, 12).value
                        oSheet1.Cells(cnt, 5) = ""
                        oSheet1.Cells(cnt, 6) = "PIECE"
                        oSheet1.Cells(cnt, 7) = 0
                        oSheet1.Cells(cnt, 8) = SalePrice
                        oSheet1.Cells(cnt, 9) = "Y"
                        oSheet1.Cells(cnt, 10) = "Y"
                        oSheet1.Cells(cnt, 11) = "N"
                        oSheet1.Cells(cnt, 12) = "Y"
                        oSheet1.Cells(cnt, 13) = 50
                        oSheet1.Cells(cnt, 14) = 40

                    End With
                End If

                pbstatus.Value = pbstatus.Value + 1
                Application.DoEvents()
                lblstatus.Text = String.Format("{0}%", ((pbstatus.Value / pbstatus.Maximum) * 100).ToString("F2"))
                tmpcls = "" : isOld = False
            End With
        Next

        sfdPath.FileName = BRANCH.Text & Now.ToString("MMddyyyy")
        tmpSavePath = tmpSavePath & "/" & sfdPath.FileName

        tmpSavePath = tmpSavePath & "_JWL"
        Me.Enabled = True
        isDone = True

        oWB1.SaveAs(tmpSavePath)
        oSheet1 = Nothing
        oWB1.Close(False)
        oWB1 = Nothing
        oXL1.Quit()
        oXL1 = Nothing


unloadObj:
        'Memory Unload
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        fileName = ""
        sfdPath.FileName = ""
        ofdJeltmp.FileName = ""
        lblPath.Text = "File not yet"

        If isDone Then
            If MsgBox("Successful generated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
            "Generate...") = MsgBoxResult.Ok Then pbstatus.Minimum = 0 : pbstatus.Value = 0 : lblstatus.Text = "0.00%"
        End If
    End Sub

    Private Sub frmJelCal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tmpSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub
    Public Sub SEARCHIDBRANCH()
        Dim mysql As String = "SELECT BRANCH_ID from tblbranch where   BRANCH_NAME='" & BRANCH.Text & "' "


        Dim ds As DataSet = LoadSQL(mysql, "BRANCH_NAME")



        For Each dr As DataRow In ds.Tables(0).Rows

            branchid = (dr("BRANCH_ID")).ToString

        Next
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        oWB = oXL.Workbooks.Open("C:\Users\MISGWAPOHON\Desktop\2016\Copy of tmplateClass.xlsx")
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        Me.Enabled = False
        Dim mysql As String = "SELECT * FROM tblclass"
        Dim ds As DataSet = LoadSQL(mysql, "tblclass")

        For cnt = 2 To MaxEntries

            Dim dsnewrow As DataRow
            dsnewrow = ds.Tables(0).NewRow
            With dsnewrow
                .Item("Class") = oSheet.Cells(cnt, 1).value
                .Item("Price") = oSheet.Cells(cnt, 2).value
                .Item("KARATID") = oSheet.Cells(cnt, 3).value
            End With
            ds.Tables(0).Rows.Add(dsnewrow)
            database.SaveEntry(ds)
        Next


        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Completed")
    End Sub

    Private Sub frmJelCal_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        frmConsole.Show()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        frmConsole.Show()
    End Sub

    Private Sub btnBrowseGR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseGR.Click
        Dim ofd1 As New OpenFileDialog
        ofd1.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        ofd1.ShowDialog()

        If ofd1.FileName = "" Then Exit Sub
        lblGRPath.Text = ofd1.FileName

        Dim oXL2 As New Excel.Application
        Dim oWB2 As Excel.Workbook
        Dim oSheet2 As Excel.Worksheet
        Dim lineNum As Integer = 0

        oWB2 = oXL2.Workbooks.Open(lblGRPath.Text)
        oSheet2 = oWB2.Worksheets(1)

        Dim MaxColumn As Integer = oSheet2.Cells(1, oSheet2.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet2.Cells(oSheet2.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        For cnt = 2 To MaxEntries
            GRFile_ht.Add(oSheet2.Cells(cnt, 1).value, oSheet2.Cells(cnt, 3))
        Next

        Console.WriteLine("GR succussfully Loaded")
    End Sub

    Private Sub btnBrowseIMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseIMD.Click
        Dim ofd2 As New OpenFileDialog
        ofd2.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        ofd2.ShowDialog()

        If ofd2.FileName = "" Then Exit Sub
        lblIMDpath.Text = ofd2.FileName
    End Sub

    Private Sub btnGRchecker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGRchecker.Click
        'Load Excel
        Dim oXL3 As New Excel.Application
        Dim oWB3 As Excel.Workbook
        Dim oSheet3 As Excel.Worksheet


        oWB3 = oXL3.Workbooks.Open(lblIMDpath.Text)
        oSheet3 = oWB3.Worksheets(1)

        Dim MaxColumn As Integer = oSheet3.Cells(1, oSheet3.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet3.Cells(oSheet3.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        pbstatus.Maximum = MaxEntries - 1


        For cnt = 2 To MaxEntries

            'msgBox(oSheet3.Cells(cnt, 10).value)

            If Not GRFile_ht.ContainsKey(oSheet3.Cells(cnt, 2).value) Then
                oSheet3.Cells(cnt, 11).value = "Dili makita sa GR"
            Else
                oSheet3.Cells(cnt, 11).value = "Dili makita sa GR"
            End If

            pbstatus.Value = pbstatus.Value + 1
            Application.DoEvents()
            lblstatus.Text = String.Format("{0}%", ((pbstatus.Value / pbstatus.Maximum) * 100).ToString("F2"))
        Next


        isDone = True

        oWB3.Save()
        oSheet3 = Nothing
        oWB3.Close(Type.Missing, Type.Missing, Type.Missing)
        oWB3 = Nothing
        oXL3.Quit()
        oXL3 = Nothing

        isDone = True
        If isDone Then
            If MsgBox("Successful generated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
            "Generate...") = MsgBoxResult.Ok Then pbstatus.Minimum = 0 : pbstatus.Value = 0 : lblstatus.Text = "0.00%"
        End If

        isDone = False
    End Sub

    Private Sub btnBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcode.Click
        frmBarcodeList.Show()
    End Sub

    Private Function getLess1GramPrice(ByVal krat As Integer, ByVal cl As String) As Double
        Dim mysql As String = "select * from tblkarat where category ='Auction - Less 1G' and karat =" & krat & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblkarat")

        Dim idx As Integer = CInt(ds.Tables(0).Rows(0).Item(0))

        Dim sql As String = "SELECT * from tblclass where karatID =" & idx & " and  class ='" & cl & " and TBLCLASS.BRANCH_ID=  " & branchid & ""
        Dim dsx As DataSet = LoadSQL(sql, "tblclass")

        If dsx.Tables(0).Rows.Count > 0 Then
            Return CDbl(dsx.Tables(0).Rows(0).Item("Price"))
        End If
        Return 0.0
    End Function

    Private Function getLess1GramPrice_BrandNew(ByVal krat As Integer, ByVal cl As String) As Double
        Dim mysql As String = "select * from tblkarat where category ='Brand New - Less 1G' and karat =" & krat
        Dim ds As DataSet = LoadSQL(mysql, "tblkarat")

        Dim idx As Integer = CInt(ds.Tables(0).Rows(0).Item(0))

        Dim sql As String = "select * from tblclass where karatID =" & idx & " and  class ='" & cl & "' and TBLCLASS.BRANCH_ID=  " & branchid & ""
        Dim dsx As DataSet = LoadSQL(sql, "tblclass")

        If dsx.Tables(0).Rows.Count > 0 Then
            Return CDbl(dsx.Tables(0).Rows(0).Item("Price"))
        End If
        Return 0.0
    End Function

  
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        frmConsole.Show()

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmmainmenu.Show()
        Me.Close()
        frmmainmenu.Focus()
    End Sub
End Class
