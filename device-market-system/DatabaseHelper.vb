Imports System.ComponentModel.DataAnnotations
Imports System.Data.SQLite

Public Class DatabaseHelper
    'palitan yung path ng database di ko magawa relative path'
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

    '---------SAVE PROFILE CHANGES-------------'    
    Public Shared Sub SaveProfile(realName As String, email As String, phoneNumber As String, gender As String)
        Try
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Using cmd As New SQLiteCommand("Update users Set realname = @realName, email = @email, phone_number = @phoneNumber, gender = @gender where username = @username", conn)
                    cmd.Parameters.AddWithValue("@realName", realName)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber)
                    cmd.Parameters.AddWithValue("@gender", gender)
                    cmd.Parameters.AddWithValue("@username", Globals.nameOfcurrentUser)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Profile saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving profile: " & ex.Message)
        End Try
    End Sub

    '----------LOAD PROFILE DATA IF IT EXISTS-------------' 
    Public Function LoadProfile() As (realName As String, email As String, phoneNumber As String, gender As String)
        Try
            Using con As New SQLiteConnection(connString)
                con.Open()
                Using cmd As New SQLiteCommand("SELECT realname, email, phone_number, gender from users where username = @username", con)
                    cmd.Parameters.AddWithValue("@username", Globals.nameOfcurrentUser)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim realName As String = If(reader.IsDBNull(0), "", reader.GetString(0))
                            Dim email As String = If(reader.IsDBNull(1), "", reader.GetString(1))
                            Dim phoneNumber As String = If(reader.IsDBNull(2), "", reader.GetString(2))
                            Dim gender As String = If(reader.IsDBNull(3), "", reader.GetString(3))
                            Return (realName, email, phoneNumber, gender)
                        Else
                            ' User not found, return empty strings
                            Return ("", "", "", "")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return ("You are dumb", "", "", "")
        End Try
    End Function


    Public Shared Sub LogoutUser()
        Globals.IsLoggedIn = False
        Globals.nameOfcurrentUser = ""

    End Sub


End Class
