Imports System.ComponentModel
Imports System.Text
Imports CHR.Common
Imports System.Net.Mail
Partial Public Class FrmMain
    Dim TaskTable As DataTable
    Dim UserTable As DataTable
    Dim PriorityTable As DataTable
    Dim StatusTable As DataTable
    Dim OverdueTasktable As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Matikan()
        GridControl1.Visible = False
        RepositoryItemComboBox1.Items.Clear()
        RepositoryItemComboBox2.Items.Clear()
        RepositoryItemComboBox3.Items.Clear()
    End Sub

    Private Sub hidupkan()
        Matikan()
        GridControl1.Visible = True
        UserTable = ExeDt("Karyawan", {""}, {""})
        For Each row In UserTable.Rows
            RepositoryItemComboBox1.Items.Add(row.item("NmKaryawan"))
        Next
        GridControl1.DataSource = UserTable
        Me.Text = UserName & "- Task Board"

    End Sub




    Private Sub CheckToFilter()
        'TaskTable = ExeDt("ListTask", {If(BarEditItem2.EditValue <> "", "AssignedTo", ""), If(BarEditItem3.EditValue <> "", "PriorityDescription", ""), If(BarEditItem4.EditValue <> "", "StatusDescription", "")}, {BarEditItem2.EditValue, BarEditItem3.EditValue, BarEditItem4.EditValue})
        'GridControl1.DataSource = TaskTable
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Matikan()
        FrmLogin.ShowDialog()
        hidupkan()

    End Sub

    Private Sub RepositoryItemComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox1.SelectedValueChanged
        CheckToFilter()
    End Sub

    Private Sub RepositoryItemComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox2.SelectedValueChanged
        CheckToFilter()
    End Sub

    Private Sub RepositoryItemComboBox3_SelectedValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox3.SelectedValueChanged
        CheckToFilter()
    End Sub

    Private Sub btnClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClear.ItemClick
        For Each item As DevExpress.XtraBars.BarItem In BarManager1.Items
            If TypeOf item Is DevExpress.XtraBars.BarEditItem And (item.Name.StartsWith("BarEditItem")) Then
                Dim barEditItem As DevExpress.XtraBars.BarEditItem = DirectCast(item, DevExpress.XtraBars.BarEditItem)
                barEditItem.EditValue = ""
                ' Lakukan sesuatu dengan BarEditItem di sini
            End If
        Next
        CheckToFilter()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnInsert.ItemClick
        Dim f As New frmList(New clsData) With {.Text = "Task", .IsGridEditable = True}
        f.ShowDialog()
        hidupkan()


    End Sub

    Private Sub Master_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Master.ItemClick
        Dim f As New frmList(New ClsMaster) With {.Text = "Master User", .IsGridEditable = True}
        f.ShowDialog()
        hidupkan()
    End Sub
End Class
