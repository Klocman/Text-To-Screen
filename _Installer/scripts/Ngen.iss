﻿[Run]
Filename: {code:GetV4NetDir}ngen.exe; Parameters: "install ""{app}\{#MyAppExeName}"""; StatusMsg: {cm:NgenOptimizing}; Flags: runhidden; Check: CheckV4NetExists;

[UninstallRun]
Filename: {code:GetV4NetDir}ngen.exe; Parameters: "uninstall ""{app}\{#MyAppExeName}"""; StatusMsg: {cm:NgenRemoving}; Flags: runhidden; Check: CheckV4NetExists; 

;CustomMessage('NgenOptimizing')      {cm:NgenRemoving}
[CustomMessages]
NgenOptimizing =Optimizing performance for your system ...
pl.NgenOptimizing =Optymalizacja wydajności dla twojego systemu ...

NgenRemoving =Removing native images and dependencies ...
pl.NgenRemoving =Usuwanie danych z pamięci podręcznej ...

[Code]
function CheckV4NetExists() : boolean;
begin
  if RegKeyExists(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full') then
  Result := True
  else
  Result := False;
end;
function GetV4NetDir(version: string) : string;
var regkey, regval  : string;
begin

    // in case the target is 3.5, replace 'v4' with 'v3.5'
    // for other info, check out this link 
    // http://stackoverflow.com/questions/199080/how-to-detect-what-net-framework-versions-and-service-packs-are-installed
    regkey := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full'

    RegQueryStringValue(HKLM, regkey, 'InstallPath', regval);

    result := regval;
end;
