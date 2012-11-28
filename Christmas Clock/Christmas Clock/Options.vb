Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x, y As Color
        x = Color.FromArgb(Form1.Button1.BackColor.ToArgb)
        y = Color.FromArgb(Form1.Button1.ForeColor.ToArgb)
        ColorDialog1.Color = x
        ColorDialog2.Color = y
        PictureBox1.BackColor = x
        PictureBox2.BackColor = y
        CheckBox1.Checked = Form1.TopMost
        CheckPresets()
        If Form1.TwelveHourClock = True Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
        If Form1.SaveLocation = True Then
            CheckBox5.Checked = True
        ElseIf Form1.SaveLocation = False Then
            CheckBox5.Checked = False
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        PictureBox1.BackColor = ColorDialog1.Color
        PictureBox1.ImageLocation = ""
        CheckPresets()
        Button5.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ColorDialog2.ShowDialog()
        PictureBox2.BackColor = ColorDialog2.Color
        PictureBox2.ImageLocation = ""
        CheckPresets()
        Button5.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Save()
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Save()
        Button5.Enabled = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button6.Text = "Recalibrating..."

        Form1.Second = My.Computer.Clock.LocalTime.Second.ToString
        Form1.Minute = My.Computer.Clock.LocalTime.Minute.ToString
        Form1.Hour24 = My.Computer.Clock.LocalTime.Hour.ToString
        If Form1.TwelveHourClock = True Then
            If Form1.Hour24 = 12 Then
                Form1.Hour = 12
                Form1.AM = False
            ElseIf Form1.Hour24 = 13 Then
                Form1.Hour = 1
                Form1.AM = False
            ElseIf Form1.Hour24 = 14 Then
                Form1.Hour = 2
                Form1.AM = False
            ElseIf Form1.Hour24 = 15 Then
                Form1.Hour = 3
                Form1.AM = False
            ElseIf Form1.Hour24 = 16 Then
                Form1.Hour = 4
                Form1.AM = False
            ElseIf Form1.Hour24 = 17 Then
                Form1.Hour = 5
                Form1.AM = False
            ElseIf Form1.Hour24 = 18 Then
                Form1.Hour = 6
                Form1.AM = False
            ElseIf Form1.Hour24 = 19 Then
                Form1.Hour = 7
                Form1.AM = False
            ElseIf Form1.Hour24 = 20 Then
                Form1.Hour = 8
                Form1.AM = False
            ElseIf Form1.Hour24 = 21 Then
                Form1.Hour = 9
                Form1.AM = False
            ElseIf Form1.Hour24 = 22 Then
                Form1.Hour = 10
                Form1.AM = False
            ElseIf Form1.Hour24 = 23 Then
                Form1.Hour = 11
                Form1.AM = False
            ElseIf Form1.Hour24 = 24 Then
                Form1.Hour = 12
                Form1.AM = True
            ElseIf Form1.Hour24 < 12 Then
                Form1.Hour = Form1.Hour24
                Form1.AM = True
            ElseIf Form1.Hour24 = 25 Then
                Form1.Hour = 1
                Form1.AM = True
            End If
        Else
            Form1.Hour = Form1.Hour24
        End If
        If Form1.TwelveHourClock = True Then
            If Form1.AM = True Then
                If Form1.Minute = 0 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "00" & " AM"
                ElseIf Form1.Minute = 1 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "01" & " AM"
                ElseIf Form1.Minute = 2 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "02" & " AM"
                ElseIf Form1.Minute = 3 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "03" & " AM"
                ElseIf Form1.Minute = 4 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "04" & " AM"
                ElseIf Form1.Minute = 5 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "05" & " AM"
                ElseIf Form1.Minute = 6 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "06" & " AM"
                ElseIf Form1.Minute = 7 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "07" & " AM"
                ElseIf Form1.Minute = 8 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "08" & " AM"
                ElseIf Form1.Minute = 9 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "09" & " AM"
                Else
                    Form1.Button1.Text = Form1.Hour & ":" & Form1.Minute & " AM"
                End If
            Else
                If Form1.Minute = 0 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "00" & " PM"
                ElseIf Form1.Minute = 1 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "01" & " PM"
                ElseIf Form1.Minute = 2 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "02" & " PM"
                ElseIf Form1.Minute = 3 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "03" & " PM"
                ElseIf Form1.Minute = 4 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "04" & " PM"
                ElseIf Form1.Minute = 5 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "05" & " PM"
                ElseIf Form1.Minute = 6 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "06" & " PM"
                ElseIf Form1.Minute = 7 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "07" & " PM"
                ElseIf Form1.Minute = 8 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "08" & " PM"
                ElseIf Form1.Minute = 9 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "09" & " PM"
                Else
                    Form1.Button1.Text = Form1.Hour & ":" & Form1.Minute & " PM"
                End If
            End If
        Else
            If Form1.Minute = 0 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "00"
            ElseIf Form1.Minute = 1 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "01"
            ElseIf Form1.Minute = 2 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "02"
            ElseIf Form1.Minute = 3 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "03"
            ElseIf Form1.Minute = 4 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "04"
            ElseIf Form1.Minute = 5 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "05"
            ElseIf Form1.Minute = 6 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "06"
            ElseIf Form1.Minute = 7 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "07"
            ElseIf Form1.Minute = 8 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "08"
            ElseIf Form1.Minute = 9 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "09"
            Else
                Form1.Button1.Text = Form1.Hour24 & ":" & Form1.Minute
            End If
        End If

        'Form1.Button1.Font = New System.Drawing.Font("Showcard Gothic", 18)
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Dim x As Color
            x = System.Drawing.Color.FromArgb(-1)
            ColorDialog1.Color = x
            PictureBox1.BackColor = x
            x = System.Drawing.Color.FromArgb(-16777216)
            ColorDialog2.Color = x
            PictureBox2.BackColor = x
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        End If
        Button5.Enabled = True
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Dim x As Color
            x = System.Drawing.Color.FromArgb(-16760832)
            ColorDialog1.Color = x
            PictureBox1.BackColor = x
            x = System.Drawing.Color.FromArgb(-65536)
            ColorDialog2.Color = x
            PictureBox2.BackColor = x
            CheckBox4.Checked = False
            CheckBox2.Checked = False
        End If
        Button5.Enabled = True
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Dim x As Color
            x = System.Drawing.Color.FromArgb(-65408)
            ColorDialog1.Color = x
            PictureBox1.BackColor = x
            x = System.Drawing.Color.FromArgb(-32513)
            ColorDialog2.Color = x
            PictureBox2.BackColor = x
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
        Button5.Enabled = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim a, b As Color
        a = ColorDialog1.Color
        b = ColorDialog2.Color
        ColorDialog1.Color = b
        ColorDialog2.Color = a
        PictureBox1.BackColor = b
        PictureBox2.BackColor = a
        CheckPresets()
        Button5.Enabled = True
    End Sub


    Sub Save()
        Form1.Button1.BackColor = ColorDialog1.Color
        Form1.Button1.FlatAppearance.BorderColor = ColorDialog1.Color
        Form1.Button1.FlatAppearance.MouseOverBackColor = ColorDialog1.Color
        Form1.Button1.FlatAppearance.MouseDownBackColor = ColorDialog1.Color
        Form1.PictureBox1.BackColor = ColorDialog1.Color
        Form1.Label1.BackColor = ColorDialog1.Color
        Form1.Button1.ForeColor = ColorDialog2.Color
        Form1.Button2.ForeColor = ColorDialog2.Color
        Form1.Button3.ForeColor = ColorDialog2.Color
        Form1.Button4.ForeColor = ColorDialog2.Color
        Form1.Label1.ForeColor = ColorDialog2.Color
        If CheckBox1.Checked = True Then
            Form1.TopMost = True
        Else
            Form1.TopMost = False
        End If
        If CheckBox5.Checked = True Then
            Form1.SaveLocation = True
        ElseIf CheckBox5.Checked = False Then
            Form1.SaveLocation = False
        End If
        If RadioButton1.Checked = True Then
            Form1.TwelveHourClock = True
            If Form1.Hour24 = 12 Then
                Form1.Hour = 12
                Form1.AM = False
            ElseIf Form1.Hour24 = 13 Then
                Form1.Hour = 1
                Form1.AM = False
            ElseIf Form1.Hour24 = 14 Then
                Form1.Hour = 2
                Form1.AM = False
            ElseIf Form1.Hour24 = 15 Then
                Form1.Hour = 3
                Form1.AM = False
            ElseIf Form1.Hour24 = 16 Then
                Form1.Hour = 4
                Form1.AM = False
            ElseIf Form1.Hour24 = 17 Then
                Form1.Hour = 5
                Form1.AM = False
            ElseIf Form1.Hour24 = 18 Then
                Form1.Hour = 6
                Form1.AM = False
            ElseIf Form1.Hour24 = 19 Then
                Form1.Hour = 7
                Form1.AM = False
            ElseIf Form1.Hour24 = 20 Then
                Form1.Hour = 8
                Form1.AM = False
            ElseIf Form1.Hour24 = 21 Then
                Form1.Hour = 9
                Form1.AM = False
            ElseIf Form1.Hour24 = 22 Then
                Form1.Hour = 10
                Form1.AM = False
            ElseIf Form1.Hour24 = 23 Then
                Form1.Hour = 11
                Form1.AM = False
            ElseIf Form1.Hour24 = 0 Then
                Form1.Hour = 12
                Form1.AM = True
            ElseIf Form1.Hour24 < 12 Then
                Form1.Hour = Form1.Hour24
                Form1.AM = True
            ElseIf Form1.Hour24 = 25 Then
                Form1.Hour = 1
                Form1.AM = True
            End If
            If Form1.AM = True Then
                If Form1.Minute = 0 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "00" & " AM"
                ElseIf Form1.Minute = 1 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "01" & " AM"
                ElseIf Form1.Minute = 2 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "02" & " AM"
                ElseIf Form1.Minute = 3 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "03" & " AM"
                ElseIf Form1.Minute = 4 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "04" & " AM"
                ElseIf Form1.Minute = 5 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "05" & " AM"
                ElseIf Form1.Minute = 6 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "06" & " AM"
                ElseIf Form1.Minute = 7 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "07" & " AM"
                ElseIf Form1.Minute = 8 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "08" & " AM"
                ElseIf Form1.Minute = 9 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "09" & " AM"
                Else
                    Form1.Button1.Text = Form1.Hour & ":" & Form1.Minute & " AM"
                End If
            Else
                If Form1.Minute = 0 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "00" & " PM"
                ElseIf Form1.Minute = 1 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "01" & " PM"
                ElseIf Form1.Minute = 2 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "02" & " PM"
                ElseIf Form1.Minute = 3 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "03" & " PM"
                ElseIf Form1.Minute = 4 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "04" & " PM"
                ElseIf Form1.Minute = 5 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "05" & " PM"
                ElseIf Form1.Minute = 6 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "06" & " PM"
                ElseIf Form1.Minute = 7 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "07" & " PM"
                ElseIf Form1.Minute = 8 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "08" & " PM"
                ElseIf Form1.Minute = 9 Then
                    Form1.Button1.Text = Form1.Hour & ":" & "09" & " PM"
                Else
                    Form1.Button1.Text = Form1.Hour & ":" & Form1.Minute & " PM"
                End If
            End If
        Else
            Form1.TwelveHourClock = False
            If Form1.Minute = 0 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "00"
            ElseIf Form1.Minute = 1 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "01"
            ElseIf Form1.Minute = 2 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "02"
            ElseIf Form1.Minute = 3 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "03"
            ElseIf Form1.Minute = 4 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "04"
            ElseIf Form1.Minute = 5 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "05"
            ElseIf Form1.Minute = 6 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "06"
            ElseIf Form1.Minute = 7 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "07"
            ElseIf Form1.Minute = 8 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "08"
            ElseIf Form1.Minute = 9 Then
                Form1.Button1.Text = Form1.Hour24 & ":" & "09"
            Else
                Form1.Button1.Text = Form1.Hour24 & ":" & Form1.Minute
            End If
        End If
    End Sub

    Sub CheckPresets()
        If ColorDialog1.Color = System.Drawing.Color.FromArgb(-1) And ColorDialog2.Color = System.Drawing.Color.FromArgb(-16777216) Then
            CheckBox2.Checked = True
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        ElseIf ColorDialog1.Color = System.Drawing.Color.FromArgb(-16760832) And ColorDialog2.Color = System.Drawing.Color.FromArgb(-65536) Then
            CheckBox3.Checked = True
            CheckBox2.Checked = False
            CheckBox4.Checked = False
        ElseIf ColorDialog1.Color = System.Drawing.Color.FromArgb(-65408) And ColorDialog2.Color = System.Drawing.Color.FromArgb(-32513) Then
            CheckBox4.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        Else
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox5.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button5.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button5.Enabled = True
    End Sub
End Class