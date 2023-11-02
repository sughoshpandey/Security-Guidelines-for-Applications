# Reconnaissance Analysis
_Make sure to install all tools and add them as system variable from Home directory before proceeding_<br>
_Prerequisite : Already have an apk_<br>
Displays list of URLs, Databases, Emails, Trackers and Strings that can be easily read by decompiling the apk which is a security concern.<br>
Some strings may contain api keys, passwords etc which only restricted people need to have access.<br>
To mitigate this risk, you need to scramble the code into unreadable or difficult to interpret code. This method is known as Code Obfuscation. Obfuscation is done during the building of the apk.<br>

## Code Obfuscation in Unity3D Engine
First, the most basic obfuscation step is changing the scripting backend to "IL2CPP" instead of the commonly used "MONO". <br>
IL2CPP (Intermediate Language to C++) converts code to C++ and then creates a native binary file which adds some level of obfuscation. <br>
For more secure obfuscation, we'll use [third party obfuscator]. I've uploaded the .unityPackage for import.<br>
Import this package in Unity.<br>

*To enable: Assets/Editor/Beebyte/Obfuscator/ObfuscatorOptions -> (inspector) ""Obfuscation Enabled"" TICK*<br>
*To disable: Assets/Editor/Beebyte/Obfuscator/ObfuscatorOptions -> (inspector) ""Obfuscation Enabled"" DESELECT"*<br>

*Always build and test the applcation after Obfuscation because some features might now work (specially Animations and Buttons) due to intensive obfuscation*

_If any method is not working, add [SkipRename] modifier from 'Beebyte.Obfuscator' library (You have to import - using Beebyte.Obfuscator;)_<br>
If assembly definations are setup in the project, you have to make a custom assembly defination and add this defination to your scripting assdef to access the Beebyte.Obfuscator library.<br>