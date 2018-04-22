# About #

StorageAccounts, Containers, Blobs.


## Background ##

* Devs should not have to know about ConnectionStrings/Keys etc. Just focus on knowing the name/keyu of a their Container, within a Context.
* A StorageAccountContext is much like a DbContext. It hides the ConnectionString, and provides a Client to the Service that wraps it for consumption
  by the rest of the System.


Therefore:
* Not much is needed in a BlobServiceAccountConfiguration package. 
* DefaultStorageAccountConfigurationSettings:
  * Retreieved and cached via KeyVaultService.
  * Has properties:
    * ResourceName (optional, from AppSettings, eg: 'orgappbranchenv'), 
    * REsourceNameSuffix (optional, from AppSettings, default:'')
    * Key (required for now, from KeyVault)
* [Default|External]StorageAccountBlobContext:
  * Registered within ServiceLocator as a Named instance.
  * Relies on DefaultStorageAccountConfigurationSettings
  * Used to build ConnectionString
  * Which is used to create a BlobClient
  * Also provides a Container Cache...which might be externalized to keep it from having to always be checked to see if exists.
* BlobService relies on ServiceLocator to return named [Default|External]StorageAccountBlobContext.
  * Containers are created and cached as needed by Context.
  * Needs nothing else really.


  