Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI
Imports System.Threading
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports Newtonsoft.Json
Imports System.IO

Public Class Form1
    Inherits MaterialForm

    Public driver As IWebDriver
    Public taskRunning As Boolean = False
    Public userDataDir As String
    Public interval As Integer
    Public remainingTime As Integer
    Public settings As New Settings()

    Private autosaveTimer As New System.Windows.Forms.Timer()
    Private countdownTimer As New System.Windows.Forms.Timer()

    Public Shared Instance As Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the shared instance
        Instance = Me

        ' Initialize MaterialSkin
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)

        ' Load settings and validate user data directory
        LoadSettings()

        Try
            userDataDir = UserDataHelper.GetUserDataDir()
            UserDataHelper.ValidateUserDataDir(userDataDir)
            settings.UserDataDir = userDataDir ' Save the detected directory to settings
            SaveSettings() ' Save settings to ensure the userDataDir is updated
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Log("Error: " & ex.Message, Color.Red)
        End Try

        ' Set form's TopMost property according to the setting
        Me.TopMost = settings.TopMostEnabled

        ' Set up autosave timer
        AddHandler autosaveTimer.Tick, AddressOf AutosaveLog
        autosaveTimer.Interval = 60000 ' Autosave every 60 seconds
        autosaveTimer.Start()

        ' Initialize remainingTime and UpdateStatusLabel
        SetIntervalAndRemainingTime()
    End Sub

    Private Sub btnStartBot_Click(sender As Object, e As EventArgs) Handles btnStartBot.Click
        If taskRunning Then
            Log("Selenium Bot: Task is already running.", Color.Red)
            Return
        End If

        Log("Selenium Bot: Starting task...", Color.Blue)
        taskRunning = True

        ' Set the user data directory for the Chrome profile
        userDataDir = settings.UserDataDir
        If String.IsNullOrEmpty(userDataDir) OrElse Not Directory.Exists(userDataDir) Then
            MessageBox.Show("User data directory is invalid. Please provide a valid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Log("Error: User data directory is invalid.", Color.Red)
            taskRunning = False
            Return
        End If

        ' Start the countdown timer
        AddHandler countdownTimer.Tick, AddressOf Timer_Tick
        countdownTimer.Interval = 1000 ' Countdown every second
        countdownTimer.Start()

        ' Start the automation task
        Task.Run(AddressOf AutoInventory.RunAutomationTask)
    End Sub

    Private Sub btnStopBot_Click(sender As Object, e As EventArgs) Handles btnStopBot.Click
        If Not taskRunning Then
            Log("Selenium Bot: No task is currently running.", Color.Red)
            Return
        End If

        Log("Selenium Bot: Stopping task...", Color.Blue)
        taskRunning = False
        driver.Quit()
        countdownTimer.Stop()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        If remainingTime > 0 Then
            remainingTime -= 1
            UpdateStatusLabel()
        Else
            remainingTime = interval
            Task.Run(AddressOf AutoInventory.RunAutomationTask)
        End If
    End Sub

    Private Sub AutosaveLog(sender As Object, e As EventArgs)
        Dim logPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt")
        File.WriteAllText(logPath, RichTextBox1.Text)
        Log("Log autosaved.", Color.Orange)
    End Sub

    Public Sub Log(message As String, color As Color)
        If RichTextBox1.InvokeRequired Then
            RichTextBox1.Invoke(Sub() Log(message, color))
        Else
            Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.SelectionLength = 0

            RichTextBox1.SelectionColor = Color.Black
            RichTextBox1.AppendText($"{timestamp} - ")
            RichTextBox1.SelectionColor = color
            RichTextBox1.AppendText(message & Environment.NewLine)
            RichTextBox1.SelectionColor = RichTextBox1.ForeColor

            ' Scroll to the bottom of the RichTextBox
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length
            RichTextBox1.ScrollToCaret()
        End If
    End Sub


    Private Sub SaveSettings()
        settings.UserDataDir = userDataDir
        settings.Interval = interval
        settings.LastSelectedRadio = If(radio60s.Checked, "60s", If(radio2Hrs.Checked, "2Hrs", If(radio6Hrs.Checked, "6Hrs", "12Hrs")))
        settings.TopMostEnabled = Me.TopMost ' Save the TopMost property

        Dim settingsPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json")
        File.WriteAllText(settingsPath, JsonConvert.SerializeObject(settings))
    End Sub

    Private Sub LoadSettings()
        Dim settingsPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json")

        If File.Exists(settingsPath) Then
            settings = JsonConvert.DeserializeObject(Of Settings)(File.ReadAllText(settingsPath))
        Else
            settings = New Settings()
            SaveSettings()
        End If

        userDataDir = settings.UserDataDir

        Select Case settings.LastSelectedRadio
            Case "60s"
                radio60s.Checked = True
            Case "2Hrs"
                radio2Hrs.Checked = True
            Case "6Hrs"
                radio6Hrs.Checked = True
            Case "12Hrs"
                radio12Hrs.Checked = True
        End Select

        ' Set the form's TopMost property
        Me.TopMost = settings.TopMostEnabled

        SetIntervalAndRemainingTime()
    End Sub

    Private Sub SetIntervalAndRemainingTime()
        Select Case settings.LastSelectedRadio
            Case "60s"
                interval = 60
            Case "2Hrs"
                interval = 2 * 60 * 60
            Case "6Hrs"
                interval = 6 * 60 * 60
            Case "12Hrs"
                interval = 12 * 60 * 60
            Case Else
                interval = 60 ' Default to 60 seconds
        End Select

        remainingTime = interval
        UpdateStatusLabel()
    End Sub

    Private Sub UpdateStatusLabel()
        Dim timeSpan As TimeSpan = TimeSpan.FromSeconds(remainingTime)
        lblStatus.Text = $"Status: {timeSpan:dd\:hh\:mm\:ss}"
    End Sub

    Private Sub radio60s_CheckedChanged(sender As Object, e As EventArgs) Handles radio60s.CheckedChanged
        If radio60s.Checked Then
            interval = 60
            remainingTime = interval
            UpdateStatusLabel()
        End If
    End Sub

    Private Sub radio2Hrs_CheckedChanged(sender As Object, e As EventArgs) Handles radio2Hrs.CheckedChanged
        If radio2Hrs.Checked Then
            interval = 2 * 60 * 60
            remainingTime = interval
            UpdateStatusLabel()
        End If
    End Sub

    Private Sub radio6Hrs_CheckedChanged(sender As Object, e As EventArgs) Handles radio6Hrs.CheckedChanged
        If radio6Hrs.Checked Then
            interval = 6 * 60 * 60
            remainingTime = interval
            UpdateStatusLabel()
        End If
    End Sub

    Private Sub radio12Hrs_CheckedChanged(sender As Object, e As EventArgs) Handles radio12Hrs.CheckedChanged
        If radio12Hrs.Checked Then
            interval = 12 * 60 * 60
            remainingTime = interval
            UpdateStatusLabel()
        End If
    End Sub
End Class
