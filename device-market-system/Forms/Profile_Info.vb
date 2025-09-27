Imports device_market_system.DatabaseHelper
Public Class Profile_Info
    Private Sub Profile_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Size = New Size(115, 40) ' Personal info selected at the start
        Panel2.Visible = False

        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Male")
        ComboBox1.Items.Add("Female")
        ComboBox1.Items.Add("Other")
        ComboBox1.Items.Add("Prefer not to say")

        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = "Select Gender"

    End Sub

    Private Sub Profile_Info_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label7.Text = Globals.nameOfcurrentUser
        Label7.AutoSize = True
        profileOpened = True 'so they cant spam profile button in home'

        '---------load existing profile data if it exists-----------------'
        Dim db As New DatabaseHelper()
        Dim profile = db.LoadProfile()

        TextBox1.Text = profile.realName
        TextBox2.Text = profile.email
        TextBox3.Text = profile.phoneNumber
        ComboBox1.Text = profile.gender
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    '---------save button of profile---------------'
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim realName As String = TextBox1.Text
        Dim email As String = TextBox2.Text
        Dim phoneNumber As String = TextBox3.Text
        Dim gender As String = ComboBox1.Text

        If String.IsNullOrWhiteSpace(realName) Then
            Label9.ForeColor = Color.Red
            Label9.Font = New Font(Label9.Font, FontStyle.Regular)
            Label9.Text = "Name cannot be empty."

            Label8.ForeColor = Color.Gray
            Label8.Font = New Font(Label8.Font, FontStyle.Italic)
            Label8.Text = "Please enter your phone number so sellers and buyers can reach you"
        ElseIf String.IsNullOrWhiteSpace(phoneNumber) Then
            Label8.ForeColor = Color.Red
            Label8.Font = New Font(Label8.Font, FontStyle.Regular)
            Label8.Text = "Phone Number cannot be empty."

            Label9.ForeColor = Color.Gray
            Label9.Font = New Font(Label9.Font, FontStyle.Italic)
            Label9.Text = "Provide the name you want displayed to sellers and buyers."
        ElseIf ComboBox1.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(ComboBox1.SelectedItem?.ToString()) Then
            Label16.ForeColor = Color.Red
            Label16.Text = "Please select a valid gender"
        Else
            ' Ask for confirmation before saving
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to save these details?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                DatabaseHelper.SaveProfile(realName, email, phoneNumber, gender)

                Label8.ForeColor = Color.Gray
                Label8.Font = New Font(Label8.Font, FontStyle.Italic)
                Label8.Text = "Please enter your phone number so sellers and buyers can reach you"

                Label9.ForeColor = Color.Gray
                Label9.Font = New Font(Label9.Font, FontStyle.Italic)
                Label9.Text = "Provide the name you want displayed to sellers and buyers."
            End If
        End If

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Size = New Size(95, 40)
        Button2.Size = New Size(115, 40)
        Panel2.Location = New Point(167, 59)
        Panel2.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Size = New Size(95, 40)
        Button1.Size = New Size(115, 40)
        Panel2.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim profile As New Profile()
        profile.Show()
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub Profile_Info_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        profileOpened = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class