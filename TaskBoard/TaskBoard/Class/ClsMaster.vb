Imports CHR.Common
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports System.Data.OleDb

Public Class ClsMaster
    Implements iclsList
    Dim dt As DataTable
    Dim template As New ClsTemplate
    Dim RoleTable As DataTable = ExeDt("RoleTable", {""}, {""})
    Dim UserName, Password, Email, RID As String
    Dim SQLQuery As String

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
                l_schema = ExeDt("UserTable", {""}, {""})
            Else
                l_Dt = GetDataTable("SELECT 0 AS ID,'' AS UserName,'' AS Kunci,'' AS Email,'' AS RoleName;", Constr)
                l_schema = GetDataTable("SELECT 0 AS ID,'' AS UserName,'' AS Kunci,'' AS Email,'' AS RoleName;", Constr, SchemaOnly:=False)
            End If
            l_Dt.Clear()
            If ActionType = cNew Then
                l_Dt.Rows.Add()
                l_Dt.Rows(0).Item("ID") =
                l_Dt.Rows(0).Item("UserName").ToString = ""
            Else
                l_Dt.ImportRow(DataRow)
            End If

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "ID",
            .RowFriendlyName = "ID",
            .RowDescription = "ID",
            .AllowNull = True,
            .IsReadOnly = True,
            .IsVisible = If(ActionType = cNew, False, True),
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "UserName",
            .RowFriendlyName = "Username",
            .RowDescription = "Username",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "Kunci",
            .RowFriendlyName = "Password",
            .RowDescription = "Password",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_MemoExEdit With {.RowName = "Email",
            .RowFriendlyName = "Email",
            .RowDescription = "Email",
            .AllowNull = True,
            .AllowTrimEmptyString = True})

            l.Add(New clsCommonDetailItem_LookupEdit With {.RowName = "RoleName",
            .RowFriendlyName = "Role",
            .RowDescription = "Role",
            .ValueMember = "RoleName",
            .DisplayMember = "RoleName",
            .DataSource = RoleTable,
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
    Private Sub ReadData(ByVal DataRow As DataRow)
        With DataRow
            UserName = IsNulls(DataRow.Item("UserName"), "")
            Password = IsNulls(DataRow.Item("Kunci"), "")
            Email = IsNulls(DataRow.Item("Email"), "")
            RID = IsNulls(DataRow.Item("RoleName"), "")
        End With
    End Sub

    Public Function isValid(ByVal DataRow As DataRow, ActionType As String) As Boolean
        isValid = False
        If Role > 1 Then
            Throw New Exception("You didn't have access")
        End If
        isValid = True
        Return isValid
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
                Dim RoleID As Integer = GetOneData("SELECT RID FROM TaskRole Where RoleName =" & StrSQL(RID), 0, Constr)
                If ActionType = cNew Then
                    SQLQuery = "INSERT INTO UserTable (UserName,UserPassword,UserEmail,UserRID)
                    VALUES (" & StrSQL(UserName) & "," & StrSQL(Password) & "," & StrSQL(Email) & ", " & RoleID & ")"
                ElseIf ActionType = cEdit Then
                    SQLQuery = "UPDATE UserTable SET UserName =" & StrSQL(UserName) & ",UserPassword =" & StrSQL(Password) & ",UserEmail =" & StrSQL(Email) & ",UserRID =" & StrSQL(RoleID) & " WHERE UserID =" & DataRow.Item("ID")
                ElseIf ActionType = cDelete Then
                    SQLQuery = "DELETE FROM UserTable WHERE UserID =" & DataRow.Item("ID")
                End If
                oCmd = New OleDbCommand(SQLQuery, oConn)
                oCmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            End Try
        End If
        Save = True
        mbInfo("Action Success")
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
        dt = ExeDt("UserTable", {""}, {""})
        Return dt
    End Function

    Public Function SummaryColumn() As List(Of GridColumnSummaryItem) Implements iclsList.SummaryColumn
        Return Nothing
    End Function
End Class
