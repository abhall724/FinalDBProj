'Andrew hall
Option Strict On

Imports MySql.Data.MySqlClient


Public Class MainForm

    Dim MysqlConn As New MySqlConnection()

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load



    End Sub



    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        'Close the form

        Me.Close()

    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click

        Dim namecmd As New MySqlCommand
        Dim dateCmd As New MySqlCommand
        Dim passCmd As New MySqlCommand

        MysqlConn.ConnectionString = "server= localhost; uid=root; database=finalproject"
        Try
            MysqlConn.Open()

            namecmd.Connection = MysqlConn
            namecmd.CommandText = "stringTogether"
            namecmd.CommandType = CommandType.StoredProcedure
            namecmd.Parameters.Add("?in_firstname", txtFirstName.Text)
            namecmd.Parameters("?in_firstname").DbType = DbType.StringFixedLength
            namecmd.Parameters("?in_firstname").Direction = ParameterDirection.Input
            namecmd.Parameters.Add("?in_lastname", txtLastName.Text)
            namecmd.Parameters("?in_firstname").DbType = DbType.StringFixedLength
            namecmd.Parameters("?in_firstname").Direction = ParameterDirection.Input
            namecmd.Parameters.Add("?results", MySqlDbType.String)
            namecmd.Parameters("?results").Direction = ParameterDirection.Output
            namecmd.ExecuteNonQuery()

            lblNameOut.Text = namecmd.Parameters("?results").Value.ToString

            dateCmd.Connection = MysqlConn
            dateCmd.CommandText = "whatTime"
            dateCmd.CommandType = CommandType.StoredProcedure
            dateCmd.Parameters.Add("?results", MySqlDbType.String)
            dateCmd.Parameters("?results").Direction = ParameterDirection.Output
            dateCmd.ExecuteNonQuery()

            lblDateOut.Text = dateCmd.Parameters("?results").Value.ToString

            passCmd.Connection = MysqlConn
            passCmd.CommandText = "hashPassword"
            passCmd.CommandType = CommandType.StoredProcedure
            passCmd.Parameters.Add("?in_password", txtPassword.Text)
            passCmd.Parameters("?in_password").Direction = ParameterDirection.Input
            passCmd.Parameters("?in_password").DbType = DbType.StringFixedLength
            passCmd.Parameters.Add("?results", MySqlDbType.String)
            passCmd.Parameters("?results").Direction = ParameterDirection.Output
            passCmd.ExecuteNonQuery()

            lblPassOut.Text = passCmd.Parameters("?results").Value.ToString

        Catch ex As MySqlException
            MessageBox.Show(ex.Number & " " & ex.Message)
        End Try

        MysqlConn.Close()
    End Sub
End Class
