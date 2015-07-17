; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

!define APP "FolderKaitai"
!define VER "0.1"

!define PROGID "FolderKaitai"
!define EXT ".${PROGID}"

;--------------------------------

; The name of the installer
Name "${APP} ${VER}"

; The file to write
OutFile "Setup_${APP}.exe"

; The default installation directory
InstallDir "$APPDATA\${APP}"

; Request application privileges for Windows Vista
RequestExecutionLevel user


!define DOTNET_VERSION "2.0"

!include "DotNET.nsh"
!include LogicLib.nsh

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  !insertmacro CheckDotNET ${DOTNET_VERSION}

  ; Put file there
  File /r /x "*.vshost.*" ".\FolderKaitai\bin\Debug\*.*"

  WriteRegStr HKCU "Software\Classes\${EXT}" "" "${PROGID}"
  WriteRegStr HKCU "Software\Classes\${EXT}\ShellNew" "" ""
  WriteRegStr HKCU "Software\Classes\${EXT}\ShellNew" "ItemName" "新しいフォルダ解体"
  WriteRegStr HKCU "Software\Classes\${EXT}\ShellNew" "NullFile" ""

  WriteRegStr HKCU "Software\Classes\${PROGID}" "" "フォルダ解体 設定ファイル"
  WriteRegStr HKCU "Software\Classes\${PROGID}" "NeverShowExt" ""
  WriteRegStr HKCU "Software\Classes\${PROGID}\shell\open" "" "実行"
  WriteRegStr HKCU "Software\Classes\${PROGID}\shell\open\command" "" '"$INSTDIR\FolderKaitai.exe" /r "%1"'
  WriteRegStr HKCU "Software\Classes\${PROGID}\shell\edit" "" "編集"
  WriteRegStr HKCU "Software\Classes\${PROGID}\shell\edit\command" "" '"$INSTDIR\FolderKaitai.exe" /e "%1"'
  WriteRegStr HKCU "Software\Classes\${PROGID}\DefaultIcon" "" '"$INSTDIR\FolderKaitai.exe"'

  System::Call 'Shell32::SHChangeNotify(i 0x8000000, i 0, i 0, i 0)'
  
SectionEnd
