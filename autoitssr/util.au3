
#include <ImageSearch.au3>
Func _YznImg( $name, $path='')
	if $path='' then
		Return 'image/' & $name & '.bmp'
	Else
		Return 'image/' & $path & $name & '.bmp'
	EndIf
EndFunc
Func _YznMouseToImg($img,$diff=0,$speed=5)
	Local $x=0, $y=0
	$img='image/' & $img & '.bmp'
	Local $search=_ImageSearch($img ,1,$x,$y,$diff)

	if $search=1 Then
		MouseMove($x,$y,$speed)
		Return True
	Else
		Return False
	EndIf
 EndFunc


 Func _YznMouseToImgs($imgs,$diff=0,$speed=5)
	Local $x=0, $y=0
	Local $img
	Local $i
	for $i=1 to $imgs[0]
		$img='image/' & $imgs[$i] & '.bmp'
		Local $search=_ImageSearch($img ,1,$x,$y,$diff)
		if $search=1 Then
			MouseMove($x,$y,$speed)
			$bFind=True
			Return True
		EndIf
	Next
	Return False
EndFunc

Func _YznMouseClick()
	MouseClick('left')
 EndFunc

 Func _YznWaitImgsAndMouseTo($imgs,$diff=0,$bClick=0,$defaultX=0,$defalutY=0,$speed=5)

	Local $x=0, $y=0,$img, $i=1, $newImgs[10]
	$newImgs[0]=$imgs[0]
	for $i=1 to $imgs[0]
		$newImgs[$i]='image/' & $imgs[$i] & '.bmp'
	Next
	Local $bFind=False

	Local $search=_WaitForImagesSearch($newImgs, 15 , 1, $x, $y,$diff)
	if $search>0 Then
		MouseMove($x,$y,$speed)
		if $bClick=1 Then
			MouseClick('left')
		EndIf
		Sleep(500)
		$bFind=True
	EndIf

	if not $bFind Then
		if $defaultX<>0 and $defalutY<>0 Then
			MouseMove($defaultX,$defalutY,$speed)
			if $bClick=1 Then
				MouseClick('left')
			EndIf
		EndIf
	EndIf
	Sleep(500)
	Return $bFind
EndFunc

Func _YznWaitImg($img,$diff=0)
	Local $x=0, $y=0
	$img='image/' & $img & '.bmp'
	Local $search=_WaitForImageSearch($img , 15 , 1, $x, $y,$diff)
	if $search=1 Then
		;MouseMove($x,$y,30)
		Return True
	Else
		Return False

	EndIf
EndFunc


Func _GetConfig($mod,$key,$default='')
	Local $ini='ini/config.ini'
	Local $ret=IniRead($ini,$mod,$key,$default)
	Return $ret
EndFunc

Func _SetConfig($mod,$key,$value)
	Local $ini='ini/config.ini'
	IniWrite($ini,$mod,$key,$value)
EndFunc

Func _DragImagShift($img,$dx,$dy)
	Sleep(1000)
	if not _YznMouseToImg($img,30) Then
		Return False
	Else
		Local $x=MouseGetPos(0)
		Local $y=MouseGetPos(1)

		MouseClickDrag('left',$x,$y,$x+$dx,$y+$dy)
		Sleep(1000)
		Return True
	EndIf
EndFunc


Func _GetPositionFromConfig($mod,$key)
	Return StringSplit(_GetConfig($mod,$key),",")
EndFunc

Func _GetImgsFromConfig($mod,$key)
	Return StringSplit(_GetConfig($mod,$key),",")
EndFunc

Func _HasImageInScreen($img,$diff=0)
	Local $x=0, $y=0
	$img='image/' & $img & '.bmp'
	Local $search=_ImageSearch($img ,1,$x,$y,$diff)

	if $search=1 Then
		;MouseMove($x,$y,50)
		Return True
	Else
		Return False
	EndIf
EndFunc
Func _HasImagesInScreen($imgs,$diff=0)
	Local $x=0, $y=0
	Local $img

	Local $i

	for $i=1 to $imgs[0]
		$img= $imgs[$i]
		if _HasImageInScreen($img,$diff) Then
			Return True
		EndIf
	Next
	Return False
EndFunc
