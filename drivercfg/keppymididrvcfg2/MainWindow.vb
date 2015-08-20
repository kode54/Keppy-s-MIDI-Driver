Imports System.IO
Imports System.Drawing
Imports System.Net
Imports Microsoft.Win32
Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Module CustomFont

    Private _pfc As PrivateFontCollection = Nothing

    Public ReadOnly Property GetInstance(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            If _pfc Is Nothing Then LoadFont()
            Return New Font(_pfc.Families(0), Size, style)
        End Get
    End Property

    Private Sub LoadFont()
        Try
            _pfc = New PrivateFontCollection
            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(My.Resources.kepsdigital.Length)
            Marshal.Copy(My.Resources.kepsdigital, 0, fontMemPointer, My.Resources.kepsdigital.Length)
            _pfc.AddMemoryFont(fontMemPointer, My.Resources.kepsdigital.Length)
            Marshal.FreeCoTaskMem(fontMemPointer)
        Catch ex As Exception
            MsgBox("Fatal error while loading custom font. Press OK to quit.")
            Application.Exit()
        End Try
    End Sub

End Module

Public Class MainWindow

    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort 'Used for the ENTER button, to manually add names to the blacklist

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Tabs.TabPages.Remove(TabPage5)

        Dim strStartupArguments() As String, intCount As Integer
        Dim currentversion As String = Application.ProductVersion
        strStartupArguments = System.Environment.GetCommandLineArgs
        For intCount = 0 To UBound(strStartupArguments)
            Select Case strStartupArguments(intCount).ToLower
                Case "-debug"
                    MsgBox("You're currently in debug mode.")
                    Win32.AllocConsole()
                    Console.BackgroundColor = ConsoleColor.Black
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Title = "Keppy's MIDI Driver (Configurator) - Debug Window"
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Keppy's MIDI Driver (Configurator)")
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Version number: " + currentversion)
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Debug started.")
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "-----------------------------------------------------")
                Case "-secret"
                    FancyClock.Font = CustomFont.GetInstance(96, FontStyle.Italic)
                    FancyClockTimer.Start()
                    Me.Tabs.TabPages.Add(TabPage5)
                Case "-min"
                    Me.Hide()
                    SystemTrayicon.Visible = True
                    ShowInTaskbar = False
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Application started hidden.")
            End Select
        Next intCount

        If My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).GetValue(Application.ProductName) Is Nothing Then
            AutomaticStartup.Checked = False
        Else
            AutomaticStartup.Checked = True
        End If

        CurrentVolumeHUE.Font = CustomFont.GetInstance(48, FontStyle.Italic) 'The fancy font for the volume label! :3

        Dim osVer As Version = Environment.OSVersion.Version 'Fancy stuff to see what O.S. you're using
        Dim osName As String = Environment.ProcessorCount.ToString
        If osVer.Major = 10 Then
            Versionlabel.Text = "Your current O.S. is: Windows 10 or Windows Server 2016"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows 10/Windows Server 2016")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 6 And osVer.Minor = 3 Then
            Versionlabel.Text = "Your current O.S. is: Windows 8.1 or Windows Server 2012 R2"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows 8.1/Windows Server 2012 R2")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 6 And osVer.Minor = 2 Then
            Versionlabel.Text = "Your current O.S. is: Windows 8 or Windows Server 2012"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows 8.0/Windows Server 2012")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 6 And osVer.Minor = 1 Then
            Versionlabel.Text = "Your current O.S. is: Windows 7 or Windows Server 2008 R2"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows 7/Windows Server 2008 R2")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 6 And osVer.Minor = 0 Then
            Versionlabel.Text = "Your current O.S. is: Windows Vista or Windows Server 2008"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows Vista/Windows Server 2008")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 5 And osVer.Minor = 2 Then
            Versionlabel.Text = "Your current O.S. is: Windows XP (64-bit) or Windows Server 2003"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows XP x64/Windows Server 2003")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 5 And osVer.Minor = 1 Then
            Versionlabel.Text = "Your current O.S. is: Windows XP (32-bit)"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows XP")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        ElseIf osVer.Major = 5 And osVer.Minor = 0 Then
            Versionlabel.Text = "Your current O.S. is: Windows 2000"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Windows 2000")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        Else
            Versionlabel.Text = "Your current O.S. is: Unknown"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. version: Unknown")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Current O.S. build number: " + osVer.ToString)
        End If

        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Number of physical cores: " + osName)
        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "-----------------------------------------------------")

        Try 'Checks if there are updates for the driver
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppydriverupdate.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "The latest version online, in the GitHub repository, is: " + newestversion.ToString
            If newestversion > currentversion Then
                UpdateDownload.Text = "Download update"
            Else

            End If
        Catch ex As Exception
            ThisVersionDriver.Text = "The current version of the driver, installed on your system, is: " + currentversion.ToString
            LatestVersionDriver.Text = "Can not check for updates. You're offline, or maybe the website is temporarily down."
        End Try
        Dim Not64Bit As String
        If Environment.Is64BitOperatingSystem Then
            Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
        Else
            Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
        End If

        Try 'Checks if the list for Port A exists
            Dim PortASFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist")
            Dim reader As StreamReader = New StreamReader(New FileStream(PortASFList, FileMode.Open))
            Do While Not reader.EndOfStream
                PortABox.Items.Add(reader.ReadLine())
            Loop
            reader.Close()
        Catch ex As Exception
            Dim PortASFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist")
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not read " + "''" + PortASFList + "''!")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Trying to create file...")
            Try
                File.Create(Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist").Dispose()
            Catch exc As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not create file!")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
        End Try

        Try 'Does the same for Port B
            Dim PortBSFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist")
            Dim reader2 As StreamReader = New StreamReader(New FileStream(PortBSFList, FileMode.Open))
            Do While Not reader2.EndOfStream
                PortBBox.Items.Add(reader2.ReadLine())
            Loop
            reader2.Close()
        Catch ex As Exception
            Dim PortBSFList As String = (Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist")
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not read " + "''" + PortBSFList + "''!")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Trying to create file...")
            Try
                File.Create(Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist").Dispose()
            Catch exc As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not create file!")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
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
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "The blacklist doesn't exist. Reading blacklist database from GitHub...")
                ProgramsBlackList.Items.Clear()
                Dim address As String = "https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppymididrv.defaultblacklist"
                Dim client As WebClient = New WebClient()
                Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
                Do While Not reader.EndOfStream
                    ProgramsBlackList.Items.Add(reader.ReadLine())
                Loop
                reader.Close()
                Try
                    Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, BlackListText, OpenMode.Output)
                    FileClose()

                    Using SW As New IO.StreamWriter(BlackListText, True)
                        For Each itm As String In Me.ProgramsBlackList.Items
                            SW.WriteLine(itm)
                        Next
                    End Using
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist saved to: " + BlackListText)
                Catch exc As Exception
                    Console.ForegroundColor = ConsoleColor.Red
                    Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                    Console.ForegroundColor = ConsoleColor.Green
                End Try
            Catch exc As Exception
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not read the online blacklist database. Retrying with the local one...")
                ProgramsBlackList.Items.Clear()
                Dim lines() As String = IO.File.ReadAllLines(Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist")
                ProgramsBlackList.Items.AddRange(lines)
                Try
                    Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                    Dim Filenum As Integer = FreeFile()
                    FileOpen(Filenum, BlackListText, OpenMode.Output)
                    FileClose()

                    Using SW As New IO.StreamWriter(BlackListText, True)
                        For Each itm As String In Me.ProgramsBlackList.Items
                            SW.WriteLine(itm)
                        Next
                    End Using
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist saved to: " + BlackListText)
                Catch excs As Exception
                    Console.ForegroundColor = ConsoleColor.Red
                    Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                    Console.ForegroundColor = ConsoleColor.Green
                End Try
            End Try
        End Try

        Try
            If My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True) Is Nothing Then 'Reads values from the registry
                If Environment.Is64BitOperatingSystem Then
                    Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
                Else
                    Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
                End If
                bufsize.Value = 100
                VolumeBar.Value = 10000
                PolyphonyLimit.Value = 512
                TracksLimit.Value = 128
                MaxCPU.Text = "85"
                sampframe.Text = "792"
                Frequency.Text = "44100"
                Preload.Checked = False
                SincInter.Checked = True
                DisableFX.Checked = False
                SoftwareRendering.Checked = False
                FloatingDisabled.Checked = False
                XAudioPipe.Checked = True
                NoteOff.Checked = False
                FloatingDisabled.Checked = False
                SoftwareRendering.Checked = True
                Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
                keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
                keppykey.SetValue("noteoff", "0", RegistryValueKind.DWord)
                keppykey.SetValue("polyphony", "512", RegistryValueKind.DWord)
                keppykey.SetValue("cpu", "85", RegistryValueKind.DWord)
                keppykey.SetValue("nofloat", "1", RegistryValueKind.DWord)
                keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
                keppykey.SetValue("nofx", "0", RegistryValueKind.DWord)
                keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
                keppykey.SetValue("buflen", "10", RegistryValueKind.DWord)
<<<<<<< HEAD
                keppykey.SetValue("frequency", "44100", RegistryValueKind.DWord)
=======
                keppykey.SetValue("polyphony", "1000", RegistryValueKind.DWord)
                keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
>>>>>>> origin/master
                keppykey.SetValue("sampframe", "792", RegistryValueKind.DWord)
                keppykey.SetValue("tracks", "128", RegistryValueKind.DWord)
                keppykey.SetValue("sinc", "0", RegistryValueKind.DWord)
                keppykey.SetValue("volume", "10000", RegistryValueKind.DWord)
<<<<<<< HEAD
=======
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
                    Preload.Checked = True
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
>>>>>>> origin/master
                Dim VolumeValue As Integer
                Dim x As Double = VolumeBar.Value.ToString / 100
                VolumeValue = Convert.ToInt32(x)
                CurrentVolumeHUE.Text = VolumeValue.ToString
                MsgBox("Settings saved!", 64, "Success")
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
                    Preload.Checked = True
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
                CurrentVolumeHUE.Text = VolumeValue.ToString
                If osVer.Major > 5 Then
                    SoftwareRendering.Checked = True
                    SoftwareRendering.Enabled = False
                    keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
                End If
            End If
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not read from the registry!")
            Console.Clear()
            Console.WriteLine("FATAL ERROR DURING THE EXECUTION OF THIS PROGRAM.")
            Console.WriteLine("")
            Console.WriteLine("Error: Unable to read from registry")
            MsgBox("Can not read from the registry! The application is useless in this way!" & vbCrLf & vbCrLf & "Press OK to quit.", 16, "Fatal error")
            Application.Exit()
        End Try
    End Sub

    ' Soundfont list part starts here!

    Private Sub ApplyPortA_Click(sender As Object, e As EventArgs) Handles ApplyPortA.Click
        Dim BASSMIDIListA As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist"
        Try
            Dim Filenum As Integer = FreeFile()
            FileOpen(Filenum, BASSMIDIListA, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BASSMIDIListA, True)
                For Each itm As String In Me.PortABox.Items
                    SW.WriteLine(itm)
                Next
                For Each itemdebug As String In Me.PortABox.Items
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Saving item to port A list: " + itemdebug.ToString)
                Next
            End Using
            MsgBox("Settings applied to Port A!", 64, "Success")
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymidi.sflist"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BASSMIDIListA)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
            MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BASSMIDIListA, 16, "Fatal error")
            Console.ForegroundColor = ConsoleColor.Green
        End Try
    End Sub

    Private Sub ApplyPortB_Click(sender As Object, e As EventArgs) Handles ApplyPortB.Click
        Dim BASSMIDIListB As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymidib.sflist"
        Try
            Dim Filenum As Integer = FreeFile()
            FileOpen(Filenum, BASSMIDIListB, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BASSMIDIListB, True)
                For Each itm As String In Me.PortBBox.Items
                    SW.WriteLine(itm)
                Next
                For Each itemdebug As String In Me.PortBBox.Items
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Saving item to port A list: " + itemdebug.ToString)
                Next
            End Using
            MsgBox("Settings applied to Port B!", 64, "Success")
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BASSMIDIListB)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
            MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BASSMIDIListB, 16, "Fatal error")
            Console.ForegroundColor = ConsoleColor.Green
        End Try
    End Sub

    Private Sub ImportSFPortA_Click(sender As Object, e As EventArgs) Handles ImportSFPortA.Click
        Try
            Dim strlist As New List(Of String)
            If DisableCheckPortA.Checked = True Then
                PortAOpenDialog1.Filter = "All files (*.*)|*.*"
            Else
                PortAOpenDialog1.Filter = "SoundFont/SFZ Files (*.sf2, *.sfpack, *.sfz)|*.sf1;*.sf2;*.sf2pack;*.sfz"
            End If
            PortAOpenDialog1.FileName = ""
            If PortAOpenDialog1.ShowDialog = DialogResult.OK Then
                Dim fileName As String = PortAOpenDialog1.FileName
                Dim extension As String
                extension = Path.GetExtension(fileName)
                If extension.ToString = ".sfz" Then
                    Dim bank As String
                    Dim preset As String
                    bank = InputBox("Enter the number of the bank. (From 0 to 127)", "Select a bank")
                    preset = InputBox("Enter the number of the preset. (From 0 to 127)", "Select a preset")
                    If CheckForAlphaCharacters(bank) And CheckForAlphaCharacters(preset) Then
                        PortABox.Items.Add("p0,0=0,0|" + PortAOpenDialog1.FileName)
                    ElseIf bank.Length = 0 And preset.Length = 0 Then
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Empty values for both bank and preset.")
                        PortABox.Items.Add("p0,0=0,0|" + PortAOpenDialog1.FileName)
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,0=0,0|" + PortAOpenDialog1.FileName)
                    Else
                        If bank > 128 Then
                            If preset > 127 Then
                                PortABox.Items.Add("p127,127=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127,127=0,0|" + PortAOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortABox.Items.Add("p127,0=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127,0=0,0|" + PortAOpenDialog1.FileName)
                            Else
                                PortABox.Items.Add("p127," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                            End If
                        ElseIf bank < 0 Then
                            If preset > 127 Then
                                PortABox.Items.Add("p0,127=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,127=0,0|" + PortAOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortABox.Items.Add("p0,0=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,0=0,0|" + PortAOpenDialog1.FileName)
                            Else
                                PortABox.Items.Add("p0," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                            End If
                        Else
                            If preset > 127 Then
                                PortABox.Items.Add("p" + bank + ",127=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + ",127=0,0|" + PortAOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortABox.Items.Add("p" + bank + ",0=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + ",0=0,0|" + PortAOpenDialog1.FileName)
                            Else
                                PortABox.Items.Add("p" + bank + "," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + "," + preset + "=0,0|" + PortAOpenDialog1.FileName)
                            End If
                        End If
                    End If
                ElseIf extension.ToString = ".sf2" Or extension.ToString = ".sfpack" Or extension.ToString = ".SF2" Or extension.ToString = ".SFPACK" Then
                    PortABox.Items.Add(PortAOpenDialog1.FileName)
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortAOpenDialog1.FileName)
                Else
                    If DisableCheckPortA.Checked = True Then
                        PortABox.Items.Add(PortAOpenDialog1.FileName)
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port A:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortAOpenDialog1.FileName)
                    Else
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not add this soundfont:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortAOpenDialog1.FileName)
                        MsgBox("Invalid soundfont! BASSMIDI only supports SFZ, SF2 and SFPACK files!" & vbCrLf & vbCrLf & "(To add these invalid soundfonts, check ''Disable file extension check''.)", 16, "Error while importing file")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImportSFPortB_Click(sender As Object, e As EventArgs) Handles ImportSFPortB.Click
        Try
            Dim strlist As New List(Of String)
            If DisableCheckPortB.Checked = True Then
                PortBOpenDialog1.Filter = "All files (*.*)|*.*"
            Else
                PortBOpenDialog1.Filter = "SoundFont/SFZ Files (*.sf2, *.sfpack, *.sfz)|*.sf1;*.sf2;*.sf2pack;*.sfz"
            End If
            PortBOpenDialog1.FileName = ""
            If PortBOpenDialog1.ShowDialog = DialogResult.OK Then
                Dim fileName As String = PortBOpenDialog1.FileName
                Dim extension As String
                extension = Path.GetExtension(fileName)
                If extension.ToString = ".sfz" Then
                    Dim bank As String
                    Dim preset As String
                    bank = InputBox("Enter the number of the bank. (From 0 to 127)", "Select a bank")
                    preset = InputBox("Enter the number of the preset. (From 0 to 127)", "Select a preset")
                    If CheckForAlphaCharacters(bank) And CheckForAlphaCharacters(preset) Then
                        PortBBox.Items.Add("p0,0=0,0|" + PortBOpenDialog1.FileName)
                    ElseIf bank.Length = 0 And preset.Length = 0 Then
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Empty values for both bank and preset.")
                        PortBBox.Items.Add("p0,0=0,0|" + PortBOpenDialog1.FileName)
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,0=0,0|" + PortBOpenDialog1.FileName)
                    Else
                        If bank > 128 Then
                            If preset > 127 Then
                                PortBBox.Items.Add("p127,127=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127,127=0,0|" + PortBOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortBBox.Items.Add("p127,0=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127,0=0,0|" + PortBOpenDialog1.FileName)
                            Else
                                PortBBox.Items.Add("p127," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p127," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                            End If
                        ElseIf bank < 0 Then
                            If preset > 127 Then
                                PortBBox.Items.Add("p0,127=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,127=0,0|" + PortBOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortBBox.Items.Add("p0,0=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0,0=0,0|" + PortBOpenDialog1.FileName)
                            Else
                                PortBBox.Items.Add("p0," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p0," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                            End If
                        Else
                            If preset > 127 Then
                                PortBBox.Items.Add("p" + bank + ",127=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + ",127=0,0|" + PortBOpenDialog1.FileName)
                            ElseIf preset < 0 Then
                                PortBBox.Items.Add("p" + bank + ",0=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + ",0=0,0|" + PortBOpenDialog1.FileName)
                            Else
                                PortBBox.Items.Add("p" + bank + "," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "p" + bank + "," + preset + "=0,0|" + PortBOpenDialog1.FileName)
                            End If
                        End If
                    End If
                ElseIf extension.ToString = ".sf2" Or extension.ToString = ".sfpack" Or extension.ToString = ".SF2" Or extension.ToString = ".SFPACK" Then
                    PortBBox.Items.Add(PortBOpenDialog1.FileName)
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                    Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortBOpenDialog1.FileName)
                Else
                    If DisableCheckPortB.Checked = True Then
                        PortBBox.Items.Add(PortBOpenDialog1.FileName)
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added soundfont to port B:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortBOpenDialog1.FileName)
                    Else
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not add this soundfont:")
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortBOpenDialog1.FileName)
                        MsgBox("Invalid soundfont! BASSMIDI only supports SFZ, SF2 and SFPACK files!" & vbCrLf & vbCrLf & "(To add these invalid soundfonts, check ''Disable file extension check''.)", 16, "Error while importing file")
                    End If
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Ew")
        End Try
    End Sub

    Private Sub MoveUpPortA_Click(sender As Object, e As EventArgs) Handles MoveUpPortA.Click
        If PortABox.SelectedIndex > 0 Then
            Dim I = PortABox.SelectedIndex - 1
            PortABox.Items.Insert(I, PortABox.SelectedItem)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Moved soundfont up in port A:")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortABox.SelectedItem.ToString)
            PortABox.Items.RemoveAt(PortABox.SelectedIndex)
            PortABox.SelectedIndex = I
        End If
    End Sub

    Private Sub MoveDownPortA_Click(sender As Object, e As EventArgs) Handles MoveDownPortA.Click
        If PortABox.SelectedIndex < PortABox.Items.Count - 1 Then
            Dim I = PortABox.SelectedIndex + 2
            PortABox.Items.Insert(I, PortABox.SelectedItem)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Moved soundfont down in port A:")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortABox.SelectedItem.ToString)
            PortABox.Items.RemoveAt(PortABox.SelectedIndex)
            PortABox.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub MoveUpPortB_Click(sender As Object, e As EventArgs) Handles MoveUpPortB.Click
        If PortBBox.SelectedIndex > 0 Then
            Dim I = PortBBox.SelectedIndex - 1
            PortBBox.Items.Insert(I, PortBBox.SelectedItem)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Moved soundfont up in port B:")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortBBox.SelectedItem.ToString)
            PortBBox.Items.RemoveAt(PortBBox.SelectedIndex)
            PortBBox.SelectedIndex = I
        End If
    End Sub

    Private Sub MoveDownPortB_Click(sender As Object, e As EventArgs) Handles MoveDownPortB.Click
        If PortBBox.SelectedIndex < PortBBox.Items.Count - 1 Then
            Dim I = PortBBox.SelectedIndex + 2
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Moved soundfont down in port B:")
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + PortBBox.SelectedItem.ToString)
            PortBBox.Items.Insert(I, PortBBox.SelectedItem)
            PortBBox.Items.RemoveAt(PortBBox.SelectedIndex)
            PortBBox.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub ClearPortA_Click(sender As Object, e As EventArgs) Handles ClearPortA.Click
        PortABox.Items.Clear()
        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Port A's listbox cleared.")
        MsgBox("List cleared!", 64, "Success")
    End Sub

    Private Sub ClearPortB_Click(sender As Object, e As EventArgs) Handles ClearPortB.Click
        PortBBox.Items.Clear()
        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Port B's listbox cleared.")
        MsgBox("List cleared!", 64, "Success")
    End Sub

    Private Sub RemoveSFPortA_Click(sender As Object, e As EventArgs) Handles RemoveSFPortA.Click
        Try
            Dim RemovedItem As String = PortABox.SelectedItem
            PortABox.Items.Remove(PortABox.SelectedItem)
            If RemovedItem.Length = 0 Then
                ' Cake
            Else
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Soundfont removed from port A:")
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + RemovedItem)
            End If
        Catch ex As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Select a soundfont to remove first!")
        End Try
        
    End Sub

    Private Sub RemoveSFPortB_Click(sender As Object, e As EventArgs) Handles RemoveSFPortB.Click
        Try
            Dim RemovedItem As String = PortBBox.SelectedItem
            PortBBox.Items.Remove(PortBBox.SelectedItem)
            If RemovedItem.Length = 0 Then
                ' Cake
            Else
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Soundfont removed from port B:")
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + RemovedItem)
            End If
        Catch ex As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Select a soundfont to remove first!")
        End Try
    End Sub

    ' Soundfont list part is over!

    Private Sub AdvancedApply_Click(sender As Object, e As EventArgs) Handles AdvancedApply.Click
        Try
            Dim Not64Bit As String
            If Environment.Is64BitOperatingSystem Then
                Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
            Else
                Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
            End If
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

            ' This is commented because the driver itself doesn't support this option yet.

            'If Preload.Checked Then
            '   keppykey.SetValue("preload", "1", RegistryValueKind.DWord)
            'Else
            '   keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
            'End If

            ' This is commented because the driver itself doesn't support this option yet.

            If DisableFX.Checked Then
                keppykey.SetValue("nofx", "1", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Audio effects enabled.")
            Else
                keppykey.SetValue("nofx", "0", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Audio effects disabled.")
            End If
            If SincInter.Checked Then
                keppykey.SetValue("sinc", "1", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Sinc enabled.")
            Else
                keppykey.SetValue("sinc", "0", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Sinc disabled.")
            End If
            If XAudioPipe.Checked = True Then
                keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Audio pipe set to XAudio.")
            ElseIf DSPipe.Checked = True Then
                keppykey.SetValue("dsorxaudio", "1", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Audio pipe set to DirectSound.")
            End If
            If MaxCPU.Text = "Disabled" Then
                keppykey.SetValue("cpu", "0", RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Max rendering time percentage: Disabled")
            Else
                keppykey.SetValue("cpu", MaxCPU.Text, RegistryValueKind.DWord)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Max rendering time percentage: " + MaxCPU.Text + "%")
            End If
            keppykey.SetValue("polyphony", PolyphonyLimit.Value.ToString, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Voice limit set to " + PolyphonyLimit.Value.ToString + ".")
            keppykey.SetValue("buflen", bufsize.Value.ToString / 10, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "New buffer length: " + bufsize.Value.ToString + "ms.")
            keppykey.SetValue("frequency", Frequency.Text, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Frequency set to " + Frequency.Text + "Hz.")
            keppykey.SetValue("sampframe", sampframe.Text, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Samples per frame set to " + sampframe.Text + ".")
            keppykey.SetValue("tracks", TracksLimit.Value.ToString, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "MIDI tracks limited to " + TracksLimit.Value.ToString + ".")
            keppykey.SetValue("volume", VolumeBar.Value.ToString, RegistryValueKind.DWord)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Volume set to " + VolumeBar.Value.ToString + ".")
            Dim uoh As Integer
            uoh = Int(bufsize.Value.ToString / 10)
            If uoh < 5 Then
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Settings saved. (Buffer length warning)")
                MsgBox("You're setting the buffer length to a value that is less than 50! Expect some stuttering and break-ups during playback!" & vbCrLf & vbCrLf & "Settings saved!", 48, "Warning!")
            Else
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Settings saved.")
                MsgBox("Settings saved!", 64, "Success")
            End If
        Catch ex As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while writing to the registry.")
        End Try
    End Sub

    Private Sub AdvancedReset_Click(sender As Object, e As EventArgs) Handles AdvancedReset.Click
        Try
            Dim Not64Bit As String
            If Environment.Is64BitOperatingSystem Then
                Not64Bit = "SOFTWARE\Wow6432Node\Keppy's MIDI Driver"
            Else
                Not64Bit = "SOFTWARE\Keppy's MIDI Driver"
            End If
            bufsize.Value = 100
            VolumeBar.Value = 10000
            PolyphonyLimit.Value = 512
            TracksLimit.Value = 128
            MaxCPU.Text = "85"
            sampframe.Text = "792"
            Frequency.Text = "44100"
            Preload.Checked = False
            SincInter.Checked = False
            DisableFX.Checked = False
            SoftwareRendering.Checked = False
            FloatingDisabled.Checked = False
            XAudioPipe.Checked = True
            NoteOff.Checked = False
            FloatingDisabled.Checked = False
            SoftwareRendering.Checked = True
            Dim keppykey = My.Computer.Registry.LocalMachine.OpenSubKey(Not64Bit, True)
            keppykey.SetValue("dsorxaudio", "0", RegistryValueKind.DWord)
            keppykey.SetValue("noteoff", "0", RegistryValueKind.DWord)
            keppykey.SetValue("polyphony", "512", RegistryValueKind.DWord)
            keppykey.SetValue("cpu", "85", RegistryValueKind.DWord)
            keppykey.SetValue("nofloat", "1", RegistryValueKind.DWord)
            keppykey.SetValue("softwaremode", "1", RegistryValueKind.DWord)
            keppykey.SetValue("nofx", "0", RegistryValueKind.DWord)
            keppykey.SetValue("preload", "0", RegistryValueKind.DWord)
            keppykey.SetValue("buflen", "10", RegistryValueKind.DWord)
            keppykey.SetValue("frequency", "44100", RegistryValueKind.DWord)
            keppykey.SetValue("sampframe", "792", RegistryValueKind.DWord)
            keppykey.SetValue("tracks", "128", RegistryValueKind.DWord)
            keppykey.SetValue("sinc", "0", RegistryValueKind.DWord)
            keppykey.SetValue("volume", "10000", RegistryValueKind.DWord)
            Dim VolumeValue As Integer
            Dim x As Double = VolumeBar.Value.ToString / 100
            VolumeValue = Convert.ToInt32(x)
            CurrentVolumeHUE.Text = VolumeValue.ToString
            MsgBox("Settings saved!", 64, "Success")
        Catch ex As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while writing to the registry.")
        End Try
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
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Update found!")
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "New version: " + newestversion)
                MsgBox("New update found, press OK to open the release page.", 48, "New update found!")
                Process.Start("http://goo.gl/BHgazb")
            Else
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "No updates found.")
                MsgBox("This release is already updated.", 64, "No updates found.")
            End If
        Catch ex As Exception
            Dim currentversion As String = Application.ProductVersion
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not check for updates!")
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
        CurrentVolumeHUE.Text = VolumeValue.ToString
        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Changed volume to: " + VolumeBar.Value.ToString)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox(My.Resources.WhyFunctionsDisabled.ToString, 48, "Why is software rendering enabled by default?")
    End Sub

    Private Sub AddBlackList_Click(sender As Object, e As EventArgs) Handles AddBlackList.Click
        If BlackListAdvancedMode.Checked = True Then
            ProgramsBlackList.Items.Add(ManualBlackList.Text)
            Try
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
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added program to the blacklist (Manual mode): " + ManualBlackList.Text)
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BlackListText, 16, "Fatal error")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
        Else
            Try
                Dim strlist As New List(Of String)
                Dim file As String
                BlackListFileDialog.Filter = "Executables|*.exe|All files|*.*"
                If BlackListFileDialog.ShowDialog = DialogResult.OK Then
                    For Each file In BlackListFileDialog.FileNames
                        Dim FileNameOnly As String
                        FileNameOnly = System.IO.Path.GetFileName(file)
                        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added program to the blacklist: " + FileNameOnly)
                        strlist.Add(FileNameOnly)
                        ProgramsBlackList.Items.Add(FileNameOnly)
                    Next
                End If
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Dim Filenum As Integer = FreeFile()

                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Saving blacklist to: " + BlackListText)

                FileOpen(Filenum, BlackListText, OpenMode.Output)
                FileClose()

                Using SW As New IO.StreamWriter(BlackListText, True)
                    For Each itm As String In Me.ProgramsBlackList.Items
                        SW.WriteLine(itm)
                    Next
                End Using
                ProgramsBlackList.TopIndex = ProgramsBlackList.Items.Count - 1
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist saved.")
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BlackListText, 16, "Fatal error")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
        End If

    End Sub

    Private Sub RemoveBlackList_Click(sender As Object, e As EventArgs) Handles RemoveBlackList.Click
        Dim lst As New List(Of Object)
        For Each a As Object In ProgramsBlackList.SelectedItems
            lst.Add(a)
        Next
        For Each a As Object In lst
            ProgramsBlackList.Items.Remove(a)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Removed program from the blacklist: " + a.ToString)
        Next
        Try
            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()

            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Saving blacklist to file: " + BlackListText)

            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
            MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BlackListText, 16, "Fatal error")
            Console.ForegroundColor = ConsoleColor.Green
        End Try
    End Sub

    Private Sub RestoreDefaultBlackList_Click(sender As Object, e As EventArgs) Handles RestoreDefaultBlackList.Click
        Dim address As String = "https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppymididrv.defaultblacklist"
        Try
            ProgramsBlackList.Items.Clear()
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist cleared")
            Dim client As WebClient = New WebClient()
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Connecting to online database...")
            Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
            Dim readerdebug As StreamReader = New StreamReader(client.OpenRead(address))
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Reading online database...")
            Do While Not reader.EndOfStream
                ProgramsBlackList.Items.Add(reader.ReadLine())
            Loop
            Do While Not readerdebug.EndOfStream
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Stream from online database: " + readerdebug.ReadLine())
            Loop
            reader.Close()
            readerdebug.Close()

            Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
            Dim Filenum As Integer = FreeFile()
            FileOpen(Filenum, BlackListText, OpenMode.Output)
            FileClose()

            Using SW As New IO.StreamWriter(BlackListText, True)
                For Each itm As String In Me.ProgramsBlackList.Items
                    SW.WriteLine(itm)
                Next
            End Using
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist restored.")
            MsgBox("The list has been restored with the default values stored in the online blacklist database.", 64, "Success")
        Catch exc As Exception
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not connect to online database! Switching to local one...")
            Dim lines() As String = IO.File.ReadAllLines(Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist")
            ProgramsBlackList.Items.AddRange(lines)
            Try
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Dim Filenum As Integer = FreeFile()
                FileOpen(Filenum, BlackListText, OpenMode.Output)
                FileClose()

                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Saving blacklist to file: " + BlackListText)

                Using SW As New IO.StreamWriter(BlackListText, True)
                    For Each itm As String In Me.ProgramsBlackList.Items
                        SW.WriteLine(itm)
                    Next
                End Using
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Can not read online file: " + address)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Blacklist restored.")
                MsgBox("The online blacklist database seems to be offline." & vbCrLf & vbCrLf & "The list has been restored with the default values stored in:" & vbCrLf & Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.defaultblacklist", 64, "Success")
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BlackListText, 16, "Fatal error")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
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
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Manual blacklist mode enabled.")
        Else
            Label12.Text = "Select a program by clicking ''Add executable(s)''."
            AddBlackList.Text = "Add executable(s)"
            ManualBlackListLabel.Enabled = False
            ManualBlackListLabel.Visible = False
            ManualBlackList.Enabled = False
            ManualBlackList.Visible = False
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Manual blacklist mode disabled.")
        End If
    End Sub

    Private Sub ManualBlackList_KeyDown(sender As Object, e As EventArgs) Handles ManualBlackList.KeyDown
        If GetAsyncKeyState(Keys.Enter) Then
            ProgramsBlackList.Items.Add(ManualBlackList.Text)
            Try
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
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Added program to the blacklist (Manual mode): " + ManualBlackList.Text)
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Dim BlackListText As String = Environment.GetEnvironmentVariable("WINDIR") + "\keppymididrv.blacklist"
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Error while saving blacklist file: " + BlackListText)
                Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Is the file accessible by the user/locked by SYSTEM?")
                MsgBox("There was an error while saving the file!" & vbCrLf & vbCrLf & "You do not have sufficient privilege to save the file in the current location:" & vbCrLf & BlackListText, 16, "Fatal error")
                Console.ForegroundColor = ConsoleColor.Green
            End Try
        End If
    End Sub

    Private Sub DisableCheckPortA_CheckedChanged(sender As Object, e As EventArgs) Handles DisableCheckPortA.CheckedChanged
        If DisableCheckPortA.Checked = True Then
            DisableCheckPortB.Checked = True
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "File extension check for Port A/Port B has been enabled.")
        Else
            DisableCheckPortB.Checked = False
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "File extension check for Port A/Port B has been disabled.")
        End If
    End Sub

    Private Sub DisableCheckPortB_CheckedChanged(sender As Object, e As EventArgs) Handles DisableCheckPortB.CheckedChanged
        If DisableCheckPortB.Checked = True Then
            DisableCheckPortA.Checked = True
        Else
            DisableCheckPortA.Checked = False
        End If
    End Sub

    Private Sub FancyClockTimer_Tick(sender As Object, e As EventArgs) Handles FancyClockTimer.Tick
        FancyClock.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            SystemTrayicon.Visible = True
            ShowInTaskbar = False
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Application hidden.")
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SystemTrayicon.DoubleClick
        Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        SystemTrayicon.Visible = False
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(Format(Now, "[hh:mm:ss]") + " " + "Application restored.")
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ShowMainWindow.Click
        Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        SystemTrayicon.Visible = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AboutDriverWindow.Click
        AboutProg.ShowDialog()
        AboutProg.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CloseApp.Click
        Application.Exit()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles AutomaticStartup.CheckedChanged
        If AutomaticStartup.Checked = True Then
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath + " -min")
        Else
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
        End If
    End Sub
End Class

Public Class Win32
    <DllImport("kernel32.dll")> Public Shared Function AllocConsole() As Boolean
    End Function
    <DllImport("kernel32.dll")> Public Shared Function FreeConsole() As Boolean
    End Function
End Class
