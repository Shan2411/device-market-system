Imports System.ComponentModel.DataAnnotations
Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class DatabaseHelper
    Private Shared ReadOnly connString As String = "Server=localhost;Database=device_market_db;Uid=root;Pwd=;"

    Public Shared Sub Initialize()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                MessageBox.Show("MySQL connection successful!")

                Dim cmd As New MySqlCommand("SELECT * FROM users", conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Check your MySQL connection settings: " & ex.Message)
        End Try
    End Sub

    '---------SIGN UP---------------'
    Public Shared Sub InsertUser(username As String, password As String, currentForm As Form2)
        Try
            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                currentForm.Label5.ForeColor = Color.Red
                currentForm.Label5.Text = "Username and password cannot be empty."
            Else
                Using conn As New MySqlConnection(connString)
                    conn.Open()
                    Using cmd As New MySqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", conn)
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
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate entry
                currentForm.Label5.ForeColor = Color.Red
                currentForm.Label5.Text = "Username already taken"
            Else
                MessageBox.Show("Database error: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message)
        End Try
    End Sub

    '---------LOG IN-------------'
    Public Shared Sub LoginUser(username As String, password As String, currentForm As Log_in)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT password FROM users WHERE username = @username", conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentForm.Label4.ForeColor = Color.Black
                            currentForm.Label4.Text = "-"
                            Dim realPassword As String = reader("password").ToString()
                            If realPassword = password Then
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
        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message)
        End Try
    End Sub

    '---------SAVE PROFILE CHANGES-------------'    
    Public Shared Sub SaveProfile(realName As String, email As String, phoneNumber As String, gender As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE users SET realname = @realName, email = @email, phone_number = @phoneNumber, gender = @gender WHERE username = @username", conn)
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
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT realname, email, phone_number, gender FROM users WHERE username = @username", conn)
                    cmd.Parameters.AddWithValue("@username", Globals.nameOfcurrentUser)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return (
                                If(reader.IsDBNull(0), "", reader.GetString(0)),
                                If(reader.IsDBNull(1), "", reader.GetString(1)),
                                If(reader.IsDBNull(2), "", reader.GetString(2)),
                                If(reader.IsDBNull(3), "", reader.GetString(3))
                            )
                        Else
                            Return ("", "", "", "")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return ("Error", "", "", "")
        End Try
    End Function

    '----------GET PRODUCTS TABLE FOR DATAGRIDVIEW-------------'
    Public Shared Function GetProductsTable() As DataTable
        Dim query As String = "SELECT name, price, type FROM products"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Using adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    '-------STORE IMAGES IN MYSQL---------------'
    Public Shared Sub InsertImage(imagePath As String, nameFromDB As String)
        Try
            Using img As Image = Image.FromFile(imagePath)
                Using ms As New IO.MemoryStream()
                    img.Save(ms, Imaging.ImageFormat.Jpeg)
                    Dim imgBytes As Byte() = ms.ToArray()
                    Using conn As New MySqlConnection(connString)
                        conn.Open()
                        Using cmd As New MySqlCommand("UPDATE products SET photo = @imageData WHERE name = @name", conn)
                            cmd.Parameters.AddWithValue("@imageData", imgBytes)
                            cmd.Parameters.AddWithValue("@name", nameFromDB)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                End Using
            End Using
            MessageBox.Show("Image inserted successfully!")
        Catch ex As Exception
            MessageBox.Show("Error inserting image: " & ex.Message)
        End Try
    End Sub

    '-----------FETCH DETAILS OF A PRODUCT--------------'
    Public Shared Function GetProductDetails(name As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM products WHERE name = @name", conn)
                    cmd.Parameters.AddWithValue("@name", name)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim productName As String = reader("name").ToString()
                            Dim price As Decimal = Convert.ToDecimal(reader("price"))
                            Dim type As String = reader("type").ToString()
                            Dim description As String = reader("description").ToString()

                            Dim photo As Image = Nothing
                            If Not IsDBNull(reader("photo")) Then
                                Dim imageData() As Byte = CType(reader("photo"), Byte())
                                Using ms As New IO.MemoryStream(imageData)
                                    photo = Image.FromStream(ms)
                                End Using
                            End If

                            Return (productName, price, type, photo, description)
                        Else
                            Return (Nothing, Nothing, Nothing, Nothing, Nothing)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return (Nothing, Nothing, Nothing, Nothing, Nothing)
        End Try
    End Function

    Public Shared Sub LogoutUser()
        Globals.IsLoggedIn = False
        Globals.nameOfcurrentUser = ""
    End Sub

    '---------SELECT BY CATEGORY BASED ON COMBOBOX ---------------------'
    Public Shared Sub SelectByCategory(searchText As String, columnName As String)
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Using cmd As New MySqlCommand($"SELECT name, price, type FROM products WHERE {columnName} LIKE CONCAT(@textFromSearchbar, '%')", conn)
                    cmd.Parameters.AddWithValue("@textFromSearchbar", searchText)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        Home.DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error during search: " & ex.Message)
        End Try
    End Sub

End Class
