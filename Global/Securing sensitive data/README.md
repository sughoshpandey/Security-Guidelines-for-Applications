# Securing local tokens and Player prefs
_DURING DEVELOPMENT PROCESS_<br/>

## Securing data stored locally
<br/>
_Should be avoided. Store data on server for better security_
<br/>
**CONCEPT** - Storing sensitive data in local storage. Generate a MD5 hash for the data and store it as well. Now whenever the data is fetched, create a new MD5 hash and cross check with initial MD5 value. If the values match, no tampering has been done. If hash doesn't match, data has been tampered with. <br/>

### Best practices
* Always set the application setting to install in INTERNAL STORAGE of the device.<br/>
* When storing application's senstive data on local storage of device always append a custom path to default variables (eg - Application.persistentDataPath). Code snipped below<br>
` Path.Combine(Application.persistentDataPath, "Resources", "TextFiles", "textfile.txt") ` <br/>

### Generate MD5 hash in Unity
Refer to the code below to generate and convert MD5 hash to string. <br>

`static string CalculateMD5(string filename)` <br/>
`{`<br/>
`    using (var md5 = MD5.Create())`<br/>
`    {`<br/>
`        using (var stream = File.OpenRead(filename))`<br/>
`        {`<br/>
`            var hash = md5.ComputeHash(stream);`<br/>
`            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();`<br/>
`        }`<br/>
`    }`<br/>
`} `<br/>
<br/>

## Flow

### When to generate a new MD5 hash
Everytime sensitive data is updated (or after a fixed period of time if data is updated very frequently) - CREATE MD5 HASH and STORE
### When to verify
Whenever sensitive data is fetched from local storage - 
* Generate a new MD5 hash from data retrieved 
* Fetch the last MD5 token generated
* Compare their values
 * If OldValue === NewValue, **NO TAMPERING, DATA SAFE TO USE**
 * If OldValue !== NewValue, **DATA TAMPERED, DISCARD SESSION**  
<br/>
Sample C# code provided in this directory - EncryptionDecryptionUnityHelper.cs <br/>
Contact contributors for more help or raise an issue. <br/>