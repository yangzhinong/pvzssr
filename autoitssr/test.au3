#include-once
#AutoIt3Wrapper_UseX64=Y
#include "util.au3"
Local $hwnd=0;
Local $title="free-ss.site 抓取工具";
Local $path="E:\\freeSSR\\freeSSR\\bin\\Debug\\freeSSR.exe";
;~ $hwnd=WinActivate('free-ss.site 抓取工具')
;~ WinMove('free-ss.site 抓取工具','',0,0,801, 517);
;~ Opt('MouseCoordMode',0);

Local $bOK=True;
Do
	if (WinExists($title)=False) Then
		ShellExecute($path);
		$hwnd=WinWaitActive($title)
	Else
		$hwnd=WinActivate($title)
	EndIf

    WinMove($title,'',0,0,801, 517);
	Opt('MouseCoordMode',0);
	 Do
		MouseMove(405, 76) ;Regresh Page
		MouseClick("left");
		Sleep(10000);
		$bOK=_HasImageInScreen('ShadowS',2)
		if $bOK Then
			Sleep(1000)
			$bOK=_HasImageInScreen('ShadowS',2)
		EndIf

	 Until $bOK

	 Sleep(1000)
	 MouseClick(97, 436)
	 MouseClickDrag('left',97,436,223, 437);

	Send("^c")
	MouseClick('left',76, 72);
	Send("^a")
	Send("{DEL}")
	Send("^v")
	MouseClick('left',306, 72);
    WinClose($title);
	Sleep(2*60*1000)

Until(False)







