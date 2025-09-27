<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profile
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button6 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Consolas", 40.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(80, 82)
        Label1.Name = "Label1"
        Label1.Size = New Size(237, 64)
        Label1.TabIndex = 0
        Label1.Text = "Hello, "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("HP Simplified Hans", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(285, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(131, 31)
        Label2.TabIndex = 1
        Label2.Text = "username"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(47, 189)
        Button1.Name = "Button1"
        Button1.Size = New Size(205, 168)
        Button1.TabIndex = 2
        Button1.Text = "Profile Information"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(258, 189)
        Button2.Name = "Button2"
        Button2.Size = New Size(205, 168)
        Button2.TabIndex = 3
        Button2.Text = "Shopping Cart"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(47, 363)
        Button3.Name = "Button3"
        Button3.Size = New Size(205, 168)
        Button3.TabIndex = 4
        Button3.Text = "Order History"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(258, 363)
        Button4.Name = "Button4"
        Button4.Size = New Size(205, 168)
        Button4.TabIndex = 5
        Button4.Text = "Sell Products"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(47, 537)
        Button6.Name = "Button6"
        Button6.Size = New Size(205, 168)
        Button6.TabIndex = 7
        Button6.Text = "Log Out"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Profile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(570, 784)
        Controls.Add(Button6)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Profile"
        Text = "Profile"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
End Class
