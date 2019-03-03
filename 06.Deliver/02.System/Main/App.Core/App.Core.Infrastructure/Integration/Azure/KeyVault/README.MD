## About ##

KeyVault is one of the many services provided within Azure -- it's 
used to store Secrets (single text fragments), generated Keys and certs.

The advantage of using KeyVault, as oppossed to AppSettings is that
developers invariably make mistakes, and commit to code Repositories whether 
public or private, confidential access credentials or tokens, defeating
security.

Use of a KeyVault allows for infrastructure support services to put
sensitive information (eg: keys to Azure Storage or Db ConnectionStrings...although
in both cases there are more secure options...) in the KeyVault, to which 
developers do *not* have access, but their application does (via AAD authentication
due to ClientId/Secret) .

### Prerequisites ###

* The Application has been registered in AAD (or B2C), and 
  * the following has transmitted back to the Developers:
    * a ClientId (the ApplicationId)
    * a ClientSecret (a key generated in AAD that is secret between App and AAD)
  * Azure has created an ServicePrincipalName (SPN) in the background, tied to the ApplicationId 
* A KeyStore has been developed.
* The SPN has been assigned sufficient rights to Read the Keystore.
* The Url to the Keystore has been transmitted back to the developers to 
  * add to their AppSettings.

* Access to the keystore can provide access to 
  * Secrets, within which can registered:
    * Storage Account Keys (ie the coarse grain access to storage accounts)
    * SingleAccesSignature (ie finer revocable grain access to storage accounts...but more difficult)
	* Keys to Certs (see below)
  * Keys:
    * ?
  * Certs:
    * Certs used for signage, as well as deployment, and asignment to environments.

### ADAL, MSAL, MSI

You may have noticed there's a bit of an issue in the above. Namely, that you can put your 
secrets in an Azure Key Vault, but then you need to put secret keys into the app to access the Key Vault anyway!