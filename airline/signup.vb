Imports System.Data.SqlClient
Public Class signup

    Private Sub signup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("M")
        ComboBox1.Items.Add("F")
        ComboBox1.Text = "select"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "" Or ComboBox1.Text = "" Then
            MessageBox.Show("Please complete the required fields..", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If TextBox1.Text = "Match" Then
            Try
                Using connection1 As New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=D:\MY LEARNING\APLIKASI\AIRLINE RESERVATION SYSTEM\AIRLINE\AIRLINERESERVATIONSYSTEM.MDF;Integrated Security=True;Connect Timeout=5;")
                    connection1.Open()

                    Dim cmd1 As New SqlCommand
                    cmd1.CommandText = "INSERT INTO users(Username, Password, Name, Age, Sex, ContactNo) VALUES (@Username, @Password, @Name, @Age, @Sex, @ContactNo)"
                    cmd1.Connection = connection1

                    ' Use parameters to prevent SQL injection
                    cmd1.Parameters.AddWithValue("@Username", TextBox3.Text)
                    cmd1.Parameters.AddWithValue("@Password", TextBox4.Text)
                    cmd1.Parameters.AddWithValue("@Name", TextBox6.Text)
                    cmd1.Parameters.AddWithValue("@Age", TextBox7.Text)
                    cmd1.Parameters.AddWithValue("@Sex", ComboBox1.Text)
                    cmd1.Parameters.AddWithValue("@ContactNo", TextBox9.Text)

                    ' Use ExecuteNonQuery for INSERT, UPDATE, DELETE
                    cmd1.ExecuteNonQuery()

                    MsgBox("Account created successfully!!", MsgBoxStyle.Information, "Record Added = ")
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                    TextBox7.Text = ""
                    ComboBox1.Text = ""
                    TextBox9.Text = ""
                    TextBox1.Text = ""
                End Using
            Catch ex As Exception
                MsgBox("Failed to create account!!" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            MessageBox.Show("Password not match... Try again", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox1.Text = ""
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox4.Text = TextBox5.Text Then
            TextBox1.Text = "Match"
            TextBox1.ForeColor = Color.Green

        Else
            TextBox1.Text = "Not match"
            TextBox1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class