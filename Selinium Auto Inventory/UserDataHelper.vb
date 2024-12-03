Imports System.IO

Module UserDataHelper
    Public Function GetUserDataDir() As String
        Dim userProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Return Path.Combine(userProfile, "AppData", "Local", "Google", "Chrome", "User Data")
    End Function

    Public Sub ValidateUserDataDir(userDataDir As String)
        If String.IsNullOrEmpty(userDataDir) OrElse Not Directory.Exists(userDataDir) Then
            Throw New ArgumentException("User data directory is invalid.")
        End If
    End Sub
End Module
