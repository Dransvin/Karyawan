Imports CHR.Common
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports System.Data.OleDb

Public Class clsData
    Implements iclsList
    Dim dt As DataTable
    Dim template As New ClsTemplate
    Dim SqlQuery As String
    Dim NmKaryawan As String
    Dim Usia As Integer
    Dim TglMasukKerja As DateTime
    Public Function Action(DataRow As DataRow, ActionType As String) As Boolean Implements iclsList.Action
        Action = False
        If ActionType = cRefresh Then
            Action = True
            Exit Function
        End If
        If Not ActionType = cNew And IsNothing(DataRow) Then Exit Function
        If ActionType = cNew Or ActionType = cEdit Or ActionType = cDelete Or ActionType = cView Then
            Dim l_Dt As DataTable = Nothing
            Dim l_schema As DataTable = Nothing
            Dim l As New List(Of Object)

            If ActionType = cView Or ActionType = cDelete Then
                l_Dt = dt.Copy
                l_schema = GetDataTable("Select IDKaryawan,NmKaryawan,TglMasukKerja,Usia From Karyawan", Constr, SchemaOnly:=False)
            Else
                l_Dt = GetDataTable("SELECT ''AS IDKaryawan,'' AS NmKaryawan,DATE() AS TglMasukKerja,0 AS Usia;", Constr)
                l_schema = GetDataTable("SELECT '' AS IDKaryawan,'' AS NmKaryawan,DATE() AS TglMasukKerja,0 AS Usia;", Constr, SchemaOnly:=False)
            End If
            l_Dt.Clear()

            If ActionType = cNew Then
                l_Dt.Rows.Add()
                l_Dt.Rows(0).Item("IDKaryawan") = ""
            Else
                l_Dt.ImportRow(DataRow)
            End If

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "IDKaryawan",
            .RowFriendlyName = "ID Karyawan",
            .RowDescription = "ID Karyawan",
            .AllowNull = True,
            .IsReadOnly = True,
            .IsVisible = If(ActionType = cNew, False, True),
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "NmKaryawan",
            .RowFriendlyName = "Nama Karyawan",
            .RowDescription = "Nama Karyawan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})


            l.Add(New clsCommonDetailItem_DateEdit With {.RowName = "TglMasukKerja",
            .RowFriendlyName = "Tanggal masuk kerja",
            .RowDescription = "Tanggal masuk kerja",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_CalcEdit  With {.RowName = "Usia",
            .RowFriendlyName = "Usia Karyawan",
            .RowDescription = "Usia Karyawan",
            .AllowNull = True,
            .AllowTrimEmptyString = True})


            Dim f As New frmCommonDetail With {.Text = ActionType,
                                         .DataSource = l_Dt,
                                         .Schema = l_schema,
                                         .ListCustomItem = l,
                                         .ButtonSaveText = If(ActionType = cNew Or ActionType = cEdit, "Save", "Delete"),
                                         .IsForView = ActionType = cView,
                                         .IsForDelete = ActionType = cDelete}

            Dim dialogresult As DialogResult = Nothing
            Try
                Do
                    dialogresult = f.ShowDialog
                    If dialogresult = DialogResult.OK Then
                        Action = Save(f.Result, ActionType)
                    End If
                Loop Until Action Or Not dialogresult
            Catch ex As Exception
                mbError(ex.ToString)
            End Try
            f.Dispose()
        End If

    End Function

    Public Function Save(DataRow As DataRow, ActionType As String) As Boolean
        Save = False
        Dim oConn As OleDbConnection = Nothing
        Dim oCmd As OleDbCommand
        ReadData(DataRow)
        Dim Lanjut As Boolean = isValid(DataRow, ActionType)

        If Lanjut = True Then
            Try
                oConn = New OleDbConnection(Constr)
                oConn.Open()
                If ActionType = cNew Then
                    Dim PID As String = GetOneData("SELECT RIGHT('000'& MAX(IDKaryawan)+1, 3) From Karyawan", 0, Constr)
                    SqlQuery = "
                    INSERT INTO Karyawan(IDKaryawan, NmKaryawan, TglMasukKerja, Usia)
                    VALUES(" & StrSQL(PID) & "," & StrSQL(NmKaryawan) & "," & SQLDatetime(TglMasukKerja) & "," & Usia & ")"
                ElseIf ActionType = cEdit Then
                    SqlQuery = "UPDATE Karyawan 
                            SET NmKaryawan =" & StrSQL(NmKaryawan) & ", TglMskKerja =" & SQLDatetime(TglMasukKerja) & ", Usia =" & Usia & " WHERE IDKaryawan =" & StrSQL(DataRow.Item("IDKaryawan"))
                ElseIf ActionType = cDelete Then
                    SqlQuery = "DELETE FROM Karyawan Where IDKaryawan =" & StrSQL(DataRow.Item("IDKaryawan"))
                End If
                oCmd = New OleDbCommand(SqlQuery, oConn)
                oCmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try
        End If
        Save = True
        mbInfo("Action Success")

    End Function

    Private Sub ReadData(ByVal DataRow As DataRow)
        With DataRow
            NmKaryawan = IsNulls(DataRow.Item("NmKaryawan"), "")
            Usia = DataRow.Item("Usia")
            TglMasukKerja = IsNulls(DataRow.Item("TglMasukKerja"), Now.Date)

        End With
    End Sub
    Public Function isValid(ByVal DataRow As DataRow, ActionType As String) As Boolean
        isValid = False

        If Role > 1 And ActionType = cDelete Then
            Throw New Exception("You didn't have access")
        End If

        isValid = True
        Return isValid
    End Function



    Public Function AddonText() As String Implements iclsList.AddonText
        Return Nothing
    End Function

    Public Function CallTypeList() As List(Of iclsCallType) Implements iclsList.CallTypeList
        Return template.CRUD
    End Function

    Public Function ColumnNumToFreeze() As String Implements iclsList.ColumnNumToFreeze
        Return Nothing
    End Function

    Public Function ConditionalFormat() As Dictionary(Of String, FormatConditionRuleExpression) Implements iclsList.ConditionalFormat
        Return Nothing
    End Function

    Public Function CustomFormat() As Dictionary(Of String, String) Implements iclsList.CustomFormat
        Return Nothing
    End Function

    Public Function RefreshData() As DataTable Implements iclsList.RefreshData
        dt = ExeDt("Karyawan", {""}, {""})
        Return dt
    End Function

    Public Function SummaryColumn() As List(Of GridColumnSummaryItem) Implements iclsList.SummaryColumn
        Return Nothing
    End Function

End Class
