
cd
pause

"D:\Program Files\Unity524f1\Editor\Data\Mono\lib\mono\2.0\pdb2mdb.exe" "%1"
xcopy /y "%1" "C:\Games\Kerbal Space Program\GameData\$(ProjectName)\Plugins\"
xcopy /y "$(TargetDir)$(TargetName).pdb" "C:\Games\Kerbal Space Program\GameData\$(ProjectName)\Plugins\"
xcopy /y "$(TargetDir)$(TargetName).dll.mdb" "C:\Games\Kerbal Space Program\GameData\$(ProjectName)\Plugins\"
taskkill /IM tail.exe /F 2>&1 | exit /B 0

pause