Imports System.Data.OleDb

Public Class Database
    Public Shared con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\rafiu\OneDrive\Desktop\OMC1.accdb")

    Public Shared Sub OpenConnection()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub

    Public Shared Sub CloseConnection()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
End Class
