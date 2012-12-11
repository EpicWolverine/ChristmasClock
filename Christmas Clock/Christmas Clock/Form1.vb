Imports System.Random
Imports System.IO

Public Class Form1
    Public Second, Minute, Hour, Hour24 As Byte
    Public GotSystemTime, AM As Boolean
    Public TwelveHourClock As Boolean
    Dim FormGotFocus As Boolean
    Dim ResourceFilePath As String
    Dim SongGoneOff As Boolean = True
    Dim SkipNumber As Byte = 0
    'Dim SongTimeLeft As Integer = 0
    Public PlayASongVisible As Boolean
    Public SaveLocation As Boolean
    'Public AutoFocusEnabled As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FilePath()
        Dim a As String
        Dim c As Color
        Dim sr As New System.IO.StreamReader(ResourceFilePath & "\InitInfo.txt")
        a = sr.ReadLine
        c = System.Drawing.Color.FromArgb(a)
        Button1.BackColor = c
        Button1.FlatAppearance.BorderColor = c
        Button1.FlatAppearance.MouseOverBackColor = c
        Button1.FlatAppearance.MouseDownBackColor = c
        PictureBox1.BackColor = c
        Label1.BackColor = c
        a = sr.ReadLine
        c = System.Drawing.Color.FromArgb(a)
        Button1.ForeColor = c
        Button2.ForeColor = c
        Button3.ForeColor = c
        Button4.ForeColor = c
        Label1.ForeColor = c
        a = sr.ReadLine
        Options.CheckBox1.Checked = a
        Me.TopMost = a
        a = sr.ReadLine
        TwelveHourClock = a
        ResourceFilePath = ""
        a = sr.ReadLine
        If a = True Then
            SaveLocation = True
            Dim x, y As Integer
            x = sr.ReadLine
            y = sr.ReadLine
            Me.Location = New Point(x, y)
            sr.Close()
        ElseIf a = False Then
            SaveLocation = False
            sr.Close()
            'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 257, Screen.PrimaryScreen.WorkingArea.Height - 99)
            'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'Me.Location = New Point(Me.Location.X + 2, Me.Location.Y + 19)
        End If

        'Warm up Windows Media Player
        FilePath()
        ' Specify the mp3 file
        AxWindowsMediaPlayer1.URL = ResourceFilePath & "\test.wav"

        GotSystemTime = False
        Timer1.Start()

        FormNotFocused()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FilePath()
        Dim sw As New System.IO.StreamWriter(ResourceFilePath & "\InitInfo.txt")
        sw.WriteLine(Button1.BackColor.ToArgb)
        sw.WriteLine(Button1.ForeColor.ToArgb)
        sw.WriteLine(Options.CheckBox1.Checked.ToString)
        sw.WriteLine(TwelveHourClock.ToString)
        If SaveLocation = True Then
            sw.WriteLine("True")
            sw.WriteLine(Me.Location.X.ToString)
            sw.WriteLine(Me.Location.Y.ToString)
        ElseIf SaveLocation = False Then
            sw.WriteLine("False")
        End If
        sw.Close()
    End Sub

    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 257, Screen.PrimaryScreen.WorkingArea.Height - 99) And Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow Or Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            PictureBox1.Visible = False
        Else
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AboutBox1.Show()
        Button2.TextAlign = ContentAlignment.TopCenter
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Options.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Play a Song" Then
            SongGoneOff = False
        ElseIf Button4.Text = "Stop" Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            'SongTimeLeft = 0
            Button4.Text = "Play a Song"
            Label1.Visible = False
            ' If Options.CheckBox1.Checked = True Then
            ' Button4.Visible = True
            ' Else
            ' Button4.Visible = False
            ' End If
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 257, Screen.PrimaryScreen.WorkingArea.Height - 99)
    End Sub

    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        Button1.Font = New System.Drawing.Font("Showcard Gothic", 16)
        Button1.Text = "Dock to Corner"
        Timer1.Stop()
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As System.EventArgs) Handles PictureBox1.MouseLeave
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Options.Button6.Text = "Recalibrate Clock"
        Button1.Font = New System.Drawing.Font("Showcard Gothic", 36)
        If GotSystemTime = True Then
            Second += 1
            If Second > 59 Then
                Second = 0
                Minute += 1
                If Minute > 59 Then
                    Minute = 0
                    Hour += 1
                    Hour24 += 1
                    SongGoneOff = False
                    If TwelveHourClock = True Then
                        If Hour24 = 12 Then
                            Hour = 12
                            AM = False
                        ElseIf Hour24 > 12 Then
                            Hour = Hour24 - 12
                            AM = False
                        ElseIf Hour24 = 0 Then
                            Hour = 12
                            AM = True
                        ElseIf Hour24 < 12 Then
                            Hour = Hour24
                            AM = True
                        ElseIf Hour24 = 25 Then
                            Hour = 1
                            AM = True
                        End If
                    Else
                        Hour = Hour24
                    End If
                End If
            End If
        Else
            Hour24 = My.Computer.Clock.LocalTime.Hour.ToString
            Minute = My.Computer.Clock.LocalTime.Minute.ToString
            Second = My.Computer.Clock.LocalTime.Second.ToString
            GotSystemTime = True
            If TwelveHourClock = True Then
                If Hour24 = 12 Then
                    Hour = 12
                    AM = False
                ElseIf Hour24 = 25 Then
                    Hour = 1
                    AM = True
                ElseIf Hour24 > 12 Then
                    Hour = Hour24 - 12
                    AM = False
                ElseIf Hour24 = 0 Then
                    Hour = 12
                    AM = True
                ElseIf Hour24 < 12 Then
                    Hour = Hour24
                    AM = True
                End If
            Else
                Hour = Hour24
            End If
        End If
        If TwelveHourClock = True Then
            If AM = True Then
                If Minute = 0 Then
                    Button1.Text = Hour & ":" & "00" & " AM"
                ElseIf Minute = 1 Then
                    Button1.Text = Hour & ":" & "01" & " AM"
                ElseIf Minute = 2 Then
                    Button1.Text = Hour & ":" & "02" & " AM"
                ElseIf Minute = 3 Then
                    Button1.Text = Hour & ":" & "03" & " AM"
                ElseIf Minute = 4 Then
                    Button1.Text = Hour & ":" & "04" & " AM"
                ElseIf Minute = 5 Then
                    Button1.Text = Hour & ":" & "05" & " AM"
                ElseIf Minute = 6 Then
                    Button1.Text = Hour & ":" & "06" & " AM"
                ElseIf Minute = 7 Then
                    Button1.Text = Hour & ":" & "07" & " AM"
                ElseIf Minute = 8 Then
                    Button1.Text = Hour & ":" & "08" & " AM"
                ElseIf Minute = 9 Then
                    Button1.Text = Hour & ":" & "09" & " AM"
                Else
                    Button1.Text = Hour & ":" & Minute & " AM"
                End If
            Else
                If Minute = 0 Then
                    Button1.Text = Hour & ":" & "00" & " PM"
                ElseIf Minute = 1 Then
                    Button1.Text = Hour & ":" & "01" & " PM"
                ElseIf Minute = 2 Then
                    Button1.Text = Hour & ":" & "02" & " PM"
                ElseIf Minute = 3 Then
                    Button1.Text = Hour & ":" & "03" & " PM"
                ElseIf Minute = 4 Then
                    Button1.Text = Hour & ":" & "04" & " PM"
                ElseIf Minute = 5 Then
                    Button1.Text = Hour & ":" & "05" & " PM"
                ElseIf Minute = 6 Then
                    Button1.Text = Hour & ":" & "06" & " PM"
                ElseIf Minute = 7 Then
                    Button1.Text = Hour & ":" & "07" & " PM"
                ElseIf Minute = 8 Then
                    Button1.Text = Hour & ":" & "08" & " PM"
                ElseIf Minute = 9 Then
                    Button1.Text = Hour & ":" & "09" & " PM"
                Else
                    Button1.Text = Hour & ":" & Minute & " PM"
                End If
            End If
        Else
            If Minute = 0 Then
                Button1.Text = Hour24 & ":" & "00"
            ElseIf Minute = 1 Then
                Button1.Text = Hour24 & ":" & "01"
            ElseIf Minute = 2 Then
                Button1.Text = Hour24 & ":" & "02"
            ElseIf Minute = 3 Then
                Button1.Text = Hour24 & ":" & "03"
            ElseIf Minute = 4 Then
                Button1.Text = Hour24 & ":" & "04"
            ElseIf Minute = 5 Then
                Button1.Text = Hour24 & ":" & "05"
            ElseIf Minute = 6 Then
                Button1.Text = Hour24 & ":" & "06"
            ElseIf Minute = 7 Then
                Button1.Text = Hour24 & ":" & "07"
            ElseIf Minute = 8 Then
                Button1.Text = Hour24 & ":" & "08"
            ElseIf Minute = 9 Then
                Button1.Text = Hour24 & ":" & "09"
            Else
                Button1.Text = Hour24 & ":" & Minute
            End If
        End If
        If SongGoneOff = False Then 'Does a song need to be played?
            Song()
            SongGoneOff = True
            Label1.Visible = True
        End If
        'If SongTimeLeft = 0 Then
        '    Button4.Text = "Play a Song"
        '    ' If FormGotFocus = True Then
        '    ' Button4.Visible = True
        '    ' Else
        '    ' Button4.Visible = False
        '    ' End If
        '    Label1.Visible = False
        'Else
        '    Button4.Text = "Stop"
        '    'SongTimeLeft -= 1
        '    Label1.Visible = True
        'End If
        If Second < My.Computer.Clock.LocalTime.Second Or Second > My.Computer.Clock.LocalTime.Second Then
            Second = My.Computer.Clock.LocalTime.Second.ToString
            Minute = My.Computer.Clock.LocalTime.Minute.ToString
            Hour24 = My.Computer.Clock.LocalTime.Hour.ToString
            If TwelveHourClock = True Then
                
                If Hour24 = 12 Then
                    Hour = 12
                    AM = False
                ElseIf Hour24 > 12 Then
                    Hour = Hour24 - 12
                    AM = False
                ElseIf Hour24 = 0 Then
                    Hour = 12
                    AM = True
                ElseIf Hour24 < 12 Then
                    Hour = Hour24
                    AM = True
                ElseIf Hour24 = 25 Then
                    Hour = 1
                    AM = True
                End If
            Else
                Hour = Hour24
            End If
            If TwelveHourClock = True Then
                If AM = True Then
                    If Minute = 0 Then
                        Button1.Text = Hour & ":" & "00" & " AM"
                    ElseIf Minute = 1 Then
                        Button1.Text = Hour & ":" & "01" & " AM"
                    ElseIf Minute = 2 Then
                        Button1.Text = Hour & ":" & "02" & " AM"
                    ElseIf Minute = 3 Then
                        Button1.Text = Hour & ":" & "03" & " AM"
                    ElseIf Minute = 4 Then
                        Button1.Text = Hour & ":" & "04" & " AM"
                    ElseIf Minute = 5 Then
                        Button1.Text = Hour & ":" & "05" & " AM"
                    ElseIf Minute = 6 Then
                        Button1.Text = Hour & ":" & "06" & " AM"
                    ElseIf Minute = 7 Then
                        Button1.Text = Hour & ":" & "07" & " AM"
                    ElseIf Minute = 8 Then
                        Button1.Text = Hour & ":" & "08" & " AM"
                    ElseIf Minute = 9 Then
                        Button1.Text = Hour & ":" & "09" & " AM"
                    Else
                        Button1.Text = Hour & ":" & Minute & " AM"
                    End If
                Else
                    If Minute = 0 Then
                        Button1.Text = Hour & ":" & "00" & " PM"
                    ElseIf Minute = 1 Then
                        Button1.Text = Hour & ":" & "01" & " PM"
                    ElseIf Minute = 2 Then
                        Button1.Text = Hour & ":" & "02" & " PM"
                    ElseIf Minute = 3 Then
                        Button1.Text = Hour & ":" & "03" & " PM"
                    ElseIf Minute = 4 Then
                        Button1.Text = Hour & ":" & "04" & " PM"
                    ElseIf Minute = 5 Then
                        Button1.Text = Hour & ":" & "05" & " PM"
                    ElseIf Minute = 6 Then
                        Button1.Text = Hour & ":" & "06" & " PM"
                    ElseIf Minute = 7 Then
                        Button1.Text = Hour & ":" & "07" & " PM"
                    ElseIf Minute = 8 Then
                        Button1.Text = Hour & ":" & "08" & " PM"
                    ElseIf Minute = 9 Then
                        Button1.Text = Hour & ":" & "09" & " PM"
                    Else
                        Button1.Text = Hour & ":" & Minute & " PM"
                    End If
                End If
            Else
                If Minute = 0 Then
                    Button1.Text = Hour24 & ":" & "00"
                ElseIf Minute = 1 Then
                    Button1.Text = Hour24 & ":" & "01"
                ElseIf Minute = 2 Then
                    Button1.Text = Hour24 & ":" & "02"
                ElseIf Minute = 3 Then
                    Button1.Text = Hour24 & ":" & "03"
                ElseIf Minute = 4 Then
                    Button1.Text = Hour24 & ":" & "04"
                ElseIf Minute = 5 Then
                    Button1.Text = Hour24 & ":" & "05"
                ElseIf Minute = 6 Then
                    Button1.Text = Hour24 & ":" & "06"
                ElseIf Minute = 7 Then
                    Button1.Text = Hour24 & ":" & "07"
                ElseIf Minute = 8 Then
                    Button1.Text = Hour24 & ":" & "08"
                ElseIf Minute = 9 Then
                    Button1.Text = Hour24 & ":" & "09"
                Else
                    Button1.Text = Hour24 & ":" & Minute
                End If
            End If
            'Button1.Font = New System.Drawing.Font("Showcard Gothic", 22)
            'Button1.Text = "Recalibrating..."
        End If
    End Sub


    Function rand(ByVal MySeed As Integer, ByVal x As Integer) As Integer
        Dim obj As New System.Random(MySeed)
        Return obj.Next(1, x)
    End Function

    Sub FilePath()
        ' Determine the Resource File Path
        If System.Diagnostics.Debugger.IsAttached() Then
            'Debugging mode
            ResourceFilePath = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        Else
            'Published mode
            ResourceFilePath = Application.StartupPath & "\resources\"
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If e.newState = 8 Then
            Button4.Text = "Play a Song"
            Label1.Visible = False
        End If
    End Sub

    Sub Song()
        Dim x As Integer
        Dim worked As Boolean

        Do Until worked = True
            Try
                FilePath()
                Dim strFileSize As String = ""
                Dim di As New IO.DirectoryInfo(ResourceFilePath)
                Dim aryFi As IO.FileInfo() = di.GetFiles("*.mp3")
                'Dim fi As IO.FileInfo
                x = rand(Now.Millisecond, aryFi.GetLength(0).ToString()) 'generate a pseudorandom number between 1 and the second parameter-1 (ex. between 1 and 10, you would put 11)

                'If SkipNumber <> x Then 'is it the same song as last time? If it isn't, play the corresponding song, otherwise restart from the beginning
                Dim s As System.Text.StringBuilder
                s = New System.Text.StringBuilder(aryFi(x).Name)
                s.Replace(".mp3", "") 'get rid of .mp3

                AxWindowsMediaPlayer1.URL = aryFi(x).FullName
                'SongTimeLeft = 60
                Label1.Text = s.ToString

                Button4.Text = "Stop"
                Label1.Visible = True

                worked = True
            Catch WMPScrewedUp As Exception 'Did WMP deside to crap out on me? Try again.
                worked = False
            End Try
        Loop
    End Sub

    Sub FormFocused() Handles Me.GotFocus, Button1.GotFocus, Button2.GotFocus, Button3.GotFocus, Button4.GotFocus
        If FormGotFocus = False Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Location = New Point(Me.Location.X - 2, Me.Location.Y - 19)
            Button2.Visible = True
            Button3.Visible = True
            Button4.Visible = True
            FormGotFocus = True
        End If
    End Sub

    Sub FormNotFocused() Handles Me.LostFocus, Button1.LostFocus, Button2.LostFocus, Button3.LostFocus, Button4.LostFocus
        If FormGotFocus = True And Button1.Focused = False And Button2.Focused = False And Button3.Focused = False And Button4.Focused = False Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Location = New Point(Me.Location.X + 2, Me.Location.Y + 19)
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            FormGotFocus = False
        End If
    End Sub

    'Sub AutoFocus() Handles Button1.MouseEnter
    '    If FormGotFocus = False And Button1.Focused = False And Button2.Focused = False And Button3.Focused = False And Button4.Focused = False Then
    '        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
    '        Me.Location = New Point(Me.Location.X - 2, Me.Location.Y - 19)
    '        Button2.Visible = True
    '        Button3.Visible = True
    '        Button4.Visible = True
    '        FormGotFocus = True
    '    End If
    'End Sub

    'Sub AutoHide() Handles Me.MouseLeave
    '    If FormGotFocus = True And Button2.Focused = False And Button3.Focused = False And Button4.Focused = False Then
    '        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    '        Me.Location = New Point(Me.Location.X + 2, Me.Location.Y + 19)
    '        Button2.Visible = False
    '        Button3.Visible = False
    '        Button4.Visible = False
    '        FormGotFocus = False
    '    End If
    'End Sub
End Class
