# Manifest Analysis Errors
_Make sure to install all tools and add them as system variable from Home directory before proceeding_<br>
_Prerequisite : Already have an apk_<br>

* For any manifest fixes, please follow these steps first to access the manifest followed by Global Changes(changes needed for all error fixes), then move on to individual error steps! *<br>

* I've uploaded 1 Bugged Manifest (BuggedAndroidManifest.xml) with all 3 errors and 1 Fixed Manifest (FixedAndroidManifest.xml) with all 3 errors fixed for reference *<br>

## IF APK already compiled!
1. First we need to be able to access and modify the manifest. <br>
 * Open command prompt in same directory as your apk
 * Type in the following command to decompile the apk
  * apktool d YourAPK.apk
  * eg - apktool d my.apk
  * d- Decompile flag *IMPORTANT*
 * This will create a new folder with same name as our apk will all the decompiled files.
2. Accessing the Manifest
 * Open the newly created folder to access all the resources the apk had.
 * You will find decrypted *AndroidManifest.xml* in the home directory of new folder.
3. *Perfrom individual error solution from below*
4. Recompiling/ binding everything back to apk
 * Open command prompt in same directory as your apk
 * Type in the following command to decompile the apk
  * apktool d YourAPK.apk
  * eg - apktool b MyNewAPK.apk
  * b- bind flag *IMPORTANT*
 * This will create a new apk inside the (extracted folder)/dist directory.
5. Resign the apk (Please check "root/Android/CertificateAnalysis" readme for steps to signing APK)<br>
And we're done.

## If APK hasn't been compiled and using UNITY3D Engine
_Make sure you've switched Build Platform to Android_ <br>
You will find an existing AndroidManifest.xml in /Assets/Plugins/Android/ <br>
*Perfrom individual error solution from below, save this file and build the apk*

## Global Changes
Add the following 2 lines in '<manifest>' tag of AndroidManifest. <br><br>
1.  xmlns:tools="http://schemas.android.com/tools" <br>
 <br>
2.  tools:replace="android:{TagToReplace}, android:{tagToReplace}, .." {TagToReplace= [overwriteValue] }


## Android:exported=true
This flag enables other applications to share resources and data thus leaving it vulnerable to manipulation.<br>
<br>
Flag - *android:exorted=value*
<br>
Modded global changes:<br>
Line 2 changes indside manifest tag : tools:replace="android:exported" android:exported="false" <br>
Also change all pre existing 'android:exported="false"' and add 'tools:replace="android:exported"'
<br>
Save the file.<br>

## Android:allowBackup=true
This flag allows anyone to backup your application data via adb. It allows users who have enabled USB debugging to copy application data off of the device.
<br>
Flag - *android:allowBackup=value*
<br>
Modded global changes:<br>
Line 2 changes indside manifest tag : tools:replace="android:allowBackup" android:allowBackup="false" <br>
Also change all pre existing 'android:allowBackup="false"' and add 'tools:replace="android:allowBackup"'
<br>
Save the file.<br>

## Android:Intent set to SingleTask/SingleInstance
No need to modify this tag. This flag is only responsible for flow of the application. 
