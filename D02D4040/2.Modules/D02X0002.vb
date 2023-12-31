Imports System.Text
''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>

Module D02X0002

    ''' <summary>
    ''' Tính tổng cho 1 cột tương ứng trên lưới
    ''' </summary>
    ''' <param name="ipCol"></param>
    ''' <param name="C1Grid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function Sum(ByVal ipCol As Integer, ByVal C1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Double
        Dim lSum As Double = 0
        For i As Integer = 0 To C1Grid.RowCount - 1
            If C1Grid(i, ipCol) Is Nothing OrElse TypeOf (C1Grid(i, ipCol)) Is DBNull Or C1Grid(i, ipCol).ToString = "" Then Continue For
            lSum += Convert.ToDouble(C1Grid(i, ipCol))
        Next
        Return lSum
    End Function


    ''' <summary>
    ''' Tìm kiếm mở rộng theo Tiêu thức
    ''' </summary>
    ''' <param name="sSQLSelection">Required. Câu đổ nguồn của combo</param>
    ''' <param name="tdbcFrom">Required. Tiêu thức Từ</param>
    ''' <param name="tdbcTo">Optional. Tiêu thức Đến</param>
    ''' <param name="iModeSelect">Optional. Default. 0: In theo giá trị Từ Đến. 1: In nhiều giá trị</param>
    ''' <returns>Chuỗi tìm kiếm. Khác rỗng khi lấy tập hợp</returns>
    ''' <remarks></remarks>
    Public Function HotKeyF2D91F6020(ByVal sSQLSelection As String, ByRef tdbcFrom As C1.Win.C1List.C1Combo, Optional ByRef tdbcTo As C1.Win.C1List.C1Combo = Nothing, Optional ByVal iModeSelect As Integer = 0) As String
        'Dim sKeyID As String = ""
        'Dim f As New D91F6020
        'With f
        '    .SQLSelection = sSQLSelection 'Theo TL phân tích 
        '    .ModeSelect = iModeSelect.ToString
        '    .ShowDialog()
        '    sKeyID = .OutPut01
        '    .Dispose()
        'End With

        Dim arrPro() As StructureProperties = Nothing
        SetProperties(arrPro, "FormIDPermission", "2")
        SetProperties(arrPro, "SQLSelection", sSQLSelection)
        SetProperties(arrPro, "ModeSelect", L3Byte(iModeSelect))
        Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6020", arrPro)
        Dim sKeyID As String = GetProperties(frm, "ReturnField").ToString

        If sKeyID <> "" Then
            If sKeyID.Substring(0, 1) <> "(" Then
                'Lấy theo giá trị Từ đến:
                '+ Gán lại giá trị cho 2 combo tiêu thức từ đến
                '+ Chuỗi tiêu thức gán bằng rỗng, sSQLOutput1= ""  
                Dim arrResult() As String = sKeyID.Split(";"c)
                tdbcFrom.Text = arrResult(0)

                If tdbcTo IsNot Nothing Then
                    If arrResult.Length = 1 Then
                        tdbcTo.Text = arrResult(0)
                    Else
                        tdbcTo.Text = arrResult(1)
                    End If
                End If

                sKeyID = ""
            Else
                'Lấy theo tập hợp:
                '+ Gán giá trị mặc định cho 2 combo tiêu thức từ đến
                '+ Chuỗi tiêu thức sSQLOutput1= sResult
                tdbcFrom.Text = "%"
                If tdbcTo IsNot Nothing Then tdbcTo.Text = "%"
            End If
        End If
        Return sKeyID
    End Function


    ''' <summary>
    ''' Cập nhật số thứ tự cho lưới
    ''' </summary>
    Public Sub UpdateOrderNum(ByVal TDBGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer)
        For i As Integer = 0 To TDBGrid.RowCount - 1
            TDBGrid(i, iCol) = i + 1
        Next
    End Sub


    Public Sub GetNewVoucherNo(ByVal strS1 As String, ByVal strS2 As String, ByVal strS3 As String, ByVal sOutputOrder As String, ByVal iOutputLength As Integer, ByVal sSeperator As String, ByVal txtVoucherNo As TextBox, ByVal bState As Boolean, ByVal sTableName As String)
        Dim conn As New SqlConnection(gsConnectionString)
        Dim frm As New D99F1111
        frm.TableName = sTableName

        frm.NewKeyString = strS1 & strS2 & strS3
        If bState Then
            frm.ShowDialog()
            If frm.Result = True Then
                Dim iOutputOrder As Integer = -1
                Select Case sOutputOrder
                    Case "NSSS"
                        iOutputOrder = D99D0041.OutOrderEnum.lmNSSS
                    Case "SNSS"
                        iOutputOrder = D99D0041.OutOrderEnum.lmSNSS
                    Case "SSNS"
                        iOutputOrder = D99D0041.OutOrderEnum.lmSSNS
                    Case "SSSN"
                        iOutputOrder = D99D0041.OutOrderEnum.lmSSSN
                End Select
                txtVoucherNo.Text = CreateIGEVoucherNo(strS1, strS2, strS3, CType(iOutputOrder, D99D0041.OutOrderEnum), iOutputLength, sSeperator, bState, sTableName) 'D99C0004.IGEVoucherNo(conn, False, gnNewLastKey, strS1, strS2, strS3, CType(iOutputOrder, D99D0041.OutOrderEnum), iOutputLength, sSeperator)

                frm.Dispose()
            Else
                frm.Dispose()
            End If
        Else
            Dim iOutputOrder As Integer = -1
            Select Case sOutputOrder
                Case "NSSS"
                    iOutputOrder = D99D0041.OutOrderEnum.lmNSSS
                Case "SNSS"
                    iOutputOrder = D99D0041.OutOrderEnum.lmSNSS
                Case "SSNS"
                    iOutputOrder = D99D0041.OutOrderEnum.lmSSNS
                Case "SSSN"
                    iOutputOrder = D99D0041.OutOrderEnum.lmSSSN
            End Select
            txtVoucherNo.Text = CreateIGEVoucherNo(strS1, strS2, strS3, CType(iOutputOrder, D99D0041.OutOrderEnum), iOutputLength, sSeperator, bState, sTableName)
            frm.Dispose()
        End If
    End Sub


End Module
