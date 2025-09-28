Imports device_market_system.DatabaseHelper

Public Class Admin_form
    Private Sub Admin_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim image = TextBox1.Text
        DatabaseHelper.Insertimage(image)
    End Sub
End Class