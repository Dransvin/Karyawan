<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtPass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Cancel = New Guna.UI2.WinForms.Guna2Button()
        Me.txtUser = New Guna.UI2.WinForms.Guna2TextBox()
        Me.OK = New Guna.UI2.WinForms.Guna2Button()
        Me.SuspendLayout()
        '
        'txtPass
        '
        Me.txtPass.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPass.Animated = True
        Me.txtPass.AutoRoundedCorners = True
        Me.txtPass.BackColor = System.Drawing.Color.Transparent
        Me.txtPass.BorderRadius = 16
        Me.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPass.DefaultText = ""
        Me.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPass.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPass.Location = New System.Drawing.Point(176, 79)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPass.PlaceholderText = "Password"
        Me.txtPass.SelectedText = ""
        Me.txtPass.Size = New System.Drawing.Size(300, 35)
        Me.txtPass.TabIndex = 2
        Me.txtPass.UseSystemPasswordChar = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Cancel.Animated = True
        Me.Cancel.AutoRoundedCorners = True
        Me.Cancel.BackColor = System.Drawing.Color.Transparent
        Me.Cancel.BorderRadius = 20
        Me.Cancel.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FillColor = System.Drawing.Color.LightGray
        Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Cancel.ForeColor = System.Drawing.Color.White
        Me.Cancel.HoverState.FillColor = System.Drawing.Color.RoyalBlue
        Me.Cancel.Location = New System.Drawing.Point(333, 122)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(124, 43)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "Cancel"
        '
        'txtUser
        '
        Me.txtUser.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUser.Animated = True
        Me.txtUser.AutoRoundedCorners = True
        Me.txtUser.BackColor = System.Drawing.Color.Transparent
        Me.txtUser.BorderRadius = 16
        Me.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser.DefaultText = ""
        Me.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.Location = New System.Drawing.Point(176, 34)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.PlaceholderText = "Username"
        Me.txtUser.SelectedText = ""
        Me.txtUser.Size = New System.Drawing.Size(300, 35)
        Me.txtUser.TabIndex = 1
        '
        'OK
        '
        Me.OK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.OK.Animated = True
        Me.OK.AutoRoundedCorners = True
        Me.OK.BackColor = System.Drawing.Color.Transparent
        Me.OK.BorderRadius = 20
        Me.OK.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.FillColor = System.Drawing.Color.LightGray
        Me.OK.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.HoverState.FillColor = System.Drawing.Color.RoyalBlue
        Me.OK.Location = New System.Drawing.Point(194, 122)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(124, 43)
        Me.OK.TabIndex = 3
        Me.OK.Text = "OK"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(632, 259)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.txtPass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Login"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Cancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtUser As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents OK As Guna.UI2.WinForms.Guna2Button
End Class
