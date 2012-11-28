@echo off
color 24
title Christmas Clock Installer

echo ------------------ Welcome to the Christmas Clock Installer! ------------------
echo This installer assumes that you are running Windows XP, Vista, or 7.
echo It also assumes that Windows is installed in drive C: and that you have .NET 
echo   Framework 3.5 or greater installed (this is included in the zip as 
echo   dotNetFx40_Client_x86_x64.exe)
echo If you do not meet this criterion, please see Advanced_Steps.txt
pause
echo INFO: Creating folders (it's ok if they already exist)
md "C:\Christmas Clock"
md "C:\Christmas Clock\Resources"
echo INFO: Copying files
copy ".\Christmas Clock" "C:\Christmas Clock" /V
copy ".\Christmas Clock\Resources" "C:\Christmas Clock\Resources" /V
copy ".\Christmas Clock.lnk" %userprofile%"\Desktop" /V
echo Done!
echo You can close the window now.
pause