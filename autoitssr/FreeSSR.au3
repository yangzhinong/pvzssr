#include-once
#AutoIt3Wrapper_UseX64=Y
#include "util.au3"
#include <WinAPIFiles.au3>
#include <MsgBoxConstants.au3>
#include <StringConstants.au3>
Local $hwnd=0;
Local $title="新标签页 - Google Chrome";
Local $chrome="C:\Program Files(x86)\Google\Chrome\Application\chrome.exe"
Local $starPath="C:\Program Files (x86)\Google\Chrome\Application"
;Local $iReturn = RunWait("notepad.exe")
$iReturn=ShellExecute("chrome.exe");
WinWaitActive($title);

Local $freeSSRUrl="https://free-ss.site/";

Send($freeSSRUrl);
Sleep(500)
Send("{ENTER}");
MsgBox(0,'验证码','是否有验证码? 有的话请手工解决验证码,按OK');
$title='免费上网账号 - Google Chrome'
WinActivate($title);
WinWaitActive($title);
WinMove($title,'',0,0,800,600);
Send("^s")
Sleep(1000)

Local $fileHtml="f:\1.html";
if FileExists($fileHtml) Then
	FileDelete($fileHtml)
EndIf
;;MsgBox(0,'','');
Send($fileHtml);
Send("{TAB}{DOWN}{DOWN}{UP}");f:\1.html
Send("{ENTER}{ENTER}");  //保存为
Sleep(2000)
Local $html=FileRead($fileHtml);
Local $aArray=StringRegExp($html,"\('#([0-9a-z]+) tbody'\).on\('click','i',function\(\){\W",$STR_REGEXPARRAYGLOBALMATCH );
Local $tbodyId=$aArray[0];

;MsgBox(0,'',$tbodyId);

Local $jsFunc="JSON.stringify($('#"  & $tbodyId & "').closest('table').DataTable().data().toArray())"
;MsgBox(0,'',$jsFunc);

Send("^+j")
Sleep(500);
Local $titleDevTool='DevTools - free-ss.site/';

WinActivate($titleDevTool);
WinWaitActive($titleDevTool);
WinMove($titleDevTool,'',0,0,800,600);
Sleep(500)
Send("^l"); 清除原来的信息
Sleep(100)
ClipPut($jsFunc);
Send("^v");
Send("{ENTER}");

MouseClick('right',235, 175);
Sleep(500)
Send("{DOWN}{DOWN}{DOWN}{DOWN}{ENTER}");
Sleep(200)
Local $fileLog="f:\1.log";
if FileExists($fileLog) Then
	FileDelete($fileLog)
EndIf
Sleep(500)
Send($fileLog)
Send("{ENTER}");
Sleep(1500)
MsgBox(0,"正确么？ " ,$tbodyId);
WinClose($titleDevTool);


;WinClose($title);
Local $txt=FileReadLine($fileLog,2);
$txt=StringTrimLeft($txt,1);
$txt=StringTrimRight($txt,1);
;MsgBox(0,'',$txt);
if FileExists($fileLog) Then
	FileDelete($fileLog)
EndIf
FileWrite($fileLog,$txt);






;MsgBox(0,"保存","请按右键保存日志f:\1.log");


















