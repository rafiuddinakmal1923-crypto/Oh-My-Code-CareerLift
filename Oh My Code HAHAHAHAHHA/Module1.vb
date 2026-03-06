Imports System.Data.OleDb
Imports Microsoft.VisualBasic.Devices

Module Module1
    ' This module contains global variables and functions for managing user data and subscription plans in the application.
    Public LoggedInEmail As String = ""
    Public UserType As String = ""
    Public CurrentPassword = ""
    Public ConsultantName As String = ""
    Public Consultantpicture As Byte() = Nothing
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rafiu\source\repos\Oh My Code HAHAHAHAHHA\Oh My Code HAHAHAHAHHA\bin\Debug\OMCreal1.accdb")
    Public Function GetUserSubscriptionPlan() As String
        Dim plan As String = "Free"
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Subscription Plan] FROM [Banking Details] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                plan = reader("Subscription Plan").ToString()
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading purchase data: " & ex.Message)
        Finally
            con.Close()
        End Try
        Return plan
    End Function

    Public Function GetUserTokens()
        Dim availabletokens As Integer = 0
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT Tokens FROM [Banking Details] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                availabletokens = CInt(reader("Tokens"))
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading purchase data: " & ex.Message)
        Finally
            con.Close()
        End Try
        Return availabletokens
    End Function


End Module
