Imports System.Data.SQLite

Public Class DatabaseHelper
    Private Shared ReadOnly dbPath As String = IO.Path.Combine(Application.StartupPath, "C:\Users\HP\source\repos\device-market-system\device-market-system\database\im_database.db")
    Private Shared ReadOnly connString As String = "Data Source=" & dbPath & ";Version=3;"

    Public Shared Sub Initialize()
        Try
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                MessageBox.Show("Connection successful!")

                Dim cmd As New SQLiteCommand("SELECT * FROM users", conn)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error connecting to DB: " & ex.Message)
        End Try
    End Sub

    '---------SIGN UP---------------'
    Public Shared Sub InsertUser(username As String, password As String, currentForm As Form2)
        Try

            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                currentForm.Label5.ForeColor = Color.Red
                currentForm.Label5.Text = "Username and password cannot be empty."
            Else 'If its not whitespace'

                Using conn As New SQLiteConnection(connString)
                    conn.Open()
                    Using cmd As New SQLiteCommand("INSERT INTO users (username, password) VALUES (@username, @password)", conn)
                        cmd.Parameters.AddWithValue("@username", username)
                        cmd.Parameters.AddWithValue("@password", password)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                currentForm.Label5.ForeColor = Color.Green
                currentForm.Label5.Text = "User successfully created!"
                MessageBox.Show("Sign up successful, Welcome!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Globals.nameOfcurrentUser = username
                currentForm.Close()
                Globals.IsLoggedIn = True
            End If

        Catch ex As SQLiteException
            If ex.ResultCode = SQLiteErrorCode.Constraint Then
                currentForm.Label5.ForeColor = Color.Red
                currentForm.Label5.Text = "Username already taken"
            Else
                MessageBox.Show("Database error: " & ex.Message)
            End If

        Catch ex As Exception
            ' Handle non-database errors
            MessageBox.Show("Unexpected error: " & ex.Message)
        End Try
    End Sub

    '---------LOG IN-------------'
    Public Shared Sub LoginUser(username As String, password As String, currentForm As Log_in)
        Try
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Using cmd As New SQLiteCommand("select password from users where username = @username", conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Using reader = cmd.ExecuteReader
                        If reader.Read() Then
                            currentForm.Label4.ForeColor = Color.Black
                            currentForm.Label4.Text = "-"

                            Dim RealPassword As String = reader("password").ToString()
                            If RealPassword = password Then
                                MessageBox.Show("Login successful, Welcome back!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Globals.IsLoggedIn = True
                                currentForm.Close()
                                Globals.LoginSignupIsOpened = False
                                Globals.nameOfcurrentUser = username
                            Else
                                currentForm.Label5.ForeColor = Color.Red
                                currentForm.Label5.Text = "Incorrect password"

                            End If
                        Else
                            currentForm.Label5.ForeColor = Color.Black
                            currentForm.Label5.Text = "-"
                            currentForm.Label4.ForeColor = Color.Red
                            currentForm.Label4.Text = "Username does not exist"
                        End If
                    End Using

                End Using
            End Using

        Catch ex As SQLiteException
            MessageBox.Show("Database error: " & ex.Message)

        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub LogoutUser()
        Globals.IsLoggedIn = False
        Globals.nameOfcurrentUser = ""

    End Sub


End Class
