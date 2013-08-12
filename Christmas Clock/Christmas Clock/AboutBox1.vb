Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description & vbCrLf & vbCrLf & vbCrLf & "Special thanks to incompetech.com for the ""Dance of the Sugar Plum Fairies"", 15th Dimension for ""Frost"" and ""Winter Breeze"", and garritan.com for the rest of the songs." & vbCrLf & vbCrLf & "Merry Christmas!" & vbCrLf & vbCrLf & "You can contact me at epicwolverine@me.com if you hve questions, comments, bug reports, or anything else on your mind." & vbCrLf & "Please do not distribute without my permission." & vbCrLf & vbCrLf & vbCrLf & "Change Log:" & vbCrLf & "Version 3.0 (12/23/2012)" & vbCrLf & "• NEW: Added many new songs and removed most of the old ones" & vbCrLf & "• NEW: Songs are no longer hard-coded into the program, but rather simply picks a random .mp3 file from the Resources folder. This means that you can now add and remove songs to your likeing, as long as they are MP3s." & vbCrLf & "• Fixed: window retaining the window border on startup" & vbCrLf & vbCrLf & "Version 2.0.1.1 (2.0) (12/24/2011)" & vbCrLf & "• NEW: added the ability to stop a playing song (the Play a Song button changes to the Stop button)" & vbCrLf & "• NEW: added Dock to Corner button" & vbCrLf & "• NEW: everything but the time will be hidden when the window loses focus" & vbCrLf & "• NEW: added the option to open the program in the same location it was in when it closed" & vbCrLf & "• NEW: added songs ""Frost"" and ""Winter Breeze"" by 15th Dimension, bringing the number of songs to 10" & vbCrLf & "• NEW: added the name of the song playing" & vbCrLf & "• Fixed: Apply button is disabled when nothing has changed" & vbCrLf & "• Fixed: got rid of the black border around the textbox that displays the time that appears after the window loses focus when that control was the last item to have focus in the window" & vbCrLf & "• Fixed (I think): Windows Media Player being stupid (re-runs the code)" & vbCrLf & "• Removed: main window doesn't show up in the taskbar" & vbCrLf & "• Misc: moved On Top option to the Options window" & vbCrLf & "• Misc: reorganized the Options window" & vbCrLf & vbCrLf & "Version 1.2 (12/19/2010)" & vbCrLf & "• NEW: added clock recalibrate button" & vbCrLf & "• Fixed: fixed a bug preventing the clock from automatically recalibrating" & vbCrLf & vbCrLf & "Version 1.1 (12/14/2010)" & vbCrLf & "• NEW: smaller, better design" & vbCrLf & "• NEW: will not play the same song twice in a row" & vbCrLf & "• NEW: added the option of switching between 12 and 24 hour clocks" & vbCrLf & "• NEW: added the ""Play a Song"" button so you can play a random song anytime" & vbCrLf & "• NEW: added color presets so you can easily switch to some common color combinations" & vbCrLf & "• Fixed: a bug regarding the clock displaying AM when it should display PM when the clock increments an hour" & vbCrLf & vbCrLf & "Version 1.0 (12/4/2010)" & vbCrLf & "• Initial release"
        'Me.TextBoxDescription.Text = 
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
