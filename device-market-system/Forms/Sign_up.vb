Imports System.Data.SQLite
Imports device_market_system.DatabaseHelper
Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name As String = TextBox1.Text.ToLower()
        Dim password As String = TextBox2.Text

        DatabaseHelper.InsertUser(name, password, Me)
    End Sub

    Public Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim login As New Log_in()
        login.Show()
        Me.Close()
    End Sub
    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown
        'ENTER KEY responsiveness'
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Optional: prevents the beep sound
            Me.SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub
    Private Sub Form2Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LoginSignupIsOpened = False
    End Sub
End Class