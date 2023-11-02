# Security Guidelines
Security Guidlines to protect applications from security threats.

## Table Of Content
- [Security-Guidelines](#security-guidelines)
  * [Tools Required <br>](#tools-required--br-)
    + [1. MobSF](#1-mobsf--)
    + [2. Java v8+](#2-java-v8-)
    + [3. Python **3.7** Python 3.8 IS NOT SUPPORTED <br>](#3-python-37-python-38-is-not-supported-)
    + [4. Microsoft Visual C++ Build Tools](#4-microsoft-visual-c-build-tools-)
    + [5. OpenSSL](#5-openssl-)
    + [6. WKHTMLTOPDF WK<HTML> TO PDF <br>](#6-wkhtmltopdf-wk-to-pdf-)
    + [7. APKTOOL](#5-apktool-)
  * [Analysis Tool Setup - MobSF <br>](#analysis-tool-setup---mobsf-)
    + [HOW TO ADD SYSTEM VARIABLE- <br>](#how-to-add-system-variable--)
      - [Windows <br>](#windows-)
        * [Windows 10 and Windows 8 <br>](#windows-10-and-windows-8-)
        * [Windows 7 <br>](#windows-7-)
        * [Windows Vista <br>](#windows-vista-)
        * [Windows XP <br>](#windows-xp-)
        * [Solaris and Linux <br>](#solaris-and-linux-)
        * [Set the PATH permanently <br>](#set-the-path-permanently-)
        * [Bash Shell <br>](#bash-shell-)
        * [C Shell (csh) <br>](#c-shell-csh-)
    + [Installing MobSF <br>](#installing-mobsf-)
    + [Running MobSF <br>](#running-mobsf-)
  * [Static Testing using MobSF (APK)](#static-testing-using-mobsf-apk)
  * [Static Testing using MobSF (iOS)](#static-testing-using-mobsf-ios)
  * [MobSF interface explained](#mobsf-interface-explained)
    + [Information Section](#information-section)
    + [Scan option](#scan-option)
    + [Signer Certificate](#signer-certificate)
    + [Binary Analysis](#binary-analysis)
    + [Android API](#android-api)
    + [Browsable Activities](#browsable-activities)
    + [Security Analysis](#security-analysis)
      - [Manifest Analysis:](#manifest-analysis-)
      - [Code Analysis:](#code-analysis-)
      - [CVSS](#cvss)
      - [CWE](#cwe)
      - [File Analysis](#file-analysis)
    + [Malware Analysis](#malware-analysis)
    + [Reconnaissance](#reconnaissance)
      - [URL](#url)
      - [Emails](#emails)
      - [Strings](#strings)
    + [Components](#components)
- [Common Vulnerabilities Found and fix](#common-vulnerabilities-found-and-fix)
 

## Tools Required <br>
### 1. [MobSF](https://github.com/MobSF/Mobile-Security-Framework-MobSF)  
Download the latest from this website  - https://github.com/MobSF/Mobile-Security-Framework-MobSF <br>
Follow the steps provided [here](https://mobsf.github.io/docs/#/) to install the software <br>

### 2. [Java v8+](http://www.oracle.com/technetwork/java/javase/downloads/index.html) 
Download Java (JDK) v8+ - http://www.oracle.com/technetwork/java/javase/downloads/index.html <br>
Steps to download and install JDK can be found [here](https://www3.ntu.edu.sg/home/ehchua/programming/howto/JDK_Howto.html)  - https://www3.ntu.edu.sg/home/ehchua/programming/howto/JDK_Howto.html <br>

### 3. [Python **3.7**](https://www.python.org/downloads/release/python-375/) Python 3.8 IS NOT SUPPORTED 
Download Anaconda + Python **3.7** - Python (https://www.python.org/downloads/release/python-375/v) **Anaconda** (https://repo.anaconda.com/archive/Anaconda3-2020.02-Windows-x86_64.exe) <br>
Follow the installer. <br>

### 4. [Microsoft Visual C++ Build Tools](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16) <br>
Download Microsoft Visual C++ Build Tools - https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16 <br>
Steps to download and install can be found [here](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019) <br>

### 5. [OpenSSL](https://slproweb.com/download/Win64OpenSSL-1_1_1g.exe) 
Download OpenSSL - https://slproweb.com/download/Win64OpenSSL-1_1_1g.exe <br>
Follow the installer <br>

### 6. [WKHTMLTOPDF](https://wkhtmltopdf.org/downloads.html) WK<HTML> TO PDF 
Download WKHTMLTOPDF - https://wkhtmltopdf.org/downloads.html <br>
Steps to install can be found [here](https://github.com/JazzCore/python-pdfkit/wiki/Installing-wkhtmltopdf) <br>

### 7. [APKTool](https://bitbucket.org/iBotPeaches/apktool/downloads)
Follow the steps: <br>
1. Download Windows wrapper script from [here](https://raw.githubusercontent.com/iBotPeaches/Apktool/master/scripts/windows/apktool.bat) <br> (Right click and Savelink as *apktool.bat*)<br>
2. Download APKTOOL (newest version) - https://bitbucket.org/iBotPeaches/apktool/downloads
3. Renamed downloaded jar from step 2 to - *apktool.jar*<br>
4. Add to Windows System Variable

## Analysis Tool Setup - MobSF <br>
_Make sure to install all the tools required before proceeding with the following steps_ <br>
Pre-requisite <br>
Add wthtmltopdf to **SYSTEM VARIABLE** <br>
Add keytool to **SYSTEM VARIABLE** <br>
Add jarsigner to **SYSTEM VARIABLE** <br>
Add apktool to **SYSTEM VARIABLE** <br>


### HOW TO ADD SYSTEM VARIABLE- <br>

#### Windows <br>
##### Windows 10 and Windows 8 <br>
1. In Search, search for and then select: System (Control Panel) <br>
2. Click the Advanced system settings link. <br>
3. Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New. <br>
4. In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK. <br>

##### Windows 7 <br>
1. From the desktop, right click the Computer icon. <br>
2. Choose Properties from the context menu. <br>
3. Click the Advanced system settings link. <br>
4. Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New. <br>
5. In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK. <br>

##### Windows Vista <br>
1. From the desktop, right click the My Computer icon. <br>
2. Choose Properties from the context menu. <br>
3. Click the Advanced tab (Advanced system settings link in Vista). <br>
4. Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New. <br>
5. In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK. <br>

##### Windows XP <br>
1. Select Start, select Control Panel. double click System, and select the Advanced tab. <br>
2. Click Environment Variables. In the section System Variables, find the PATH environment variable and select it. Click Edit. If the PATH environment variable does not exist, click New. <br>
3. In the Edit System Variable (or New System Variable) window, specify the value of the PATH environment variable. Click OK. Close all remaining windows by clicking OK. <br>

##### Solaris and Linux <br>
1. To find out if the path is properly set: <br>
In a terminal windows, enter: <br>
% [%application_name%]  <br>
This will print the help section of tool, if it can find it. If the version is old or you get the error : Command not found, then the path is not properly set. <br>

##### Set the PATH permanently <br>
To set the path permanently, set the path in your startup file. <br>
Note: Instructions for two most popular Shells on Linux and Solaris are listed. If you are using other shells, see the Path Setting Tutorial. <br>

##### Bash Shell <br>
Edit the startup file (~/.bashrc) <br>

1. Modify PATH variable <br>
PATH=[%path_to_tools/application%] <br>
export PATH <br>
2. Save and close the file <br>
3. Load the startup file <br>
% . /.profile <br>

##### C Shell (csh) <br>
Edit the startup file (~/.cshrc) <br>

1. Set Path <br>
set path=[%path_to_tool/application%] <br>
2. Save and close the file <br>
3. Load the startup file <br>
% source ~/.cshrc <br>

### Installing MobSF <br>

* Clone the [git repository](https://github.com/MobSF/Mobile-Security-Framework-MobSF.git) in a directory. <br>
* Run CommandPrompt and opent the directory where Git Repo has been cloned. <br>
 * cd Mobile-Software-Framework-MobSF <br>
* Type the command -  <br>
    setup.bat <br>
* Let the installer run <br>

### Running MobSF <br>

* Open the git repo in Command Prompt <br>
* Type the command -  <br>
    run.bat <br>
* MobSF should start at your localhost PORT 8080 i.e. [http://localhost:8080](http://localhost:8080) <br>

## Static Testing using MobSF (APK)
_You just need apk_
1. Open browser and go to url : http://localhost:8080 <br>
2. Upload the APK  <br>
Wait for a while
3. You'll see a detailed report. Refer to Section: MobSF interfact explained. <br>

## Static Testing using MobSF (iOS)
_Preperations needed to process iOS testing_ <br>
1. Go to the folder where ".xproject" is stored <br>
2. Zip together - ".xproject" , "Info.plist" <br>

3. Open browser and go to url : http://localhost:8080 <br>
4. Upload the zip created in Step 2. <br>
Wait for a while <br>
5. You'll see a detailed report. Refer to Section: MobSF interfact explained. <br>

## MobSF interface explained

### Information Section
Display data such as app icon, app name, size, package name etc.MD5 & SHA1 are also shown. They can be useful to detect known malicious applications. <br>

### Scan option
1. Rescan the application <br>
2. Start the dynamic analysis <br>
3. Check the java code and the manifest file <br>

### Signer Certificate
* Display the certificate information <br>
* Determine if an application has come from its original source <br>

### Binary Analysis
* It is threat assessment & vulnerability testing at the binary code level. <br>
* It can also be used to analyze third party libraries, allowing a richer analysis & better visibility into how applications will interact with libraries. <br>
* This is analysis of binary code to identify security issues. For complex systems using third party libraries for which source code is not available binary code analysis helps to identify issues. <br>

### Android API
You can view android API used in app like java reflection, location. <br>

### Browsable Activities
That can be safely invoked from a browser.

### Security Analysis

#### Manifest Analysis:
Find vulnerability inside one of the components in the AndroidManifest.xml file.
#### Code Analysis:
* Analysis result of java code by a static analyzer. <br>
* Identifies potential vulnerabilities, determines their severity & the files in which this type of vulnerability was found. <br>
#### CVSS
* Common Vulnerability Scoring System <br>
* Vulnerability is assigned a CVSS base score between 0.0 & 10.0. <br>
 * 0.0 → No risk <br>
 * 0.1–3.9 → Low risk <br>
 * 4.0–6.9 → Medium risk <br>
 * 7.0–8.9 → High risk <br>
 * 9.0–10.0 → Critical risk score <br>
#### CWE
* Common Weakness Enumeration <br>
* It is a list of software architecture, design or a code weakness. <br>
#### File Analysis
Shows analysis of file

### Malware Analysis
Determine the functionality, origin & potential impact of a given malware sample such as virus. <br>

### Reconnaissance

#### URL
Display list of URLs, IP addresses & the files in which they are stores or called. Analyzes where the android app sends the data & where it stores the info.<br>
#### Emails
#### Strings
* Analyzes the text files that are in the res directory. <br>
* May contain sensitive data. <br>

### Components
Display a complete list of components (activity, service, content provider & receiver), imported libraries & files without defining the extension. <br>

# Common Vulnerabilities Found and fix
Refer to sub directories in this git!
