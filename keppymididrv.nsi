!include "x64.nsh"
!include MUI2.nsh
!include WinVer.nsh

; The name of the installer
Name "Keppy's MIDI Driver"

!ifdef INNER
  !echo "Inner invocation"
  OutFile "$%temp%\tempinstaller.exe"
  SetCompress off
!else
  !echo "Outer invocation"

  !system "$\"${NSISDIR}\makensis$\" /DINNER keppymididrv.nsi" = 0
  
  !system "$%TEMP%\tempinstaller.exe" = 2

  ; The file to write
  OutFile "keppymididrv.exe"

  ; Request application privileges for Windows Vista
  RequestExecutionLevel admin
!endif

;--------------------------------
; Pages
!insertmacro MUI_PAGE_WELCOME
Page Custom LockedListShow
!insertmacro MUI_PAGE_INSTFILES
UninstPage Custom un.LockedListShow
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_LANGUAGE "English"

!macro DeleteOnReboot Path
  IfFileExists `${Path}` 0 +3
    SetFileAttributes `${Path}` NORMAL
    Delete /rebootok `${Path}`
!macroend
!define DeleteOnReboot `!insertmacro DeleteOnReboot`

Function LockedListShow
  !insertmacro MUI_HEADER_TEXT `Let's see if something's blocking the DLLs...` `Is something blocking keppymididrv.dll? Hello?`
  ${If} ${RunningX64}
	LockedList::AddModule \keppymididrv.dll
  ${EndIf}
  LockedList::AddModule \keppymididrv.dll
  LockedList::Dialog /autonext 
  Pop $R0
FunctionEnd

Function un.LockedListShow
  !insertmacro MUI_HEADER_TEXT `Let's see if something's blocking the DLLs...` `Is something blocking keppymididrv.dll? Hello?`
  ${If} ${RunningX64}
	LockedList::AddModule \keppymididrv.dll
  ${EndIf}
  LockedList::AddModule \keppymididrv.dll
  LockedList::Dialog /autonext 
  Pop $R0
FunctionEnd

;--------------------------------
Function .onInit

!ifdef INNER
  WriteUninstaller "$%TEMP%\keppymididrvuninstall.exe"
  Quit
!endif

ReadRegStr $R0 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "UninstallString"
  StrCmp $R0 "" done
  MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
  "You need to uninstall the previous version before installing the new one. $\n$\nClick `OK` to remove it \
  or `Cancel` to cancel this upgrade. $\n$\n''Start Windows in safe mode, to avoid permissions problems!''" \
  IDOK uninst
  Abort
;Run the uninstaller
uninst:
  ClearErrors
  Exec $R0
  Abort
done:
   MessageBox MB_YESNO "This will install the Keppy's MIDI Driver. Continue?" IDYES NoAbort
     Abort ; causes installer to quit.
   NoAbort:
 FunctionEnd
; The stuff to install
Section "Needed (required)"
  SectionIn RO
  ; Copy files according to whether its x64 or not.
   DetailPrint "Copying driver and synth..."
   ${If} ${RunningX64}
   SetOutPath "$WINDIR\SysWow64\keppymididrv"
   File output\bass.dll 
   File output\bassflac.dll
   File output\basswv.dll
   File output\bassopus.dll   
   File output\bass_mpc.dll 
   File output\bassmidi.dll 
   File output\keppymididrvcfg.exe
   File output\keppymididrv.dll
   File output\sfpacker.exe
!ifndef INNER
   File $%TEMP%\keppymididrvuninstall.exe
!endif
   SetOutPath "$WINDIR\SysNative\keppymididrv"
   File output\64\bass.dll
   File output\64\bassflac.dll
   File output\64\basswv.dll
   File output\64\bassopus.dll
   File output\64\bass_mpc.dll
   File output\64\bassmidi.dll
   File output\64\keppymididrv.dll
   SetOutPath "$WINDIR"
   File output\keppymididrv.defaultblacklist
   ;check if already installed
   StrCpy  $1 "0"
LOOP1:
  ;k not installed, do checks
  IntOp $1 $1 + 1
  ClearErrors
  ReadRegStr $0  HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1"
  StrCmp $0 "" INSTALLDRIVER NEXTCHECK
  NEXTCHECK:
  StrCmp $0 "wdmaud.drv" 0  NEXT1
INSTALLDRIVER:
  WriteRegStr HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1" "keppymididrv\keppymididrv.dll"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDI" "midi$1"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDIDRV" "$0"
  Goto REGDONE32
NEXT1:
  StrCmp $1 "9" 0 LOOP1
  ; check if 64 is installed
REGDONE32:
  SetRegView 64
  StrCpy  $1 "0"
LOOP2:
  ;k not installed, do checks
  IntOp $1 $1 + 1
  ClearErrors
  ReadRegStr $0  HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1"
  StrCmp $0 "" INSTALLDRIVER2 NEXTCHECK2
  NEXTCHECK2:
  StrCmp $0 "wdmaud.drv" 0  NEXT2 
INSTALLDRIVER2:
  WriteRegStr HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1" "keppymididrv\keppymididrv.dll"
  SetRegView 32
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDI64" "midi$1"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDIDRV64" "$0"
  Goto REGDONE
NEXT2:
  StrCmp $1 "9" 0 LOOP2
   ${Else}
   SetOutPath "$WINDIR\System32\keppymididrv"
   File output\bass.dll 
   File output\bassflac.dll
   File output\basswv.dll
   File output\bassopus.dll   
   File output\bass_mpc.dll 
   File output\bassmidi.dll 
   File output\keppymididrv.dll 
   File output\keppymididrvcfg.exe
   File output\sfpacker.exe
!ifndef INNER
   File $%TEMP%\keppymididrvuninstall.exe
!endif
   SetOutPath "$WINDIR"
   File output\keppymididrv.defaultblacklist
   ;check if already installed
   StrCpy  $1 "0"

LOOP3:
  ;k not installed, do checks
  IntOp $1 $1 + 1
  ClearErrors
  ReadRegStr $0  HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1"
  StrCmp $0 "" INSTALLDRIVER3 NEXTCHECK3
  NEXTCHECK3:
  StrCmp $0 "wdmaud.drv" 0  NEXT3
INSTALLDRIVER3:
  WriteRegStr HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "midi$1" "keppymididrv\keppymididrv.dll"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDI" "midi$1"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDIDRV" "$0"
  Goto REGDONE
NEXT3:
  StrCmp $1 "9" 0 LOOP3
   ${EndIf}
REGDONE:
  ; Write the uninstall keys
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "DisplayName" "Keppy's MIDI Driver 1.5 (Bugfix 220)"
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "NoRepair" 1
  WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "volume" "10000"
  CreateDirectory "$SMPROGRAMS\Keppy's MIDI Driver"
 ${If} ${RunningX64}
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "UninstallString" '"$WINDIR\SysWow64\keppymididrv\keppymididrvuninstall.exe"'
   WriteRegStr HKLM "Software\Keppy's MIDI Driver" "path" "$WINDIR\SysWow64\keppymididrv"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "buflen" "10"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "preload" "1"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "cpu" "100"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "nofloat" "1"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "volume" "10000"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "dsorxaudio" "0"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "tracks" "128"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "polyphony" "512"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "frequency" "44100"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "sampframe" "792"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "buflen" "10"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "preload" "1"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "cpu" "0"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "nofloat" "1"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "volume" "10000"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "dsorxaudio" "0"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "polyphony" "512"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "tracks" "128"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "frequency" "44100"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "sampframe" "792"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "UninstallString" '"$WINDIR\SysWow64\keppymididrv\keppymididrvuninstall.exe"'
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Uninstall.lnk" "$WINDIR\SysWow64\keppymididrv\keppymididrvuninstall.exe" "" "$WINDIR\SysWow64\keppymididrv\keppymididrvuninstall.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\SoundFont Packer.lnk" "$WINDIR\SysWow64\keppymididrv\sfpacker.exe" "" "$WINDIR\SysWow64\sfpacker.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Configure Keppy's MIDI Driver.lnk" "$WINDIR\SysWow64\keppymididrv\keppymididrvcfg.exe" "" "$WINDIR\SysWow64\keppymididrv\keppymididrvcfg.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Configure Keppy's MIDI Driver (Debug mode).lnk" "$WINDIR\SysWow64\keppymididrv\keppymididrvcfg.exe" "-debug" "$WINDIR\SysWow64\keppymididrv\keppymididrvcfg.exe" 0
   ${Else}
   WriteRegStr HKLM "Software\Keppy's MIDI Driver" "path" "$WINDIR\System32\keppymididrv"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "buflen" "10"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "preload" "1"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "cpu" "100"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "nofloat" "1"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "volume" "10000"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "dsorxaudio" "0"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "tracks" "128"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "polyphony" "512"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "frequency" "44100"
   WriteRegDWORD HKLM "Software\Keppy's MIDI Driver" "sampframe" "792"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "buflen" "10"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "preload" "1"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "cpu" "0"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "nofloat" "1"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "volume" "10000"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "dsorxaudio" "0"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "polyphony" "512"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "tracks" "128"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "frequency" "44100"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "polyphony" "512"
   WriteRegDWORD HKLM "Software\Wow6432Node\Keppy's MIDI Driver" "sampframe" "792"
   WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver" "UninstallString" '"$WINDIR\System32\keppymididrv\keppymididrvuninstall.exe"'
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Uninstall.lnk" "$WINDIR\System32\keppymididrv\keppymididrvuninstall.exe" "" "$WINDIR\System32\keppymididrv\keppymididrvuninstall.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\SoundFont Packer.lnk" "$WINDIR\System32\keppymididrv\sfpacker.exe" "" "$WINDIR\System32\sfpacker.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Configure Keppy's MIDI Driver.lnk" "$WINDIR\System32\keppymididrv\keppymididrvcfg.exe" "" "$WINDIR\System32\keppymididrv\keppymididrvcfg.exe" 0
   CreateShortCut "$SMPROGRAMS\Keppy's MIDI Driver\Configure Keppy's MIDI Driver (Debug mode).lnk" "$WINDIR\System32\keppymididrv\keppymididrvcfg.exe" "-debug" "$WINDIR\System32\keppymididrv\keppymididrvcfg.exe" 0
   ${EndIf}
   MessageBox MB_OK "Installation complete! Use the driver configuration tool which is in the 'Keppy's MIDI Driver' program shortcut directory to configure the driver."
   
SectionEnd
;--------------------------------

; Uninstaller

!ifdef INNER
Section "Uninstall"
   ; Remove registry keys
    ReadRegStr $0 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
       "MIDI"
  ReadRegStr $1 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDIDRV"
  WriteRegStr HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "$0" "$1"
 ${If} ${RunningX64}
     ReadRegStr $0 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
       "MIDI64"
  ReadRegStr $1 HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver\Backup" \
      "MIDIDRV64"
  SetRegView 64
  WriteRegStr HKLM "Software\Microsoft\Windows NT\CurrentVersion\Drivers32" "$0" "$1"
  SetRegView 32
${EndIf}
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Keppy's MIDI Driver"
  DeleteRegKey HKLM "Software\Keppy's MIDI Driver"
  RMDir /r "$SMPROGRAMS\Keppy's MIDI Driver"
 ${If} ${RunningX64}
 ${If} ${AtLeastWinVista}
  RMDir /r  "$WINDIR\SysWow64\keppymididrv"
  RMDir /r  "$WINDIR\SysNative\keppymididrv"
  ${DeleteOnReboot} $WINDIR\keppymidi.sflist
  ${DeleteOnReboot} $WINDIR\keppymidib.sflist
  ${DeleteOnReboot} $WINDIR\keppymididrv.defaultblacklist
  ${DeleteOnReboot} $WINDIR\keppymididrv.blacklist
${Else}
  MessageBox MB_OK "Note: The uninstaller will reboot your system to remove drivers."
  ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\bass.dll
  ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\bassmidi.dll
  ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\keppymididrv.dll
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\bass_mpc.dll 
  ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\keppymididrvuninstall.exe
  ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\keppymididrvcfg.exe
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\bassflac.dll
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\basswv.dll
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\blacklist.txt
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\bassopus.dll
   ${DeleteOnReboot} $WINDIR\SysWow64\keppymididrv\sfpacker.exe
  ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\bass.dll
  ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\bassmidi.dll
  ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\keppymididrv.dll
   ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\bass_mpc.dll 
   ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\bassflac.dll
   ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\basswv.dll
   ${DeleteOnReboot} $WINDIR\SysNative\keppymididrv\bassopus.dll
  ${DeleteOnReboot} $WINDIR\keppymidi.sflist
  ${DeleteOnReboot} $WINDIR\keppymidib.sflist
  Reboot
${Endif}
${Else}
${If} ${AtLeastWinVista}
  RMDir /r  "$WINDIR\System32\keppymididrv"
  ${DeleteOnReboot} $WINDIR\keppymidi.sflist
  ${DeleteOnReboot} $WINDIR\keppymidib.sflist
  ${DeleteOnReboot} $WINDIR\keppymididrv.defaultblacklist
  ${DeleteOnReboot} $WINDIR\keppymididrv.blacklist
${Else}
  MessageBox MB_OK "Note: The uninstaller will reboot your system to remove drivers."
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\bass.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\bassmidi.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\keppymididrv.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\bass_mpc.dll 
  ${DeleteOnReboot} $WINDIR\keppymididrv.defaultblacklist
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\keppymididrvuninstall.exe
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\keppymididrvcfg.exe
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\bassflac.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\basswv.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\bassopus.dll
  ${DeleteOnReboot} $WINDIR\System32\keppymididrv\sfpacker.exe
  ${DeleteOnReboot} $WINDIR\keppymidi.sflist
  ${DeleteOnReboot} $WINDIR\keppymidib.sflist
  Reboot
${Endif}
${EndIf}
SectionEnd
!endif
