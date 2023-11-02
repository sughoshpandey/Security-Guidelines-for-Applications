# Certificate Analysis Errors
_Make sure to install all tools and add them as system variable from Home directory before proceeding_<br>
_Prerequisite : Already have an apk_<br>

*I've added a reference keystore that I created using these steps (my.keystore) in this directory.*<br>
*Passwor- testpassword*<br>

## No certificate found
You need to create a new keystore certificate and sign the application. <br>
1. Steps to generate a new keystore : <br>
 * Open command prompt (Ctrl+R -> 'cmd' -> ENTER) <br>
 * Navigate to the directory where you've stored the apk<br>
 _Following steps need command prompt_<br>
 First we will create a new keystore<br>
 * In command prompt type in the following command-<br>
  * keytool -genkey -v -keystore CustomKeyStoreName.keystore -keyalg KeyAlgorithmToBeUsed -sigalg SigningAlgo -keysize KeySize -validity InDays -alias  AliasForApplication
  * Press ENTER<br>
  * Enter a password for keystore. *BE CAREFUL WHILE TYPING THE PASSWORD BECAUSE YOU WON'T BE ABLE TO SEE YOUR TYPED PASSWORD*<br>
  * Re enter your password.<br>
  * Enter your details<br>
  * eg -<br>
   * keytool -genkey -v -keystore my.keystore -keyalg RSA -sigalg SHA256withRSA -keysize 2048 -validity 3650 -alias MyAlias<br>
   * Here my custom keystore name is - my.keystore<br>
   * Key algorithm - RSA <br>
   * Signing Algorithm - SHA256withRSA *IMPORTANT - You want to increase security of your certificate by using a strong encryption certificate*<br>
   * Validity is - 10 years (3650 days)<br>
   * Alias - MyAlias *IMPORTANT - You need to remember this to sign your application later*<br>
2. Now we will Sign this keystore on our apk (using JarSigner)-<br>
 * In command prompt type in the following command-<br>
  * jarsigner -verbose -sigalg SignAlgo -digestalg DiagestAlgo -keystore YourCustomKeystore.keystore YourAPK.apk YourAliasSetInKeystore <br>
  * Press ENTER <br>
  * eg - <br>
   * jarsigner -verbose -sigalg SHA256withRSA -keystore my.keystore my.apk MyAlias<br>
   * Sign Algorithm - SHA256withRSA<br>
   * Diagest Algorithm - NONE * default is SHA256 *, if using SHA1withRSA use :  -digestalg SHA1<br>
   * Keystore - Custom made keystore<br>
   * Followed by the apk you want to sign<br>
   * Followed by the alias that you used when creating the certificate<br>
   * Press ENTER
3. Now we have signed the apk with our custom certificate.<br>
 To verify our signature: <br>
 * Type the following command-<br>
  * jarsigner -verify -verbose YourAPK.apk
  * You'll see a message "jar signed" means signature is signed on our apk
  * eg-<br>
   * jarsigner -verify -verbose my.apk<br>
3. Next we have to Align the apk<br> 
 _Very important step if you want to upload on Google Play Store_
 * Download any apk from google play store and put it in the same directory as your own apk
 * Type the following commands-
  * zipalign -f 4 YourAPK.apk FinalNameOfAPK.apk
  * eg-
   * zipalign -f 4 my.apk finalRelease.apk
<br>
<br>
<br>
Your final Signed Aligned APK would be - finalRelease.apk in the same directory.<br>


## Signing certificate algorithm erro - eg (SHA1 known to have collisions)
Since the apk is already signed, first we need to decompile the apk, delete the old certificate and then sign our own certificate on the apk. <br>
You need to create a new keystore certificate and sign the application. <br>
1. Steps to generate a new keystore : <br>
 * Open command prompt (Ctrl+R -> 'cmd' -> ENTER) <br>
 * Navigate to the directory where you've stored the apk<br>
 _Following steps need command prompt_<br>
 First we will create a new keystore<br>
 * In command prompt type in the following command-<br>
  * keytool -genkey -v -keystore CustomKeyStoreName.keystore -keyalg KeyAlgorithmToBeUsed -sigalg SigningAlgo -keysize KeySize -validity InDays -alias  AliasForApplication
  * Press ENTER<br>
  * Enter a password for keystore. *BE CAREFUL WHILE TYPING THE PASSWORD BECAUSE YOU WON'T BE ABLE TO SEE YOUR TYPED PASSWORD*<br>
  * Re enter your password.<br>
  * Enter your details<br>
  * eg -<br>
   * keytool -genkey -v -keystore my.keystore -keyalg RSA -sigalg SHA256withRSA -keysize 2048 -validity 3650 -alias MyAlias<br>
   * Here my custom keystore name is - my.keystore<br>
   * Key algorithm - RSA <br>
   * Signing Algorithm - SHA256withRSA *IMPORTANT - You want to increase security of your certificate by using a stronger encryption than the one mentioned in the error*<br>
   * Validity is - 10 years (3650 days)<br>
   * Alias - MyAlias *IMPORTANT - You need to remember this to sign your application later*<br>
2. Now we will remove existing signature from the apk
 * Rename existing apk extension from '.apk' to '.zip'
 * Extract all files
 * Open extracted folder and remove the folder *META-INF*
 * Archive the exrtacted folder to an '.zip' file
 * Change the new archived folder extension to '.apk' from '.zip'
3. Check if certificate has been removed
 * Type the following command-<br>
  * jarsigner -verify -verbose YourAPK.apk
  * You'll see a message "jar not signed" means signature has been successfully removed.
4. Now we will Sign this keystore on our apk (using JarSigner)-<br>
 * In command prompt type in the following command-<br>
  * jarsigner -verbose -sigalg SignAlgo -digestalg DiagestAlgo -keystore YourCustomKeystore.keystore YourAPK.apk YourAliasSetInKeystore <br>
  * Press ENTER <br>
  * eg - <br>
   * jarsigner -verbose -sigalg SHA256withRSA -keystore my.keystore my.apk MyAlias<br>
   * Sign Algorithm - SHA256withRSA<br>
   * Diagest Algorithm - NONE * default is SHA256 *, if using SHA1withRSA use :  -digestalg SHA1<br>
   * Keystore - Custom made keystore<br>
   * Followed by the apk you want to sign<br>
   * Followed by the alias that you used when creating the certificate<br>
   * Press ENTER
5. Now we have signed the apk with our custom certificate.<br>
 To verify our signature: <br>
 * Type the following command-<br>
  * jarsigner -verify -verbose YourAPK.apk
  * You'll see a message "jar signed" means signature is signed on our apk
  * eg-<br>
   * jarsigner -verify -verbose my.apk<br>
6. Next we have to Align the apk<br> 
 _Very important step if you want to upload on Google Play Store_
 * Download any apk from google play store and put it in the same directory as your own apk
 * Type the following commands-
  * zipalign -f 4 YourAPK.apk FinalNameOfAPK.apk
  * eg-
   * zipalign -f 4 my.apk finalRelease.apk
<br>
<br>
<br>
Your final Signed Aligned APK would be - finalRelease.apk in the same directory.<br>