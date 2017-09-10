@echo OFF
title 红警2控制台 1.1
color 4e
mode con cols=40 lines=20
:loop
cls
echo ========================================
echo       命令与征服: 红色警戒2 控制台
echo ========================================
echo.
echo        1  启动 红警2
::echo        11 启动 红警2 窗口模式
echo        2  启动 尤里的复仇
::echo        22 启动 尤里复仇 窗口模式
echo.
echo        3  结束 红警2
echo        4  结束 尤里的复仇

::echo        s  关机
::echo        r  重启
echo.
echo        9  帮助
echo        0  退出  
echo.

set/p n=    ?      请选择：
if %n%==1 goto ra2
if %n%==11 goto ra2win
if %n%==2 goto yuri
if %n%==22 goto yuriwin
if %n%==3 goto exitra2
if %n%==4 goto exityuri
if %n%==s goto shutdown
if %n%==r goto reboot
if %n%==00 goto test
if %n%==0 goto end
if %n%==9 goto help
goto loop
:end

exit
:ra2
start ra2.exe -speedcontrol
goto loop
:ra2win

start ra2.exe -win -speedcontrol
goto loop
:yuri
start ra2md.exe -speedcontrol
goto loop
:yuriwin

start ra2md.exe -win -speedcontrol
goto loop
:exitra2
taskkill /f /im ra2.exe
taskkill /f /im game.exe
goto loop
:exityuri
taskkill /f /im ra2md.exe
taskkill /f /im gamemd.exe
goto loop
:test
color 5a
echo ----------------------------------------
echo          BE ONE WITH YURI！
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
echo     建议以管理员身份运行此程序。
echo     窗口模式需要调整颜色深度为16位色。
echo.
echo     附加指令：
echo     “11”或“22”—窗口模式
echo     “s”——————关机
echo     “r”——————重启
::echo     “00”—————彩蛋~
echo.
echo.
pause
goto loop