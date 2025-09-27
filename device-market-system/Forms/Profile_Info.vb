Public Class Profile_Info
    Private Sub Profile_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Profile_Info_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label7.Text = Globals.nameOfcurrentUser
        Label7.AutoSize = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class