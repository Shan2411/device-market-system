<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New ComponentModel.Container()
        Button2 = New Button()
        DataGridView1 = New DataGridView()
        DatabaseHelperBindingSource = New BindingSource(components)
        Panel1 = New Panel()
        TextBox1 = New TextBox()
        ComboBox1 = New ComboBox()
        Button5 = New Button()
        Button4 = New Button()
        Panel2 = New Panel()
        Label3 = New Label()
        Button3 = New Button()
        Button1 = New Button()
        Label2 = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DatabaseHelperBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = Color.White
        Button2.FlatAppearance.BorderSize = 0
        Button2.Font = New Font("Segoe UI Emoji", 12F)
        Button2.ForeColor = SystemColors.ControlText
        Button2.Location = New Point(941, 6)
        Button2.Margin = New Padding(0)
        Button2.Name = "Button2"
        Button2.Size = New Size(123, 28)
        Button2.TabIndex = 3
        Button2.Text = "👤  Profile"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridView1.Location = New Point(7, 55)
        DataGridView1.Margin = New Padding(0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(470, 583)
        DataGridView1.TabIndex = 4
        ' 
        ' DatabaseHelperBindingSource
        ' 
        DatabaseHelperBindingSource.DataSource = GetType(DatabaseHelper)
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Gainsboro
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Button5)
        Panel1.Controls.Add(Button2)
        Panel1.Location = New Point(1, 1)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1255, 39)
        Panel1.TabIndex = 5
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(145, 6)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(248, 27)
        TextBox1.TabIndex = 9
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownHeight = 110
        ComboBox1.DropDownWidth = 120
        ComboBox1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBox1.FormattingEnabled = True
        ComboBox1.IntegralHeight = False
        ComboBox1.Location = New Point(7, 7)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(132, 25)
        ComboBox1.TabIndex = 7
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Segoe UI Emoji", 12F)
        Button5.Location = New Point(1067, 5)
        Button5.Name = "Button5"
        Button5.Size = New Size(123, 28)
        Button5.TabIndex = 5
        Button5.Text = ChrW(55357) & ChrW(57042) & " View Cart"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(427, 563)
        Button4.Name = "Button4"
        Button4.Size = New Size(314, 23)
        Button4.TabIndex = 4
        Button4.Text = "remove lateradd picture for admin purpose only"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Control
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Button4)
        Panel2.Controls.Add(Button3)
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Location = New Point(412, 42)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(779, 620)
        Panel2.TabIndex = 6
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(115, 277)
        Label3.Name = "Label3"
        Label3.Size = New Size(83, 20)
        Label3.TabIndex = 5
        Label3.Text = "description"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(394, 170)
        Button3.Name = "Button3"
        Button3.Size = New Size(103, 36)
        Button3.TabIndex = 4
        Button3.Text = "Add to Cart"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(268, 170)
        Button1.Name = "Button1"
        Button1.Size = New Size(103, 36)
        Button1.TabIndex = 3
        Button1.Text = "Purchase"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(268, 109)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 25)
        Label2.TabIndex = 2
        Label2.Text = "49.5 PHP"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(251, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(246, 37)
        Label1.TabIndex = 1
        Label1.Text = "Gaming Mouse"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources._3_Tasten_Maus_Microsoft
        PictureBox1.Location = New Point(35, 36)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(194, 170)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Home
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1255, 724)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(DataGridView1)
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        Name = "Home"
        Text = "Device Market System"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DatabaseHelperBindingSource, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DatabaseHelperBindingSource As BindingSource
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ComboBox1 As ComboBox

End Class
