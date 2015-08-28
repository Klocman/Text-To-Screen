﻿[Setup]
Uninstallable=not IsPortable()
DisableProgramGroupPage=no

[CustomMessages]
InstallPortableTitle =Portable Installation
pl.InstallPortableTitle =Instalacja przenośna 

InstallTypeChoiceTitle =Installation type
pl.InstallTypeChoiceTitle =Typ instalacji

InstallStandardTitle =Standard Installation
pl.InstallStandardTitle =Instalacja standardowa

InstallPortableInfo =Portable installation will not register itself in the system, it will only extract files to the specified directory. You can set the directory to anything you''d like, for example to a USB drive. You will be able to move this directory freely since the whole app is inside of it.
pl.InstallPortableInfo =Instalacja przenośna nie zostanie zarejestrowana w systemie, zostaną tylko wypakowane pliki. Pliki mogą zostać wypakowane do dowolnego folderu i mogą być bez problemu przenoszone. Wszystkie pliki używane przez tą aplikację będą przechowywane w wybranym folderze.

InstallStandardInfo =This application will be installed and registered on your computer. Standard uninstaller will be created and it will be visible under "Programs and Features" as well as in other third-party uninstallers.
pl.InstallStandardInfo =Ta aplikacja zostanie zainstalowana i zarejestrowana w twoim systemie. Zostanie stworzony deinstalator i będzie on widoczny w panelu sterowania i innych deinstalatorach.


[Code]
var
  CustomPage: TWizardPage;
  StandardDescLabel: TLabel;
  {*StandardRadioButton: TNewRadioButton;  
  AdvancedRadioButton: TNewRadioButton;    *}
  AdvancedDescLabel: TLabel;
  StandardRadioButton: TNewRadioButton;  
  AdvancedRadioButton: TNewRadioButton;  

function IsPortable(): Boolean;
begin
  if(StandardRadioButton.Checked = True) then
  Result := False
  else
  Result := True;
end;
function IsNotPortable(): Boolean;
begin
  if(StandardRadioButton.Checked = True) then
  Result := True
  else
  Result := False;
end;

procedure InitializeWizard;     

begin
  CustomPage := CreateCustomPage(wpWelcome, CustomMessage('InstallTypeChoiceTitle'), '');
  StandardRadioButton := TNewRadioButton.Create(WizardForm);
  StandardRadioButton.Parent := CustomPage.Surface;
  StandardRadioButton.Checked := True;
  StandardRadioButton.Top := 16;
  StandardRadioButton.Width := CustomPage.SurfaceWidth;
  StandardRadioButton.Font.Style := [fsBold];
  StandardRadioButton.Font.Size := 9;
  StandardRadioButton.Caption := CustomMessage('InstallStandardTitle');
  StandardDescLabel := TLabel.Create(WizardForm);
  StandardDescLabel.Parent := CustomPage.Surface;
  StandardDescLabel.Left := 8;
  StandardDescLabel.Top := StandardRadioButton.Top + StandardRadioButton.Height + 8;
  StandardDescLabel.Width := CustomPage.SurfaceWidth - 10; 
  StandardDescLabel.Height := 40;
  StandardDescLabel.AutoSize := False;
  StandardDescLabel.Wordwrap := True;
  StandardDescLabel.Caption := CustomMessage('InstallStandardInfo');
  AdvancedRadioButton := TNewRadioButton.Create(WizardForm);
  AdvancedRadioButton.Parent := CustomPage.Surface;
  AdvancedRadioButton.Top := StandardDescLabel.Top + StandardDescLabel.Height + 16;
  AdvancedRadioButton.Width := CustomPage.SurfaceWidth;
  AdvancedRadioButton.Font.Style := [fsBold];
  AdvancedRadioButton.Font.Size := 9;
  AdvancedRadioButton.Caption := CustomMessage('InstallPortableTitle');
  AdvancedDescLabel := TLabel.Create(WizardForm);
  AdvancedDescLabel.Parent := CustomPage.Surface;
  AdvancedDescLabel.Left := 8;
  AdvancedDescLabel.Top := AdvancedRadioButton.Top + AdvancedRadioButton.Height + 8;
  AdvancedDescLabel.Width := CustomPage.SurfaceWidth - 10;
  AdvancedDescLabel.Height := 60;
  AdvancedDescLabel.AutoSize := False;
  AdvancedDescLabel.Wordwrap := True;
  AdvancedDescLabel.Caption := CustomMessage('InstallPortableInfo');
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  // initialize result to not skip any page (not necessary, but safer)
  Result := False;

  if PageID = wpSelectProgramGroup then
    Result := IsPortable();       
end;