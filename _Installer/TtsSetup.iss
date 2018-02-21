#include "InstallDependancies.iss"

#define MyAppName "Text To Screen"   
#define MyAppNameShort "TextToScreen"  
#define MyAppPublisher "Marcin Szeniak"
#define MyAppURL "https://github.com/Klocman/Text-To-Screen"
#define MyAppExeName "TextToScreen.exe"
  
#define MyAppVersion "1.9.0.0"     
#define MyAppVersionShort "1.9"

#include "scripts\PortablePage.iss" 
#include "scripts\PortableIcons.iss"
#include "scripts\Ngen.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{826a6c11-a031-4b91-850c-63cbc2cc9487}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}

WizardImageFile=bigImage.bmp  
WizardSmallImageFile=smallImage.bmp
SetupIconFile=logo.ico

AllowNoIcons=yes                  
LicenseFile=Input\Licence.txt
OutputBaseFilename={#MyAppNameShort}_{#MyAppVersionShort}_setup

Compression=lzma2/ultra
SolidCompression=yes

[Languages]
Name: "en"; MessagesFile: "compiler:Default.isl"    
Name: "pl"; MessagesFile: "compiler:Languages\Polish.isl"  

[Files]                                          
Source: "Input\TextToScreen.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Input\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
