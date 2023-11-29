Module ModQuery
    Dim SqlQuery As String
    Public RunQuery As String
    Public Constr As String = My.Settings.Connection
    Public Function ExeDt(ByVal ModeDataTable As String, ByRef Filter As String(), ByRef FilterValues As String()) As DataTable
        Dim IsiFilter As String = ""
        Dim x As Integer = 0
        If ModeDataTable = "User" Then
            RunQuery = "Select UserName From UserTable"
        ElseIf ModeDataTable = "Karyawan" Then
            RunQuery = "Select IDKaryawan,NmKaryawan,TglMasukKerja,Usia From Karyawan"
        ElseIf ModeDataTable = "UserTable" Then
            RunQuery = "Select UserID,UserName,UserPassword,UserEmail,UserRID From UserTable"
        ElseIf ModeDataTable = "Priority" Then
            RunQuery = "Select PriorityDescription From TaskPriority"
        ElseIf ModeDataTable = "RoleTable" Then
            RunQuery = "Select RoleName from TaskRole"
        ElseIf ModeDataTable = "Status" Then
            RunQuery = "Select StatusDescription From TaskStatus"
        ElseIf ModeDataTable = "ListTask" Then
            RunQuery = "SELECT ID, TP.PriorityDescription, TS.StatusDescription, TaskDescription, TaskDate, DateStart, DateCompleted, DateDeadline, AssignedTo, IsCompleted FROM   ((TaskTable TT LEFT OUTER JOIN
             TaskPriority TP ON TP.PID = TT.PID) LEFT OUTER JOIN
             TaskStatus TS ON TS.SID = TT.SID) WHERE (TT.IsCompleted = 0)"
        ElseIf ModeDataTable = "AllTask" Then
            RunQuery = "SELECT ID, TP.PriorityDescription, TS.StatusDescription, TaskDescription, TaskDate, DateStart, DateCompleted, DateDeadline, AssignedTo, IsCompleted FROM   ((TaskTable TT LEFT OUTER JOIN
             TaskPriority TP ON TP.PID = TT.PID) LEFT OUTER JOIN
             TaskStatus TS ON TS.SID = TT.SID) WHERE (TT.IsCompleted IS NOT NULL)"
        ElseIf ModeDataTable = "OverdueTask" Then
            RunQuery = "SELECT ID, TP.PriorityDescription, TS.StatusDescription, TaskDescription, TaskDate, DateStart, DateCompleted, DateDeadline, AssignedTo, IsCompleted FROM   ((TaskTable TT LEFT OUTER JOIN
             TaskPriority TP ON TP.PID = TT.PID) LEFT OUTER JOIN
             TaskStatus TS ON TS.SID = TT.SID) WHERE (TT.IsCompleted = 0) AND (TT.DateDeadline >= NOW())"
        Else
        End If

        For Each Filters As String In Filter
            If Filters <> "" Then
                IsiFilter = IsiFilter & " AND " & Filters & " = " & StrSQL(FilterValues(x))
            End If
            x = x + 1
        Next
        RunQuery = RunQuery & IsiFilter

        ExeDt = GetDataTable(RunQuery, Constr)

        Return ExeDt
    End Function


End Module
