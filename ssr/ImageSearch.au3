#Region ;**** Directives created by AutoIt3Wrapper_GUI ****
#AutoIt3Wrapper_UseX64=y
#EndRegion ;**** Directives created by AutoIt3Wrapper_GUI ****
#include-once
; ------------------------------------------------------------------------------
;
; AutoIt Version: 3.0
; Language:       English
; Description:    Functions that assist with Image Search
;                 Require that the ImageSearchDLL.dll be loadable
;
; ------------------------------------------------------------------------------

;===============================================================================
;
; Description:      Find the position of an image on the desktop
; Syntax:           _ImageSearchArea, _ImageSearch
; Parameter(s):
;                   $findImage - the image to locate on the desktop
;                   $tolerance - 0 for no tolerance (0-255). Needed when colors of
;                                image differ from desktop. e.g GIF
;                   $resultPosition - Set where the returned x,y location of the image is.
;                                     1 for centre of image, 0 for top left of image
;                   $x $y - Return the x and y location of the image
;
; Return Value(s):  On Success - Returns 1
;                   On Failure - Returns 0
;
; Note: Use _ImageSearch to search the entire desktop, _ImageSearchArea to specify
;       a desktop region to search
;
;===============================================================================
;https://www.autoitscript.com/forum/topic/65748-image-search-library/?page=4
Func _ImageSearch($findImage , $resultPosition, ByRef $x, ByRef $y, $tolerance, $HBMP=0)
   return _ImageSearchArea($findImage,$resultPosition,0,0,@DesktopWidth,@DesktopHeight,$x,$y,$tolerance,$HBMP)
EndFunc

Func _ImageSearchArea($findImage, $resultPosition, $x1, $y1, $right, $bottom, ByRef $x, ByRef $y, $tolerance, $HBMP = 0)
    ;MsgBox(0,"asd","" & $x1 & " " & $y1 & " " & $right & " " & $bottom)
    If $tolerance > 0 Then $findImage = "*" & $tolerance & " " & $findImage
    If IsString($findImage) Then
        $result = DllCall("ImageSearchDLL.dll", "str", "ImageSearch", "int", $x1, "int", $y1, "int", $right, "int", $bottom, "str", $findImage, "ptr", $HBMP)
        $err = @error
    Else
        $result = DllCall("ImageSearchDLL.dll", "str", "ImageSearch", "int", $x1, "int", $y1, "int", $right, "int", $bottom, "ptr", $findImage, "ptr", $HBMP)
        $err = @error
    EndIf
    Switch $err
        Case 1
            ConsoleWriteError("unable to use the DLL file" & @CRLF)
            exit 1
        Case 2
            ConsoleWriteError('unknown "return type" ' & @CRLF)
            exit 1
        Case 3
            ConsoleWriteError('"ImageSearch" not found in DLL' & @CRLF)
            exit 1
        Case 4
            ConsoleWriteError('bad number of parameters' & @CRLF)
            exit 1
        Case 5
            ConsoleWriteError('bad parameter' & @CRLF)
            exit 1
    EndSwitch

    ; If error exit
    If $result[0] = "0" Then Return 0

    ; Otherwise get the x,y location of the match and the size of the image to
    ; compute the centre of search
    $array = StringSplit($result[0], "|")

    $x = Int(Number($array[2]))
    $y = Int(Number($array[3]))
    If $resultPosition = 1 Then
        $x = $x + Int(Number($array[4]) / 2)
        $y = $y + Int(Number($array[5]) / 2)
    EndIf
    Return 1
EndFunc

;===============================================================================
;
; Description:      Wait for a specified number of seconds for an image to appear
;
; Syntax:           _WaitForImageSearch, _WaitForImagesSearch
; Parameter(s):
;					$waitSecs  - seconds to try and find the image
;                   $findImage - the image to locate on the desktop
;                   $tolerance - 0 for no tolerance (0-255). Needed when colors of
;                                image differ from desktop. e.g GIF
;                   $resultPosition - Set where the returned x,y location of the image is.
;                                     1 for centre of image, 0 for top left of image
;                   $x $y - Return the x and y location of the image
;
; Return Value(s):  On Success - Returns 1
;                   On Failure - Returns 0
;
;
;===============================================================================
Func _WaitForImageSearch($findImage , $waitSecs , $resultPosition , ByRef $x, ByRef $y,$tolerance,$HBMP=0)
	$waitSecs = $waitSecs * 1000
	$startTime=TimerInit()
	While TimerDiff($startTime) < $waitSecs
		sleep(100)
		$result=_ImageSearch($findImage,$resultPosition,$x, $y,$tolerance,$HBMP)
		if $result > 0 Then
			return 1
		EndIf
	WEnd
	return 0
EndFunc

;===============================================================================
;
; Description:      Wait for a specified number of seconds for any of a set of
;                   images to appear
;
; Syntax:           _WaitForImagesSearch
; Parameter(s):
;					$waitSecs  - seconds to try and find the image
;                   $findImage - the ARRAY of images to locate on the desktop
;                              - ARRAY[0] is set to the number of images to loop through
;								 ARRAY[1] is the first image
;                   $tolerance - 0 for no tolerance (0-255). Needed when colors of
;                                image differ from desktop. e.g GIF
;                   $resultPosition - Set where the returned x,y location of the image is.
;                                     1 for centre of image, 0 for top left of image
;                   $x $y - Return the x and y location of the image
;
; Return Value(s):  On Success - Returns the index of the successful find
;                   On Failure - Returns 0
;
;
;===============================================================================
Func _WaitForImagesSearch($findImage , $waitSecs , $resultPosition , ByRef $x , ByRef $y , $tolerance , $HBMP=0)
	$waitSecs = $waitSecs * 1000
	$startTime=TimerInit()
	While TimerDiff($startTime) < $waitSecs
		for $i = 1 to $findImage[0]
		    sleep(100)
		    $result=_ImageSearch($findImage[$i],$resultPosition,$x, $y,$tolerance,$HBMP)
		    if $result > 0 Then
			    return $i
		    EndIf
		Next
	WEnd
	return 0
EndFunc

