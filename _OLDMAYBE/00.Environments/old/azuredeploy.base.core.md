# Synopsis


# Key Issues

* References and Builds Resources starting from base subscriptions and SKUs back up to tangible servers, then finally the Execution Environments, then finally the Services on them. More or less like the following order:
  * Service Accounts (eg: Storage),
  * then the Containers (Storage Account Containers), then 
* child templates Inputs/Outputs:
  * app.base.core.sqlserver.json:
    * Inputs:
      * Location: because Sql Servers cannot be created in all locations
      * UserName
      * Password



# Tips 
* Use Shift-Alt-F to reformat JSON Code in Visual Code.
* Notice how when ARM Templates "resources" other ARM Templates, the "type" is set to "Microsoft.Resources/deployments".
  * See more about nesting templates: https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-linked-templates
 
