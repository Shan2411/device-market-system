Imports device_market_system.DatabaseHelper
Public Class Profile
    Private tooltip As New ToolTip()
    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tooltip.AutoPopDelay = 10000   ' 10 seconds visible
        tooltip.InitialDelay = 100     ' 0.1 seconds before it appears
        tooltip.ReshowDelay = 50       ' 0.05 seconds for reshow
        tooltip.ShowAlways = True

    End Sub
    Private Sub Profile_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label2.Text = Globals.nameOfcurrentUser
        Label2.AutoEllipsis = True
        Label2.AutoSize = False
        Label2.Width = 150

        tooltip.SetToolTip(Label2, Globals.nameOfcurrentUser)
    End Sub


    Private Sub Profile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        profileOpened = False
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            LogoutUser()
            Me.Close()
        ElseIf result = DialogResult.No Then
            MessageBox.Show("Logout canceled.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Profile_info As New Profile_Info()
        Profile_info.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class