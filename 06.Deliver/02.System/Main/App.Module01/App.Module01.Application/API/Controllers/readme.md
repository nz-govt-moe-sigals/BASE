# About #

All OData controllers within a Module all share one or two common base classes specific to the Module.

The base classes can all trace their ancestry back to base classes in Core, which in turn inherits from 
ODataController.

* ODataController (in .NET)
  * CommonODataControllerBase  (in Core)
    * ActiveRecordStateCommonODataControllerBase<TEntity,TDto>  (in Core)
      * TenantedGuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto> (in Core)
        * TenantedGuidIdActiveRecordStateODataControllerDataBase<TEntity, TDto> (in this Module)
	       * This Module's Controllers


There are two reasons to use this base controller. 

The first reason is to set the controller's OData Route base:

        protected override void Initialize()
        {
            this._dbContextIdentifier = AppModuleDbContextNames.Default; //which will be something like "ModuleXX"
        }

This ensures the url to get to Controllers within this Module start with "ModuleXX". An example would be:

https://foo.bar.com/odata/ModuleXX/Something


Another reason is to address, pragmatically, the fact that although controller should not access Repositories directly (DDD recommends that Controllers are Thin/Dumb, 
and in turn call an Application Service, which in turn invokes infrastructure services such as RepositoryService)...developers 
will.
So if that is the case, then it's best to put common repository logic in a base class so that Controller developers
have as little technology as possible to think about. You just need to define the Type of the EF Entity, and it's DTO.



