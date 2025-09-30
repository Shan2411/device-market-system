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
        DataGridView1.DataSource = DatabaseHelper.GetProductsTable()

        DataGridView1.Columns("name").Width = 160
        DataGridView1.Columns("price").Width = 65
        DataGridView1.Columns("type").Width = 156

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False

        ' Select the 3rd row
        If DataGridView1.Rows.Count > 2 Then
            DataGridView1.ClearSelection()
            DataGridView1.Rows(2).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(2).Cells(0)
        End If

        'Load gaming mouse at the start '
        Dim productName As String = "Gaming Mouse"
        Dim detailsOfProduct = DatabaseHelper.GetProductDetails(productName)
        Dim name As String = detailsOfProduct.Item1
        Dim price As Decimal = detailsOfProduct.Item2
        Dim description As String = detailsOfProduct.Item5
        Dim photo As Image = detailsOfProduct.Item4

        Label1.Text = name
        Label2.Text = "₱ " & price.ToString("F2")
        Label3.Text = description
        PictureBox1.Image = photo

        '-----------LOAD COMBOBOX=------------  '
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Add(" Search by name:")
        ComboBox1.Items.Add(" Search by type:")
        ComboBox1.Items.Add(" Search by price:")

        ComboBox1.SelectedIndex = 0

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


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        'once a row is double clicked display details on the left'
        Try
            If e.RowIndex >= 0 Then
                Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

                ' Example: Get a value from the first column
                Dim productName As String = selectedRow.Cells("name").Value.ToString()
                Dim detailsOfProduct = DatabaseHelper.GetProductDetails(productName)
                Dim name As String = detailsOfProduct.Item1
                Dim price As Decimal = detailsOfProduct.Item2
                Dim description As String = detailsOfProduct.Item5
                Dim photo As Image = detailsOfProduct.Item4

                Label1.Text = name
                Label2.Text = "₱ " & price.ToString("F2")
                Label3.Text = description
                PictureBox1.Image = photo

            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving product details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim admin As New Admin_form()
        admin.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If IsLoggedIn Then

            MessageBox.Show("This feature is currently under development.", "Feature Not Ready Yet", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsLoggedIn Then

            MessageBox.Show("This feature is currently under development.", "Feature Not Ready Yet", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If ComboBox1.SelectedIndex = 0 Then 'index 0 is search by name'
            Dim comboText As String = "name"
            Dim searchText As String = TextBox1.Text

            DatabaseHelper.SelectByCategory(searchText, comboText)

        ElseIf ComboBox1.SelectedIndex = 1 Then 'index 1 is search by type'
            Dim comboText As String = "type"
            Dim searchText As String = TextBox1.Text
            DatabaseHelper.SelectByCategory(searchText, comboText)

        ElseIf ComboBox1.SelectedIndex = 2 Then 'index 2 is search by price'
            Dim comboText As String = "price"
            Dim searchText As String = TextBox1.Text
            DatabaseHelper.SelectByCategory(searchText, comboText)
        Else


        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If IsLoggedIn Then
            MessageBox.Show("This feature is currently under development.", "Feature Not Ready Yet", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
End Class
