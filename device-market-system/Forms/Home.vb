Imports System.Data.SQLite
Imports System.Diagnostics.Eventing
Imports device_market_system.DatabaseHelper
Module Globals
    Public IsLoggedIn As Boolean = False
    Public LoginSignupIsOpened As Boolean = False
    Public profileOpened As Boolean = False

    Public nameOfcurrentUser As String = ""
    Public userIsVerified As Boolean = False

End Module

Public Class Home
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DatabaseHelper.Initialize()
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsLoggedIn Then

            If Not profileOpened Then
                Dim profile As New Profile()
                profile.Show()
                profileOpened = True
            Else
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is Profile Then
                        f.BringToFront()
                        Exit For
                    End If
                Next
            End If

        Else 'If not logged in yet'
            MessageBox.Show("Please log in to access the dashboard.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If Not LoginSignupIsOpened Then
                Dim frm3 As New Log_in()
                frm3.Show()
                LoginSignupIsOpened = True
            Else
                'If login/signup window is opened do nothing bring the form to the front instead'
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is Log_in Then
                        f.BringToFront()
                        Exit For
                    ElseIf TypeOf f Is Form2 Then
                        f.BringToFront()
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If IsLoggedIn Then



        Else 'If not logged in yet'
            MessageBox.Show("Please log in to access the dashboard.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If Not LoginSignupIsOpened Then
                Dim frm3 As New Log_in
                frm3.Show()
                LoginSignupIsOpened = True
            Else
                'If login/signup window is opened do nothing bring the form to the front instead'
                For Each f As Form In Application.OpenForms
                    If TypeOf f Is Log_in Then
                        f.BringToFront()
                        Exit For
                    ElseIf TypeOf f Is Form2 Then
                        f.BringToFront()
                        Exit For
                    End If
                Next
            End If

        End If
    End Sub

End Class
