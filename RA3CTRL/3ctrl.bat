@ECHO OFF
REM  QBFC Project Options Begin
REM  HasVersionInfo: Yes
REM  Companyname: 
REM  Productname: RedAlert3Control
REM  Filedescription: 
REM  Copyrights: 
REM  Trademarks: 
REM  Originalname: 
REM  Comments: 
REM  Productversion: 01.00.00.00
REM  Fileversion: 01.00.00.00
REM  Internalname: ra3CTRL
REM  Appicon: ..\..\..\Gallery\Icons\RA2HDICON\Ra2ICO.ico
REM  AdministratorManifest: No
REM  Embeddedfile: ra3fix.exe
REM  Embeddedfile: ra3trainer.txt
REM  Embeddedfile: ra3trainer1.12.exe
REM  QBFC Project Options End
ECHO ON
@echo OFF
title 红警3控制台
color 4e
mode con cols=40 lines=20
:loop
cls
echo ========================================
echo        红色警戒3
echo ========================================
echo.
echo        1  启动 红警3
echo        11 启动 红警3 窗口模式

echo.
echo        2  结束 红警3

echo        3  工具箱。
::echo        s  关机
::echo        r  重启
echo.
echo        9  帮助
echo        0  退出  
echo.

set/p n=    ?      请选择：
if %n%==1 goto ra3
if %n%==11 goto ra3win

if %n%==2 goto exitra3

if %n%==3 goto toolbox
if %n%==s goto shutdown
if %n%==r goto reboot
if %n%==00 goto test
if %n%==0 goto end
if %n%==9 goto help
goto loop

:end
exit

:ra3
start RA3.exe -ui 
goto loop

:ra3win
start RA3.exe -win -ui
goto loop

:exitra3
taskkill /f /im ra3.exe
taskkill /f /im ra3_1.12.game
goto loop

goto loop
:test
color 4c
echo ----------------------------------------
echo                   3!
echo ----------------------------------------
goto test

:shutdown
shutdown -s -t 0
exit

:reboot
shutdown -r -t 0
exit

:help
cls
echo ========================================
echo               帮助与关于
echo ========================================
echo     将本程序放在红警3文件夹。
echo     建议以管理员身份运行此程序。
echo     将自动打开控制台。
::echo     全屏调整分辨率1366*768。
echo     为红警3_1.12版本打造 。

echo.
echo     附加指令：
echo     “11”—————窗口模式
echo     “s”——————关机
echo     “r”——————重启
::echo     “00”—————彩蛋~
echo.
echo      2016.2
echo.
pause
goto loop

:toolbox
cls
echo ========================================
echo               工具箱。
echo ========================================
echo     1.红警3修复(必须管理员)
echo     2.红警3 31项修改器
echo     3.31项修改器说明
echo     0.返回
echo.
set/p y=    ?      请选择：
if %y%==1 goto ra3fix
if %y%==2 goto ra3tr
if %y%==3 goto ra3trt
if %y%==0 goto loop
pause
goto toolbox
:ra3fix
start %MYFILES%\ra3fix.exe
goto toolbox

:ra3tr
start %MYFILES%\ra3trainer1.12.exe
goto toolbox

:ra3trt
start %MYFILES%\ra3trainer.txt
goto toolbox
