Imports System.IO
Imports System.Drawing
Imports System.Net
Imports Microsoft.Win32

Public Class MainWindow

    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort 'Used for the ENTER button, to manually add names to the blacklist

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try 'Checks if there are updates for the driver
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppydriverupdate.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "The latest version online, in the GitHub repository, is: " + newestversion.ToString
            If newestversion > currentversion Then
                UpdateDownload.Text = "Download update"
            Else

            End If
        Catch ex As Exception
            Dim currentversion As String = Application.ProductVersion
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "Can not check for updates. You're offline, or maybe the website is temporarily down."
        End Try
        Dim Not64Bit As String
        If Environment.Is64BitOperatingSystem Then
            Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
        Else
            Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
        End If
        Me.Text = "Keppy's MIDI Driver (Configurator) - Version 1.5, Bugfix 213"

        Try 'Checks if the list for Port A exists
            Dim PortASFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist")
            Dim reader As StreamReader = New StreamReader(New FileStream(PortASFList, FileMode.Open))
            Do While Not reader.EndOfStream
                PortABox.Items.Add(reader.ReadLine())
            Loop
            reader.Close()
        Catch ex As Exception
            MsgBox("The file " & Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist" & " can not be found, press OK to continue. (It'll be automatically created in a second)", 64, "Information")
            File.Create(Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist").Dispose()
        End Try
        
        Try 'Does the same for Port B
            Dim PortBSFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist")
            Dim reader2 As StreamReader = New StreamReader(New FileStream(PortBSFList, FileMode.Open))
            Do While Not reader2.EndOfStream
                PortBBox.Items.Add(reader2.ReadLine())
            Loop
            reader2.Close()
        Catch ex As Exception
            MsgBox("The file " & Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist" & " can not be found, press OK to continue. (It'll be automatically created in a second)", 64, "Information")
            File.Create(Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist").Dispose()
        End Try

        Try 'Again, the same as for both Port A and Port B, but for the blacklist system
            Dim BlackList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist")
            Dim reader3 As StreamReader = New StreamReader(New FileStream(Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist", FileMode.Open))
            Do While Not reader3.EndOfStream
                ProgramsBlackList.Items.Add(reader3.ReadLine())
            Loop
            reader3.Close()
        Catch ex As Exception
            Try
                ProgramsBlackList.Items.Clear()
                Dim address As String = "https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppymididrv.defaultblacklist"
                Dim client As WebClient = New WebClient()
                Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
                Do While Not reader.EndOfStream
                    ProgramsBlackList.Items.Add(reader.ReadLine())
                Loop
                reader.Close()

                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Dim Filenum As Integer = FreeFile()
                FileOpen(Filenum, BlackListText, OpenMode.Output)
                FileClose()

                Using SW As New IO.StreamWriter(BlackListText, True)
                    For Each itm As String In Me.ProgramsBlackList.Items
                        SW.WriteLine(itm)
                    Next
                End Using
            Catch exc As Exception
                ProgramsBlackList.Items.Clear()
                Dim lines() As String = IO.File.ReadAllLines(Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist")
                ProgramsBlackList.Items.AddRange(lines)

                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Dim Filenum As Integer = FreeFile()
                FileOpen(Filenum, BlackListText, OpenMode.Output)
                FileClose()

                Using SW As New IO.StreamWriter(BlackListText, True)
                    For Each itm As String In Me.ProgramsBlackList.Items
                        SW.WriteLine(itm)
                    Next
                End Using
            End Try
        End Try

        Dim osVer As Version = Environment.OSVersion.Version 'Fancy stuff to see what O.S. you're using
        If osVer.Major = 10 Then
            Versionlabel.Text = "Your current O.S. is: Windows 10 or Windows Server 2016"
        ElseIf osVer.Major = 6 And osVer.Minor = 3 Then
            Versionlabel.Text = "Your current O.S. is: Windows 8.1 or Windows Server 2012 R2"
        ElseIf osVer.Major = 6 And osVer.Minor = 2 Then
            Versionlabel.Text = "Your current O.S. is: Windows 8 or Windows Server 2012"
        ElseIf osVer.Major = 6 And osVer.Minor = 1 Then
            Versionlabel.Text = "Your current O.S. is: Windows 7 or Windows Server 2008 R2"
        ElseIf osVer.Major = 6 And osVer.Minor = 0 Then
            Versionlabel.Text = "Your current O.S. is: Windows Vista or Windows Server 2008"
        ElseIf osVer.Major = 5 And osVer.Minor = 2 Then
            Versionlabel.Text = "Your current O.S. is: Windows XP (64-bit) or Windows Server 2003"
        ElseIf osVer.Major = 5 And osVer.Minor = 1 Then
            Versionlabel.Text = "Your current O.S. is: Windows XP (32-bit)"
        ElseIf osVer.Major = 5 And osVer.Minor = 0 Then
            Versionlabel.Text = "Your current O.S. is: Windows 2000 (Really strange...)"
        ElseIf osVer.Major = 4 Then
            Versionlabel.Text = "Your current O.S. is: Wine, I guess?"
        End If

        If My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True) Is Nothing Then 'Reads values from the registry
            My.Computer.Registry.LocalMachine.CreateSubKey("SOFTWARE\Wow6432Node\Keppy's MIDI Driver\")
            Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
            keppykey.SetValue("buflen", "10", RegistryValueKind.DWord)
            keppykey.SetValue("polyphony", "1000", RegistryValueKind.DWord)
            keppykey.SetValue("preload", "1", RegistryValueKind.DWord)
            keppykey.SetValue("sampframe", "792", RegistryValueKind.DWord)
            keppykey.SetValue("nofloat", "1", RegistryValueKind.DWord)
            keppykey.SetValue("softwaremode", "0", RegistryValueKind.DWord)
            keppykey.SetValue("sinc", "1", RegistryValueKind.DWord)
            keppykey.SetValue("tracks", "128", RegistryValueKind.DWord)
            keppykey.SetValue("volume", "10000", RegistryValueKind.DWord)
            keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
            If osVer.Major >= 5 Then
                SoftwareRendering.Checked = True
                SoftwareRendering.Enabled = False
                keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
            End If
            PolyphonyLimit.Value = keppykey.GetValue("polyphony")
            bufsize.Value = keppykey.GetValue("buflen") * 10
            sampframe.Text = keppykey.GetValue("sampframe")
            TracksLimit.Value = keppykey.GetValue("tracks")
            VolumeBar.Value = keppykey.GetValue("volume")
            If keppykey.GetValue("preload") = 1 Then
                Preload.Checked = False
            Else
                Preload.Checked = False
            End If
            If keppykey.GetValue("sinc") = 1 Then
                SincInter.Checked = True
            Else
                SincInter.Checked = False
            End If
            If keppykey.GetValue("dsorxaudio") = 0 Then
                XAudioPipe.Checked = True
                DSPipe.Checked = False
            Else
                XAudioPipe.Checked = False
                DSPipe.Checked = True
            End If
            Dim VolumeValue As Integer
            Dim x As Double = VolumeBar.Value.ToString / 100
            VolumeValue = Convert.ToInt32(x)
            CurrentVolumeHUE.Text = "Volume: " + VolumeValue.ToString
        Else
            Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
            MaxCPU.Text = keppykey.GetValue("cpu")
            PolyphonyLimit.Value = keppykey.GetValue("polyphony")
            bufsize.Value = keppykey.GetValue("buflen") * 10
            sampframe.Text = keppykey.GetValue("sampframe")
            TracksLimit.Value = keppykey.GetValue("tracks")
            VolumeBar.Value = keppykey.GetValue("volume")
            If keppykey.GetValue("cpu") = "0" Then
                MaxCPU.Text = "Disabled"
            Else
                MaxCPU.Text = keppykey.GetValue("cpu")
            End If
            Frequency.Text = keppykey.GetValue("frequency")
            Dim lnumber As Double
            Dim lResult As Long
            lnumber = keppykey.GetValue("volume") / 100
            lResult = Int(lnumber)
            If keppykey.GetValue("preload") = 1 Then
                Preload.Checked = False
            Else
                Preload.Checked = False
            End If
            If keppykey.GetValue("nofx") = 1 Then
                DisableFX.Checked = True
            Else
                DisableFX.Checked = False
            End If
            If keppykey.GetValue("softwaremode") = 1 Then
                SoftwareRendering.Checked = True
            Else
                SoftwareRendering.Checked = False
            End If
            If keppykey.GetValue("nofloat") = 0 Then
                FloatingDisabled.Checked = True
            Else
                FloatingDisabled.Checked = False
            End If
            If keppykey.GetValue("noteoff") = 1 Then
                NoteOff.Checked = True
            Else
                NoteOff.Checked = False
            End If
            If keppykey.GetValue("sinc") = 1 Then
                SincInter.Checked = True
            Else
                SincInter.Checked = False
            End If
            If keppykey.GetValue("dsorxaudio") = 0 Then
                XAudioPipe.Checked = True
                DSPipe.Checked = False
            Else
                XAudioPipe.Checked = False
                DSPipe.Checked = True
            End If
            Dim VolumeValue As Integer
            Dim x As Double = VolumeBar.Value.ToString / 100
            VolumeValue = Convert.ToInt32(x)
            CurrentVolumeHUE.Text = "Volume: " + VolumeValue.ToString
            If osVer.Major > 5 Then
                SoftwareRendering.Checked = True
                SoftwareRendering.Enabled = False
                keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
            End If
        End If
    End Sub

    Private Sub RemoveSFPortA_Click(sender As Object, e As EventArgs) Handles RemoveSFPortA.Click
        PortABox.Items.Remove(PortABox.SelectedItem)
    End Sub

    Private Sub ApplyPortA_Click(sender As Object, e As EventArgs) Handles ApplyPortA.Click
        Dim BASSMIDIListA As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist"
        Dim Filenum As Integer = FreeFile()
        FileOpen(Filenum, BASSMIDIListA, OpenMode.Output)
        FileClose()

        Using SW As New IO.StreamWriter(BASSMIDIListA, True)
            For Each itm As String In Me.PortABox.Items
                SW.WriteLine(itm)
            Next
        End Using
        MsgBox("Settings applied to Port A!", 64, "Success")
    End Sub

    Private Sub ImportSFPortA_Click(sender As Object, e As EventArgs) Handles ImportSFPortA.Click
        Try
            Dim strlist As New List(Of String)
            Dim file As String
            PortAOpenDialog1.Filter = "SoundFont/SFZ Files|*.sf1;*.sf2;*.sf2pack;*.sfz|All files|*.*"
            PortAOpenDialog1.FileName = ""
            If PortAOpenDialog1.ShowDialog = DialogResult.OK Then
                For Each file In PortAOpenDialog1.FileNames
                    strlist.Add(file)
                    PortABox.Items.Add(file)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MoveUpPortA_Click(sender As Object, e As EventArgs) Handles MoveUpPortA.Click
        If PortABox.SelectedIndex > 0 Then
            Dim I = PortABox.SelectedIndex - 1
            PortABox.Items.Insert(I, PortABox.SelectedItem)
            PortABox.Items.RemoveAt(PortABox.SelectedIndex)
            PortABox.SelectedIndex = I
        End If
    End Sub

    Private Sub MoveDownPortA_Click(sender As Object, e As EventArgs) Handles MoveDownPortA.Click
        If PortABox.SelectedIndex < PortABox.Items.Count - 1 Then
            Dim I = PortABox.SelectedIndex + 2
            PortABox.Items.Insert(I, PortABox.SelectedItem)
            PortABox.Items.RemoveAt(PortABox.SelectedIndex)
            PortABox.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub ClearPortA_Click_1(sender As Object, e As EventArgs)
        PortABox.Items.Clear()
    End Sub

    Private Sub ImportSFPortB_Click(sender As Object, e As EventArgs) Handles ImportSFPortB.Click
        Try
            Dim strlist As New List(Of String)
            Dim file As String
            PortBOpenDialog1.Filter = "SoundFont/SFZ Files|*.sf1;*.sf2;*.sf2pack;*.sfz|All files|*.*"
            PortBOpenDialog1.FileName = ""
            If PortBOpenDialog1.ShowDialog = DialogResult.OK Then
                For Each file In PortBOpenDialog1.FileNames
                    strlist.Add(file)
                    PortBBox.Items.Add(file)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RemoveSFPortB_Click(sender As Object, e As EventArgs) Handles RemoveSFPortB.Click
        PortBBox.Items.Remove(PortBBox.SelectedItem)
    End Sub

    Private Sub MoveUpPortB_Click(sender As Object, e As EventArgs) Handles MoveUpPortB.Click
        If PortBBox.SelectedIndex > 0 Then
            Dim I = PortBBox.SelectedIndex - 1
            PortBBox.Items.Insert(I, PortBBox.SelectedItem)
            PortBBox.Items.RemoveAt(PortBBox.SelectedIndex)
            PortBBox.SelectedIndex = I
        End If
    End Sub

    Private Sub MoveDownPortB_Click(sender As Object, e As EventArgs) Handles MoveDownPortB.Click
        If PortBBox.SelectedIndex < PortBBox.Items.Count - 1 Then
            Dim I = PortBBox.SelectedIndex + 2
            PortBBox.Items.Insert(I, PortBBox.SelectedItem)
            PortBBox.Items.RemoveAt(PortBBox.SelectedIndex)
            PortBBox.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub ClearPortB_Click(sender As Object, e As EventArgs) Handles ClearPortB.Click
        PortBBox.Items.Clear()
        MsgBox("List cleared!", 64, "Success")
    End Sub

    Private Sub ApplyPortB_Click(sender As Object, e As EventArgs) Handles ApplyPortB.Click
        Dim BASSMIDIListB As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist"
        Dim Filenum As Integer = FreeFile()
        FileOpen(Filenum, BASSMIDIListB, OpenMode.Output)
        FileClose()

        Using SW As New IO.StreamWriter(BASSMIDIListB, True)
            For Each itm As String In Me.PortBBox.Items
                SW.WriteLine(itm)
            Next
        End Using
        MsgBox("Settings applied to Port B!", 64, "Success")
    End Sub

    Private Sub VolumeBar_Scroll(sender As Object, e As EventArgs)
        Dim lnumber As Double
        Dim lResult As Long
        Dim myTB As System.Windows.Forms.TrackBar
        myTB = sender
        lnumber = myTB.Value.ToString() / 100
        lResult = Int(lnumber)
    End Sub

    Private Sub AdvancedApply_Click(sender As Object, e As EventArgs) Handles AdvancedApply.Click
        Dim Not64Bit As String
        If Environment.Is64BitOperatingSystem Then
            Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
        Else
            Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
        End If
        Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
        keppykey.SetValue("polyphony", PolyphonyLimit.Value.ToString, RegistryValueKind.DWord)
        keppykey.SetValue("buflen", "0", RegistryValueKind.DWord)
        If NoteOff.Checked Then
            keppykey.SetValue("noteoff", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("noteoff", "0", RegistryValueKind.DWord)
        End If
        If FloatingDisabled.Checked Then
            keppykey.SetValue("nofloat", "0", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("nofloat", "1", RegistryValueKind.DWord)
        End If
        If SoftwareRendering.Checked Then
            keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("softwaremode", "0", RegistryValueKind.DWord)
        End If
        If Preload.Checked Then
            keppykey.SetValue("preload", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
        End If
        If DisableFX.Checked Then
            keppykey.SetValue("nofx", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("nofx", "0", RegistryValueKind.DWord)
        End If
        If SincInter.Checked Then
            keppykey.SetValue("sinc", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("sinc", "0", RegistryValueKind.DWord)
        End If
        If XAudioPipe.Checked = True Then
            keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
        ElseIf DSPipe.Checked = True Then
            keppykey.SetValue("dsorxaudio", "1", RegistryValueKind.DWord)
        End If
        If MaxCPU.Text = "Disabled" Then
            keppykey.SetValue("cpu", "0", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("cpu", MaxCPU.Text, RegistryValueKind.DWord)
        End If
        keppykey.SetValue("buflen", bufsize.Value.ToString / 10, RegistryValueKind.DWord)
        keppykey.SetValue("frequency", Frequency.Text, RegistryValueKind.DWord)
        keppykey.SetValue("sampframe", sampframe.Text, RegistryValueKind.DWord)
        keppykey.SetValue("tracks", TracksLimit.Value.ToString, RegistryValueKind.DWord)
        keppykey.SetValue("volume", VolumeBar.Value.ToString, RegistryValueKind.DWord)
        Dim uoh As Integer
        uoh = Int(bufsize.Value.ToString / 10)
        If uoh < 5 Then
            MsgBox("You're setting the buffer size to a value that is less than 50! Expect some stuttering and break-ups during playback!" & vbCrLf & vbCrLf & "Settings saved!", 48, "Warning!")
        Else
            MsgBox("Settings saved!", 64, "Success")
        End If
    End Sub

    Private Sub ClearPortA_Click(sender As Object, e As EventArgs) Handles ClearPortA.Click
        PortABox.Items.Clear()
        MsgBox("List cleared!", 64, "Success")
    End Sub


    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles PolyphonyLimit.ValueChanged

    End Sub

    Private Sub AdvancedReset_Click(sender As Object, e As EventArgs) Handles AdvancedReset.Click
        Dim Not64Bit As String
        If Environment.Is64BitOperatingSystem Then
            Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
        Else
            Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
        End If
        PolyphonyLimit.Value = "512"
        bufsize.Value = 100
        VolumeBar.Value = 10000
        MaxCPU.Text = "85"
        Preload.Checked = False
        SincInter.Checked = True
        DisableFX.Checked = False
        SoftwareRendering.Checked = False
        FloatingDisabled.Checked = False
        Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
        If NoteOff.Checked Then
            keppykey.SetValue("noteoff", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("noteoff", "0", RegistryValueKind.DWord)
        End If
        If FloatingDisabled.Checked Then
            keppykey.SetValue("nofloat", "0", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("nofloat", "1", RegistryValueKind.DWord)
        End If
        If SoftwareRendering.Checked Then
            keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("softwaremode", "0", RegistryValueKind.DWord)
        End If
        If Preload.Checked Then
            keppykey.SetValue("preload", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
        End If
        If SincInter.Checked Then
            keppykey.SetValue("sinc", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("sinc", "0", RegistryValueKind.DWord)
        End If
        If DisableFX.Checked Then
            keppykey.SetValue("nofx", "1", RegistryValueKind.DWord)
        Else
            keppykey.SetValue("nofx", "0", RegistryValueKind.DWord)
        End If
        keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
        keppykey.SetValue("polyphony", PolyphonyLimit.Value.ToString, RegistryValueKind.DWord)
        keppykey.SetValue("cpu", "85", RegistryValueKind.DWord)
        keppykey.SetValue("buflen", "10", RegistryValueKind.DWord)
        keppykey.SetValue("frequency", "44100", RegistryValueKind.DWord)
        keppykey.SetValue("sampframe", "792", RegistryValueKind.DWord)
        keppykey.SetValue("tracks", "128", RegistryValueKind.DWord)
        keppykey.SetValue("volume", "10000", RegistryValueKind.DWord)
        Dim VolumeValue As Integer
        Dim x As Double = VolumeBar.Value.ToString / 100
        VolumeValue = Convert.ToInt32(x)
        CurrentVolumeHUE.Text = "Volume: " + VolumeValue.ToString
        If keppykey.GetValue("dsorxaudio") = 1 Then
            XAudioPipe.Checked = True
            DSPipe.Checked = False
        Else
            XAudioPipe.Checked = False
            DSPipe.Checked = True
        End If
        MsgBox("Settings saved!", 64, "Success")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AboutProg.ShowDialog()
    End Sub

    Private Sub UpdateDownload_Click(sender As Object, e As EventArgs) Handles UpdateDownload.Click
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppydriverupdate.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "The latest version online, in the GitHub repository, is: " + newestversion.ToString
            If newestversion > currentversion Then
                MsgBox("New update found, press OK to open the release page.", 48, "New update found!")
                Process.Start("http://goo.gl/BHgazb")
            Else
                MsgBox("This release is already updated.", 64, "No updates found.")
            End If
        Catch ex As Exception
            Dim currentversion As String = Application.ProductVersion
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "Can not check for updates. You're offline, or maybe the website is temporarily down."
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Changelog.ShowDialog()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles VolumeBar.Scroll
        Dim VolumeValue As Integer
        Dim x As Double = VolumeBar.Value.ToString / 100
        VolumeValue = Convert.ToInt32(x)
        CurrentVolumeHUE.Text = "Volume: " + VolumeValue.ToString
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox(My.Resources.WhyFunctionsDisabled.ToString, 48, "Why is software rendering enabled by default?")
    End Sub

    Private Sub AddBlackList_Click(sender As Object, e As EventArgs) Handles AddBlackList.Click
        If BlackListAdvancedMode.Checked = True Then
            ProgramsBlackList.Items.Add(ManualBlackList.Text)

            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()

            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using
            ProgramsBlackList.TopIndex = ProgramsBlackList.Items.Count - 1
        Else
            Try
                Dim strlist As New List(Of String)
                Dim file As String
                BlackListFileDialog.Filter = "Executables|*.exe|All files|*.*"
                If BlackListFileDialog.ShowDialog = DialogResult.OK Then
                    For Each file In BlackListFileDialog.FileNames
                        Dim FileNameOnly As String
                        FileNameOnly = System.IO.Path.GetFileName(file)
                        strlist.Add(FileNameOnly)
                        ProgramsBlackList.Items.Add(FileNameOnly)
                    Next
                End If
            Catch ex As Exception
            End Try
            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()

            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using
            ProgramsBlackList.TopIndex = ProgramsBlackList.Items.Count - 1
        End If

    End Sub

    Private Sub RemoveBlackList_Click(sender As Object, e As EventArgs) Handles RemoveBlackList.Click
        Dim lst As New List(Of Object)
        For Each a As Object In ProgramsBlackList.SelectedItems
            lst.Add(a)
        Next
        For Each a As Object In lst
            ProgramsBlackList.Items.Remove(a)
        Next
        Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
        Dim Filenum As Integer = FreeFile()
        FileOpen(Filenum, BlackListText, OpenMode.Output)
        FileClose()

        Using SW As New IO.StreamWriter(BlackListText, True)
            For Each itm As String In Me.ProgramsBlackList.Items
                SW.WriteLine(itm)
            Next
        End Using
    End Sub

    Private Sub RestoreDefaultBlackList_Click(sender As Object, e As EventArgs) Handles RestoreDefaultBlackList.Click
        Try
            ProgramsBlackList.Items.Clear()
            Dim address As String = "https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppymididrv.defaultblacklist"
            Dim client As WebClient = New WebClient()
            Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
            Do While Not reader.EndOfStream
                ProgramsBlackList.Items.Add(reader.ReadLine())
            Loop
            reader.Close()

            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()
            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using

            MsgBox("The list has been restored with the default values stored in the online blacklist database.", 64, "Success")
        Catch exc As Exception
            ProgramsBlackList.Items.Clear()
            Dim lines() As String = IO.File.ReadAllLines(Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist")
            ProgramsBlackList.Items.AddRange(lines)

            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()
            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using

            MsgBox("The online blacklist database seems to be offline." & vbCrLf & vbCrLf & "The list has been restored with the default values stored in:" & vbCrLf & Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist", 64, "Success")
        End Try
    End Sub

    Private Sub BlackListAdvancedMode_CheckedChanged(sender As Object, e As EventArgs) Handles BlackListAdvancedMode.CheckedChanged
        If BlackListAdvancedMode.Checked = True Then
            Label12.Text = "Type the name of the program in the textbox, and confirm by pressing the ''Enter'' key."
            AddBlackList.Text = "Add executable"
            ManualBlackListLabel.Enabled = True
            ManualBlackListLabel.Visible = True
            ManualBlackList.Enabled = True
            ManualBlackList.Visible = True
        Else
            Label12.Text = "Select a program by clicking ''Add executable(s)''."
            AddBlackList.Text = "Add executable(s)"
            ManualBlackListLabel.Enabled = False
            ManualBlackListLabel.Visible = False
            ManualBlackList.Enabled = False
            ManualBlackList.Visible = False
        End If
    End Sub

    Private Sub ManualBlackList_KeyDown(sender As Object, e As EventArgs) Handles ManualBlackList.KeyDown
        If GetAsyncKeyState(Keys.Enter) Then
            ProgramsBlackList.Items.Add(ManualBlackList.Text)

            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()

            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using
            ProgramsBlackList.TopIndex = ProgramsBlackList.Items.Count - 1
        End If
    End Sub
End Class
