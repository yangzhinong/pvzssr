#AutoIt3Wrapper_UseX64=Y
$sOSArch = @OSArch ;Check if running on x64 or x32 Windows ;@OSArch Returns one of the following: "X86", "IA64", "X64" - this is the architecture type of the currently running operating system.
ConsoleWrite("$sOSArch=" & $sOSArch & @CR)
$sAutoItX64 = @AutoItX64 ;Check if using x64 AutoIt ;@AutoItX64 Returns 1 if the script is running under the native x64 version of AutoIt.
ConsoleWrite("$sAutoItX64=" & $sAutoItX64 & @CR)