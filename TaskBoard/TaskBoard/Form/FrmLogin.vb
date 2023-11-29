Imports CHR.Common
Imports System.Data.OleDb

Public Class FrmLogin

    '  Dim conStr As String = GetConnectionString(My.Settings.SERVER, My.Settings.Database, My.Settings.AppID, False, "sa", "ipiserver!234")
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Dim mode As Integer = ModeForm
    Dim Con As New OleDbConnection(My.Settings.Connection)
    Dim cmd As New OleDbCommand
    Dim Dt As DataTable = Nothing
    Dim dataSet As New DataSchedule() ' Ganti dengan nama dataset Anda
    Dim tableAdapter As New DataScheduleTableAdapters.UserTableTableAdapter() ' Ganti dengan nama TableAdapter Anda


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Con.Open()
        Dim da As New OleDbDataAdapter("SELECT UserName,UserRID,UserEmail FROM UserTable Where UserName =" & StrSQL(txtUser.Text) & "AND UserPassword =" & StrSQL(txtPass.Text), Con)
        Dim dt As New DataTable
            da.Fill(dt) 'dataadapter fills a datatable

        If txtPass.Text = "" Then
            MsgBox("Password tidak boleh kosong")
        ElseIf txtUser.Text = "" Then
            MsgBox("Username tidak boleh kosong")
        ElseIf txtPass.Text = "" And txtUser.Text = "" Then
            MsgBox("UserName Dan Password harus diisi !!!")
        Else
            If dt.Rows.Count = 1 Then
                UserName = dt.Rows(0)("UserName").ToString()
                Role = dt.Rows(0)("UserRID")
                AlamatEmail = dt.Rows(0)("UserEmail").ToString()
                Me.Visible = False
                Me.Dispose()
            ElseIf dt.Rows.Count = 0 Then
                MsgBox("User tidak ditemukan !!!")
            End If
        End If
        Con.Close()

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
        Application.Exit()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class
