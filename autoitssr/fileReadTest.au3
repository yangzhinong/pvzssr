;~ Local $html=FileRead("f:\1.html");
#include <MsgBoxConstants.au3>
#include <StringConstants.au3>

;~ Local $aArray=StringRegExp($html,"\('#([0-9a-z]+) tbody'\).on\('click','i',function\(\){\W",$STR_REGEXPARRAYGLOBALMATCH );

;~ ;MsgBox(0,'',$ss);


;~ ;Local $aArray = StringRegExp('<test>a</test> <test>b</test> <test>c</Test>', '(?i)<test>(.*?)</test>', $STR_REGEXPARRAYGLOBALMATCH)
;~ For $i = 0 To UBound($aArray) - 1
;~     MsgBox($MB_SYSTEMMODAL, "RegExp Test with Option 3 - " & $i, $aArray[$i])
;~ Next

;~ Local $titleDevTool='Developer Tools - https://free-ss.site/';

;~ WinActivate($titleDevTool);
;~ WinWaitActive($titleDevTool);
;~ Sleep(500)
;~ local $hwnd=WinMove($titleDevTool,'',0,0,900,600);
;~ MsgBox(0,'',$hwnd);

Local $fileLog='f:\1.log'
Local $txt=FileReadLine('f:\1.log',2);
$txt=StringMid($txt,2);
$txt=StringLeft($txt,StringLen($txt)-1);
if FileExists($fileLog) Then
	FileDelete($fileLog)
EndIf
FileWrite('f:\1.log',$txt);


