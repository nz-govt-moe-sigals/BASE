## Synopsis ##

The firewall rules are used to limit access to a SqlServer from range of Ips.

By default, one can get to a SqlServer from any Ip. That's fine -- as long as one is using IntegratedSecurity *only*.


## Notes ##

* Notice that the resource type name (`"type": "Microsoft.Sql/servers/firewallrules"`) is plural -- and therefore incorrect since it only defines one Rule.
Hence whereever I've referenced it (file name, rulename, parameter names, variable names) I've used the singular format.  
Except in the ARM itself, where I had to use the official referenceType tag, which is plural (`"type": "Microsoft.Sql/servers/firewallrules"`).